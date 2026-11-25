// Lokalisierung der gemeinsamen UI-Bausteine (#653).
//
// Die Bausteine bringen ihren eigenen Katalog mit (../locales/*.json) und
// melden ihn beim ersten Gebrauch unter dem Namensraum `weblibs-ui` bei der
// Shell an (`neherapp3.i18n.register`). Deutsch ist Quellsprache, der
// Schlüssel IST der deutsche Text; fehlt eine Übersetzung, erscheint der
// deutsche Text.
//
// Die Anmeldung erfolgt bewusst erst beim ersten Aufruf: die Rahmen-App
// importiert die Bausteine selbst, bevor `globalThis.neherapp3` steht.
// `register` ist in der Shell idempotent und schichtweise — jedes Modul, das
// die Bausteine mitkompiliert, meldet denselben Katalog erneut an, ohne zu
// stören.
//
// Ohne Shell (eigenständiger Test-Harness) bleibt der deutsche Text stehen,
// Platzhalter werden trotzdem ersetzt.

import en from "../locales/en.json";
import du from "../locales/de-x-du.json";

/** Namensraum des Katalogs der UI-Bausteine. */
export const UI_I18N_NAMESPACE = "weblibs-ui";

/** @type {any} */
let endpoint = null;

/** @returns {any} */
function shellI18n() {
    return /** @type {any} */ (globalThis).neherapp3?.i18n ?? null;
}

/** @returns {any} */
function getEndpoint() {
    if (endpoint) return endpoint;
    const shell = shellI18n();
    if (!shell?.register) return null;
    endpoint = shell.register(UI_I18N_NAMESPACE, { en, "de-x-du": du });
    shell.onLocaleChange?.((/** @type {string} */ code) => {
        locale = code;
    });
    locale = shell.locale ?? "de";
    return endpoint;
}

/**
 * @param {string} text
 * @param {Record<string, unknown>} [params]
 * @returns {string}
 */
function ersetzePlatzhalter(text, params) {
    if (!params) return text;
    return text.replace(/\{(\w+)\}/g, (ganz, name) => (name in params ? String(params[name]) : ganz));
}

/**
 * Übersetzt im Namensraum der UI-Bausteine. Wie `localize` der Shell in zwei
 * Rollen: mit einem String übersetzt die Funktion, mit einem DOM-Knoten ist
 * sie die Svelte-Action (`use:uiLocalize`).
 *
 * @param {any} arg deutscher Quelltext oder DOM-Knoten
 * @param {any} [params] Platzhalter bzw. Action-Optionen
 * @returns {any}
 */
export function uiLocalize(arg, params) {
    const ep = getEndpoint();
    if (ep) return ep.localize(arg, params);
    if (typeof arg === "string") return ersetzePlatzhalter(arg, params);
    return undefined;
}

// Texte, die der AUFRUFER hereinreicht (Titel, Labels, Reiternamen …), sind
// Schlüssel im Katalog des Moduls, nicht in dem der UI-Bausteine. Das Modul
// meldet dafür seine eigene `localize`-Funktion an (`setModuleLocalize`,
// einmal beim Start); ohne Anmeldung gilt `uiLocalize`, dessen Rückfall auf
// den Katalog der Shell gemeinsame Begriffe trotzdem übersetzt.

/** @type {((arg: any, params?: any) => any) | null} */
let moduleFn = null;

/**
 * Meldet die `localize`-Funktion des eigenen Namensraums an (z. B. das
 * `localize` aus `neherapp3.i18n.register("m3", …)`). Sie übersetzt alle
 * Texte, die das Modul an die Bausteine übergibt, und die Meldungen aus
 * `notify.js`.
 * @param {(arg: any, params?: any) => any} fn
 */
export function setModuleLocalize(fn) {
    moduleFn = fn;
}

/**
 * Übersetzt einen vom Modul übergebenen Text in dessen Namensraum — als
 * Funktion und als Svelte-Action (`use:moduleLocalize`).
 * @param {any} arg
 * @param {any} [params]
 * @returns {any}
 */
export function moduleLocalize(arg, params) {
    return (moduleFn ?? uiLocalize)(arg, params);
}

// Reaktiver Spiegel der Host-Sprache: das Projekt, das die Bausteine
// kompiliert, hat ggf. ein eigenes Svelte-Runtime und kann den $state der
// Shell nicht reaktiv lesen. `use:uiLocalize` folgt dem Sprachwechsel von
// selbst; für `$derived` und Aufrufe im Markup gibt es diesen Spiegel.
let locale = $state("de");

/**
 * Aktuelle Sprache, reaktiv.
 * @returns {string}
 */
export function uiLocale() {
    getEndpoint();
    return locale;
}

/**
 * Vergleich zweier ANZEIGETEXTE mit dem Collator der aktiven Sprache.
 * @param {string} a
 * @param {string} b
 * @returns {number}
 */
export function uiCompare(a, b) {
    uiLocale();
    const shell = shellI18n();
    if (shell?.compare) return shell.compare(a, b);
    return a.localeCompare(b, "de");
}
