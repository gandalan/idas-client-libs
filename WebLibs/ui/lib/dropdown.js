/**
 * Svelte-Action für absolut positionierte Dropdown-Menüs (Filterleisten-Stil):
 * klappt das Menü nach OBEN auf und begrenzt seine Höhe, wenn unterhalb des
 * Auslösers nicht genug Platz ist.
 *
 * Hintergrund: Die Menüs sind `absolute` im nächsten Scroll-Container
 * (DaisyUI-Modal-Box mit overflow-y, Tabs-Inhalt). Ragen sie über dessen
 * Unterkante hinaus, werden sie abgeschnitten bzw. scrollen den Container auf,
 * statt ihn zu überlagern. `position: fixed` (wie im Autocomplete) ist in der
 * Modal-Box keine Option — sie trägt translate/scale und wird damit selbst zum
 * Containing Block. Innerhalb desselben Scrollers ist Platz nach oben dagegen
 * immer erreichbar.
 *
 * Anwendung: `use:autoDropDirection` auf dem Menü-Element (das `absolute
 * top-full`-Kind eines `relative`-Wrappers). Läuft beim Aufklappen (Mount des
 * bedingten Blocks); als Höhen-Obergrenze gilt die max-height aus den Klassen
 * (z. B. max-h-72/96).
 *
 * @param {HTMLElement} menu
 */
export function autoDropDirection(menu) {
    const anker = menu.parentElement?.getBoundingClientRect();
    if (!anker) return;

    // Grenze = nächster Scroll-Container (Modal-Box, Tabs-Inhalt, …),
    // sonst der Viewport.
    let grenzeOben = 0;
    let grenzeUnten = window.innerHeight;
    for (let el = menu.parentElement; el; el = el.parentElement) {
        // Ein <dialog> liegt im Top-Layer: äußere Scroll-Container (z. B. der
        // Tabs-Inhalt, der das dialog-Element im DOM umschließt) clippen ihn
        // nicht — ab hier zählt nur noch der Viewport.
        if (el.tagName === "DIALOG") break;
        const overflowY = getComputedStyle(el).overflowY;
        if (overflowY === "auto" || overflowY === "scroll") {
            const r = el.getBoundingClientRect();
            grenzeOben = r.top;
            grenzeUnten = r.bottom;
            break;
        }
    }

    const cap = Number.parseFloat(getComputedStyle(menu).maxHeight) || 288;
    const platzUnten = grenzeUnten - anker.bottom;
    const platzOben = anker.top - grenzeOben;
    const nachOben = platzUnten < Math.min(cap, 240) && platzOben > platzUnten;
    const hoehe = Math.max(120, Math.min(cap, (nachOben ? platzOben : platzUnten) - 12));

    menu.style.maxHeight = `${hoehe}px`;
    if (nachOben) {
        menu.style.top = "auto";
        menu.style.bottom = "100%";
        menu.style.marginTop = "0";
        menu.style.marginBottom = "0.25rem";
    }
}

/**
 * Svelte-Action: hält den per Pfeiltaste markierten Eintrag einer
 * Vorschlagsliste im sichtbaren Bereich. Ohne sie wanderte die Markierung
 * unter die Unterkante der (max-h-begrenzten, scrollenden) Liste, und man sah
 * nicht mehr, was Enter übernimmt.
 *
 * Anwendung: `use:keepHighlightVisible={{ index: highlight, perTaste }}` auf
 * dem scrollenden Listen-Element; der markierte Eintrag trägt
 * `data-markiert`. Gescrollt wird nur bei Markierung per Pfeiltaste
 * (`perTaste`) und nur die Liste selbst (kein `scrollIntoView`, das auch
 * Drawer und Seite mitziehen würde). Markierung per Maus scrollt nicht —
 * sonst rückte die Liste unter dem Zeiger weiter und liefe von selbst durch.
 * Die Listen markieren per Maus über `mousemove`, nicht `mouseenter`: rückt
 * ein Eintrag beim Pfeiltasten-Scrollen unter einen ruhenden Zeiger, meldet
 * Chrome `mouseenter`, und die Markierung spränge dorthin.
 *
 * @param {HTMLElement} liste
 * @param {{ index: number, perTaste: boolean }} _param
 */
export function keepHighlightVisible(liste, _param) {
    /** @param {{ index: number, perTaste: boolean }} param */
    function nachziehen(param) {
        if (!param?.perTaste) return;
        // Erst nach dem Flush: das data-Attribut des neuen Eintrags steht im
        // selben Durchlauf wie dieser Aufruf.
        queueMicrotask(() => {
            const eintrag = liste.querySelector("[data-markiert]");
            if (!eintrag) return;
            const l = liste.getBoundingClientRect();
            const e = eintrag.getBoundingClientRect();
            if (e.top < l.top) liste.scrollTop -= l.top - e.top;
            else if (e.bottom > l.bottom) liste.scrollTop += e.bottom - l.bottom;
        });
    }
    return { update: nachziehen };
}
