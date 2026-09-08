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
 * Settings handle of a single namespace — what
 * `neherapp3.settings.register("my-module")` returns.
 * @typedef {Object} NeherApp3SettingsHandle
 * @property {string} namespace - The bound namespace (lower case).
 * @property {(key: string, fallback?: any) => any} get - Value of a setting, or `fallback`. Reactive.
 * @property {(key: string, value: unknown) => void} set - Store a value: applied locally at once, sent to the server coalesced.
 * @property {(key: string) => void} remove - Drop a setting; the user is back to its default.
 * @property {() => Record<string, unknown>} all - All settings of this namespace.
 * @property {() => Promise<void>} flush - Write pending changes now. Call before a reload.
 */

/**
 * User settings, exposed at `neherapp3.settings`.
 *
 * The store is the **database**, not `localStorage`: inside the i3 WebView
 * `localStorage` is ephemeral and would lose every setting on each start. A
 * setting is addressed by namespace and key, both lower case; `shell` belongs
 * to the framework, every module uses its own namespace — the same one it uses
 * for `i18n.register`. Values are arbitrary JSON.
 *
 * Reads are reactive. Writes are applied locally at once and sent to the
 * server after a short coalescing delay, so call `flush()` before a reload.
 * @typedef {Object} NeherApp3Settings
 * @property {string} scope - Namespace of the framework (`"shell"`).
 * @property {boolean} loaded - `true` once the values from the database have arrived.
 * @property {(namespace: string) => NeherApp3SettingsHandle} register - Settings handle bound to a module's namespace.
 * @property {(scope: string, key: string, fallback?: any) => any} get - Value of a setting, or `fallback`. Reactive.
 * @property {(scope: string, key: string, value: unknown) => void} set - Store a value.
 * @property {(scope: string, key: string) => void} remove - Drop a setting.
 * @property {(scope: string) => Record<string, unknown>} all - All settings of one namespace.
 * @property {() => Promise<void>} flush - Write pending changes now. Call before a reload.
 */

/**
 * The profile of *another* user, as returned by `profile.byEmail` and friends.
 *
 * Identity comes from the platform's user table — whoever has signed in here at
 * least once; the remaining fields are filled in only where that user curated
 * them.
 * @typedef {Object} NeherApp3PublicProfile
 * @property {string} userId - The user's `benutzerGuid`.
 * @property {string} userName - Login name.
 * @property {string} email - E-mail address.
 * @property {string | null} displayName - Self-chosen name shown in the interface.
 * @property {string | null} initials - Self-chosen initials, up to 3 characters.
 * @property {string | null} jobTitle - Job title / function.
 * @property {string | null} department - Department.
 * @property {string | null} location - Site / plant.
 * @property {string | null} mobile - Mobile number.
 * @property {string | null} avatar - The avatar as a data URL, or `null` when none is stored.
 * @property {string | null} avatarUpdatedAt - When the avatar was last uploaded.
 */

/**
 * The signed-in user, exposed at `neherapp3.profile`.
 *
 * Two sources in one place: identity comes from the IDAS token (user id, login
 * name, e-mail, roles, rights), the remaining fields from the platform's own
 * profile table — above all the avatar, which IDAS does not carry.
 *
 * Read-only and reactive: the local fields arrive shortly after start and are
 * edited in the framework's settings, not by a module. The same object carries
 * the lookup of *other* users' profiles (`byEmail`, `byEmails`, `byUserId`) —
 * the way to put a name and a face next to a user id in a list.
 * @typedef {Object} NeherApp3Profile
 * @property {string} userId - `benutzerGuid` from the token.
 * @property {string} userName - Login name (`id` claim).
 * @property {string} email - E-mail address from the token.
 * @property {string[]} roles - Roles from the token.
 * @property {string[]} rights - Rights from the token.
 * @property {string} displayName - Best available name: the self-chosen one, otherwise the token's.
 * @property {string} initials - Up to 3 characters: self-chosen, otherwise derived from the name.
 * @property {string | null} avatar - The avatar as a data URL, or `null` when none is stored.
 * @property {string | null} jobTitle - Job title / function.
 * @property {string | null} department - Department.
 * @property {string | null} location - Site / plant.
 * @property {string | null} mobile - Mobile number (IDAS carries only one phone number).
 * @property {boolean} loaded - `true` once the local profile has been fetched.
 * @property {() => Promise<void>} reload - Fetch the local profile again.
 * @property {(email: string) => Promise<NeherApp3PublicProfile | null>} byEmail - The profile of another user by e-mail address; `null` when this platform does not know them. Calls made close together are coalesced into one request and cached for the session.
 * @property {(emails: string[]) => Promise<NeherApp3PublicProfile[]>} byEmails - The profiles of several users; unknown addresses are absent from the result.
 * @property {(userId: string) => Promise<NeherApp3PublicProfile | null>} byUserId - The profile of another user by their `benutzerGuid`.
 * @property {() => void} clearCache - Discard the cached profiles, so the next lookup asks again.
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
 * @property {NeherApp3Settings} settings - Per-user settings, stored in the database (not `localStorage`).
 * @property {NeherApp3Profile} profile - The signed-in user: identity from the IDAS token plus the platform's own profile fields (avatar, job title, …).
 * @property {boolean} isEmbedded - Indicates if the app is embedded inside i3
 */

export {};
