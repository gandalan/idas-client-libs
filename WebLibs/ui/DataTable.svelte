<script>
    import { isCompact } from "./lib/layoutLevel.svelte.js";

    /**
     * Tabelle mit feststehendem Spaltenkopf: nur die Zeilen scrollen, und die
     * Bildlaufleiste reicht genau so weit wie der Zeilenbereich.
     *
     * Warum zwei `<table>`? Mit `position: sticky` am `<thead>` bleibt der Kopf
     * zwar stehen, die Bildlaufleiste gehört aber zum Scroll-Container und
     * liefe damit auch neben dem Kopf hoch — das sah falsch aus. Der sichtbare
     * Kopf steht deshalb AUSSERHALB des Scroll-Containers.
     *
     * Damit die Spalten trotzdem zusammenpassen, rendert die Körper-Tabelle
     * denselben Kopf ein zweites Mal als Messkopf: er bestimmt die
     * Spaltenbreiten wie bisher mit (automatisches Tabellen-Layout), wird per
     * negativem `margin-top` über den Scroll-Anfang hinaus geschoben und
     * dadurch weggeschnitten (oberhalb des Scroll-Ursprungs ist nichts
     * erreichbar). Seine gemessenen Breiten liegen dann als feste Breiten auf
     * der Kopf-Tabelle.
     *
     * @type {{
     *   head: import('svelte').Snippet,
     *   body: import('svelte').Snippet,
     *   footer?: import('svelte').Snippet | null,
     *   cards?: import('svelte').Snippet | null,
     *   frameClass?: string,
     *   tableClass?: string,
     *   headClass?: string,
     *   responsive?: boolean,
     * }}
     */
    let {
        head,
        body,
        footer = null,
        // Alternative Darstellung für schmale Breiten (siehe `responsive`):
        // ersetzt Kopf+Tabelle durch eine eigene Liste, z. B. Karten.
        cards = null,
        // Der Rahmen füllt standardmäßig die Resthöhe seines Flex-Elters
        // (Höhenkette: `#shadow-mount { height: 100% }` in app.css).
        frameClass = 'flex-1 min-h-0',
        tableClass = 'table table-zebra',
        headClass = '[&_th]:bg-neutral [&_th]:text-neutral-content [&_th]:font-semibold [&_th]:uppercase [&_th]:tracking-wide',
        // Schaltet das responsive Verhalten unterhalb 48rem (Tailwind-
        // Container-Variante `@max-3xl/content:`, gemessen am benannten
        // Container `content` der Host-Shell) frei: der Rahmen bekommt
        // natürliche Höhe statt Resthöhe, und bei gesetztem `cards`-Snippet
        // ersetzen Karten die Tabelle. Die Karten werden dabei per `{#if}`
        // STATT der Tabelle gerendert (`isCompact()` aus
        // `./lib/layoutLevel.svelte.js`), nicht beide parallel im DOM und per
        // CSS umgeschaltet — sonst existierten Popover, Editoren und
        // Komponenten mit eigenem Zustand doppelt, und große Listen
        // (Bedarfsplan, Artikel) rendern alles zweimal (#16600). Grund für
        // die Karten selbst: Kopf+Filter sind auf dem Handy
        // oft höher als der Bildschirm, die Shell scrollt dann selbst — ein
        // `flex-1 min-h-0`-Rahmen bekommt darin 0 px Höhe und die Tabelle
        // verschwindet.
        //
        // WARNUNG: in einem Dialog/Modal (natives `<dialog>`) misst die
        // Container-Query weiter den Inhaltsbereich der Shell dahinter, nicht
        // den (meist schmaleren) Dialog — die Umschaltung würde dort nach der
        // falschen Breite greifen oder spontan auf dem Handy zuschlagen, wo
        // der Dialog ohnehin schon zusammengedrückt dargestellt wird. Jede
        // DatenTabelle in einem Dialog MUSS deshalb `responsive={false}`
        // setzen.
        responsive = true
    } = $props();

    // Bei gesetztem `cards`-Snippet entfällt in kompakt zusätzlich der
    // Rahmen (Border/Schatten) — die Karten stehen dann direkt auf dem
    // Seitenhintergrund statt in einer zweiten umschließenden Box um bereits
    // kartenförmige Elemente; das wirkte im Vergleich ruhiger.
    let kompaktRahmenKlasse = $derived(
        !responsive
            ? ''
            : `@max-3xl/content:flex-none @max-3xl/content:h-auto${
                  cards
                      ? ' @max-3xl/content:border-0 @max-3xl/content:shadow-none @max-3xl/content:rounded-none @max-3xl/content:bg-transparent'
                      : ''
              }`
    );

    // Scroller in kompakt ohne Karten: natürliche Höhe statt `flex-1
    // min-h-0`, waagerecht bleibt er scrollbar (breite Tabellen). Bewusst
    // `overflow-y-hidden` statt `overflow-y-visible`: die CSS-Spec koppelt
    // beide Achsen — steht eine auf `auto` (hier `overflow-x`) und die andere
    // auf `visible`, wird `visible` vom Browser automatisch zu `auto`
    // aufgewertet, was hier ungewollt eine zweite (senkrechte) Bildlaufleiste
    // erzeugt hätte. Die Höhe hängt hier ohnehin am Inhalt (kein Clipping
    // nötig), daher ist `hidden` gefahrlos.
    let kompaktScrollerKlasse = $derived(
        responsive
            ? '@max-3xl/content:flex-none @max-3xl/content:overflow-x-auto @max-3xl/content:overflow-y-hidden'
            : ''
    );

    // Karten ersetzen Kopf+Tabelle nur, wenn alles zutrifft: `cards`
    // gesetzt, `responsive` aktiv (in Dialogen bleibt immer die Tabelle,
    // siehe Warnung oben) UND die Inhaltsbreite ist kompakt. Strukturwechsel
    // per `{#if}` — zu jedem Zeitpunkt existiert nur EINE Darstellung
    // (#16600).
    let kartenStattTabelle = $derived(Boolean(cards) && responsive && isCompact());

    // Unter @5xl/content (mittel/kompakt) weniger Innenabstand je Zelle: bei
    // vielen sichtbaren Spalten (z. B. Wareneingang, 7 Spalten × 16 px
    // links+rechts) sprengt daisyUIs Standard-Zellpadding sonst die
    // verfügbare Breite. Bewusst NICHT in den Default von `tableClass`
    // eingebaut, sondern separat angehängt — `tableClass` ist eine Prop,
    // die Verwender komplett überschreiben können, die Reduktion soll aber
    // auch dann greifen. `[&_th]:px-2`/`[&_td]:px-2` erzeugen eine Regel mit
    // Klassen+Element-Spezifität; daisyUIs Zellpadding steckt hinter
    // `:where(...)` (Spezifität 0) und wird dadurch zuverlässig
    // überschrieben — Kopf- UND Körper-Tabelle bekommen dieselben Klassen,
    // damit die `<col>`-Breiten aus `messen()` weiter zu den Körperzellen
    // passen. Ab @5xl/content (breit) unverändert (#16600).
    let kompaktZellpolsterKlasse = $derived(
        responsive ? '@max-5xl/content:[&_th]:px-2 @max-5xl/content:[&_td]:px-2' : ''
    );

    /** @type {HTMLDivElement | null} */
    let scroller = $state(null);
    /** @type {HTMLDivElement | null} */
    let kopfBox = $state(null);
    /** @type {HTMLTableElement | null} */
    let koerperTabelle = $state(null);
    /** @type {HTMLTableSectionElement | null} */
    let messkopf = $state(null);

    /** Spaltenbreiten des Messkopfs in px. @type {number[]} */
    let breiten = $state([]);
    let gesamtbreite = $state(0);
    let messkopfHoehe = $state(0);
    // Breite der senkrechten Bildlaufleiste: die Kopf-Tabelle darf nur so
    // breit sein wie der Inhaltsbereich des Scrollers, sonst steht sie über.
    // Sie wird als PADDING gesetzt, nicht als Margin — die Kopf-Hülle reicht so
    // bis an den rechten Rand und schließt die Lücke über der Bildlaufleiste
    // (sie trägt dafür dieselbe Fläche wie die Spaltenköpfe, s. u.).
    let scrollbarBreite = $state(0);

    let messungAngefordert = false;

    function anfordern() {
        if (messungAngefordert) return;
        messungAngefordert = true;
        requestAnimationFrame(() => {
            messungAngefordert = false;
            messen();
        });
    }

    function messen() {
        if (!scroller || !koerperTabelle || !messkopf) return;
        const zeile = messkopf.rows[0];
        if (!zeile) return;

        // Transform-Korrektur: `getBoundingClientRect` liefert GERENDERTE
        // Maße. Liegt die Tabelle in einem Vorfahren mit `transform: scale`
        // — DaisyUI blendet die Modal-Box beim Öffnen von 0,95 auf 1 ein —,
        // fällt die Messung mitten in die Animation und ist um den Faktor
        // zu klein. Der ResizeObserver feuert danach nicht erneut, weil sich
        // die LAYOUT-Größen nicht ändern; der Kopf blieb im Bestell-Dialog
        // dauerhaft 5 % schmaler als der Körper. Die Layoutbreite
        // (`offsetWidth`, transform-unabhängig) geteilt durch die gerenderte
        // Breite ergibt die Skalierung, mit der alle Rect-Maße zurück in
        // Layout-Pixel gerechnet werden.
        const tabelleRect = koerperTabelle.getBoundingClientRect();
        if (tabelleRect.width === 0) return;
        const skala = koerperTabelle.offsetWidth / tabelleRect.width;

        // Nur sichtbare Zellen messen: Verwender blenden Spalten per
        // Container-Query aus (`hidden` auf `<th>`/`<td>`, z. B.
        // `@3xl/content:@max-5xl/content:hidden`). Eine ausgeblendete Zelle
        // (display:none) bildet keine Spalte — flösse sie in `breiten` ein,
        // verschöben sich die `<col>`-Breiten der sichtbaren Kopf-Tabelle
        // gegenüber den tatsächlich sichtbaren Spalten, und Kopfzellen
        // überlagerten sich (#16600).
        const sichtbareZellen = Array.from(zeile.cells).filter((z) => z.getClientRects().length > 0);
        const neu = sichtbareZellen.map((z) => z.getBoundingClientRect().width * skala);
        // Nur bei echter Abweichung schreiben: sonst löst jede Messung ein
        // Update aus, das den ResizeObserver erneut weckt.
        if (neu.length !== breiten.length || neu.some((w, i) => Math.abs(w - breiten[i]) > 0.5)) {
            breiten = neu;
        }
        gesamtbreite = tabelleRect.width * skala;
        messkopfHoehe = messkopf.getBoundingClientRect().height * skala;
        scrollbarBreite = scroller.offsetWidth - scroller.clientWidth;
    }

    $effect(() => {
        if (!scroller || !koerperTabelle) return;
        const ro = new ResizeObserver(anfordern);
        ro.observe(scroller);
        ro.observe(koerperTabelle);
        // Zeilen kommen und gehen (Filter, „weitere anzeigen", Nachladen) —
        // dabei ändern sich die Spaltenbreiten, ohne dass sich die
        // Tabellenbreite ändern muss.
        const mo = new MutationObserver(anfordern);
        mo.observe(koerperTabelle, { childList: true, subtree: true, characterData: true });
        anfordern();
        return () => {
            ro.disconnect();
            mo.disconnect();
        };
    });

    function scrollSync() {
        if (kopfBox && scroller) kopfBox.scrollLeft = scroller.scrollLeft;
    }
</script>

<div
    class="flex flex-col overflow-hidden rounded-lg border border-base-300 bg-base-100 shadow-md {frameClass} {kompaktRahmenKlasse}"
>
    {#if cards && kartenStattTabelle}
        <div class="flex flex-col gap-2 px-0 py-1">
            {@render cards()}
        </div>
    {:else}
        <!-- `shrink-0`: als Flex-Kind mit `overflow: hidden` hätte die Kopf-Hülle
             `min-height: 0` und würde bei begrenzter Rahmenhöhe (`max-h-…`, z. B.
             im Bestell-Dialog) zusammengedrückt — der Kopf erschien abgeschnitten. -->
        <div
            bind:this={kopfBox}
            class="shrink-0 overflow-hidden bg-neutral"
            style:padding-right="{scrollbarBreite}px"
        >
            <table
                class="{tableClass} table-fixed {kompaktZellpolsterKlasse}"
                style:width={gesamtbreite ? `${gesamtbreite}px` : null}
            >
                <colgroup>
                    {#each breiten as b, i (i)}
                        <col style:width="{b}px" />
                    {/each}
                </colgroup>
                <thead class={headClass}>
                    {@render head()}
                </thead>
            </table>
        </div>

        <div
            bind:this={scroller}
            class="flex-1 min-h-0 overflow-auto {kompaktScrollerKlasse}"
            onscroll={scrollSync}
        >
            <table
                bind:this={koerperTabelle}
                class="{tableClass} {kompaktZellpolsterKlasse}"
                style:margin-top="-{messkopfHoehe}px"
            >
                <!-- Messkopf: nur für die Spaltenbreiten da, liegt oberhalb des
                     Scroll-Ursprungs und ist damit unsichtbar und unerreichbar. -->
                <thead bind:this={messkopf} class={headClass} aria-hidden="true" inert>
                    {@render head()}
                </thead>
                <tbody>
                    {@render body()}
                </tbody>
            </table>
        </div>
    {/if}

    {#if footer}
        {@render footer()}
    {/if}
</div>
