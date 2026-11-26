// Benachrichtigungen (Toasts) über die Rahmen-App (m3 #17890, weblibs #653).
//
// Module bauen keine eigenen Snackbars und ruft kein `alert()` auf: Ergebnis- und
// Fehlermeldungen laufen über `neherapp3.notify` und erscheinen damit als
// Standard-Toast der Shell (unten links), genau wie in allen anderen Modulen.
// Verhalten laut Host (docs/MESSAGING.md): Info und Erfolg verschwinden nach
// fünf Sekunden, Warnung und Fehler bleiben bis zum Klick stehen.
//
// Die Shell übersetzt den Text NICHT. Aufrufer übergeben den deutschen
// Quelltext; übersetzt wird hier über `localize` — mit Platzhaltern über
// `params`. Bereits fertige Texte (z. B. die Meldung eines Fehlers aus dem
// Backend) laufen ebenfalls durch `localize`: ist der Text kein Schlüssel,
// kommt er unverändert zurück.

// Übersetzt wird im Namensraum des AUFRUFERS (`moduleLocalize`, siehe
// `setModuleLocalize` in i18n.svelte.js).

import { moduleLocalize as localize } from "./i18n.svelte.js";

/** @returns {any} */
function getNeherApp3() {
    return /** @type {any} */ (globalThis).neherapp3 ?? null;
}

/** Typen von `neherapp3.notify` (Host: notify.svelte.js). */
const INFO = 0;
const WARNUNG = 1;
const FEHLER = 2;
const ERFOLG = 3;

/**
 * @param {string} text deutscher Quelltext
 * @param {number} typ
 * @param {Record<string, unknown>} [params]
 */
function zeige(text, typ, params) {
    const meldung = localize(text, params);
    const host = getNeherApp3();
    if (typeof host?.notify === "function") {
        host.notify(meldung, /** @type {any} */ (typ));
        return;
    }
    // Ohne Shell (eigenständiger Dev-Harness) wenigstens sichtbar in der Konsole.
    (typ === FEHLER || typ === WARNUNG ? console.warn : console.info)(meldung);
}

/**
 * Hinweis, verschwindet nach fünf Sekunden.
 * @param {string} text
 * @param {Record<string, unknown>} [params]
 */
export function notifyInfo(text, params) {
    zeige(text, INFO, params);
}

/**
 * Erfolgsmeldung, verschwindet nach fünf Sekunden.
 * @param {string} text
 * @param {Record<string, unknown>} [params]
 */
export function notifySuccess(text, params) {
    zeige(text, ERFOLG, params);
}

/**
 * Warnung, bleibt bis zum Klick stehen.
 * @param {string} text
 * @param {Record<string, unknown>} [params]
 */
export function notifyWarning(text, params) {
    zeige(text, WARNUNG, params);
}

/**
 * Fehlermeldung, bleibt bis zum Klick stehen. Mit `detail` (z. B. die
 * Meldung des Fehlers) wird sie angehängt — der Toast zeigt reinen Text in
 * einer Zeile, Umbrüche gingen verloren.
 * @param {string} text
 * @param {{ params?: Record<string, unknown>, detail?: unknown }} [optionen]
 */
export function notifyError(text, { params, detail } = {}) {
    const zusatz = fehlerText(detail);
    zeige(zusatz ? `${localize(text, params)} ${zusatz}` : text, FEHLER, zusatz ? undefined : params);
}

/**
 * Lesbarer Text zu einem gefangenen Fehler, oder "" ohne Fehler.
 * @param {unknown} err
 * @returns {string}
 */
function fehlerText(err) {
    if (err == null) return "";
    if (err instanceof Error) return err.message;
    if (typeof err === "object" && "message" in err) return String(/** @type {any} */ (err).message);
    return String(err);
}
