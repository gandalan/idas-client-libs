<script>
    import { mount, unmount } from 'svelte';
    import TooltipBubble from './TooltipBubble.svelte';
    import { bubbleTarget } from './tooltip.js';

    /**
     * Generischer Tooltip (Ticket 15879) für die direkte Verwendung als
     * Komponente. `children` ist der Anker (Link, Button, andere interaktive
     * Komponente); der Inhalt kommt als `text`-Prop oder — für Rich-Content —
     * als `tip`-Snippet:
     *
     *     <Tooltip text="Hilfetext"><button>…</button></Tooltip>
     *
     *     <Tooltip maxWidth="max-w-sm">
     *         {#snippet tip()}<LagerUmschlag … />{/snippet}
     *         <button>…</button>
     *     </Tooltip>
     *
     * Öffnet beim Hover/Fokus mit kurzer Verzögerung (Hover-Intent) und bleibt
     * offen, solange der Zeiger über Anker ODER Blase ist — so bleiben Links im
     * Tooltip klickbar. Klick/Tap auf den Anker schaltet sofort um — nötig für
     * Touch-Geräte, wo Hover fehlt und z. B. iOS Buttons beim Tippen nicht
     * fokussiert. Escape schließt. Für einfache Text-Tooltips ohne
     * Wrapper-Element gibt es die Action `use:tooltip` (./tooltip.js).
     *
     * Die Blase wird wie bei der Action in den Root des Ankers gemountet
     * (ShadowRoot des Moduls bzw. document.body im Dev-Harness), NICHT inline
     * neben dem Anker: sonst erbt sie Opacity/Transform der Umgebung — z. B.
     * opacity-60 inaktiver Bestandszeilen — und wirkt halb transparent.
     */

    /**
     * @type {{
     *   text?: string,
     *   tip?: import('svelte').Snippet | null,
     *   placement?: 'top' | 'bottom',
     *   maxWidth?: string,
     *   openDelay?: number,
     *   closeDelay?: number,
     *   children: import('svelte').Snippet
     * }}
     */
    let {
        text = '',
        tip = null,
        placement = 'top',
        maxWidth = 'max-w-xs',
        openDelay = 200,
        closeDelay = 250,
        children
    } = $props();

    /** @type {HTMLSpanElement | null} */
    let anchorEl = $state(null);
    let open = $state(false);
    let openTimer = 0;
    let closeTimer = 0;

    function scheduleOpen() {
        clearTimeout(closeTimer);
        clearTimeout(openTimer);
        openTimer = setTimeout(() => (open = true), openDelay);
    }

    function cancelClose() {
        clearTimeout(closeTimer);
    }

    function scheduleClose() {
        clearTimeout(openTimer);
        clearTimeout(closeTimer);
        closeTimer = setTimeout(() => (open = false), closeDelay);
    }

    function toggleNow() {
        clearTimeout(openTimer);
        clearTimeout(closeTimer);
        open = !open;
    }

    $effect(() => () => {
        clearTimeout(openTimer);
        clearTimeout(closeTimer);
    });

    // Blase programmatisch in den Root mounten (siehe Doku-Kommentar oben).
    $effect(() => {
        if (!open || !anchorEl) return;
        const instance = mount(TooltipBubble, {
            target: bubbleTarget(anchorEl),
            props: {
                anchor: anchorEl,
                text,
                placement,
                maxWidth,
                children: tip,
                onenter: cancelClose,
                onleave: scheduleClose,
                onclose: () => (open = false)
            }
        });
        return () => unmount(instance);
    });
</script>

<span
    bind:this={anchorEl}
    role="presentation"
    class="inline-flex"
    onmouseenter={scheduleOpen}
    onmouseleave={scheduleClose}
    onfocusin={scheduleOpen}
    onfocusout={scheduleClose}
    onclick={toggleNow}
>
    {@render children()}
</span>
