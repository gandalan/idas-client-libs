import { readFile, readdir, writeFile } from "node:fs/promises";
import path from "node:path";
import { fileURLToPath } from "node:url";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const rootDir = path.resolve(__dirname, "..");

const rootIndexPath = path.join(rootDir, "index.js");
const rootDtsPath = path.join(rootDir, "index.d.ts");
const dtoIndexPath = path.join(rootDir, "api", "dtos", "index.js");
const businessIndexPath = path.join(rootDir, "api", "business", "index.js");
const uiIndexPath = path.join(rootDir, "ui", "index.js");

const dtoLeafDirectory = path.join(rootDir, "api", "dtos");
const businessLeafDirectory = path.join(rootDir, "api", "business");
const uiLeafDirectory = path.join(rootDir, "ui");

const dtoRootMarkerStart = "// BEGIN GENERATED ROOT DTO TYPEDEFS";
const dtoRootMarkerEnd = "// END GENERATED ROOT DTO TYPEDEFS";
const businessRootMarkerStart = "// BEGIN GENERATED ROOT BUSINESS TYPEDEFS";
const businessRootMarkerEnd = "// END GENERATED ROOT BUSINESS TYPEDEFS";

const rootValueExportStatements = [];

const rootFunctionDeclarationStatements = [
    "export function createApi(): FluentApi;",
    "export function fluentApi(url: string, authManager: FluentAuthManager | null, serviceName: string): FluentApi;",
    "export function createIDASApi(): IDASFluentApi;",
    "export function idasFluentApi(url: string, authManager: FluentAuthManager, serviceName: string): IDASFluentApi;",
    "export function createAuthManager(): FluentAuthManager;",
    "export function fluentIdasAuthManager(appToken: string, authBaseUrl: string): FluentAuthManager;",
    "export function fetchEnvConfig(envConfig?: string): Promise<EnvironmentConfig>;",
    "export function restClient(): FluentRESTClient;"
];

const simpleImportTypePattern = /^import\((?:"|').+(?:"|')\)\.[A-Za-z0-9_$]+$/;
const returnTypeOfCreateApiPattern = /^ReturnType<\s*typeof\s+(create[A-Za-z0-9_$]+Api)\s*>$/;

async function collectFiles(directoryPath, allowedExtensions) {
    const entries = await readdir(directoryPath, { withFileTypes: true });
    const files = [];

    for (const entry of entries) {
        const fullPath = path.join(directoryPath, entry.name);

        if (entry.isDirectory()) {
            files.push(...await collectFiles(fullPath, allowedExtensions));
            continue;
        }

        if (entry.isFile() && allowedExtensions.has(path.extname(entry.name))) {
            files.push(fullPath);
        }
    }

    return files.sort();
}

function toPosixRelativePath(filePath) {
    return path.relative(rootDir, filePath).replace(/\\/g, "/");
}

function toRelativeImportPath(fromFilePath, targetFilePath) {
    const relativePath = path.relative(path.dirname(fromFilePath), targetFilePath).replace(/\\/g, "/");
    return relativePath.startsWith(".") ? relativePath : `./${relativePath}`;
}

function getJSDocBlocks(source) {
    return source.match(/\/\*\*[\s\S]*?\*\//g) ?? [];
}

function normalizeJSDocBlock(block) {
    return block
        .replace(/^\/\*\*/, "")
        .replace(/\*\/$/, "")
        .split("\n")
        .map((line) => line.replace(/^\s*\*\s?/, ""))
        .join("\n")
        .trim();
}

function skipQuotedString(source, startIndex, quoteCharacter) {
    let index = startIndex + 1;

    while (index < source.length) {
        const character = source[index];

        if (character === "\\") {
            index += 2;
            continue;
        }

        if (character === quoteCharacter) {
            return index + 1;
        }

        index += 1;
    }

    return source.length;
}

function skipBlockComment(source, startIndex) {
    const endIndex = source.indexOf("*/", startIndex + 2);
    return endIndex === -1 ? source.length : endIndex + 2;
}

function skipLineComment(source, startIndex) {
    const endIndex = source.indexOf("\n", startIndex + 2);
    return endIndex === -1 ? source.length : endIndex + 1;
}

function findMatchingDelimiter(source, startIndex, openCharacter, closeCharacter) {
    let depth = 1;

    for (let index = startIndex + 1; index < source.length; index += 1) {
        const character = source[index];
        const nextCharacter = source[index + 1];

        if (character === "\"" || character === "'") {
            index = skipQuotedString(source, index, character) - 1;
            continue;
        }

        if (character === "`") {
            index = skipTemplateLiteral(source, index) - 1;
            continue;
        }

        if (character === "/" && nextCharacter === "*") {
            index = skipBlockComment(source, index) - 1;
            continue;
        }

        if (character === "/" && nextCharacter === "/") {
            index = skipLineComment(source, index) - 1;
            continue;
        }

        if (character === openCharacter) {
            depth += 1;
            continue;
        }

        if (character === closeCharacter) {
            depth -= 1;

            if (depth === 0) {
                return index;
            }
        }
    }

    return -1;
}

function skipTemplateLiteral(source, startIndex) {
    let index = startIndex + 1;

    while (index < source.length) {
        const character = source[index];

        if (character === "\\") {
            index += 2;
            continue;
        }

        if (character === "`") {
            return index + 1;
        }

        if (character === "$" && source[index + 1] === "{") {
            const closingIndex = findMatchingDelimiter(source, index + 1, "{", "}");

            if (closingIndex === -1) {
                return source.length;
            }

            index = closingIndex + 1;
            continue;
        }

        index += 1;
    }

    return source.length;
}

function skipWhitespace(value, startIndex) {
    let index = startIndex;

    while (index < value.length && /\s/u.test(value[index])) {
        index += 1;
    }

    return index;
}

function skipWhitespaceAndComments(source, startIndex) {
    let index = startIndex;

    while (index < source.length) {
        index = skipWhitespace(source, index);

        if (source.startsWith("/**", index) || source.startsWith("/*", index)) {
            index = skipBlockComment(source, index);
            continue;
        }

        if (source.startsWith("//", index)) {
            index = skipLineComment(source, index);
            continue;
        }

        break;
    }

    return index;
}

function isIdentifierStart(character) {
    return /[A-Za-z_$]/u.test(character);
}

function isIdentifierPart(character) {
    return /[A-Za-z0-9_$]/u.test(character);
}

function buildFunctionTypeExpressionFromJSDoc(block) {
    const normalizedBlock = normalizeJSDocBlock(block);
    const params = extractParamEntries(normalizedBlock);
    const returns = extractReturnsEntry(normalizedBlock)?.typeExpression ?? "void";

    return `(${params.map((param) => `${param.name}${param.optional ? "?" : ""}: ${param.typeExpression}`).join(", ")}) => ${returns}`;
}

function buildObjectLiteralTypeExpression(properties) {
    return `{ ${properties.map((property) => `${property.name}${property.optional ? "?" : ""}: ${property.typeExpression}`).join("; ")} }`;
}

function parseFunctionParameterTypes(jsDocBlock) {
    if (!jsDocBlock) {
        return new Map();
    }

    const normalizedBlock = normalizeJSDocBlock(jsDocBlock);
    const params = extractParamEntries(normalizedBlock);

    return new Map(params.map((param) => [param.name, param.typeExpression]));
}

function readLeadingJSDoc(source, startIndex) {
    let index = startIndex;
    let jsDocBlock = null;

    while (index < source.length) {
        index = skipWhitespace(source, index);

        if (source.startsWith("/**", index)) {
            const endIndex = skipBlockComment(source, index);
            jsDocBlock = source.slice(index, endIndex);
            index = endIndex;
            continue;
        }

        if (source.startsWith("/*", index)) {
            index = skipBlockComment(source, index);
            continue;
        }

        if (source.startsWith("//", index)) {
            index = skipLineComment(source, index);
            continue;
        }

        break;
    }

    return {
        jsDocBlock,
        nextIndex: index
    };
}

function findExpressionEnd(source, startIndex) {
    let braceDepth = 0;
    let bracketDepth = 0;
    let parenDepth = 0;

    for (let index = startIndex; index < source.length; index += 1) {
        const character = source[index];
        const nextCharacter = source[index + 1];

        if (character === "\"" || character === "'") {
            index = skipQuotedString(source, index, character) - 1;
            continue;
        }

        if (character === "`") {
            index = skipTemplateLiteral(source, index) - 1;
            continue;
        }

        if (character === "/" && nextCharacter === "*") {
            index = skipBlockComment(source, index) - 1;
            continue;
        }

        if (character === "/" && nextCharacter === "/") {
            index = skipLineComment(source, index) - 1;
            continue;
        }

        if (character === "{") {
            braceDepth += 1;
            continue;
        }

        if (character === "}") {
            if (braceDepth === 0 && bracketDepth === 0 && parenDepth === 0) {
                return index;
            }

            braceDepth = Math.max(0, braceDepth - 1);
            continue;
        }

        if (character === "[") {
            bracketDepth += 1;
            continue;
        }

        if (character === "]") {
            bracketDepth = Math.max(0, bracketDepth - 1);
            continue;
        }

        if (character === "(") {
            parenDepth += 1;
            continue;
        }

        if (character === ")") {
            parenDepth = Math.max(0, parenDepth - 1);
            continue;
        }

        if (character === "," && braceDepth === 0 && bracketDepth === 0 && parenDepth === 0) {
            return index;
        }
    }

    return source.length;
}

function inferTypeExpressionFromInitializer(initializerSource, scopeTypeMap) {
    const trimmedInitializer = initializerSource.trim();

    if (!trimmedInitializer) {
        return "any";
    }

    if (scopeTypeMap.has(trimmedInitializer)) {
        return scopeTypeMap.get(trimmedInitializer);
    }

    if (trimmedInitializer === "null") {
        return "null";
    }

    if (trimmedInitializer === "true" || trimmedInitializer === "false") {
        return "boolean";
    }

    if (/^[-+]?\d+(?:\.\d+)?$/u.test(trimmedInitializer)) {
        return "number";
    }

    if ((trimmedInitializer.startsWith("\"") && trimmedInitializer.endsWith("\"")) || (trimmedInitializer.startsWith("'") && trimmedInitializer.endsWith("'"))) {
        return "string";
    }

    return "any";
}

function parseObjectLiteralProperties(objectSource, scopeTypeMap) {
    if (!objectSource.startsWith("{")) {
        throw new Error("Expected object literal source to start with '{'.");
    }

    const properties = [];
    let index = 1;

    while (index < objectSource.length) {
        const { jsDocBlock, nextIndex } = readLeadingJSDoc(objectSource, index);
        index = nextIndex;

        if (objectSource[index] === "}") {
            break;
        }

        let propertyName = null;

        if (objectSource.startsWith("async", index) && !isIdentifierPart(objectSource[index + 5] ?? "")) {
            index = skipWhitespace(objectSource, index + 5);
        }

        if (objectSource[index] === "\"" || objectSource[index] === "'") {
            const quoteCharacter = objectSource[index];
            const endIndex = skipQuotedString(objectSource, index, quoteCharacter);
            propertyName = objectSource.slice(index + 1, endIndex - 1);
            index = endIndex;
        } else if (isIdentifierStart(objectSource[index] ?? "")) {
            const nameStart = index;
            index += 1;

            while (index < objectSource.length && isIdentifierPart(objectSource[index])) {
                index += 1;
            }

            propertyName = objectSource.slice(nameStart, index);
        }

        if (!propertyName) {
            index += 1;
            continue;
        }

        index = skipWhitespaceAndComments(objectSource, index);

        let typeExpression = "any";
        let optional = false;

        if (objectSource[index] === ":") {
            index = skipWhitespaceAndComments(objectSource, index + 1);

            if (objectSource[index] === "{") {
                const objectEndIndex = findMatchingDelimiter(objectSource, index, "{", "}");

                if (objectEndIndex === -1) {
                    throw new Error(`Could not find end of nested object literal for property ${propertyName}`);
                }

                const nestedProperties = parseObjectLiteralProperties(objectSource.slice(index, objectEndIndex + 1), scopeTypeMap);
                typeExpression = buildObjectLiteralTypeExpression(nestedProperties);
                index = objectEndIndex + 1;
            } else {
                const expressionEndIndex = findExpressionEnd(objectSource, index);
                const initializerSource = objectSource.slice(index, expressionEndIndex);
                typeExpression = jsDocBlock ? buildFunctionTypeExpressionFromJSDoc(jsDocBlock) : inferTypeExpressionFromInitializer(initializerSource, scopeTypeMap);
                index = expressionEndIndex;
            }
        } else if (objectSource[index] === "(") {
            const paramsEndIndex = findMatchingDelimiter(objectSource, index, "(", ")");

            if (paramsEndIndex === -1) {
                throw new Error(`Could not find end of parameter list for property ${propertyName}`);
            }

            index = skipWhitespaceAndComments(objectSource, paramsEndIndex + 1);

            if (objectSource[index] === "{") {
                const methodEndIndex = findMatchingDelimiter(objectSource, index, "{", "}");

                if (methodEndIndex === -1) {
                    throw new Error(`Could not find end of method body for property ${propertyName}`);
                }

                index = methodEndIndex + 1;
            }

            typeExpression = jsDocBlock ? buildFunctionTypeExpressionFromJSDoc(jsDocBlock) : "(...args: any[]) => any";
        } else {
            typeExpression = scopeTypeMap.get(propertyName) ?? "any";
        }

        properties.push({
            name: propertyName,
            optional,
            typeExpression
        });

        index = skipWhitespaceAndComments(objectSource, index);

        if (objectSource[index] === ",") {
            index += 1;
        }
    }

    return properties;
}

function getNearestLeadingJSDoc(source, startIndex) {
    let cursor = startIndex;

    while (cursor > 0 && /\s/u.test(source[cursor - 1])) {
        cursor -= 1;
    }

    if (!source.startsWith("*/", cursor - 2)) {
        return null;
    }

    const blockStartIndex = source.lastIndexOf("/**", cursor - 2);
    return blockStartIndex === -1 ? null : source.slice(blockStartIndex, cursor);
}

function extractCreateFunctionInfo(source, createFunctionName) {
    const functionPattern = new RegExp(`export\\s+(?:async\\s+)?function\\s+${createFunctionName}\\s*\\(`);
    const functionMatch = functionPattern.exec(source);

    if (functionMatch) {
        const functionIndex = functionMatch.index;
        const functionBodyStartIndex = source.indexOf("{", functionIndex);
        const functionBodyEndIndex = functionBodyStartIndex === -1 ? -1 : findMatchingDelimiter(source, functionBodyStartIndex, "{", "}");

        if (functionBodyStartIndex === -1 || functionBodyEndIndex === -1) {
            return null;
        }

        return {
            jsDocBlock: getNearestLeadingJSDoc(source, functionIndex),
            bodySource: source.slice(functionBodyStartIndex + 1, functionBodyEndIndex)
        };
    }

    const constPattern = new RegExp(`export\\s+const\\s+${createFunctionName}\\s*=\\s*(?:async\\s*)?\\([^)]*\\)\\s*=>\\s*\\{`);
    const constMatch = constPattern.exec(source);

    if (!constMatch) {
        return null;
    }

    const arrowBodyStartIndex = source.indexOf("{", constMatch.index);
    const arrowBodyEndIndex = arrowBodyStartIndex === -1 ? -1 : findMatchingDelimiter(source, arrowBodyStartIndex, "{", "}");

    if (arrowBodyStartIndex === -1 || arrowBodyEndIndex === -1) {
        return null;
    }

    return {
        jsDocBlock: getNearestLeadingJSDoc(source, constMatch.index),
        bodySource: source.slice(arrowBodyStartIndex + 1, arrowBodyEndIndex)
    };
}

function extractTopLevelReturnedObjectSource(functionBodySource, createFunctionName) {
    let braceDepth = 0;
    let bracketDepth = 0;
    let parenDepth = 0;

    for (let index = 0; index < functionBodySource.length; index += 1) {
        const character = functionBodySource[index];
        const nextCharacter = functionBodySource[index + 1];

        if (character === "\"" || character === "'") {
            index = skipQuotedString(functionBodySource, index, character) - 1;
            continue;
        }

        if (character === "`") {
            index = skipTemplateLiteral(functionBodySource, index) - 1;
            continue;
        }

        if (character === "/" && nextCharacter === "*") {
            index = skipBlockComment(functionBodySource, index) - 1;
            continue;
        }

        if (character === "/" && nextCharacter === "/") {
            index = skipLineComment(functionBodySource, index) - 1;
            continue;
        }

        if (character === "{") {
            braceDepth += 1;
            continue;
        }

        if (character === "}") {
            braceDepth = Math.max(0, braceDepth - 1);
            continue;
        }

        if (character === "[") {
            bracketDepth += 1;
            continue;
        }

        if (character === "]") {
            bracketDepth = Math.max(0, bracketDepth - 1);
            continue;
        }

        if (character === "(") {
            parenDepth += 1;
            continue;
        }

        if (character === ")") {
            parenDepth = Math.max(0, parenDepth - 1);
            continue;
        }

        if (braceDepth === 0 && bracketDepth === 0 && parenDepth === 0 && functionBodySource.startsWith("return", index) && !isIdentifierPart(functionBodySource[index - 1] ?? "") && !isIdentifierPart(functionBodySource[index + 6] ?? "")) {
            const objectStartIndex = skipWhitespaceAndComments(functionBodySource, index + 6);

            if (functionBodySource[objectStartIndex] !== "{") {
                continue;
            }

            const objectEndIndex = findMatchingDelimiter(functionBodySource, objectStartIndex, "{", "}");

            if (objectEndIndex === -1) {
                throw new Error(`Could not find end of returned object literal for ${createFunctionName}`);
            }

            return functionBodySource.slice(objectStartIndex, objectEndIndex + 1);
        }
    }

    throw new Error(`Could not find top-level returned object literal for ${createFunctionName}`);
}

function inferReturnTypeObjectEntry(source, filePath, typeName, createFunctionName) {
    const functionInfo = extractCreateFunctionInfo(source, createFunctionName);

    if (!functionInfo) {
        return null;
    }

    const returnedObjectSource = extractTopLevelReturnedObjectSource(functionInfo.bodySource, createFunctionName);
    const scopeTypeMap = parseFunctionParameterTypes(functionInfo.jsDocBlock);
    const properties = parseObjectLiteralProperties(returnedObjectSource, scopeTypeMap);

    return {
        kind: "object",
        name: typeName,
        properties,
        filePath
    };
}

function parseBracketedType(rest) {
    if (!rest.startsWith("{")) {
        return null;
    }

    let braceDepth = 0;
    let closingBraceIndex = -1;

    for (let index = 0; index < rest.length; index += 1) {
        const character = rest[index];

        if (character === "{") {
            braceDepth += 1;
        } else if (character === "}") {
            braceDepth -= 1;

            if (braceDepth === 0) {
                closingBraceIndex = index;
                break;
            }
        }
    }

    if (closingBraceIndex === -1) {
        return null;
    }

    return {
        typeExpression: rest.slice(1, closingBraceIndex).trim(),
        remainder: rest.slice(closingBraceIndex + 1).trim()
    };
}

function parseTagWithType(line, tagName) {
    const marker = `@${tagName}`;
    const tagIndex = line.indexOf(marker);

    if (tagIndex === -1) {
        return null;
    }

    const parsed = parseBracketedType(line.slice(tagIndex + marker.length).trimStart());

    if (!parsed) {
        return null;
    }

    return parsed;
}

function parseNameToken(remainder) {
    const nameMatch = remainder.match(/^(\[[^\]]+\]|[^\s-]+)/);

    if (!nameMatch) {
        return null;
    }

    const rawName = nameMatch[1];
    const optional = rawName.startsWith("[") && rawName.endsWith("]");
    const normalizedName = optional ? rawName.slice(1, -1).replace(/=.*/, "") : rawName;
    const description = remainder.slice(nameMatch[0].length).trim().replace(/^-/u, "").trim();

    return {
        name: normalizedName,
        optional,
        description
    };
}

function extractPropertyEntries(normalizedBlock) {
    const properties = [];

    for (const line of normalizedBlock.split("\n")) {
        if (!line.includes("@property")) {
            continue;
        }

        const parsedTag = parseTagWithType(line, "property");

        if (!parsedTag) {
            continue;
        }

        const parsedName = parseNameToken(parsedTag.remainder);

        if (!parsedName) {
            continue;
        }

        properties.push({
            name: parsedName.name,
            optional: parsedName.optional,
            description: parsedName.description,
            typeExpression: parsedTag.typeExpression
        });
    }

    return properties;
}

function extractParamEntries(normalizedBlock) {
    const params = [];

    for (const line of normalizedBlock.split("\n")) {
        if (!line.includes("@param")) {
            continue;
        }

        const parsedTag = parseTagWithType(line, "param");

        if (!parsedTag) {
            continue;
        }

        const parsedName = parseNameToken(parsedTag.remainder);

        if (!parsedName) {
            continue;
        }

        params.push({
            name: parsedName.name,
            optional: parsedName.optional,
            typeExpression: parsedTag.typeExpression
        });
    }

    return params;
}

function extractReturnsEntry(normalizedBlock) {
    for (const line of normalizedBlock.split("\n")) {
        if (!line.includes("@returns") && !line.includes("@return")) {
            continue;
        }

        return parseTagWithType(line, line.includes("@returns") ? "returns" : "return");
    }

    return null;
}

function extractTypedefEntry(normalizedBlock) {
    const typedefIndex = normalizedBlock.indexOf("@typedef");

    if (typedefIndex === -1) {
        return null;
    }

    const afterTag = normalizedBlock.slice(typedefIndex + "@typedef".length).trimStart();

    if (!afterTag.startsWith("{")) {
        return null;
    }

    let braceDepth = 0;
    let closingBraceIndex = -1;

    for (let index = 0; index < afterTag.length; index += 1) {
        const character = afterTag[index];

        if (character === "{") {
            braceDepth += 1;
        } else if (character === "}") {
            braceDepth -= 1;

            if (braceDepth === 0) {
                closingBraceIndex = index;
                break;
            }
        }
    }

    if (closingBraceIndex === -1) {
        return null;
    }

    const typeExpression = afterTag.slice(1, closingBraceIndex).trim();
    const remainder = afterTag.slice(closingBraceIndex + 1).trim();
    const nameMatch = remainder.match(/^([A-Za-z0-9_$]+)/);

    if (!nameMatch) {
        return null;
    }

    const properties = extractPropertyEntries(normalizedBlock);

    return {
        kind: typeExpression === "Object" && properties.length > 0 ? "object" : "typedef",
        name: nameMatch[1],
        typeExpression,
        properties
    };
}

function extractCallbackEntry(normalizedBlock) {
    const callbackMatch = normalizedBlock.match(/@callback\s+([A-Za-z0-9_$]+)/);

    if (!callbackMatch) {
        return null;
    }

    return {
        kind: "callback",
        name: callbackMatch[1],
        typeExpression: null,
        params: extractParamEntries(normalizedBlock),
        returns: extractReturnsEntry(normalizedBlock)?.typeExpression ?? "void"
    };
}

function isSimpleImportAlias(typeExpression) {
    return simpleImportTypePattern.test(typeExpression.replace(/\s+/g, ""));
}

function extractPublicTypeEntries(source, filePath) {
    const entries = [];

    for (const block of getJSDocBlocks(source).map(normalizeJSDocBlock)) {
        const typedefEntry = extractTypedefEntry(block);

        if (typedefEntry) {
            const inferredCreateApiName = typedefEntry.typeExpression.match(returnTypeOfCreateApiPattern)?.[1] ?? null;

            if (inferredCreateApiName) {
                const inferredObjectEntry = inferReturnTypeObjectEntry(source, filePath, typedefEntry.name, inferredCreateApiName);

                if (inferredObjectEntry) {
                    entries.push(inferredObjectEntry);
                    continue;
                }
            }

            if (!isSimpleImportAlias(typedefEntry.typeExpression)) {
                entries.push({ ...typedefEntry, filePath });
            }

            continue;
        }

        const callbackEntry = extractCallbackEntry(block);

        if (callbackEntry) {
            entries.push({ ...callbackEntry, filePath });
        }
    }

    return entries;
}

function splitTopLevel(text, delimiterCharacter) {
    const parts = [];
    let current = "";
    let angleDepth = 0;
    let braceDepth = 0;
    let bracketDepth = 0;
    let parenDepth = 0;

    for (const character of text) {
        if (character === "<") {
            angleDepth += 1;
        } else if (character === ">") {
            angleDepth = Math.max(0, angleDepth - 1);
        } else if (character === "{") {
            braceDepth += 1;
        } else if (character === "}") {
            braceDepth = Math.max(0, braceDepth - 1);
        } else if (character === "[") {
            bracketDepth += 1;
        } else if (character === "]") {
            bracketDepth = Math.max(0, bracketDepth - 1);
        } else if (character === "(") {
            parenDepth += 1;
        } else if (character === ")") {
            parenDepth = Math.max(0, parenDepth - 1);
        }

        if (character === delimiterCharacter && angleDepth === 0 && braceDepth === 0 && bracketDepth === 0 && parenDepth === 0) {
            parts.push(current.trim());
            current = "";
            continue;
        }

        current += character;
    }

    if (current.trim()) {
        parts.push(current.trim());
    }

    return parts;
}

function replaceObjectGenerics(typeExpression, transformTypeExpression) {
    let result = "";

    for (let index = 0; index < typeExpression.length; index += 1) {
        if (!typeExpression.startsWith("Object<", index)) {
            result += typeExpression[index];
            continue;
        }

        let angleDepth = 0;
        let closingIndex = -1;

        for (let cursor = index + "Object".length; cursor < typeExpression.length; cursor += 1) {
            const character = typeExpression[cursor];

            if (character === "<") {
                angleDepth += 1;
            } else if (character === ">") {
                angleDepth -= 1;

                if (angleDepth === 0) {
                    closingIndex = cursor;
                    break;
                }
            }
        }

        if (closingIndex === -1) {
            result += typeExpression[index];
            continue;
        }

        const genericContent = typeExpression.slice(index + "Object<".length, closingIndex);
        const genericParts = splitTopLevel(genericContent, ",");

        if (genericParts.length === 2) {
            result += `Record<${transformTypeExpression(genericParts[0])}, ${transformTypeExpression(genericParts[1])}>`;
        } else {
            result += "object";
        }

        index = closingIndex;
    }

    return result;
}

function transformTypeExpressionForDts(typeExpression, availableTypeNames) {
    const normalizedExpression = typeExpression.trim();

    if (normalizedExpression === "*") {
        return "any";
    }

    let transformedExpression = normalizedExpression.replace(
        /import\((?:"|')[^"']+(?:"|')\)\.([A-Za-z0-9_$]+)(\[[^\]]+\])?/g,
        (fullMatch, typeName, suffix = "") => availableTypeNames.has(typeName) ? `${typeName}${suffix}` : fullMatch
    );

    transformedExpression = replaceObjectGenerics(transformedExpression, (innerExpression) => transformTypeExpressionForDts(innerExpression, availableTypeNames));
    transformedExpression = transformedExpression.replace(/\bObject\b/g, "object");
    transformedExpression = transformedExpression.replace(/\bfunction\b/g, "Function");

    return transformedExpression;
}

function renderTypeEntryAsDts(entry, availableTypeNames) {
    if (entry.kind === "object") {
        const lines = [`export type ${entry.name} = {`];

        for (const property of entry.properties) {
            lines.push(`    ${property.name}${property.optional ? "?" : ""}: ${transformTypeExpressionForDts(property.typeExpression, availableTypeNames)};`);
        }

        lines.push("};", "");
        return lines;
    }

    if (entry.kind === "callback") {
        const params = entry.params.map((param) => `${param.name}${param.optional ? "?" : ""}: ${transformTypeExpressionForDts(param.typeExpression, availableTypeNames)}`).join(", ");
        return [`export type ${entry.name} = (${params}) => ${transformTypeExpressionForDts(entry.returns, availableTypeNames)};`, ""];
    }

    return [`export type ${entry.name} = ${transformTypeExpressionForDts(entry.typeExpression, availableTypeNames)};`, ""];
}

function buildTypeExportMap(typeEntries) {
    const exportMap = new Map();

    for (const entry of typeEntries) {
        const existingEntry = exportMap.get(entry.name);

        if (!existingEntry) {
            exportMap.set(entry.name, entry);
            continue;
        }

        if (existingEntry.filePath === entry.filePath) {
            continue;
        }

        throw new Error(
            `Duplicate exported type name "${entry.name}" found in ${toPosixRelativePath(existingEntry.filePath)} and ${toPosixRelativePath(entry.filePath)}`
        );
    }

    return exportMap;
}

function buildDtoAliases(dtoEntries) {
    return [...dtoEntries.values()].sort((left, right) => {
        const pathComparison = toPosixRelativePath(left.filePath).localeCompare(toPosixRelativePath(right.filePath));
        return pathComparison || left.name.localeCompare(right.name);
    });
}

function buildDtoIndexSource(dtoAliases) {
    const lines = [
        "/**",
        " * JSDoc Type Definitions for Gandalan.IDAS.WebApi.Client DTOs",
        " * Auto-generated from DTO leaf files in ./api/dtos/",
        " * Do not modify manually - changes will be overwritten",
        " */",
        ""
    ];

    let currentImportPath = null;

    for (const alias of dtoAliases) {
        const importPath = toRelativeImportPath(dtoIndexPath, alias.filePath);

        if (currentImportPath !== importPath) {
            if (currentImportPath !== null) {
                lines.push("");
            }

            currentImportPath = importPath;
        }

        lines.push(`/** @typedef {import("${importPath}").${alias.name}} ${alias.name} */`);
    }

    lines.push("", "export {};");
    return `${lines.join("\n")}\n`;
}

function extractBusinessCreateExports(source) {
    const exportNames = new Set();
    const patterns = [
        /export\s+function\s+(create[A-Za-z0-9_$]+Api)\b/g,
        /export\s+async\s+function\s+(create[A-Za-z0-9_$]+Api)\b/g,
        /export\s+const\s+(create[A-Za-z0-9_$]+Api)\s*=/g
    ];

    for (const pattern of patterns) {
        for (const match of source.matchAll(pattern)) {
            exportNames.add(match[1]);
        }
    }

    return [...exportNames].sort();
}

function buildBusinessAliases(businessFiles, sourceByFilePath) {
    const aliases = [];

    for (const filePath of businessFiles) {
        const source = sourceByFilePath.get(filePath);
        const createExports = extractBusinessCreateExports(source);

        if (createExports.length === 0) {
            continue;
        }

        const publicTypes = new Set(extractPublicTypeEntries(source, filePath).map((entry) => entry.name));

        for (const createExportName of createExports) {
            const typeName = createExportName.replace(/^create/, "");

            if (!publicTypes.has(typeName)) {
                throw new Error(`Expected ${toPosixRelativePath(filePath)} to define a public JSDoc type named ${typeName}`);
            }

            aliases.push({
                createExportName,
                typeName,
                filePath
            });
        }
    }

    return aliases.sort((left, right) => left.createExportName.localeCompare(right.createExportName));
}

function buildBusinessIndexSource(businessAliases) {
    const lines = [
        "// Business Routines API Exports",
        "// Auto-generated from ./api/business leaf files",
        "// Do not modify manually - changes will be overwritten",
        ""
    ];

    for (const alias of businessAliases) {
        const importPath = toRelativeImportPath(businessIndexPath, alias.filePath);
        lines.push(`export { ${alias.createExportName} } from "${importPath}";`);
    }

    lines.push("", "// Type exports for JSDoc");

    for (const alias of businessAliases) {
        const importPath = toRelativeImportPath(businessIndexPath, alias.filePath);
        lines.push(`/** @typedef {import("${importPath}").${alias.typeName}} ${alias.typeName} */`);
    }

    lines.push("");
    return `${lines.join("\n")}\n`;
}

function buildUiIndexSource(uiFiles, sourceByFilePath) {
    const lines = [
        "// UI exports",
        "// Auto-generated from ./ui leaf files",
        "// Do not modify manually - changes will be overwritten",
        ""
    ];

    const usedNames = new Map();

    for (const filePath of uiFiles) {
        const extension = path.extname(filePath);
        const importPath = toRelativeImportPath(uiIndexPath, filePath);
        const exportName = path.basename(filePath, extension);

        if (usedNames.has(exportName)) {
            throw new Error(`Duplicate UI export name ${exportName} from ${usedNames.get(exportName)} and ${toPosixRelativePath(filePath)}`);
        }

        usedNames.set(exportName, toPosixRelativePath(filePath));

        if (extension === ".svelte") {
            lines.push(`export { default as ${exportName} } from "${importPath}";`);
            continue;
        }

        const source = sourceByFilePath.get(filePath);

        if (/export\s+default\b/.test(source)) {
            lines.push(`export { default as ${exportName} } from "${importPath}";`);
        }

        lines.push(`export * from "${importPath}";`);
    }

    lines.push("");
    return `${lines.join("\n")}\n`;
}

function buildRootAliasBlock(startMarker, endMarker, description, aliases, importPath, nameSelector) {
    const lines = [
        startMarker,
        description,
        `// This block is generated by scripts/generate-dts.mjs from ${importPath}`,
        ...aliases.map((alias) => {
            const name = nameSelector(alias);
            return `/** @typedef {import("${importPath}").${name}} ${name} */`;
        }),
        endMarker
    ];

    return lines.join("\n");
}

function replaceGeneratedBlock(source, startMarker, endMarker, generatedBlock, targetFilePath) {
    const startIndex = source.indexOf(startMarker);
    const endIndex = source.indexOf(endMarker);

    if (startIndex === -1 || endIndex === -1 || endIndex < startIndex) {
        throw new Error(`Could not find generated block markers ${startMarker} / ${endMarker} in ${targetFilePath}`);
    }

    const before = source.slice(0, startIndex);
    const after = source.slice(endIndex + endMarker.length);
    return `${before}${generatedBlock}${after}`;
}

function buildRootDts(publicTypeEntries) {
    const lines = [
        "export * from \"./index.js\";",
        ...rootValueExportStatements,
        ...rootFunctionDeclarationStatements,
        ""
    ];

    const typeExportMap = buildTypeExportMap(publicTypeEntries);
    const sortedEntries = [...typeExportMap.values()].sort((left, right) => left.name.localeCompare(right.name));
    const availableTypeNames = new Set(sortedEntries.map((entry) => entry.name));

    for (const entry of sortedEntries) {
        lines.push(...renderTypeEntryAsDts(entry, availableTypeNames));
    }

    return `${lines.join("\n")}\n`;
}

const dtoLeafFiles = (await collectFiles(dtoLeafDirectory, new Set([".js"]))).filter((filePath) => path.basename(filePath) !== "index.js");
const businessLeafFiles = (await collectFiles(businessLeafDirectory, new Set([".js"]))).filter((filePath) => path.basename(filePath) !== "index.js");
const uiLeafFiles = (await collectFiles(uiLeafDirectory, new Set([".js", ".svelte"]))).filter((filePath) => path.basename(filePath) !== "index.js");
const otherApiJsFiles = (await collectFiles(path.join(rootDir, "api"), new Set([".js"]))).filter((filePath) => {
    if (path.basename(filePath) === "index.js") {
        return false;
    }

    return !filePath.startsWith(dtoLeafDirectory) && !filePath.startsWith(businessLeafDirectory);
});

const sourceByFilePath = new Map();

for (const filePath of [rootIndexPath, ...dtoLeafFiles, ...businessLeafFiles, ...otherApiJsFiles, ...uiLeafFiles]) {
    sourceByFilePath.set(filePath, await readFile(filePath, "utf8"));
}

const dtoEntries = buildTypeExportMap(dtoLeafFiles.flatMap((filePath) => extractPublicTypeEntries(sourceByFilePath.get(filePath), filePath)));
const dtoAliases = buildDtoAliases(dtoEntries);
const businessAliases = buildBusinessAliases(businessLeafFiles, sourceByFilePath);
const publicTypeEntries = [
    ...dtoLeafFiles.flatMap((filePath) => extractPublicTypeEntries(sourceByFilePath.get(filePath), filePath)),
    ...businessLeafFiles.flatMap((filePath) => extractPublicTypeEntries(sourceByFilePath.get(filePath), filePath)),
    ...otherApiJsFiles.flatMap((filePath) => extractPublicTypeEntries(sourceByFilePath.get(filePath), filePath)),
    ...uiLeafFiles.filter((filePath) => path.extname(filePath) === ".js").flatMap((filePath) => extractPublicTypeEntries(sourceByFilePath.get(filePath), filePath))
];

const generatedDtoIndexSource = buildDtoIndexSource(dtoAliases);
const generatedBusinessIndexSource = buildBusinessIndexSource(businessAliases);
const generatedUiIndexSource = buildUiIndexSource(uiLeafFiles, sourceByFilePath);

await writeFile(dtoIndexPath, generatedDtoIndexSource);
await writeFile(businessIndexPath, generatedBusinessIndexSource);
await writeFile(uiIndexPath, generatedUiIndexSource);

sourceByFilePath.set(dtoIndexPath, generatedDtoIndexSource);
sourceByFilePath.set(businessIndexPath, generatedBusinessIndexSource);
sourceByFilePath.set(uiIndexPath, generatedUiIndexSource);

const dtoRootBlock = buildRootAliasBlock(
    dtoRootMarkerStart,
    dtoRootMarkerEnd,
    "// DTO Type Definitions - copied to the package root for stable JSDoc imports",
    dtoAliases,
    "./api/dtos/index.js",
    (alias) => alias.name
);

const businessRootBlock = buildRootAliasBlock(
    businessRootMarkerStart,
    businessRootMarkerEnd,
    "// Business API Type Definitions - copied to the package root for stable JSDoc imports",
    businessAliases,
    "./api/business/index.js",
    (alias) => alias.typeName
);

const currentRootIndexSource = sourceByFilePath.get(rootIndexPath);
const rootIndexWithDtoAliases = replaceGeneratedBlock(currentRootIndexSource, dtoRootMarkerStart, dtoRootMarkerEnd, dtoRootBlock, rootIndexPath);
const updatedRootIndexSource = replaceGeneratedBlock(rootIndexWithDtoAliases, businessRootMarkerStart, businessRootMarkerEnd, businessRootBlock, rootIndexPath);

await writeFile(rootIndexPath, updatedRootIndexSource);
sourceByFilePath.set(rootIndexPath, updatedRootIndexSource);

const generatedRootDts = buildRootDts(publicTypeEntries);
await writeFile(rootDtsPath, generatedRootDts);

console.log(`Updated ${toPosixRelativePath(dtoIndexPath)} with ${dtoAliases.length} generated DTO aliases.`);
console.log(`Updated ${toPosixRelativePath(businessIndexPath)} with ${businessAliases.length} generated business API exports.`);
console.log(`Updated ${toPosixRelativePath(uiIndexPath)} with ${uiLeafFiles.length} generated UI exports.`);
console.log(`Updated ${toPosixRelativePath(rootIndexPath)} generated JSDoc alias blocks.`);
console.log(`Wrote ${toPosixRelativePath(rootDtsPath)} with full package type exports.`);
