<script>
    import ArrowUp from '@lucide/svelte/icons/arrow-up';
    import ArrowDown from '@lucide/svelte/icons/arrow-down';
    import ChevronsUpDown from '@lucide/svelte/icons/chevrons-up-down';
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";

    /**
     * Klickbarer Tabellen-Spaltenkopf für Sortierung. Rendert selbst das
     * `<th>`, damit Eltern-Selektoren am `<thead>` (z. B. `[&_th]:bg-neutral`)
     * weiter greifen — ein Wrapper-Element würde sie aushebeln.
     *
     * Reine Darstellungskomponente: keine eigene Zustandslogik. Die nächste
     * Sortierrichtung ermittelt der Aufrufer (siehe z. B. m3 `$lib/data/sort.js`).
     *
     * @type {{
     *   label: string,
     *   column: string,
     *   sort: { column: string|null, direction: "asc"|"desc" },
     *   onSort: (column: string) => void,
     *   class?: string,
     *   align?: "left" | "right",
     * }}
     */
    // label: deutscher Quelltext, die Komponente übersetzt selbst per
    // use:localize (siehe Progress.svelte) — Aufrufer übergeben Deutsch.
    let { label, column, sort, onSort, class: className = '', align = 'left' } = $props();

    let active = $derived(sort.column === column);
    /** @type {"none" | "ascending" | "descending"} */
    let ariaSort = $derived(
        !active ? 'none' : sort.direction === 'asc' ? 'ascending' : 'descending'
    );
</script>

<th class={className} aria-sort={ariaSort}>
    <button
        type="button"
        class="inline-flex items-center gap-1 cursor-pointer"
        class:flex-row-reverse={align === 'right'}
        title={active ? 'Sortierung umschalten' : `Nach ${label} sortieren`}
        aria-label={active ? 'Sortierung umschalten' : `Nach ${label} sortieren`}
        use:localize={{
            attrs: {
                title: active ? 'Sortierung umschalten' : 'Nach {spalte} sortieren',
                'aria-label': active ? 'Sortierung umschalten' : 'Nach {spalte} sortieren'
            },
            params: { spalte: moduleLocalize(label) }
        }}
        onclick={() => onSort(column)}
    >
        <span use:moduleLocalize={{ text: label }}>{label}</span>
        {#if active && sort.direction === 'asc'}
            <ArrowUp size="14" />
        {:else if active && sort.direction === 'desc'}
            <ArrowDown size="14" />
        {:else}
            <ChevronsUpDown size="14" class="opacity-40" />
        {/if}
    </button>
</th>
