<script>
    import { mount, unmount } from 'svelte';
    import PopoverBubble from './PopoverBubble.svelte';

    /**
     * Klick-geöffnetes Overlay in Tooltip-Optik für kleine Inline-Editoren
     * (z. B. Bestellmenge/Lieferant im Bedarfsplan). `children` ist der Anker
     * (Button); `content` das Popover-Innere und erhält eine `close`-Funktion:
     *
     *     <Popover onopen={initEntwurf} onclose={(reason) => reason !== 'escape' && übernehmen()}>
     *         {#snippet content(close)}<input … onkeydown={enter → close()} />{/snippet}
     *         <button>…</button>
     *     </Popover>
     *
     * Klick auf den Anker toggelt. Escape, Klick außerhalb und Fokusverlust
     * schließen ebenfalls; `onclose` bekommt den Grund gemeldet, damit der
     * Aufrufer Übernahme (blur/outside/close) von Abbruch (escape) trennen
     * kann. `onopen` läuft vor dem Öffnen — dort den Bearbeitungs-Entwurf
     * initialisieren.
     *
     * Die Blase wird wie beim Tooltip weit oben gemountet, NICHT inline neben
     * dem Anker: sonst erbt sie Opacity/Transform der Umgebung und
     * `position: fixed` bräche in transformierten Ancestors.
     *
     * Ziel ist dabei die Modulwurzel im Shadow Root (das Element, das das
     * aktive `data-theme` trägt), nicht der ShadowRoot selbst: die Shell
     * bindet das Theme an diese Wurzel, eine Blase *daneben* erbt nur die
     * Variablen von `:host` — also dauerhaft das helle Theme — und bliebe im
     * Dark Mode hell. Die Wurzel ist der äußerste Modul-Container und bringt
     * weder Transform noch Opacity mit, der Grund für den Mount weit oben
     * bleibt also gewahrt.
     */

    /**
     * @type {{
     *   placement?: 'top' | 'bottom',
     *   maxWidth?: string,
     *   class?: string,
     *   open?: boolean,
     *   onopen?: (() => void) | null,
     *   onclose?: ((reason: 'escape' | 'outside' | 'blur' | 'close' | 'anchor') => void) | null,
     *   content: import('svelte').Snippet<[() => void]>,
     *   children: import('svelte').Snippet
     * }}
     */
    let {
        placement = 'bottom',
        maxWidth = 'max-w-xs',
        class: className = 'inline-flex',
        open = $bindable(false),
        onopen = null,
        onclose = null,
        content,
        children
    } = $props();

    /** @type {HTMLSpanElement | null} */
    let anchorEl = $state(null);
    // Merkt beim pointerdown, ob das Popover offen war: in manchen Browsern
    // schließt der Fokusverlust die Blase schon vor dem click — ohne das Flag
    // würde derselbe Anker-Klick sie sofort wieder öffnen.
    let wasOpenAtPointerDown = false;

    /** @param {'escape' | 'outside' | 'blur' | 'close' | 'anchor'} reason */
    function requestClose(reason) {
        if (!open) return;
        open = false;
        onclose?.(reason);
        // Bei Tastatur-/programmatischem Schließen den Fokus zum Anker
        // zurückgeben; bei blur/outside hat der Benutzer bereits woanders hin
        // fokussiert.
        // Fokus-Rückgabe bewusst erst im nächsten Frame: synchrones focus()
        // während eines Enter-keydown lässt Chromes native Enter-Aktivierung
        // einen Click (detail: 0) auf dem frisch fokussierten Anker feuern →
        // Popover öffnet sofort wieder. Im rAF ist die Default-Action des
        // auslösenden keydown längst abgeschlossen. Guard über isConnected,
        // weil der Anker bis dahin (onclose kann neu rendern) verschwunden
        // sein kann.
        if (reason === 'escape' || reason === 'close') {
            requestAnimationFrame(() => {
                if (!anchorEl?.isConnected) return;
                const target = anchorEl.querySelector('button, input, select, a, [tabindex]');
                if (target instanceof HTMLElement) target.focus();
            });
        }
    }

    function onAnchorPointerDown() {
        wasOpenAtPointerDown = open;
    }

    function onAnchorClick() {
        if (wasOpenAtPointerDown) {
            requestClose('anchor');
        } else if (!open) {
            onopen?.();
            open = true;
        } else {
            // click ohne vorangegangenes pointerdown bei bereits offener Blase:
            // passiert bei nativer Tastatur-Aktivierung des Ankers (z. B. löst
            // Enter/Space auf dem fokussierten Button in Chromium einen
            // synthetischen click ohne pointerdown aus). Der Anker toggelt —
            // also schließen, statt die Aktivierung stillschweigend zu
            // verschlucken.
            requestClose('anchor');
        }
        wasOpenAtPointerDown = false;
    }

    // Blase programmatisch weit oben mounten (siehe Doku-Kommentar oben).
    $effect(() => {
        if (!open || !anchorEl) return;
        const root = anchorEl.getRootNode();
        // Im Shadow Root das theme-tragende Element bevorzugen (die Modulwurzel,
        // die der Host mit `data-theme` versorgt); ohne Treffer bleibt der
        // ShadowRoot das Ziel wie bisher. Im Dev-Harness ohne Shadow DOM erbt
        // document.body das `data-theme` vom <html> der Shell.
        const ziel = root instanceof ShadowRoot
            ? (root.querySelector('[data-theme]') ?? root)
            : document.body;
        const instance = mount(PopoverBubble, {
            target: ziel,
            props: {
                anchor: anchorEl,
                placement,
                maxWidth,
                children: content,
                onclose: requestClose
            }
        });
        return () => unmount(instance);
    });
</script>

<span
    bind:this={anchorEl}
    role="presentation"
    class={className}
    onpointerdown={onAnchorPointerDown}
    onclick={onAnchorClick}
>
    {@render children()}
</span>
