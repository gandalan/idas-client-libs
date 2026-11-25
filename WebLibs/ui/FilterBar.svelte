<script>
    import Funnel from '@lucide/svelte/icons/funnel';
    import FunnelX from '@lucide/svelte/icons/funnel-x';
    import { uiLocalize as localize } from "./lib/i18n.svelte.js";
    import { isCompact } from "./lib/layoutLevel.svelte.js";

    /**
     * Rahmen aller Filterleisten (Vorgabe 22.09.2026, Modal-Umbau #16600
     * am 24.09.2026): links eine schmale Icon-Spalte, rechts die Filterfelder
     * als `children` — gilt für mittel/breit (≥ 48rem).
     *
     * - Oben das **Filter-Icon** auf Höhe der Feld-Beschriftungen; ein Klick
     *   klappt die Leiste ein und aus. Eingeklappt bleibt nur die Icon-Spalte;
     *   sind dann Filter gesetzt, trägt das Icon einen roten Punkt — sonst
     *   sähe man nicht, warum die Liste kürzer ist.
     * - Darunter **Zurücksetzen** als Filter-mit-X, nur aktiv, wenn Filter
     *   gesetzt sind. Der frühere „Zurücksetzen"-Knopf am rechten Rand entfällt.
     *
     * Kompakt (< 48rem, `isCompact()` aus `./lib/layoutLevel.svelte.js`) ersetzt
     * die ganze Leiste durch einen einzelnen Icon-Knopf (roter Punkt bei
     * `active`, wie oben) plus ein daisyUI-Modal mit den Feldern (`children`,
     * untereinander) und „Zurücksetzen"/„Schließen" — Filter wirken ohnehin
     * sofort, ein Übernehmen-Knopf ist nicht nötig. Ersetzt den früheren
     * internen `kompaktOffen`-Umschaltmechanismus samt
     * `@max-3xl/content:`-Sichtbarkeitsklassen, die hier rein optisch nicht
     * mehr ausreichten (Strukturwechsel, siehe `./lib/layoutLevel.svelte.js`).
     *
     * `element` gibt den Knoten heraus, an dem die Leisten (genauer: die
     * `FarbeOberflaecheFilter`-Dropdowns darin) ihr Outside-Click-Handling
     * aufhängen (`onOutsidePointerDown`, `./lib/outsideClick.js`). Kompakt
     * zeigt `element` auf die Modal-Box, NICHT auf einen Leisten-Wurzelknoten
     * (den gibt es dort nicht): die Dropdown-Panels liegen dann innerhalb der
     * Modal-Box, und `container.contains(dropdown)` funktioniert unabhängig
     * vom Top-Layer der `<dialog>` — die Prüfung arbeitet auf dem DOM-Baum,
     * nicht auf der Render-/Stacking-Reihenfolge. Svelte setzt `element` beim
     * Wechsel zwischen den Zweigen automatisch neu (`bind:this` an genau
     * einem Knoten je Zweig).
     *
     * @type {{
     *   active?: boolean,
     *   onReset?: (() => void) | null,
     *   open?: boolean,
     *   element?: HTMLElement | null,
     *   children?: import('svelte').Snippet
     * }}
     */
    let {
        active = false,
        onReset = null,
        open = $bindable(true),
        element = $bindable(null),
        children
    } = $props();

    let modalOffen = $state(false);

    /** @type {HTMLDialogElement | null} */
    let dialog = $state(null);

    $effect(() => {
        if (!dialog) return;
        if (modalOffen && !dialog.open) dialog.showModal();
        else if (!modalOffen && dialog.open) dialog.close();
    });

    function toggle() {
        open = !open;
    }
</script>

{#if isCompact()}
    <button
        type="button"
        class="btn btn-sm btn-square bg-base-200 relative"
        title="Filter"
        aria-label="Filter"
        use:localize
        data-i18n="title aria-label"
        onclick={() => (modalOffen = true)}
    >
        <Funnel size="16" />
        {#if active}
            <span class="absolute -top-0.5 -right-0.5 h-2 w-2 rounded-full bg-error" aria-hidden="true"></span>
        {/if}
    </button>

    <dialog bind:this={dialog} class="modal font-sans" onclose={() => (modalOffen = false)}>
        <div bind:this={element} class="modal-box">
            <h3 class="text-lg font-bold mb-4" use:localize>Filter</h3>
            <div class="flex flex-col items-stretch gap-2">
                {@render children?.()}
            </div>
            <div class="modal-action">
                <button
                    type="button"
                    class="btn btn-ghost"
                    disabled={!active}
                    onclick={() => onReset?.()}
                    use:localize
                >
                    Zurücksetzen
                </button>
                <button type="button" class="btn btn-primary" onclick={() => (modalOffen = false)} use:localize>
                    Schließen
                </button>
            </div>
        </div>
        <form method="dialog" class="modal-backdrop">
            <button>close</button>
        </form>
    </dialog>
{:else}
    <div bind:this={element} class="flex items-start gap-3 p-3 rounded-lg bg-base-200">
        <!-- Icon-Spalte: ausgeklappt eine Spalte mit Filter oben und
             Zurücksetzen mittig zur Feldzeile — Hairline zu den Feldern wie
             zwischen „Serie" und dem Rest der Bedarfsplan-Leiste. Eingeklappt
             beide Icons nebeneinander in einer Zeile, ohne Hairline. -->
        <div class="flex shrink-0 self-stretch
            {open ? 'flex-col items-center pr-3 border-r border-base-300' : 'flex-row items-center gap-1'}"
        >
            <button
                type="button"
                class="btn btn-ghost btn-xs btn-square relative"
                aria-expanded={open}
                title={open ? 'Filter einklappen' : 'Filter ausklappen'}
                use:localize={{ attrs: { title: open ? 'Filter einklappen' : 'Filter ausklappen' } }}
                onclick={toggle}
            >
                <Funnel size="16" />
                {#if active}
                    <span
                        class="absolute -top-0.5 -right-0.5 h-2 w-2 rounded-full bg-error {open ? 'hidden' : 'block'}"
                        aria-hidden="true"
                    ></span>
                {/if}
            </button>
            <!-- Zurücksetzen mittig zur Feldzeile (nur im Spalten-Layout): das
                 Filter-Icon steht oben auf Höhe der Beschriftungen, der Rest
                 der Spalte (Höhe der Felder) zentriert den Knopf — ohne die
                 Feldhöhe zu kennen. Im Zeilen-Layout (eingeklappt) macht
                 `contents` den Knopf zum direkten Geschwister des
                 Filter-Icons. -->
            <div class={open ? 'flex flex-1 items-center mt-1' : 'contents'}>
                <button
                    type="button"
                    class="btn btn-ghost btn-xs btn-square"
                    disabled={!active}
                    title="Filter zurücksetzen"
                    aria-label="Filter zurücksetzen"
                    use:localize
                    data-i18n="title aria-label"
                    onclick={() => onReset?.()}
                >
                    <FunnelX size="16" />
                </button>
            </div>
        </div>
        <div class="flex-1 min-w-0 flex-wrap items-end gap-2 {open ? 'flex' : 'hidden'}">
            {@render children?.()}
        </div>
    </div>
{/if}
