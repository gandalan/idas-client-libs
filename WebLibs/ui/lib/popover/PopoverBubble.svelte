<script>
    /**
     * Interne Schwebe-Blase für klick-geöffnete Popover — wird von
     * Popover.svelte programmatisch gemountet, nicht direkt verwenden.
     *
     * Positionierung wie TooltipBubble (../tooltip): Shadow-DOM-tauglich über
     * `position: fixed` + getBoundingClientRect, flippt automatisch zwischen
     * oben/unten, Pfeil zeigt auf die Anker-Mitte, ResizeObserver
     * repositioniert bei Größenänderung des Inhalts.
     *
     * Zusätzlich Dismiss-Verhalten für Editoren: Escape, Pointerdown außerhalb
     * und Fokusverlust schließen — der Grund wird an `onclose` gemeldet, damit
     * der Aufrufer Übernahme (blur/outside) von Abbruch (escape) trennen kann.
     */

    /**
     * @type {{
     *   anchor: HTMLElement,
     *   placement?: 'top' | 'bottom',
     *   maxWidth?: string,
     *   children?: import('svelte').Snippet<[() => void]> | null,
     *   onclose?: ((reason: 'escape' | 'outside' | 'blur' | 'close') => void) | null
     * }}
     */
    let {
        anchor,
        placement = 'bottom',
        maxWidth = 'max-w-xs',
        children = null,
        onclose = null
    } = $props();

    /** @type {HTMLDivElement | null} */
    let el = $state(null);
    let pos = $state({ x: 0, y: 0, arrowX: 0, place: /** @type {'top' | 'bottom'} */ ('bottom'), ready: false });

    // Mehrere Dismiss-Quellen können im selben Klick feuern (pointerdown +
    // focusout) — nur der erste Grund zählt.
    let closed = false;
    /** @param {'escape' | 'outside' | 'blur' | 'close'} reason */
    function requestClose(reason) {
        if (closed) return;
        closed = true;
        onclose?.(reason);
    }

    function update() {
        if (!el || !anchor?.isConnected) return;
        const a = anchor.getBoundingClientRect();
        const t = el.getBoundingClientRect();
        const gap = 8;

        let place = placement;
        if (place === 'top' && a.top - t.height - gap < 4) place = 'bottom';
        else if (place === 'bottom' && a.bottom + t.height + gap > window.innerHeight - 4) place = 'top';

        let x = a.left + a.width / 2 - t.width / 2;
        x = Math.max(4, Math.min(x, window.innerWidth - t.width - 4));
        const y = place === 'top' ? a.top - t.height - gap : a.bottom + gap;
        const arrowX = Math.max(10, Math.min(a.left + a.width / 2 - x, t.width - 10));

        pos = { x, y, arrowX, place, ready: true };
    }

    /** @param {PointerEvent} e */
    function onWindowPointerDown(e) {
        // composedPath statt target: window-Listener sehen für Shadow-DOM-
        // Inhalte nur den retargeteten Host. Der Anker zählt nicht als
        // „außerhalb" — sein Klick schließt über den Toggle in Popover.svelte.
        const path = e.composedPath();
        if (el && path.includes(el)) return;
        if (anchor && path.includes(anchor)) return;
        requestClose('outside');
    }

    /** @param {FocusEvent} e */
    function onFocusOut(e) {
        const next = e.relatedTarget;
        if (next instanceof Node && (el?.contains(next) || anchor?.contains(next))) return;
        requestClose('blur');
    }

    /** @param {MouseEvent} e */
    function onMouseDown(e) {
        // Klick auf nicht-interaktive Bereiche der Blase (Label, Padding) darf
        // dem Eingabefeld nicht den Fokus nehmen — sonst schlösse focusout das
        // Popover mitten in der Bedienung.
        const t = e.target;
        if (t instanceof Element && !t.closest('input, select, textarea, button, a, [tabindex]')) {
            e.preventDefault();
        }
    }

    $effect(() => {
        update();
        const ro = new ResizeObserver(update);
        if (el) ro.observe(el);
        // capture-phase, damit auch scrollende Container (overflow-auto) greifen
        window.addEventListener('scroll', update, true);
        window.addEventListener('resize', update);
        window.addEventListener('pointerdown', onWindowPointerDown, true);
        /** @param {KeyboardEvent} e */
        const onKey = (e) => { if (e.key === 'Escape') requestClose('escape'); };
        window.addEventListener('keydown', onKey);
        return () => {
            ro.disconnect();
            window.removeEventListener('scroll', update, true);
            window.removeEventListener('resize', update);
            window.removeEventListener('pointerdown', onWindowPointerDown, true);
            window.removeEventListener('keydown', onKey);
        };
    });
</script>

<!-- "popover-bubble" ist Hook für die Fokus-Ring-Ausnahme in app.css (siehe
     dort): Svelte-<style>-Blöcke dieser Komponente landen im Build in einer
     eigenen m3.css, die der Host nie in den ShadowRoot injiziert — nur
     app.css tut das (extraCSS in app.js). Die Klasse daher nicht entfernen. -->
<div
    bind:this={el}
    role="dialog"
    tabindex="-1"
    class="popover-bubble fixed z-50 font-sans {maxWidth}"
    style="left:{pos.x}px; top:{pos.y}px; visibility:{pos.ready ? 'visible' : 'hidden'}"
    onfocusout={onFocusOut}
    onmousedown={onMouseDown}
>
    <div class="relative rounded-box border border-base-300 bg-base-100 text-base-content shadow-lg">
        <div class="max-h-96 overflow-auto p-2 text-sm">
            {@render children?.(() => requestClose('close'))}
        </div>
        <div
            class="absolute h-2 w-2 rotate-45 border-base-300 bg-base-100
                   {pos.place === 'top' ? 'border-r border-b' : 'border-t border-l'}"
            style="left:{pos.arrowX - 4}px; {pos.place === 'top' ? 'bottom:-4.5px' : 'top:-4.5px'}"
        ></div>
    </div>
</div>
