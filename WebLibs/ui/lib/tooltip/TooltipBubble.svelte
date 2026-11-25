<script>
    /**
     * Interne Schwebe-Blase für den generischen Tooltip (Ticket 15879) — wird von
     * Tooltip.svelte und der tooltip-Action gerendert, nicht direkt verwenden.
     *
     * Positionierung Shadow-DOM-tauglich: kein Portal an document.body, sondern
     * `position: fixed` + getBoundingClientRect relativ zum Viewport. Flippt
     * automatisch zwischen oben/unten, wenn am Rand kein Platz ist. Der
     * Sprechblasen-Pfeil zeigt auf die Anker-Mitte. Ein ResizeObserver
     * repositioniert bei nachladendem Inhalt (z. B. Lagerumschlag).
     */

    /**
     * @type {{
     *   anchor: HTMLElement,
     *   text?: string,
     *   placement?: 'top' | 'bottom',
     *   maxWidth?: string,
     *   children?: import('svelte').Snippet | null,
     *   onenter?: (() => void) | null,
     *   onleave?: (() => void) | null,
     *   onclose?: (() => void) | null
     * }}
     */
    let {
        anchor,
        text = '',
        placement = 'top',
        maxWidth = 'max-w-xs',
        children = null,
        onenter = null,
        onleave = null,
        onclose = null
    } = $props();

    /** @type {HTMLDivElement | null} */
    let el = $state(null);
    // place wird bei jedem update() aus der placement-Prop neu berechnet;
    // bis dahin ist die Blase unsichtbar (ready: false).
    let pos = $state({ x: 0, y: 0, arrowX: 0, place: /** @type {'top' | 'bottom'} */ ('top'), ready: false });

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

    $effect(() => {
        update();
        const ro = new ResizeObserver(update);
        if (el) ro.observe(el);
        // capture-phase, damit auch scrollende Container (overflow-auto) greifen
        window.addEventListener('scroll', update, true);
        window.addEventListener('resize', update);
        /** @param {KeyboardEvent} e */
        const onKey = (e) => { if (e.key === 'Escape') onclose?.(); };
        window.addEventListener('keydown', onKey);
        return () => {
            ro.disconnect();
            window.removeEventListener('scroll', update, true);
            window.removeEventListener('resize', update);
            window.removeEventListener('keydown', onKey);
        };
    });
</script>

<div
    bind:this={el}
    role="tooltip"
    class="fixed z-50 font-sans {maxWidth}"
    style="left:{pos.x}px; top:{pos.y}px; visibility:{pos.ready ? 'visible' : 'hidden'}"
    onpointerenter={() => onenter?.()}
    onpointerleave={() => onleave?.()}
>
    <!-- Innere Kappung auf die Viewportbreite minus Randabstand (#16600):
         `maxWidth` (z. B. max-w-sm = 384 px beim Lagerumschlag) ist auf einem
         390-px-Handy breiter als der Platz zwischen den 4-px-Rändern, die
         update() einhält — die Blase ragte sonst rechts aus dem Bild. Bewusst
         vw: die Blase ist position: fixed, maßgeblich ist der Viewport, nicht
         der Container `content`. -->
    <div class="relative max-w-[calc(100vw-0.5rem)] rounded-box border border-base-300 bg-base-100 text-base-content shadow-lg">
        <div class="max-h-96 overflow-auto p-2 text-sm">
            {#if children}{@render children()}{:else}{text}{/if}
        </div>
        <div
            class="absolute h-2 w-2 rotate-45 border-base-300 bg-base-100
                   {pos.place === 'top' ? 'border-r border-b' : 'border-t border-l'}"
            style="left:{pos.arrowX - 4}px; {pos.place === 'top' ? 'bottom:-4.5px' : 'top:-4.5px'}"
        ></div>
    </div>
</div>
