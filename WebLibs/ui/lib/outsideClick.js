/**
 * Registriert Pointerdown-Listener, die `onOutside` aufrufen, sobald außerhalb
 * eines offenen Filter-Dropdowns geklickt wird — auch außerhalb des Shadow DOM
 * des Moduls (z. B. in die NeherApp3-Host-Shell).
 *
 * Vertrag: Jeder Dropdown-Wrapper (Button + aufgeklapptes Menü) trägt das
 * Attribut `data-filter-dropdown`. Nur Klicks IN so einem Wrapper innerhalb
 * des Containers lassen das Menü offen; alles andere — auch der graue
 * Hintergrund der Filterleiste — schließt es.
 *
 * Zwei Listener, weil das Modul im Shadow DOM des Hosts läuft:
 *
 * 1. Auf der Shadow-Root des Containers: sieht alle Klicks INNERHALB des
 *    Moduls mit echten (nicht retargeteten) Zielen → präziser contains-Test
 *    gegen den Container. Funktioniert unabhängig vom Root-Modus.
 * 2. Auf document: entscheidet nur „kam der Klick von außerhalb des Moduls?"
 *    über den Shadow-HOST im composedPath(). Der Host ist dort immer
 *    sichtbar — die inneren Knoten dagegen nicht, wenn die Root `closed`
 *    ist. Deshalb KEIN contains-Test auf document-Ebene: Innen-Klicks
 *    behandelt Listener 1.
 *
 * Läuft der Container gar nicht im Shadow DOM (main.js-Harness), reicht ein
 * einzelner document-Listener mit contains-Test.
 *
 * @param {() => (HTMLElement | null)} getContainer Element, das als „innen" gilt
 * @param {() => void} onOutside wird bei Pointerdown außerhalb aufgerufen
 * @returns {() => void} Cleanup zum Abmelden (aus onMount zurückgeben)
 */
export function onOutsidePointerDown(getContainer, onOutside) {
    // In onMount ist bind:this bereits gesetzt; die Root ist über die
    // Lebensdauer der Komponente stabil.
    const initial = getContainer();
    const root = initial?.getRootNode?.() ?? document;
    const isShadow = typeof ShadowRoot !== "undefined" && root instanceof ShadowRoot;

    /**
     * Innen-Klicks: Als „innen" zählt NUR ein Dropdown-Wrapper
     * ([data-filter-dropdown] = Button + aufgeklapptes Menü) innerhalb des
     * Containers — nicht der restliche Leisten-Hintergrund. Ein Klick auf die
     * graue Filterleiste selbst schließt das offene Menü also ebenfalls.
     * @param {Event} e
     */
    const insideHandler = (e) => {
        const container = getContainer();
        if (!container) return;
        const target = e.composedPath ? e.composedPath()[0] : e.target;
        const el = target instanceof Element ? target : /** @type {Node} */ (target)?.parentElement;
        const dropdown = el?.closest?.("[data-filter-dropdown]");
        if (!dropdown || !container.contains(dropdown)) onOutside();
    };

    // Klicks in die Browser-UI (DevTools, anderes Fenster) erzeugen KEIN
    // pointerdown auf der Seite — dort schließt der Fokusverlust die Menüs.
    const blurHandler = () => onOutside();
    window.addEventListener("blur", blurHandler);

    if (!isShadow) {
        document.addEventListener("pointerdown", insideHandler, true);
        return () => {
            document.removeEventListener("pointerdown", insideHandler, true);
            window.removeEventListener("blur", blurHandler);
        };
    }

    const host = /** @type {ShadowRoot} */ (root).host;

    /** Außen-Klicks: Modul-Host nicht im Pfad = außerhalb. @param {Event} e */
    const outsideHandler = (e) => {
        if (!e.composedPath) return;
        if (!e.composedPath().includes(host)) onOutside();
    };

    root.addEventListener("pointerdown", insideHandler, true);
    document.addEventListener("pointerdown", outsideHandler, true);
    return () => {
        root.removeEventListener("pointerdown", insideHandler, true);
        document.removeEventListener("pointerdown", outsideHandler, true);
        window.removeEventListener("blur", blurHandler);
    };
}
