<script>
    import ArrowLeft from "@lucide/svelte/icons/arrow-left";
    import X from "@lucide/svelte/icons/x";
    import { uiLocalize as localize } from "./lib/i18n.svelte.js";

    /**
     * Eine Seite im SidePanel (#18053, aus dem IDASUserManager): Kopf, Inhalt,
     * Fuß. `onback`: Unterseite mit Pfeil zurück zur Hauptansicht.
     * `scroll=false`: der Inhalt regelt das Scrollen selbst. Schmal füllt das
     * Blatt den ganzen Bildschirm und scrollt samt Kopf, sonst bleibt für den
     * Inhalt kaum Platz; der Fuß bleibt stehen. `pinned`: auch schmal bleibt
     * der Kopf stehen und nur der Inhalt scrollt. `onclose` (m3): das X
     * ruft diese Funktion statt den Dialog nativ zu schließen.
     *
     * @type {{
     *   busy?: boolean,
     *   scroll?: boolean,
     *   pinned?: boolean,
     *   onback?: () => void,
     *   onclose?: () => void,
     *   header: import("svelte").Snippet,
     *   children: import("svelte").Snippet,
     *   footer: import("svelte").Snippet
     * }}
     */
    let { busy = false, scroll = true, pinned = false, onback, onclose, header, children, footer } = $props();

    const mobile = $derived(pinned ? "" : "max-sm:flex-[1_0_auto] max-sm:overflow-visible");
</script>

<div class="flex items-start gap-3 border-b border-base-300 px-5 py-4 shrink-0">
    {#if onback}
        <button
            type="button"
            class="btn btn-ghost btn-square btn-sm -ml-2"
            aria-label="Zurück"
            use:localize
            data-i18n="aria-label"
            onclick={onback}
            disabled={busy}
        ><ArrowLeft size="20" /></button>
    {/if}
    <div class="flex-1 min-w-0">{@render header()}</div>
    {#if onclose}
        <button
            type="button"
            class="btn btn-ghost btn-square btn-sm -mr-2"
            aria-label="Schließen"
            use:localize
            data-i18n="aria-label"
            disabled={busy}
            onclick={onclose}
        ><X size="20" /></button>
    {:else}
        <form method="dialog">
            <button
                class="btn btn-ghost btn-square btn-sm -mr-2"
                aria-label="Schließen"
                use:localize
                data-i18n="aria-label"
                disabled={busy}
            ><X size="20" /></button>
        </form>
    {/if}
</div>
<div class="flex-1 min-h-0 px-5 {mobile} {scroll ? 'overflow-y-auto pb-4' : 'flex flex-col overflow-hidden'}">
    {@render children()}
</div>
<div class="flex flex-wrap justify-end gap-2 border-t border-base-300 px-5 py-3 max-sm:sticky max-sm:bottom-0 bg-base-100">{@render footer()}</div>
