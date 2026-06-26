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
 * @property {string} [text] - Display text (ignored for separator items)
 * @property {string | null} [parent] - Parent menu item (optional). If not set, the item will be added to the top level menu.
 * @property {boolean} [hidden] - If true, the menu item will not be displayed
 * @property {boolean} [separator] - If true, renders as a non-interactive divider between items (text/icon/url are ignored). Use `parent` to place the separator inside a sub-menu.
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
 * A single message envelope delivered to handlers.
 * @typedef {Object} NeherMessage
 * @property {string} id - Unique message id (`crypto.randomUUID`).
 * @property {string} type - Message kind, e.g. `"artikel.selected"`.
 * @property {string | null} to - Target module name (directed) or `null` (broadcast).
 * @property {string | null} from - Sender module name (stamped by the endpoint) or `null`.
 * @property {any} payload - Arbitrary payload.
 * @property {number} ts - Timestamp (`Date.now`).
 */

/**
 * Handler invoked with the full message envelope.
 * @callback MessageHandler
 * @param {NeherMessage} message
 * @returns {void}
 */

/**
 * Subscription type pattern: exact (`"a.b"`), prefix glob (`"a.*"`), all (`"*"`)
 * or a list of patterns.
 * @typedef {string | string[]} TypePattern
 */

/**
 * Options for `send`/`broadcast`.
 * @typedef {Object} SendOptions
 * @property {string} [from] - Sender module name (bus-level `send`/`broadcast` only; set automatically via an endpoint).
 * @property {boolean} [retain] - Keep this `(to, type)` as a last value; subscribers that register later receive it immediately. Default `false`.
 * @property {boolean} [requireRecipient] - If nobody received it, call `onUndeliverable` instead of silently dropping. Default `false`.
 * @property {boolean} [deliverWhenAvailable] - If nobody is listening, buffer the directed message and deliver it when the target registers. Default `false`.
 * @property {boolean} [echo] - For broadcast: also deliver to the sender itself. Default `false`.
 * @property {number} [ttlMs] - Lifetime for buffered messages. Default `30000`.
 * @property {(message: NeherMessage) => void} [onUndeliverable] - Callback invoked with the envelope when `requireRecipient` and no recipient.
 */

/**
 * Delivery information returned by `send`/`broadcast` — never the result of a handler.
 * @typedef {Object} Delivery
 * @property {boolean} delivered - At least one recipient was reached.
 * @property {number} recipients - Number of distinct modules delivered to.
 * @property {boolean} queued - Buffered for a later recipient.
 */

/**
 * A registered endpoint, returned by `messages.register`. `register` is
 * idempotent; each handle's `dispose` only removes subscriptions made through it.
 * @typedef {Object} Endpoint
 * @property {string} name - The module name of this endpoint.
 * @property {(type: TypePattern, handler: MessageHandler) => (() => void)} on - Subscribe; returns an unsubscribe function.
 * @property {(to: string, type: string, payload?: any, options?: SendOptions) => Delivery} send - Directed message (`from` is stamped automatically).
 * @property {(type: string, payload?: any, options?: SendOptions) => Delivery} broadcast - Broadcast (`from` is stamped automatically).
 * @property {() => void} dispose - Remove all subscriptions created through this handle.
 */

/**
 * In-realm message bus for module-to-module communication, exposed at
 * `neherapp3.messages`. Messaging, not RPC: `send`/`broadcast` return delivery
 * information, never a handler's result.
 * @typedef {Object} NeherApp3Messages
 * @property {(moduleName: string) => Endpoint} register - Register a module as a reachable endpoint.
 * @property {(to: string, type: string, payload?: any, options?: SendOptions) => Delivery} send - Directed message (`from` via `options.from`).
 * @property {(type: string, payload?: any, options?: SendOptions) => Delivery} broadcast - Broadcast to all subscribers (`from` via `options.from`).
 * @property {(moduleName: string) => boolean} isReachable - Does the module have at least one live handler?
 * @property {(moduleName: string) => boolean} isKnown - Is the module registered (loaded via `addApp`)?
 * @property {string[]} reachable - Reactive list of all currently reachable module names.
 */

/**
 * @typedef {Object} NeherApp3
 * @property {(menuItem: NeherApp3MenuItem) => void} addMenuItem - Adds a menu item. If an item with the same `id` already exists it is replaced.
 * @property {(id: string, patch: Partial<NeherApp3MenuItem>) => boolean} updateMenuItem - Updates properties of an existing menu item by `id`. Only keys present in `patch` are changed; the `id` is preserved. Returns `true` if the item existed. Relative icon URLs are resolved against the module's base URL.
 * @property {(id: string) => boolean} removeMenuItem - Removes the menu item with the given `id`. Returns `true` if an item was removed.
 * @property {(appModule: NeherApp3Module | string) => Promise<void>} addApp
 * @property {(message: string, type?: NeherApp3NotifyType, cb?: function) => void} notify - Shows a notification. Type defaults to 0 (info). Callback is optional.
 * @property {NeherApp3ApiCollection} api
 * @property {NeherApp3CacheCollection} cache
 * @property {NeherApp3Messages} messages - In-realm message bus for module-to-module communication.
 * @property {boolean} isEmbedded - Indicates if the app is embedded inside i3
 */

export {};
