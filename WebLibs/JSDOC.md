# JSDoc Reference for WebLibs

This document records the JSDoc stabilization work done in `WebLibs` and defines the rules that must be followed going forward.

The goal is simple:

- No API member should degrade to `any` because of broken JSDoc.
- No DTO type should degrade to `any` because of missing exports, missing imports, or non-module files.
- Type information must stay discoverable in VS Code IntelliSense through `import("...").Type` and local typedef aliases.


## What Was Changed

The following classes of problems were fixed.

### 1. API typedef exports were completed

Several business API files did not export a stable API type alias, or exported it inconsistently.

The working pattern is:

```js
/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
```

This pattern was added or standardized for affected business API files.


### 2. Circular API typing was removed

Some API factory functions used this pattern:

```js
/**
 * @returns {ProduktionApi}
 */
export function createProduktionApi(fluentApi) {
```

while the same file also defined:

```js
/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
```

That is circular. The JS language service can collapse this to `any`.

The `@returns {XApi}` annotation was removed from those files when `XApi` was defined via `ReturnType<typeof createXApi>`.


### 3. `idasFluentApi` member typing was stabilized

`IDASFluentApi` was normalized so that business members are typed consistently through imported API aliases, for example:

```js
/**
 * @typedef {import("./business/produktionApi.js").ProduktionApi} ProduktionApi
 */

/**
 * @typedef {import("./fluentApi.js").FluentApi & {
 *   produktion: ProduktionApi;
 * }} IDASFluentApi
 */
```

This avoids ad hoc per-member typing strategies.


### 4. DTO script files were converted into actual ES modules

Some DTO files only contained `@typedef` declarations and no export. In practice, that can make `import("./file.js").Type` unstable or unusable.

These DTO files were converted into modules by adding:

```js
export {};
```

This was required in plain typedef-only files such as:

- `api/dtos/belege.js`
- `api/dtos/kunden.js`
- `api/dtos/produktion.js`


### 5. DTO cross-file dependencies were fixed

Some DTOs referenced other DTOs from different files without importing them locally.

Example of the broken pattern:

```js
/**
 * @typedef {Object} BelegDTO
 * @property {BeleganschriftDTO} BelegAdresse
 */
```

if `BeleganschriftDTO` lives in another file and is not imported locally.

That was fixed by either:

- adding a local typedef alias, or
- using an inline import in the property type.

Example:

```js
/** @typedef {import('./kunden.js').BeleganschriftDTO} BeleganschriftDTO */
```

or:

```js
 * @property {import('./kunden.js').BeleganschriftDTO} BelegAdresse
```


### 6. Missing DTO definitions in JSDoc were added

Several DTO names used by the API surface existed in C# or were referenced in JS but were not actually modeled in JSDoc. Missing DTO definitions were added where source information was available.

Examples added from source models:

- `RechnungsNummer`
- `ZusatztextDTO`
- `BelegPositionSonderwunschDTO`


### 7. Business API method signatures were normalized

Inline method-level types like this were reduced:

```js
 * @returns {Promise<import('../dtos/index.js').ProduktionsfreigabeItemDTO[]>}
```

and replaced with local aliases at file top plus clean signatures:

```js
/** @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO */

/**
 * @returns {Promise<ProduktionsfreigabeItemDTO[]>}
 */
```

This is easier to read, easier to maintain, and resolves more reliably in IntelliSense.


### 8. `FluentApi` typedef usage was standardized

Business API files must use:

```js
/** @typedef {import('../fluentApi.js').FluentApi} FluentApi */
```

and not:

- a hand-written fake `FluentApi` object type
- a missing typedef
- an import path without `.js`


## Files Touched By This Work

The exact set may evolve later, but the primary files changed during this stabilization were:

### API files

- `api/idasFluentApi.js`
- `api/business/benutzerApi.js`
- `api/business/artikelApi.js`
- `api/business/belegApi.js`
- `api/business/produktionApi.js`
- `api/business/fakturaApi.js`
- `api/business/settingsApi.js`
- `api/business/uiApi.js`
- `api/business/utilityApi.js`
- `api/business/serienApi.js`
- `api/business/kontaktApi.js`
- `api/business/belegPositionenApi.js`
- `api/business/materialApi.js`

### DTO files

- `api/dtos/index.js`
- `api/dtos/belege.js`
- `api/dtos/kunden.js`
- `api/dtos/produktion.js`
- `api/dtos/settings.js`
- `api/dtos/ui.js`
- `api/dtos/technik.js`


## The Rules

These rules are mandatory if you want JSDoc discoverability to remain stable.


## Rule 1: Every DTO file must be an ES module

If a DTO file only contains typedefs, still add:

```js
export {};
```

Why:

- `import("./file.js").Type` is far more reliable when the target file is a real module.
- Script files with only comments can cause type imports to degrade to `any`.

Applies to:

- DTO files
- Any pure-type helper JS file used as a JSDoc import target


## Rule 2: Use `.js` in all JSDoc import paths

Always write:

```js
import("../dtos/belege.js").VorgangDTO
```

Never write:

```js
import("../dtos/belege").VorgangDTO
```

Why:

- The repo is ESM.
- The JS language service resolves explicit file extensions more consistently.


## Rule 3: DTO files must import cross-file DTO dependencies locally

If a DTO property references a type from another DTO file, that dependency must be represented in the file itself.

Preferred forms:

```js
/** @typedef {import('./kunden.js').BeleganschriftDTO} BeleganschriftDTO */
```

or directly in the property:

```js
 * @property {import('./kunden.js').BeleganschriftDTO} BelegAdresse
```

Never assume a type from another file is globally visible.

Why:

- Cross-file DTO references otherwise become weak links.
- A top-level DTO may exist, but nested properties can still collapse to `any`.


## Rule 4: API files should define local type aliases at the top

At the top of each API file, create short local aliases for every DTO used in that file.

Example:

```js
/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO
 * @typedef {import('../dtos/produktion.js').ProduktionsInfoDTO} ProduktionsInfoDTO
 */
```

Then use those aliases in method docs.

Why:

- Method signatures stay readable.
- Repeated inline import expressions are error-prone.
- VS Code resolves these aliases more reliably than repeated deep inline imports.


## Rule 5: Prefer direct DTO source imports over aggregate imports when practical

Preferred:

```js
/** @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO */
```

Acceptable when the type truly belongs to the index layer:

```js
/** @typedef {import('../dtos/index.js').LoginDTO} LoginDTO */
```

Avoid defaulting everything to `dtos/index.js` when the concrete DTO source file is known.

Why:

- Fewer resolution layers.
- Easier debugging.
- Better discoverability of the true type owner.


## Rule 6: Do not use circular factory typedef patterns

Do not do this:

```js
/**
 * @returns {ProduktionApi}
 */
export function createProduktionApi(...) {}

/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
```

If the exported API type is defined through `ReturnType<typeof createXApi>`, then the factory should not also declare `@returns {XApi}`.

Correct pattern:

```js
/**
 * @param {FluentApi} fluentApi
 */
export function createProduktionApi(fluentApi) {
    return {
        ...
    };
}

/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
```


## Rule 7: `idasFluentApi` members must use imported API aliases consistently

Correct pattern:

```js
/** @typedef {import('./business/produktionApi.js').ProduktionApi} ProduktionApi */

/**
 * @typedef {import('./fluentApi.js').FluentApi & {
 *   produktion: ProduktionApi;
 * }} IDASFluentApi
 */
```

Do not mix:

- imported alias types for some members
- inline `ReturnType<typeof import(...).createXApi>` for others
- unresolved local names for others

One consistent member strategy must be used.


## Rule 8: Every API file must define `FluentApi` the same way

Always:

```js
/** @typedef {import('../fluentApi.js').FluentApi} FluentApi */
```

Never:

- hand-write a fake subset object
- omit it and still write `@param {FluentApi}`
- use extensionless import paths


## Rule 9: Optional parameters must be documented exactly

If a parameter has a default value or is optional at call sites, mark it optional in JSDoc.

Correct forms:

```js
 * @param {boolean} [includeDetails=true]
 * @param {Date} [changedSince]
 * @param {string} [statusText='']
```

Rules:

- Use square brackets for optional parameters.
- Include the default if the runtime defines one.
- The JSDoc type must match the runtime type exactly.
- If `null` is accepted, include it explicitly.

Examples:

```js
 * @param {Date | null} [changedSince=null]
 * @param {boolean} [includeUIDefs=true]
 * @param {string[]} belegGuids
```

Do not omit optionality when the implementation has a default value.


## Rule 10: Method names, parameter names, and types must match runtime code exactly

JSDoc is not a sketch. It must match the code.

That means:

- parameter order must match the function signature
- parameter names must match the implementation
- optional/default markers must match runtime defaults
- return types must match actual API responses, not assumptions

If the runtime returns a decoded JWT claims object, do not document it as a Swagger login DTO.


## Rule 11: DTO property types must be concrete where possible

Prefer:

```js
 * @property {string} VorgangGuid
 * @property {number | null} VE_Menge
 * @property {Array<BelegPositionDTO>} PositionsObjekte
```

Avoid broad placeholders unless the source model is genuinely unknown.

Use placeholders only when:

- no source model exists in the repo
- the backend contract is genuinely unknown
- the placeholder is temporary and explicitly marked as such


## Rule 12: Placeholders are allowed, but they must be obvious and deliberate

If a DTO cannot yet be modeled concretely, keep the placeholder explicit:

```js
/** @typedef {Object} WebJobHistorieDTO */
```

and keep it centralized in `api/dtos/index.js` with a note that it is a placeholder.

Do not scatter placeholder definitions across business API files.


## Rule 13: Avoid duplicate semantic owners when possible

There are two patterns in this repo:

- concrete DTO file owns the actual shape
- `dtos/index.js` re-exports or aliases it for convenience

The concrete source file should remain the semantic owner of the shape.

Examples:

- `belege.js` owns `VorgangDTO`
- `produktion.js` owns `ProduktionsfreigabeItemDTO`
- `kunden.js` owns `KontaktDTO`

`dtos/index.js` may alias them, but should not silently replace a concrete definition with a weaker one.


## Rule 14: If a DTO file references types from C# sources, keep the JSDoc aligned to the source names

If you add or fix a DTO from C#:

- preserve the original name
- preserve nullability where clear
- preserve enum value meaning where clear
- preserve nested object types when known

Example fixes performed in this work came from C# source classes and enums.


## Rule 15: Use clean method-level JSDoc, not deep import expressions

Preferred:

```js
/** @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO */

/**
 * @returns {Promise<ProduktionsfreigabeItemDTO[]>}
 */
getAllProduktionsfreigabeItems: () => fluentApi.get("ProduktionsfreigabeListe"),
```

Avoid:

```js
/**
 * @returns {Promise<import('../dtos/index.js').ProduktionsfreigabeItemDTO[]>}
 */
```


## Rule 16: Keep JSDoc formatting strict

Formatting affects readability and can affect tooling robustness.

Rules:

- keep indentation consistent with the file
- keep comment stars aligned
- do not leave malformed comment lines
- do not mix single-quote and double-quote styles against repo lint rules
- run lint fix after large edits in `WebLibs`


## Recommended Patterns

### Pattern A: DTO-only module

```js
/**
 * @typedef {Object} ExampleDTO
 * @property {string} Guid
 * @property {number | null} Version
 */

export {};
```


### Pattern B: DTO with cross-file dependency

```js
/** @typedef {import('./kunden.js').KontaktDTO} KontaktDTO */

/**
 * @typedef {Object} VorgangDTO
 * @property {KontaktDTO} Kunde
 */

export {};
```


### Pattern C: Business API file

```js
/**
 * @typedef {import('../fluentApi.js').FluentApi} FluentApi
 * @typedef {import('../dtos/produktion.js').ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO
 */

/**
 * @param {FluentApi} fluentApi
 */
export function createProduktionApi(fluentApi) {
    return {
        /**
         * @returns {Promise<ProduktionsfreigabeItemDTO[]>}
         */
        getAllProduktionsfreigabeItems: () => fluentApi.get("ProduktionsfreigabeListe")
    };
}

/**
 * @typedef {ReturnType<typeof createProduktionApi>} ProduktionApi
 */
```


### Pattern D: Optional parameter with default

```js
/**
 * @param {boolean} [includeDetails=true]
 * @param {Date | null} [changedSince=null]
 * @returns {Promise<AblageDTO[]>}
 */
```


## Edge Cases Checklist

Before finishing any JSDoc work, verify all of the following.

### DTO checklist

- The DTO file is an ES module.
- Every cross-file DTO property type is imported locally or written as an inline import.
- Every enum-like type is documented with the correct primitive union or numeric union.
- Nullability is explicit.
- Arrays use `Type[]` or `Array<Type>` consistently.
- No referenced type name exists only in C# while missing from JSDoc.
- If a placeholder remains, it is explicit and centralized.

### API checklist

- `FluentApi` is imported with `.js`.
- DTOs used in method docs have top-of-file aliases.
- No inline `import('../dtos/index.js').Type` remains in `@param` or `@returns` unless there is a deliberate reason.
- Optional parameters use square-bracket syntax.
- Default values in code are reflected in JSDoc.
- There is no circular `@returns {XApi}` with `ReturnType<typeof createXApi>`.
- The exported `XApi` typedef exists at the end of the file.

### `idasFluentApi` checklist

- Every business member type is imported explicitly.
- All member properties use one consistent typing strategy.
- The `userInfo` type matches the runtime object shape, not a guessed backend DTO.


## Validation Workflow

Whenever you touch JSDoc in `WebLibs`, validate in this order.

1. Fix local file diagnostics.
2. Ensure DTO files are ES modules.
3. Ensure DTO cross-file property references are imported locally.
4. Ensure API files use local DTO aliases.
5. Ensure no circular API `ReturnType` patterns remain.
6. Run ESLint fix on changed files.
7. Restart the TS server if IntelliSense still shows stale `any`.


## Known Remaining Risk

`api/dtos/index.js` still contains some placeholder DTOs that were kept intentionally because no complete JSDoc source model was fully introduced in this pass.

That is acceptable for now as long as:

- they remain explicit placeholders
- they do not replace stronger concrete definitions
- they are upgraded when the source DTO shape becomes available


## Bottom Line

If you follow these rules, JSDoc discoverability in this repo stays stable.

The three most important requirements are:

1. DTO files must be ES modules.
2. DTO cross-file property types must be imported locally.
3. API files must use local typedef aliases and avoid circular or overly indirect typing.

If one of those three is violated, IntelliSense will often fall back to `any` even though the comments look valid at first glance.