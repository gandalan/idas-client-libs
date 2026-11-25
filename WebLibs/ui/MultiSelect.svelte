<script>
    import { uiLocalize as localize, moduleLocalize, uiLocale as currentLocale } from "./lib/i18n.svelte.js";

    /**
     * Mehrfachauswahl-Dropdown für Filterleisten (#16061).
     *
     * Formt das Muster aus bedarfsplan/components/FilterBar.svelte und
     * lager/LagerFilterBar.svelte in eine Komponente: Trigger in Select-Optik,
     * absolut positioniertes Menü mit Checkboxen, „Alle" als Reset-Eintrag.
     * Die beiden bestehenden Leisten sind bewusst noch nicht umgestellt — das
     * kann einzeln nachgezogen werden.
     *
     * Leere Auswahl bedeutet „alle", wie beim Ampelfilter im Lager: wer die
     * letzte Option abwählt, sieht wieder alles statt nichts.
     *
     * Das Auf/Zu liegt beim Aufrufer (`open`), damit eine Leiste mit mehreren
     * Dropdowns immer nur eines offen hat. Der Wrapper trägt
     * `data-filter-dropdown` — darauf stützt sich onOutsidePointerDown aus
     * ./lib/outsideClick.js, das die Leiste als Ganzes registriert.
     *
     * `optionContent` ist optional: ohne ihn zeigt jede Menüzeile schlicht
     * `o.label` (unverändert für bestehende Verwender). Wird er übergeben,
     * rendert er den Zeileninhalt selbst — z. B. um wie im Artikelstamm ein
     * Farbquadrat hinter dem Label zu zeigen — und bekommt dazu die jeweilige
     * Option (samt etwaiger Zusatzfelder) übergeben.
     *
     * Kompakt (#16600) nehmen Knopf und Menü die volle Breite ein — eingebaut,
     * damit Verwender das nicht über `width`/`menuWidth` setzen müssen.
     *
     * Mit Auswahl trägt der Knopf `filter-aktiv` (roter Rahmen, #18049) —
     * leere Auswahl heißt „Alle" und ist der Standard.
     *
     * @type {{
     *   label: string,
     *   options?: Array<{ value: string, label: string, [key: string]: any }>,
     *   selected?: string[],
     *   open?: boolean,
     *   plural: string,
     *   width?: string,
     *   menuWidth?: string,
     *   optionContent?: import('svelte').Snippet<[any]>
     * }}
     */
    // label/plural: deutscher Quelltext, die Komponente übersetzt selbst per
    // use:localize / localize() (siehe Progress.svelte) — Aufrufer übergeben
    // Deutsch (auch für `plural`, das in den zusammengesetzten Zähltext
    // "{anzahl} {einheit}" einfließt).
    let {
        label,
        options = [],
        selected = $bindable([]),
        open = $bindable(false),
        plural,
        width = 'w-56',
        menuWidth = 'w-72',
        optionContent
    } = $props();

    /**
     * Trigger-Text wie im Bedarfsplan: „Alle" ohne Auswahl, sonst der Wert
     * selbst bzw. gezählt. Eine Auswahl, deren Option verschwunden ist (die
     * Liste hängt am Datenbestand), fällt beim Zählen nicht auf — deshalb wird
     * die Beschriftung aus den vorhandenen Optionen gebildet.
     */
    let visibleSelection = $derived(options.filter((o) => selected.includes(o.value)));

    // `currentLocale()` als Abhängigkeit ist hier nötig — siehe Kommentar zum
    // Sprach-Spiegel in ./lib/i18n.svelte.js: ohne sie folgt dieser $derived
    // einem reinen Sprachwechsel nicht, und der Trigger-Text bliebe stehen.
    let triggerLabel = $derived.by(() => {
        currentLocale();
        return visibleSelection.length === 0
            ? localize('Alle')
            : visibleSelection.length === 1
                ? visibleSelection[0].label
                : localize('{anzahl} {einheit}', { anzahl: visibleSelection.length, einheit: moduleLocalize(plural) });
    });

    function toggle(value, checked) {
        selected = checked ? [...selected, value] : selected.filter((w) => w !== value);
    }
</script>

<div class="flex flex-col @max-3xl/content:w-full">
    <span class="mb-1" use:moduleLocalize={{ text: label }}>{label}</span>
    <div class="relative" data-filter-dropdown>
        <button
            type="button"
            class="select select-bordered {width} @max-3xl/content:w-full flex items-center cursor-pointer"
            class:filter-aktiv={selected.length > 0}
            onclick={() => (open = !open)}
            title={triggerLabel}
        >
            <span class="truncate">{triggerLabel}</span>
        </button>
        {#if open}
            <!-- max-h-72 + scroll: die Liste kann lang werden (im Artikelstamm
                 rund 60 Warengruppen). -->
            <ul
                class="absolute top-full left-0 mt-1 bg-base-100 rounded-box border border-base-300 shadow-lg z-50 {menuWidth} @max-3xl/content:w-full @max-3xl/content:max-w-full max-h-72 overflow-y-auto p-2 flex flex-col gap-1"
            >
                <li>
                    <button
                        type="button"
                        class="w-full text-left py-1 px-2 rounded hover:bg-base-200 font-medium"
                        class:opacity-50={selected.length === 0}
                        onclick={() => (selected = [])}
                        disabled={selected.length === 0}
                        use:localize
                    >
                        Alle
                    </button>
                </li>
                <li class="border-b border-base-300 my-1"></li>
                {#if options.length === 0}
                    <li class="py-1 px-2 opacity-60" use:localize>Keine Auswahl vorhanden.</li>
                {:else}
                    {#each options as o (o.value)}
                        <li>
                            <label class="flex items-center gap-2 cursor-pointer py-1 px-2 rounded hover:bg-base-200">
                                <input
                                    type="checkbox"
                                    class="checkbox checkbox-sm"
                                    checked={selected.includes(o.value)}
                                    onchange={(e) => toggle(o.value, e.currentTarget.checked)}
                                />
                                {#if optionContent}
                                    {@render optionContent(o)}
                                {:else}
                                    <span>{o.label}</span>
                                {/if}
                            </label>
                        </li>
                    {/each}
                {/if}
            </ul>
        {/if}
    </div>
</div>
