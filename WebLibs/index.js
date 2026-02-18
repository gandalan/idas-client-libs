/**
 * @module @gandalan/weblibs
 * @fileoverview Gandalan WebLibs - JavaScript/TypeScript client libraries for IDAS integration
 * @description
 * WebLibs provides a comprehensive set of tools for building web applications
 * that integrate with the Gandalan IDAS (Integriertes Daten- und Auftrags-System) platform.
 * 
 * ## Installation
 * 
 * ```bash
 * npm install @gandalan/weblibs
 * ```
 * 
 * ## Features
 * 
 * - **Fluent API Client**: Modern, chainable API for HTTP requests
 * - **Authentication Manager**: JWT token handling and refresh
 * - **Legacy IDAS Client**: Backwards-compatible IDAS integration
 * - **UI Components**: Svelte components for common UI patterns
 * 
 * ## Quick Start
 * 
 * ```javascript
 * import { createApi, createAuthManager, fetchEnvConfig } from "@gandalan/weblibs";
 * 
 * // Initialize with environment configuration
 * const env = await fetchEnvConfig("https://hub.gandalan.de", "my-app-token");
 * 
 * // Create authentication manager
 * const auth = createAuthManager()
 *   .useAppToken("my-app-token")
 *   .useBaseUrl(env.apiBaseUrl);
 * 
 * // Create API client
 * const api = createApi()
 *   .useBaseUrl(env.apiBaseUrl)
 *   .useAuthManager(auth);
 * 
 * // Make authenticated requests
 * const data = await api.get("/api/data");
 * ```
 * 
 * @author Philipp Reif
 * @version 1.5.13
 * @license ISC
 * @see {@link https://github.com/gandalan/idas-client-libs|GitHub Repository}
 */

import { IDASFactory } from "./api/IDAS";
import { RESTClient } from "./api/RESTClient";
import { initIDAS } from "./api/authUtils";

/**
 * Factory function for creating IDAS client instances (legacy)
 * @type {typeof import("./api/IDAS").IDASFactory}
 * @export
 */
export { IDASFactory };

/**
 * Initialize IDAS client with settings (legacy)
 * @type {typeof import("./api/authUtils").initIDAS}
 * @export
 */
export { initIDAS };

/**
 * REST client class for HTTP requests (legacy)
 * @type {typeof import("./api/RESTClient").RESTClient}
 * @export
 */
export { RESTClient };

/**
 * Create a fluent API client builder
 * @type {typeof import("./api/fluentApi").createApi}
 * @export
 */
export { createApi } from "./api/fluentApi";

/**
 * Pre-configured fluent API client
 * @type {typeof import("./api/fluentApi").fluentApi}
 * @export
 */
export { fluentApi } from "./api/fluentApi";

/**
 * Create a fluent authentication manager
 * @type {typeof import("./api/fluentAuthManager").createAuthManager}
 * @export
 */
export { createAuthManager } from "./api/fluentAuthManager";

/**
 * Pre-configured fluent authentication manager
 * @type {typeof import("./api/fluentAuthManager").fluentIdasAuthManager}
 * @export
 */
export { fluentIdasAuthManager } from "./api/fluentAuthManager";

/**
 * Fetch environment configuration from hub
 * @type {typeof import("./api/fluentEnvUtils").fetchEnvConfig}
 * @export
 */
export { fetchEnvConfig } from "./api/fluentEnvUtils";

/**
 * Create a fluent REST client
 * @type {typeof import("./api/fluentRestClient").restClient}
 * @export
 */
export { restClient } from "./api/fluentRestClient";

// re-export all modules from the ui folder as named exports
export * from "./ui/index.js";

/**
 * @typedef {import("./api/fluentApi").FluentApi} FluentApi
 * @typedef {import("./api/fluentAuthManager").FluentAuthManager} FluentAuthManager
 * @typedef {import("./api/fluentApi").FluentApi} IDAS
 */

/**
 * @typedef {Object} NeherApp3Module
 * @property {string} moduleName
 * @property {(app: NeherApp3) => void} setup 
 * @property {(node : HTMLElement, props : NeherApp3Props) => function} mount Must return an unmount function
 * @property {string?} embedUrl
 * @property {string[]} extraCSS
 * @property {boolean} useShadowDom - If true, the app will be embedded in a shadow DOM. This is required for CSS isolation. 
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
 * @property {string|null} [url] - Relative URL to use for routes
 * @property {string} text - Display text
 * @property {string|null} [parent] - Parent menu item (optional). If not set, the item will be added to the top level menu.
 * @property {boolean} [hidden] - If true, the menu item will not be displayed
 */

/**
 * Global NeherApp3 instance
 * @type {NeherApp3}
 * @global
 */
globalThis.neherapp3 = globalThis.neherapp3 || {};

/**
 * @typedef {Object} NeherApp3Props
 * @property {import("./api/fluentApi").FluentApi} api
 * @property {import("./api/fluentAuthManager").FluentAuthManager} authManager
 * @property {import("./api/fluentApi").FluentApi} idas
 */
