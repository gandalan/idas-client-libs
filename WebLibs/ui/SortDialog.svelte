<script>
    import ArrowUpDown from '@lucide/svelte/icons/arrow-up-down';
    import ArrowUpNarrowWide from '@lucide/svelte/icons/arrow-up-narrow-wide';
    import ArrowDownWideNarrow from '@lucide/svelte/icons/arrow-down-wide-narrow';
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";

    /**
     * Generischer Sortier-Knopf + Modal für die kompakte Breite (#16600,
     * < 48rem, siehe `./lib/layoutLevel.svelte.js`): Ersatz für die Sortierung
     * über klickbare Spaltenköpfe (`SortableTh`), die auf dem Handy entweder
     * gar nicht alle sichtbar sind oder keinen brauchbaren Klickbereich je
     * Spalte mehr bieten.
     *
     * Rendert IMMER Knopf + Modal — ob sie sichtbar sein sollen, entscheidet
     * der Aufrufer selbst per `{#if isCompact()}` um die Komponente (siehe
     * in m3 `wareneingang/Wareneingang.svelte`, Snippet `aktionen`): in breit/
     * mittel bleibt die Sortierung über die Tabellen-Spaltenköpfe, diese
     * Komponente wird dort gar nicht erst eingebunden.
     *
     * `columns[].defaultDirection` (optional, Default `"asc"`) legt fest,
     * welche Richtung ein Spaltenwechsel im Modal setzt — Zahlenspalten
     * (Mengen) starten wie an den Spaltenköpfen absteigend, Textspalten
     * aufsteigend (siehe `sortiereNach` in
     * `wareneingang/components/WareneingangBestellung.svelte`). Die
     * Richtungsknöpfe darunter setzen die Richtung dagegen immer explizit,
     * unabhängig von diesem Default.
     *
     * @type {{
     *   columns: { id: string, label: string, defaultDirection?: "asc" | "desc" }[],
     *   sort: { column: string | null, direction: "asc" | "desc" },
     *   onChange: (sort: { column: string, direction: "asc" | "desc" }) => void
     * }}
     */
    let { columns, sort, onChange } = $props();

    let modalOpen = $state(false);

    /** @type {HTMLDialogElement | null} */
    let dialog = $state(null);

    $effect(() => {
        if (!dialog) return;
        if (modalOpen && !dialog.open) dialog.showModal();
        else if (!modalOpen && dialog.open) dialog.close();
    });

    /** @param {string} column */
    function selectColumn(column) {
        if (column === sort.column) return;
        const fallback = columns.find((s) => s.id === column)?.defaultDirection ?? 'asc';
        onChange({ column, direction: fallback });
    }

    /** @param {"asc" | "desc"} direction */
    function selectDirection(direction) {
        if (!sort.column || direction === sort.direction) return;
        onChange({ column: sort.column, direction });
    }
</script>

<button
    type="button"
    class="btn btn-sm btn-square bg-base-200"
    title="Sortieren"
    aria-label="Sortieren"
    use:localize
    data-i18n="title aria-label"
    onclick={() => (modalOpen = true)}
>
    <ArrowUpDown size="16" />
</button>

<dialog bind:this={dialog} class="modal font-sans" onclose={() => (modalOpen = false)}>
    <div class="modal-box">
        <h3 class="text-lg font-bold mb-4" use:localize>Sortieren</h3>
        <ul class="flex flex-col gap-1 mb-4">
            {#each columns as column (column.id)}
                <li>
                    <label class="flex items-center gap-2 cursor-pointer py-1 px-2 rounded hover:bg-base-200">
                        <input
                            type="radio"
                            name="sortier-spalte"
                            class="radio radio-sm radio-secondary"
                            checked={sort.column === column.id}
                            onchange={() => selectColumn(column.id)}
                        />
                        <span use:moduleLocalize={{ text: column.label }}>{column.label}</span>
                    </label>
                </li>
            {/each}
        </ul>
        <!-- Aktive Richtung deutlich markiert: Neher-Blau (secondary) statt btn-active,
             siehe Design-Skill (secondary = Auswahl/strukturelle Hervorhebung, #16600) -->
        <div class="join w-full">
            <button
                type="button"
                class="btn btn-sm join-item flex-1"
                class:btn-secondary={sort.direction === 'asc'}
                aria-pressed={sort.direction === 'asc'}
                onclick={() => selectDirection('asc')}
            >
                <ArrowUpNarrowWide size="16" />
                <span use:localize>Aufsteigend</span>
            </button>
            <button
                type="button"
                class="btn btn-sm join-item flex-1"
                class:btn-secondary={sort.direction === 'desc'}
                aria-pressed={sort.direction === 'desc'}
                onclick={() => selectDirection('desc')}
            >
                <ArrowDownWideNarrow size="16" />
                <span use:localize>Absteigend</span>
            </button>
        </div>
        <div class="modal-action">
            <button type="button" class="btn btn-primary" onclick={() => (modalOpen = false)} use:localize>
                Schließen
            </button>
        </div>
    </div>
    <form method="dialog" class="modal-backdrop">
        <button>close</button>
    </form>
</dialog>
