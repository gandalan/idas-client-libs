/**
 * Auto-generated NeherApp3 root type definitions.
 * Do not modify manually - changes will be overwritten by scripts/generate-root-dto-typedefs.mjs
 */

/** @typedef {import("./fluentApi.js").FluentApi} FluentApi */
/** @typedef {import("./idasFluentApi.js").IDASFluentApi} IDASFluentApi */
/** @typedef {import("./fluentAuthManager.js").FluentAuthManager} FluentAuthManager */

/**
 * @typedef {0 | 1 | 2} NeherApp3NotifyType
 */

/**
 * @typedef {Object} ArtikelstammEintrag
 * @property {string} [KatalogArtikelGuid]
 * @property {string} [KatalogNummer]
 * @property {string} [Katalognummer]
 * @property {string} [Nummer]
 */

/**
 * @typedef {Object} Variante
 * @property {string} [VarianteGuid]
 * @property {string} [Name]
 * @property {string} [Kuerzel]
 */

/**
 * @typedef {Object} Werteliste
 * @property {string} [WerteListeGuid]
 * @property {string} [Name]
 */

/**
 * @typedef {Object} NeherApp3ArtikelstammCache
 * @property {() => Promise<ArtikelstammEintrag[]>} getArtikelStamm
 * @property {() => Promise<Object[]>} getWarenGruppen
 * @property {(guid: string) => Promise<ArtikelstammEintrag | undefined>} getArtikelByGuid
 * @property {(nummer: string) => Promise<ArtikelstammEintrag | undefined>} getArtikelByKatalognummer
 */

/**
 * @typedef {Object} NeherApp3ErfassungCache
 * @property {() => Promise<Variante[]>} getVarianten
 * @property {(variantenNameOderKuerzel: string) => Promise<Variante | undefined>} getVariante
 * @property {() => Promise<Werteliste[]>} getWertelisten
 * @property {(name: string) => Promise<Werteliste | undefined>} getWerteliste
 * @property {() => Promise<Object[]>} getScripts
 * @property {(v: Variante) => void} createUIMachine
 */

/**
 * @typedef {Object} NeherApp3Props
 * @property {import("./fluentApi.js").FluentApi} api
 * @property {import("./fluentAuthManager.js").FluentAuthManager} [authManager]
 * @property {import("./idasFluentApi.js").IDASFluentApi} idas
 * @property {string} [mainCssPath]
 */

/**
 * @typedef {Object} NeherApp3MenuItem
 * @property {string} [id] - Unique identifier for the menu item (auto-generated if not provided)
 * @property {boolean} [selected] - Indicates if the menu item is currently selected (managed by the menu system)
 * @property {string} [icon] - URL to an icon
 * @property {string | null} [url] - Relative URL to use for routes
 * @property {string} text - Display text
 * @property {string | null} [parent] - Parent menu item (optional). If not set, the item will be added to the top level menu.
 * @property {boolean} [hidden] - If true, the menu item will not be displayed
 */

/**
 * @typedef {NeherApp3Props & { neherapp3: NeherApp3 }} NeherApp3SetupContext
 */

/**
 * @typedef {Object} NeherApp3Module
 * @property {string} moduleName
 * @property {(context: NeherApp3SetupContext) => void | Promise<void>} [setup]
 * @property {(node: HTMLElement, props: NeherApp3SetupContext) => void | function} [mount] - Must return an optional unmount function
 * @property {string} [embedUrl]
 * @property {string[]} [extraCSS]
 * @property {boolean} [useShadowDom] - If true, the app will be embedded in a shadow DOM. This is required for CSS isolation.
 */

/**
 * @typedef {Object} NeherApp3ApiCollection
 * @property {import("./idasFluentApi.js").IDASFluentApi} [idas]
 * @property {import("./fluentApi.js").FluentApi} [hostingEnvironment]
 */

/**
 * @typedef {Object} NeherApp3CacheCollection
 * @property {NeherApp3ArtikelstammCache} artikelstamm
 * @property {NeherApp3ErfassungCache} erfassung
 */

/**
 * @typedef {Object} NeherApp3
 * @property {(menuItem: NeherApp3MenuItem) => void} addMenuItem
 * @property {(appModule: NeherApp3Module | string) => Promise<void>} addApp
 * @property {(message: string, type?: NeherApp3NotifyType, cb?: function) => void} notify - Shows a notification. Type defaults to 0 (info). Callback is optional.
 * @property {NeherApp3ApiCollection} api
 * @property {NeherApp3CacheCollection} cache
 */

export {};
