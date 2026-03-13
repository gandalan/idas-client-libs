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
const neherApp3TypesJsPath = path.join(rootDir, "api", "neherApp3Types.js");
const neherApp3TypesDtsPath = path.join(rootDir, "api", "neherApp3Types.d.ts");

const dtoLeafDirectory = path.join(rootDir, "api", "dtos");
const businessLeafDirectory = path.join(rootDir, "api", "business");
const uiLeafDirectory = path.join(rootDir, "ui");

const sourceDirectories = ["api", "ui"];

const dtoRootMarkerStart = "// BEGIN GENERATED ROOT DTO TYPEDEFS";
const dtoRootMarkerEnd = "// END GENERATED ROOT DTO TYPEDEFS";
const businessRootMarkerStart = "// BEGIN GENERATED ROOT BUSINESS TYPEDEFS";
const businessRootMarkerEnd = "// END GENERATED ROOT BUSINESS TYPEDEFS";

const simpleImportTypePattern = /^import\((?:"|').+(?:"|')\)\.[A-Za-z0-9_$]+$/;

const rawType = (js, ts = js) => ({ kind: "raw", js, ts });
const refType = (name) => rawType(name);
const importType = (importPath, name) => rawType(`import("${importPath}").${name}`);
const arrayType = (elementType) => ({ kind: "array", elementType });
const promiseType = (valueType) => ({ kind: "promise", valueType });
const unionType = (...types) => ({ kind: "union", types });
const intersectionType = (...types) => ({ kind: "intersection", types });
const functionType = (params, returnType) => ({ kind: "function", params, returnType });
const objectLiteralType = (properties) => ({ kind: "objectLiteral", properties });

const stringType = refType("string");
const booleanType = refType("boolean");
const voidType = refType("void");
const jsObjectType = rawType("Object", "object");
const jsFunctionType = rawType("function", "Function");

const neherApp3JsImports = [
    { importPath: "./fluentApi.js", name: "FluentApi" },
    { importPath: "./idasFluentApi.js", name: "IDASFluentApi" },
    { importPath: "./fluentAuthManager.js", name: "FluentAuthManager" }
];

const neherApp3TypeDefinitions = [
    {
        kind: "alias",
        name: "NeherApp3NotifyType",
        type: unionType(rawType("0"), rawType("1"), rawType("2"))
    },
    {
        kind: "object",
        name: "ArtikelstammEintrag",
        properties: [
            { name: "KatalogArtikelGuid", type: stringType, optional: true },
            { name: "KatalogNummer", type: stringType, optional: true },
            { name: "Katalognummer", type: stringType, optional: true },
            { name: "Nummer", type: stringType, optional: true }
        ]
    },
    {
        kind: "object",
        name: "Variante",
        properties: [
            { name: "VarianteGuid", type: stringType, optional: true },
            { name: "Name", type: stringType, optional: true },
            { name: "Kuerzel", type: stringType, optional: true }
        ]
    },
    {
        kind: "object",
        name: "Werteliste",
        properties: [
            { name: "WerteListeGuid", type: stringType, optional: true },
            { name: "Name", type: stringType, optional: true }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3ArtikelstammCache",
        properties: [
            { name: "getArtikelStamm", type: functionType([], promiseType(arrayType(refType("ArtikelstammEintrag")))) },
            { name: "getWarenGruppen", type: functionType([], promiseType(arrayType(jsObjectType))) },
            {
                name: "getArtikelByGuid",
                type: functionType([{ name: "guid", type: stringType }], promiseType(unionType(refType("ArtikelstammEintrag"), rawType("undefined"))))
            },
            {
                name: "getArtikelByKatalognummer",
                type: functionType([{ name: "nummer", type: stringType }], promiseType(unionType(refType("ArtikelstammEintrag"), rawType("undefined"))))
            }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3ErfassungCache",
        properties: [
            { name: "getVarianten", type: functionType([], promiseType(arrayType(refType("Variante")))) },
            {
                name: "getVariante",
                type: functionType([{ name: "variantenNameOderKuerzel", type: stringType }], promiseType(unionType(refType("Variante"), rawType("undefined"))))
            },
            { name: "getWertelisten", type: functionType([], promiseType(arrayType(refType("Werteliste")))) },
            {
                name: "getWerteliste",
                type: functionType([{ name: "name", type: stringType }], promiseType(unionType(refType("Werteliste"), rawType("undefined"))))
            },
            { name: "getScripts", type: functionType([], promiseType(arrayType(jsObjectType))) },
            { name: "createUIMachine", type: functionType([{ name: "v", type: refType("Variante") }], voidType) }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3Props",
        properties: [
            { name: "api", type: importType("./fluentApi.js", "FluentApi") },
            { name: "authManager", type: importType("./fluentAuthManager.js", "FluentAuthManager"), optional: true },
            { name: "idas", type: importType("./idasFluentApi.js", "IDASFluentApi") },
            { name: "mainCssPath", type: stringType, optional: true }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3MenuItem",
        properties: [
            { name: "id", type: stringType, optional: true, description: "Unique identifier for the menu item (auto-generated if not provided)" },
            { name: "selected", type: booleanType, optional: true, description: "Indicates if the menu item is currently selected (managed by the menu system)" },
            { name: "icon", type: stringType, optional: true, description: "URL to an icon" },
            { name: "url", type: unionType(stringType, rawType("null")), optional: true, description: "Relative URL to use for routes" },
            { name: "text", type: stringType, description: "Display text" },
            { name: "parent", type: unionType(stringType, rawType("null")), optional: true, description: "Parent menu item (optional). If not set, the item will be added to the top level menu." },
            { name: "hidden", type: booleanType, optional: true, description: "If true, the menu item will not be displayed" }
        ]
    },
    {
        kind: "alias",
        name: "NeherApp3SetupContext",
        type: intersectionType(
            refType("NeherApp3Props"),
            objectLiteralType([{ name: "neherapp3", type: refType("NeherApp3") }])
        )
    },
    {
        kind: "object",
        name: "NeherApp3Module",
        properties: [
            { name: "moduleName", type: stringType },
            {
                name: "setup",
                type: functionType([{ name: "context", type: refType("NeherApp3SetupContext") }], unionType(voidType, promiseType(voidType))),
                optional: true
            },
            {
                name: "mount",
                type: functionType(
                    [
                        { name: "node", type: refType("HTMLElement") },
                        { name: "props", type: refType("NeherApp3SetupContext") }
                    ],
                    unionType(voidType, jsFunctionType)
                ),
                optional: true,
                description: "Must return an optional unmount function"
            },
            { name: "embedUrl", type: stringType, optional: true },
            { name: "extraCSS", type: arrayType(stringType), optional: true },
            { name: "useShadowDom", type: booleanType, optional: true, description: "If true, the app will be embedded in a shadow DOM. This is required for CSS isolation." }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3ApiCollection",
        properties: [
            { name: "idas", type: importType("./idasFluentApi.js", "IDASFluentApi"), optional: true },
            { name: "hostingEnvironment", type: importType("./fluentApi.js", "FluentApi"), optional: true }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3CacheCollection",
        properties: [
            { name: "artikelstamm", type: refType("NeherApp3ArtikelstammCache") },
            { name: "erfassung", type: refType("NeherApp3ErfassungCache") }
        ]
    },
    {
        kind: "object",
        name: "NeherApp3",
        properties: [
            { name: "addMenuItem", type: functionType([{ name: "menuItem", type: refType("NeherApp3MenuItem") }], voidType) },
            { name: "addApp", type: functionType([{ name: "appModule", type: unionType(refType("NeherApp3Module"), stringType) }], promiseType(voidType)) },
            {
                name: "notify",
                type: functionType(
                    [
                        { name: "message", type: stringType },
                        { name: "type", type: refType("NeherApp3NotifyType"), optional: true },
                        { name: "cb", type: jsFunctionType, optional: true }
                    ],
                    voidType
                ),
                description: "Shows a notification. Type defaults to 0 (info). Callback is optional."
            },
            { name: "api", type: refType("NeherApp3ApiCollection") },
            { name: "cache", type: refType("NeherApp3CacheCollection") }
        ]
    }
];

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

function toRelativeDtsImportPath(fromFilePath, targetFilePath) {
    const importPath = toRelativeImportPath(fromFilePath, targetFilePath);

    if (targetFilePath === path.join(rootDir, "api", "neherApp3Types.js")) {
        return importPath.replace(/\.js$/, "");
    }

    return importPath;
}

function getJSDocBlocks(source) {
    return source.match(/\/\*\*[\s\S]*?\*\//g) ?? [];
}

function renderTypeExpression(typeExpression, format) {
    switch (typeExpression.kind) {
        case "raw":
            return format === "js" ? typeExpression.js : typeExpression.ts;
        case "array":
            return `${renderTypeExpression(typeExpression.elementType, format)}[]`;
        case "promise":
            return `Promise<${renderTypeExpression(typeExpression.valueType, format)}>`;
        case "union":
            return typeExpression.types.map((type) => renderTypeExpression(type, format)).join(" | ");
        case "intersection":
            return typeExpression.types.map((type) => renderTypeExpression(type, format)).join(" & ");
        case "function":
            return `(${typeExpression.params.map((param) => `${param.name}${param.optional ? "?" : ""}: ${renderTypeExpression(param.type, format)}`).join(", ")}) => ${renderTypeExpression(typeExpression.returnType, format)}`;
        case "objectLiteral":
            return `{ ${typeExpression.properties.map((property) => `${property.name}${property.optional ? "?" : ""}: ${renderTypeExpression(property.type, format)}`).join("; ")} }`;
        default:
            throw new Error(`Unsupported type expression kind: ${typeExpression.kind}`);
    }
}

function buildNeherApp3TypesJsSource() {
    const lines = [
        "/**",
        " * Auto-generated NeherApp3 root type definitions.",
        " * Do not modify manually - changes will be overwritten by scripts/generate-root-dto-typedefs.mjs",
        " */",
        ""
    ];

    for (const jsImport of neherApp3JsImports) {
        lines.push(`/** @typedef {import("${jsImport.importPath}").${jsImport.name}} ${jsImport.name} */`);
    }

    lines.push("");

    for (const definition of neherApp3TypeDefinitions) {
        if (definition.kind === "alias") {
            lines.push("/**");
            lines.push(` * @typedef {${renderTypeExpression(definition.type, "js")}} ${definition.name}`);
            lines.push(" */");
            lines.push("");
            continue;
        }

        lines.push("/**");
        lines.push(` * @typedef {Object} ${definition.name}`);

        for (const property of definition.properties) {
            const propertyName = property.optional ? `[${property.name}]` : property.name;
            const propertyLine = ` * @property {${renderTypeExpression(property.type, "js")}} ${propertyName}`;
            lines.push(property.description ? `${propertyLine} - ${property.description}` : propertyLine);
        }

        lines.push(" */");
        lines.push("");
    }

    lines.push("export {};");
    return `${lines.join("\n")}\n`;
}

function buildNeherApp3TypesDtsSource() {
    const lines = [
        "// Auto-generated NeherApp3 root type definitions.",
        "// Do not modify manually - changes will be overwritten by scripts/generate-root-dto-typedefs.mjs",
        ""
    ];

    for (const definition of neherApp3TypeDefinitions) {
        if (definition.kind === "alias") {
            lines.push(`export type ${definition.name} = ${renderTypeExpression(definition.type, "ts")};`);
            lines.push("");
            continue;
        }

        lines.push(`export type ${definition.name} = {`);

        for (const property of definition.properties) {
            lines.push(`    ${property.name}${property.optional ? "?" : ""}: ${renderTypeExpression(property.type, "ts")};`);
        }

        lines.push("};");
        lines.push("");
    }

    return `${lines.join("\n")}\n`;
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
        `// This block is generated by scripts/generate-root-dto-typedefs.mjs from ${importPath}`,
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
const generatedNeherApp3TypesJsSource = buildNeherApp3TypesJsSource();
const generatedNeherApp3TypesDtsSource = buildNeherApp3TypesDtsSource();

await writeFile(dtoIndexPath, generatedDtoIndexSource);
await writeFile(businessIndexPath, generatedBusinessIndexSource);
await writeFile(uiIndexPath, generatedUiIndexSource);
await writeFile(neherApp3TypesJsPath, generatedNeherApp3TypesJsSource);
await writeFile(neherApp3TypesDtsPath, generatedNeherApp3TypesDtsSource);

sourceByFilePath.set(dtoIndexPath, generatedDtoIndexSource);
sourceByFilePath.set(businessIndexPath, generatedBusinessIndexSource);
sourceByFilePath.set(uiIndexPath, generatedUiIndexSource);
sourceByFilePath.set(neherApp3TypesJsPath, generatedNeherApp3TypesJsSource);

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
console.log(`Updated ${toPosixRelativePath(neherApp3TypesJsPath)} generated NeherApp3 JSDoc type exports.`);
console.log(`Updated ${toPosixRelativePath(neherApp3TypesDtsPath)} generated NeherApp3 declaration exports.`);
console.log(`Updated ${toPosixRelativePath(rootIndexPath)} generated JSDoc alias blocks.`);
console.log(`Wrote ${toPosixRelativePath(rootDtsPath)} with full package type exports.`);
