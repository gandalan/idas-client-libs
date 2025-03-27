import { IDASFactory } from "./api/IDAS";
import { RESTClient } from "./api/RESTClient";
import { initIDAS } from "./api/authUtils";
export { IDASFactory, initIDAS, RESTClient };

export { createApi, fluentApi } from "./api/fluentApi";
export { createAuthManager, fluentIdasAuthManager } from "./api/fluentAuthManager";
export { fetchEnvConfig } from "./api/fluentEnvUtils";
export { restClient } from "./api/fluentRestClient";

/**
 * @typedef {Object} NeherApp3Module
 * @property {string} moduleName
 * @property {(app: NeherApp3) => void} setup 
 * @property {(node : HTMLElement, props : *) => function} mount Must return an unmount function
 * @property {string?} embedUrl 
 */

/**
 * @typedef {Object} NeherApp3 
 * @property {(menuItem : NeherApp3MenuItem) => void} addMenuItem
 * @property {(appModule: NeherApp3Module) => void} addApp
 * @property {(message: string, type? : number, cb? : function) => void} notify - Shows a notification. Type defaults to 0 (info). Callback is optional.
 * @property {function} getArtikelStamm
 * @property {function} getWarenGruppen
 * @property {function} getArtikelByGuid
 * @property {function} getWertelisten
 * @property {function} getScripts
 * @property {function} getVarianten
 */

/** 
 * @typedef {Object} NeherApp3MenuItem
 * @property {string} [id] - Unique identifier for the menu item (auto-generated if not provided)
 * @property {boolean} [selected] - Indicates if the menu item is currently selected (managed by the menu system)
 * @property {string} [icon] - URL to an icon
 * @property {string} url - Relative URL to use for routes
 * @property {string} text - Display text
 * @property {string} [parent] - Parent menu item (optional). If not set, the item will be added to the top level menu.
 */

/**
 * Global NeherApp3 instance
 * @type {NeherApp3}
 * @global
 */
globalThis.neherapp3 = globalThis.neherapp3 || {};
