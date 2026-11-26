<script>
    import { tick } from 'svelte';
    import { moduleLocalize } from "./lib/i18n.svelte.js";
    import { keepHighlightVisible } from "./lib/dropdown.js";

    let {
        value = $bindable(''),
        search,
        primary = (item) => item.label ?? '',
        secondary = null,
        onselect = null,
        // Wird nach dem Enter-Commit gerufen — für Erfassungsmasken, die den
        // Fokus danach ins nächste Feld weiterreichen (Direkteingabe,
        // #16033/#16388). Feuert unabhängig davon, ob Enter einen Treffer
        // übernommen hat oder die Eingabe als Freitext stehen bleibt.
        onenter = null,
        placeholder = '',
        disabled = false,
        // Zusätzlich zum Standard-Blur-Verhalten (nichts) — für Felder, die
        // beim Verlassen noch eine eigene Auflösung brauchen (Farbfeld mit
        // Kürzel-Eingabe, #16388). Optional, wirkt sich auf andere Aufrufer
        // ohne dieses Prop nicht aus.
        onblur = null,
        // Formatiert die Eingabe bei jedem Tastendruck (z. B. Katalognummer
        // mit Punkten, #16451). Additiv: Aufrufer ohne dieses Prop verhalten
        // sich exakt wie bisher.
        format = null,
        // Ohne Vorauswahl (#18050, Filterleisten): kein Vorschlag ist
        // markiert, bis man ihn per Pfeiltaste (oder Maus) wählt. Enter ohne
        // Auswahl schließt nur die Liste — eine gewollte Teileingabe wie „10"
        // bleibt als Filter stehen, statt vom ersten Treffer überschrieben zu
        // werden. Erfassungsmasken behalten den Standard (erster Treffer
        // markiert, Enter übernimmt ihn).
        preselect = true
    } = $props();

    // -1 = kein Vorschlag markiert (nur ohne Vorauswahl).
    let ohneMarkierung = $derived(preselect ? 0 : -1);

    let open = $state(false);
    // svelte-ignore state_referenced_locally
    let highlight = $state(preselect ? 0 : -1);
    /** Letzte Markierung per Pfeiltaste (nicht per Maus)? Steuert keepHighlightVisible. */
    let perTaste = $state(false);
    let wrapperEl;
    let inputEl;

    /**
     * Fokussiert das Feld. Für Erfassungsmasken, die den Fokus programmatisch
     * ins nächste Feld weiterreichen (Direkteingabe, #16033/#16388) — löst
     * denselben `onfocus`-Handler wie ein manueller Klick/Tab aus, die Liste
     * klappt also wie gewohnt mit auf (sonst bliebe `onKey` ohne offene Liste
     * hängen und ein Enter ohne vorherige Eingabe täte nichts).
     */
    export function focus() {
        inputEl?.focus();
    }

    let results = $derived.by(() => {
        if (!open) return [];
        return search(value, 12) ?? [];
    });

    // Positionierung der Vorschlagsliste: außerhalb von Modals wird sie fixed
    // am Viewport verankert — in Scroll-Containern (z. B. dem Tabs-Inhalt)
    // zählt eine absolute Liste sonst zum Scrollbereich und wird an der
    // Container-Kante abgeschnitten statt ihn zu überlagern. Innerhalb der
    // DaisyUI-Modal-Box geht fixed nicht: sie trägt translate/scale und wird
    // damit selbst zum Containing Block — dort bleibt die Liste absolute
    // (die Box scrollt intern). Reicht der Platz unter dem Feld nicht,
    // klappt die Liste nach oben auf.
    let listStyle = $state('');

    function positionList() {
        if (!wrapperEl || wrapperEl.closest('.modal-box')) {
            listStyle = '';
            return;
        }
        const r = wrapperEl.getBoundingClientRect();
        const platzUnten = window.innerHeight - r.bottom;
        const platzOben = r.top;
        const maxHoehe = 288; // entspricht max-h-72
        const nachOben = platzUnten < 240 && platzOben > platzUnten;
        const hoehe = Math.max(120, Math.min(maxHoehe, (nachOben ? platzOben : platzUnten) - 12));
        listStyle = `position:fixed;left:${r.left}px;width:${r.width}px;max-height:${hoehe}px;`
            + (nachOben ? `bottom:${window.innerHeight - r.top + 4}px;` : `top:${r.bottom + 4}px;`);
    }

    function openList() {
        // Gesperrt: kein Aufklappen. Der Guard sitzt hier statt an jedem
        // Handler — ein disabled input feuert zwar kein input/focus, per
        // Tastatur (ArrowDown) käme man aber sonst noch an die Liste.
        if (disabled) return;
        positionList();
        open = true;
    }

    function choose(item) {
        value = primary(item);
        open = false;
        highlight = ohneMarkierung;
        onselect?.(item);
    }

    function onInput(e) {
        const roh = e.currentTarget.value;
        if (!format) {
            value = roh;
            openList();
            highlight = ohneMarkierung;
            return;
        }
        // Cursor merken, BEVOR das Setzen von value ihn ans Ende springen
        // lässt (Standardverhalten bei geändertem Input-Value). Gezählt wird
        // in "Nutzzeichen" (Buchstaben/Ziffern) statt in Roh-Zeichenposition,
        // weil format() Trennzeichen (Punkte) verwirft und neu setzt — deren
        // Anzahl vor dem Cursor ändert sich bei jedem Tastendruck.
        const cursorRoh = e.currentTarget.selectionStart ?? roh.length;
        const nutzzeichenVorCursor = (roh.slice(0, cursorRoh).match(/[A-Za-z0-9]/g) ?? []).length;
        value = format(roh);
        openList();
        highlight = ohneMarkierung;
        tick().then(() => {
            if (!inputEl) return;
            let pos = 0;
            let gezaehlt = 0;
            while (pos < value.length && gezaehlt < nutzzeichenVorCursor) {
                if (/[A-Za-z0-9]/.test(value[pos])) gezaehlt++;
                pos++;
            }
            inputEl.setSelectionRange(pos, pos);
        });
    }

    function onKey(e) {
        if (!open && (e.key === 'ArrowDown' || e.key === 'ArrowUp')) {
            openList();
            return;
        }
        if (!open) return;
        if (e.key === 'ArrowDown') {
            e.preventDefault();
            perTaste = true;
            highlight = Math.min(highlight + 1, results.length - 1);
        } else if (e.key === 'ArrowUp') {
            e.preventDefault();
            perTaste = true;
            highlight = Math.max(highlight - 1, ohneMarkierung);
        } else if (e.key === 'Enter') {
            // Leere Query liefert per prefixContainsSearch die ersten Treffer
            // (siehe search.js) — bei leerem Feld darf Enter nur die Liste
            // schließen, nicht results[0] auswählen.
            if (!(value || '').trim() || highlight < 0) {
                e.preventDefault();
                open = false;
                highlight = ohneMarkierung;
            } else if (results[highlight]) {
                e.preventDefault();
                choose(results[highlight]);
            }
            // Freitext ohne Treffer bleibt stehen (siehe choose()/Komponentenkopf
            // der Aufrufer) — onenter feuert trotzdem, damit eine Erfassungs-
            // Kette auch ohne Auswahl weiterläuft.
            onenter?.();
        } else if (e.key === 'Escape') {
            open = false;
            highlight = ohneMarkierung;
        } else if (e.key === 'Tab') {
            // Tab verlässt das Feld zum nächsten Eingabefeld (#18050): die
            // Vorschläge sind per tabindex="-1" aus der Tab-Reihenfolge
            // genommen (Auswahl per Pfeiltaste/Maus), die Liste schließt.
            open = false;
            highlight = ohneMarkierung;
        }
    }

    function onFocus() {
        highlight = ohneMarkierung;
        openList();
    }

    function onPointerDownOutside(e) {
        if (!wrapperEl) return;
        const root = wrapperEl.getRootNode();
        const target = (root instanceof ShadowRoot ? e.composedPath()[0] : e.target);
        if (!wrapperEl.contains(target)) open = false;
    }

    $effect(() => {
        const root = wrapperEl?.getRootNode?.() ?? document;
        const target = root instanceof ShadowRoot ? root : document;
        target.addEventListener('pointerdown', onPointerDownOutside, true);
        return () => target.removeEventListener('pointerdown', onPointerDownOutside, true);
    });

    // Bei Scroll/Resize während offener Liste nachführen. Scroll-Events sind
    // nicht composed — der Capture-Listener muss zusätzlich auf der
    // Shadow-Root sitzen, sonst sieht window das Scrollen der inneren
    // Container (Tabs-Inhalt) nicht.
    $effect(() => {
        if (!open) return;
        const root = wrapperEl?.getRootNode?.() ?? document;
        const targets = root instanceof ShadowRoot ? [root, window] : [window];
        const update = () => positionList();
        for (const t of targets) t.addEventListener('scroll', update, true);
        window.addEventListener('resize', update);
        return () => {
            for (const t of targets) t.removeEventListener('scroll', update, true);
            window.removeEventListener('resize', update);
        };
    });

    function highlightMatch(text, q) {
        const s = (text || '').toString();
        const needle = (q || '').toString().toLowerCase();
        if (!needle) return [{ t: s, hit: false }];
        const i = s.toLowerCase().indexOf(needle);
        if (i < 0) return [{ t: s, hit: false }];
        return [
            { t: s.slice(0, i), hit: false },
            { t: s.slice(i, i + needle.length), hit: true },
            { t: s.slice(i + needle.length), hit: false }
        ];
    }
</script>

<div class="relative" bind:this={wrapperEl}>
    <input
        type="text"
        class="input input-bordered w-full"
        {placeholder}
        use:moduleLocalize={{ attrs: { placeholder } }}
        bind:this={inputEl}
        value={value}
        {disabled}
        oninput={onInput}
        onfocus={onFocus}
        onkeydown={onKey}
        onblur={() => onblur?.()}
        autocomplete="off"
    />
    {#if open && results.length > 0}
        <ul
            class="z-50 bg-base-100 border border-base-300 rounded-box shadow-lg overflow-y-auto {listStyle ? '' : 'absolute mt-1 w-full max-h-72'}"
            style={listStyle}
            use:keepHighlightVisible={{ index: highlight, perTaste }}
            onmouseleave={() => { if (!preselect) highlight = -1; }}
        >
            {#each results as r, i (primary(r) + '|' + i)}
                <li>
                    <button
                        type="button"
                        tabindex="-1"
                        class="w-full text-left px-3 py-2 flex flex-col gap-0.5 hover:bg-base-200 {i === highlight ? 'bg-base-200' : ''}"
                        data-markiert={i === highlight || undefined}
                        onmousemove={() => { if (highlight !== i || perTaste) { perTaste = false; highlight = i; } }}
                        onclick={() => choose(r)}
                    >
                        <span>
                            {#each highlightMatch(primary(r), value) as part, pi (pi)}
                                {#if part.hit}<strong class="text-primary">{part.t}</strong>{:else}{part.t}{/if}
                            {/each}
                        </span>
                        {#if secondary}
                            <span class="text-xs opacity-70">
                                {#each highlightMatch(secondary(r), value) as part, pi (pi)}
                                    {#if part.hit}<strong class="text-primary">{part.t}</strong>{:else}{part.t}{/if}
                                {/each}
                            </span>
                        {/if}
                    </button>
                </li>
            {/each}
        </ul>
    {/if}
</div>
