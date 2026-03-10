import { IDASFactory } from "./api/IDAS";
import { RESTClient } from "./api/RESTClient";
import { initIDAS } from "./api/authUtils";
export { IDASFactory, initIDAS, RESTClient };

export { createApi, fluentApi } from "./api/fluentApi";
export { createAuthManager, fluentIdasAuthManager } from "./api/fluentAuthManager";
export { fetchEnvConfig } from "./api/fluentEnvUtils";
export { restClient } from "./api/fluentRestClient";

// Business Routines APIs
export {
    createVorgangApi,
    createKontaktApi,
    createBelegPositionenApi,
    createMaterialApi,
    createSerienApi,
    createBenutzerApi,
    createArtikelApi,
    createBelegApi,
    createProduktionApi,
    createFakturaApi,
    createSettingsApi,
    createUiApi,
    createUtilityApi
} from "./api/business/index.js";

// DTO Type Definitions (for JSDoc)
export * from "./api/dtos/index.js";

// re-export all modules from the ui folder as named exports
export * from "./ui/index.js";

/**
 * @typedef {import("./api/fluentApi").FluentApi} FluentApi
 * @typedef {import("./api/fluentAuthManager").FluentAuthManager} FluentAuthManager
 * @typedef {import("./api/fluentApi").FluentApi} IDAS
 * @typedef {import("./api/business/vorgangApi").VorgangApi} VorgangApi
 * @typedef {import("./api/business/kontaktApi").KontaktApi} KontaktApi
 * @typedef {import("./api/business/belegPositionenApi").BelegPositionenApi} BelegPositionenApi
 * @typedef {import("./api/business/materialApi").MaterialApi} MaterialApi
 * @typedef {import("./api/business/serienApi").SerienApi} SerienApi
 * @typedef {import("./api/business/benutzerApi").BenutzerApi} BenutzerApi
 * @typedef {import("./api/business/artikelApi").ArtikelApi} ArtikelApi
 * @typedef {import("./api/business/belegApi").BelegApi} BelegApi
 * @typedef {import("./api/business/produktionApi").ProduktionApi} ProduktionApi
 * @typedef {import("./api/business/fakturaApi").FakturaApi} FakturaApi
 * @typedef {import("./api/business/settingsApi").SettingsApi} SettingsApi
 * @typedef {import("./api/business/uiApi").UiApi} UiApi
 * @typedef {import("./api/business/utilityApi").UtilityApi} UtilityApi
 */

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
 * @typedef {Object} NeherApp3ArtikelstammApi
 * @property {() => Promise<ArtikelstammEintrag[]>} getArtikelStamm
 * @property {() => Promise<Object[]>} getWarenGruppen
 * @property {(guid: string) => Promise<ArtikelstammEintrag | undefined>} getArtikelByGuid
 * @property {(nummer: string) => Promise<ArtikelstammEintrag | undefined>} getArtikelByKatalognummer
 */

/**
 * @typedef {Object} NeherApp3ErfassungApi
 * @property {() => Promise<Variante[]>} getVarianten
 * @property {(variantenNameOderKuerzel: string) => Promise<Variante | undefined>} getVariante
 * @property {() => Promise<Werteliste[]>} getWertelisten
 * @property {(name: string) => Promise<Werteliste | undefined>} getWerteliste
 * @property {() => Promise<Object[]>} getScripts
 * @property {(v: Variante) => void} createUIMachine
 */

/**
 * @typedef {Object} NeherApp3Props
 * @property {FluentApi} api
 * @property {FluentAuthManager} [authManager]
 * @property {FluentApi} idas
 * @property {string} [mainCssPath]
 */

/** 
 * @typedef {Object} NeherApp3MenuItem
 * @property {string} [id] - Unique identifier for the menu item (auto-generated if not provided)
 * @property {boolean} [selected] - Indicates if the menu item is currently selected (managed by the menu system)
 * @property {string} [icon] - URL to an icon
 * @property {string|null} [url] - Relative URL to use for routes
 * @property {string} text - Display text
 * @property {string|null} [parent] - Parent menu item (optional). If not set, the item will be added to the top level menu.
 * @property {boolean} [hidden] - If true, the menu item will not be displayed
 */

/**
 * @typedef {NeherApp3Props & { neherapp3: NeherApp3 }} NeherApp3SetupContext
 */

/**
 * @typedef {Object} NeherApp3Module
 * @property {string} moduleName
 * @property {(context: NeherApp3SetupContext) => (void | Promise<void>)} [setup]
 * @property {(node: HTMLElement, props: NeherApp3SetupContext) => (void | function)} [mount] Must return an optional unmount function
 * @property {string} [embedUrl]
 * @property {string[]} [extraCSS]
 * @property {boolean} [useShadowDom] - If true, the app will be embedded in a shadow DOM. This is required for CSS isolation.
 */

/**
 * @typedef {Object} NeherApp3
 * @property {(menuItem: NeherApp3MenuItem) => void} addMenuItem
 * @property {(appModule: NeherApp3Module | string) => Promise<void>} addApp
 * @property {(message: string, type?: NeherApp3NotifyType, cb?: function) => void} notify - Shows a notification. Type defaults to 0 (info). Callback is optional.
 * @property {NeherApp3ArtikelstammApi} artikelstamm
 * @property {NeherApp3ErfassungApi} erfassung
 */

/**
 * Global NeherApp3 instance
 * @type {NeherApp3}
 * @global
 */
globalThis.neherapp3 = globalThis.neherapp3 || {};

