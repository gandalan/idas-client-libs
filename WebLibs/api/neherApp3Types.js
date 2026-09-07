/**
 * NeherApp3 root type definitions — the master reference for the shell's host
 * API. Maintained by hand; `scripts/generate-dts.mjs` reads these typedefs and
 * emits them into `index.d.ts`.
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
 * @property {boolean} [iconAdaptive] - If true, the icon adapts to the active theme (e.g. inverted in dark mode via the host's `icon-adaptive` styling).
 * @property {string | null} [url] - Relative URL to use for routes
 * @property {string} [text] - Display text (ignored for separator items)
 * @property {string | null} [parent] - Parent menu item (optional). If not set, the item will be added to the top level menu.
 * @property {boolean} [hidden] - If true, the menu item will not be displayed
 * @property {boolean} [separator] - If true, renders as a non-interactive divider between items (text/icon/url are ignored). Use `parent` to place the separator inside a sub-menu.
 * @property {string} [i18nNamespace] - Catalog in which `text` is translated. Set automatically to the registering module's name; only pass it explicitly for items added outside `setup`. See `NeherApp3I18n`.
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
 *
 * Topics the shell itself broadcasts: `i18n.localeChanged` with payload
 * `{ locale: string }` (sent with `retain: true`, so late subscribers receive
 * the current language as well).
 * @typedef {Object} NeherApp3Messages
 * @property {(moduleName: string) => Endpoint} register - Register a module as a reachable endpoint.
 * @property {(to: string, type: string, payload?: any, options?: SendOptions) => Delivery} send - Directed message (`from` via `options.from`).
 * @property {(type: string, payload?: any, options?: SendOptions) => Delivery} broadcast - Broadcast to all subscribers (`from` via `options.from`).
 * @property {(moduleName: string) => boolean} isReachable - Does the module have at least one live handler?
 * @property {(moduleName: string) => boolean} isKnown - Is the module registered (loaded via `addApp`)?
 * @property {string[]} reachable - Reactive list of all currently reachable module names.
 */

/**
 * A translation table: key (the German source text) -> translation.
 * @typedef {Record<string, string>} TranslationTable
 */

/**
 * Translation tables by BCP-47 language code, e.g. `{ en: { "Bestand": "Stock" } }`.
 * @typedef {Record<string, TranslationTable>} TranslationCatalogs
 */

/**
 * Values for `{placeholder}` markers inside a translated text.
 * @typedef {Record<string, string | number>} LocalizeParams
 */

/**
 * A language offered by the shell.
 * @typedef {Object} NeherApp3LocaleInfo
 * @property {string} code - BCP-47 code, e.g. `de`, `de-x-du`, `en`.
 * @property {string} label - Display name in its own language.
 */

/**
 * Options for the `use:localize` action.
 *
 * Without options the action translates the element's own text nodes (child
 * elements are left untouched) and every attribute listed in the element's
 * `data-i18n` attribute, using each attribute's current value as the key.
 * These fields cover everything that cannot be written statically in markup.
 * @typedef {Object} LocalizeActionOptions
 * @property {string} [text] - Key for the whole text content (replaces it).
 * @property {string} [html] - Like `text`, but the translation contains markup.
 * @property {LocalizeParams} [params] - Values for `{placeholder}` markers in text, html and attributes.
 * @property {Record<string, string>} [attrs] - Attribute name -> key, for dynamic attribute values.
 * @property {string} [ns] - Namespace to look in first (defaults to the endpoint's namespace, otherwise `shell`).
 */

/**
 * Return value of the `use:localize` action (a Svelte action handle).
 * @typedef {Object} LocalizeActionHandle
 * @property {(options?: LocalizeActionOptions) => void} update - Re-translate with new options (called by Svelte when the parameter changes).
 * @property {() => void} destroy - Detach from language/catalog changes.
 */

/**
 * Dual-purpose translation entry point: pass a **key** to translate a string,
 * pass a **DOM node** to use it as a Svelte action (`use:localize`).
 *
 * ```js
 * localize("Speichern");                       // -> "Save"
 * localize("{n} Treffer", { n: 3 });           // placeholders
 * ```
 * ```svelte
 * <h2 use:localize>Persönliche Daten</h2>
 * <button title="Kopieren" use:localize data-i18n="title">…</button>
 * ```
 *
 * @typedef {{
 *     (key: string, params?: LocalizeParams, namespace?: string): string;
 *     (node: Element, options?: LocalizeActionOptions): LocalizeActionHandle;
 * }} Localize
 */

/**
 * A registered translation namespace, returned by `i18n.register`. `register`
 * is idempotent; each handle's `dispose` only removes the tables added through
 * it. Lookups fall back to the shell catalog, so shared terms such as
 * "Speichern" need not be translated again per module.
 * @typedef {Object} NeherApp3I18nEndpoint
 * @property {string} namespace - The namespace of this handle (usually the module name).
 * @property {Localize} localize - Translate in this namespace: as a function for script code, as a `use:` action for markup.
 * @property {(translations: TranslationCatalogs) => void} add - Add further tables later (e.g. lazily loaded language files).
 * @property {(key: string) => boolean} has - Is there a real translation (not just the key)?
 * @property {() => void} dispose - Remove exactly the tables registered through this handle.
 */

/**
 * Localization, exposed at `neherapp3.i18n`.
 *
 * German is the source language and **the key is the German text**
 * (`localize("Speichern")`); a missing translation falls back to the key, so an
 * untranslated UI is never broken, just German. There is therefore no `de`
 * catalog. The shell carries only its own texts (namespace `shell`); every
 * module registers its own catalog under its module name.
 * @typedef {Object} NeherApp3I18n
 * @property {(namespace: string, translations?: TranslationCatalogs) => NeherApp3I18nEndpoint} register - Register a namespace's translation tables.
 * @property {Localize} localize - Translate a key, or translate an element via `use:localize`.
 * @property {(key: string, namespace?: string) => boolean} has - Is there a real translation for the key?
 * @property {(a: string, b: string) => number} compare - Compare two **display texts** with the collator of the active language.
 * @property {<T>(items: readonly T[], selector?: (item: T) => string) => T[]} sort - Sorted copy, ordered by the **translated** text (translate first, then sort).
 * @property {(code: string) => void} setLocale - Switch the language and persist the choice.
 * @property {(listener: (locale: string) => void) => (() => void)} onLocaleChange - Listen for language changes (for consumers without Svelte reactivity); returns an unsubscribe function.
 * @property {string} sourceLocale - The source language — the keys themselves are texts in this language (`"de"`).
 * @property {string} locale - Active language (reactive).
 * @property {NeherApp3LocaleInfo[]} locales - Languages offered by the shell.
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
 * @property {NeherApp3I18n} i18n - Localization: register a module's translation catalog, translate, switch language, sort language-aware.
 * @property {Localize} localize - Shorthand for `i18n.localize` (namespace `shell`): a function for strings, a `use:` action for elements.
 * @property {boolean} isEmbedded - Indicates if the app is embedded inside i3
 */

export {};
