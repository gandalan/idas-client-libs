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

const sourceDirectories = ["api", "ui"];

const dtoRootMarkerStart = "// BEGIN GENERATED ROOT DTO TYPEDEFS";
const dtoRootMarkerEnd = "// END GENERATED ROOT DTO TYPEDEFS";
const businessRootMarkerStart = "// BEGIN GENERATED ROOT BUSINESS TYPEDEFS";
const businessRootMarkerEnd = "// END GENERATED ROOT BUSINESS TYPEDEFS";

const simpleImportTypePattern = /^import\((?:"|').+(?:"|')\)\.[A-Za-z0-9_$]+$/;

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

    return {
        kind: "typedef",
        name: nameMatch[1],
        typeExpression
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
        typeExpression: null
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

function buildRootDts(dtoAliases, sourceByFilePath, allJsFilesByDirectory) {
    const dtoAliasNames = new Set(dtoAliases.map((alias) => alias.name));
    const lines = [
        "export * from \"./index.js\";",
        ""
    ];

    const sourceFiles = [rootIndexPath];

    for (const directory of sourceDirectories) {
        sourceFiles.push(...allJsFilesByDirectory.get(directory));
    }

    const discoveredTypeEntries = [];

    for (const filePath of sourceFiles) {
        const source = sourceByFilePath.get(filePath);
        discoveredTypeEntries.push(...extractPublicTypeEntries(source, filePath));
    }

    const canonicalizedTypeEntries = discoveredTypeEntries.filter((entry) => {
        const relativeFilePath = toPosixRelativePath(entry.filePath);
        const isDtoLeafFile = relativeFilePath.startsWith("api/dtos/") && relativeFilePath !== "api/dtos/index.js";

        if (isDtoLeafFile && dtoAliasNames.has(entry.name)) {
            return false;
        }

        return true;
    });

    const typeExportMap = buildTypeExportMap(canonicalizedTypeEntries);
    const sortedEntries = [...typeExportMap.values()].sort((left, right) => left.name.localeCompare(right.name));

    for (const entry of sortedEntries) {
        if (dtoAliasNames.has(entry.name)) {
            lines.push(`export type ${entry.name} = import("./api/dtos/index.js").${entry.name};`);
            dtoAliasNames.delete(entry.name);
            continue;
        }

        const relativeImportPath = `./${toPosixRelativePath(entry.filePath)}`;
        lines.push(`export type ${entry.name} = import("${relativeImportPath}").${entry.name};`);
    }

    for (const alias of dtoAliases) {
        if (!dtoAliasNames.has(alias.name)) {
            continue;
        }

        lines.push(`export type ${alias.name} = import("./api/dtos/index.js").${alias.name};`);
    }

    lines.push("");
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

const allJsFilesByDirectory = new Map([
    ["api", [...dtoLeafFiles, ...businessLeafFiles, ...otherApiJsFiles].sort()],
    ["ui", uiLeafFiles.filter((filePath) => path.extname(filePath) === ".js").sort()]
]);

const generatedRootDts = buildRootDts(dtoAliases, sourceByFilePath, allJsFilesByDirectory);
await writeFile(rootDtsPath, generatedRootDts);

console.log(`Updated ${toPosixRelativePath(dtoIndexPath)} with ${dtoAliases.length} generated DTO aliases.`);
console.log(`Updated ${toPosixRelativePath(businessIndexPath)} with ${businessAliases.length} generated business API exports.`);
console.log(`Updated ${toPosixRelativePath(uiIndexPath)} with ${uiLeafFiles.length} generated UI exports.`);
console.log(`Updated ${toPosixRelativePath(rootIndexPath)} generated JSDoc alias blocks.`);
console.log(`Wrote ${toPosixRelativePath(rootDtsPath)} with full package type exports.`);
