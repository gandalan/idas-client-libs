/**
 * Layoutstufe des Moduls (m3 #16600, weblibs #653): eine modulweite Svelte-5-Rune, die sagt,
 * ob die Inhaltsbreite gerade „kompakt" ist (< 48rem) — dieselbe Schwelle wie
 * die Tailwind-Container-Variante `@max-3xl/content:`, die im Modul bereits
 * überall für rein optische Anpassungen verwendet wird (PageHeader.svelte,
 * FilterBar.svelte, neher-theme.css).
 *
 * Warum das hier zusätzlich als JS-Zustand existiert, statt alles über CSS zu
 * lösen: an der kompakten Breite ändert sich nicht nur die Optik, sondern die
 * STRUKTUR — z. B. rendert die Filterleiste dann ein `<dialog>` mit Modal
 * statt der inline ausklappbaren Leiste (FilterBar.svelte). Zwei parallel
 * im DOM liegende Kopien der Filterfelder (eine inline, eine im Modal, per
 * CSS ein-/ausgeblendet) hätten doppelten `$state` in den Eingabefeldern und
 * ein kaputtes Outside-Click-Handling zur Folge (siehe `onOutsidePointerDown`
 * in `./outsideClick.js`, das genau EINEN Container kennt). `isCompact()`
 * erlaubt stattdessen ein `{#if}`, das zu jedem Zeitpunkt nur eine Instanz
 * rendert. Rein optische Umschaltungen (Textgröße, Zeilenumbruch, feste
 * Spaltenbreiten …) bleiben bewusst bei den Container-Varianten in Klassen/
 * app.css — dafür braucht es diesen Zustand nicht.
 *
 * 48rem = 768px: der Shadow-Root des Moduls legt die Root-Schriftgröße fest
 * (`:host { font-size: 16px }` in app.css, unabhängig von Zoom/Root-Font der
 * Host-Seite) — deshalb hier als feste Pixelzahl statt einer rem-Rechnung
 * zur Laufzeit.
 *
 * Gemessen wird NICHT der Browser-Viewport, sondern der Mount-Knoten des
 * Moduls (`#shadow-mount`, von der NeherApp3-Shell per `mount(domNode, …)`
 * hereingereicht): das ist dieselbe Breite, an der auch
 * `@container content` in app.css hängt. `#shadow-mount` ist ohne eigene
 * Breite oder Padding das einzige Kind der Shadow-Root und füllt deshalb
 * exakt die Content-Box des Host-Containers (`#container` in
 * NeherApp3/App.svelte, dort `@container/content` + `p-4`) — an genau dieser
 * Content-Box misst auch die Container Query selbst (sie misst den
 * Container, an dem `container-type` gesetzt ist, an SEINER eigenen
 * Content-Box, also bereits ohne dessen `p-4`). Ein ResizeObserver auf
 * `#shadow-mount` liefert damit dieselbe Zahl wie `@container content
 * (width < 48rem)`, ohne dass dieses Modul den Host-Container kennen müsste
 *
 * Jedes Projekt kompiliert die Bausteine selbst und hat damit genau eine
 * Instanz dieses Moduls: der Verbraucher ruft `observeMountNode(domNode)` in
 * seinem `mount()` auf, die Bausteine lesen `isCompact()`.
 */

const COMPACT_THRESHOLD_PX = 768;

// -1 = noch nicht gemessen (kein observeMountNode): dann gilt „breit“.
let width = $state(-1);

/** @type {ResizeObserver | null} */
let observer = null;

/**
 * Registriert den Mount-Knoten des Moduls (`domNode` aus `mount()` in
 * Verbrauchers) für die Breitenmessung. Einmal beim Mounten des Moduls aufrufen;
 * die zurückgegebene Funktion beim Unmount wieder abmelden, sonst bleibt der
 * ResizeObserver über den Modul-Lebenszyklus hinaus aktiv.
 * @param {HTMLElement} node
 * @returns {() => void}
 */
export function observeMountNode(node) {
    observer?.disconnect();
    // Sofortwert, damit `isCompact()` schon vor der ersten (asynchronen)
    // ResizeObserver-Meldung stimmt — sonst rendert der allererste Frame
    // immer in „breit".
    width = node.getBoundingClientRect().width;
    observer = new ResizeObserver(([entry]) => {
        width = entry.contentRect.width;
    });
    observer.observe(node);
    return () => {
        observer?.disconnect();
        observer = null;
    };
}

/**
 * `true` unterhalb 48rem (768px) Inhaltsbreite — siehe Kopfkommentar.
 * @returns {boolean}
 */
export function isCompact() {
    return width >= 0 && width < COMPACT_THRESHOLD_PX;
}
