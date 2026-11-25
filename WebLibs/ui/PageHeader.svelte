<script>
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";
    import { getContext } from 'svelte';
    import { isCompact } from "./lib/layoutLevel.svelte.js";
    import { PAGE_HEADER_WITHOUT_TITLE } from "./lib/pageHeaderContext.js";

    // Im Reiter einer Ansicht mit eigenem Seitenkopf (Lager, Stammdaten) steht der
    // Titel schon im Host-Kopf: hier entfällt er, Meta/Aktionen/Filter bleiben.
    const imReiter = getContext(PAGE_HEADER_WITHOUT_TITLE) === true;

    /**
     * Kopf einer Ansicht — dieselbe Form wie auf der Übersicht/Cockpit-Seite
     * (start/Startseite.svelte): Titel und Kurzinfo links, Bedienelemente
     * rechts, KEINE Karte und kein eigener Rahmen darum. Der Kopf gehört zur
     * Ansicht, die in der Navigation verlinkt ist, nie zur Datentabelle.
     *
     * Rechts stehen nur Dinge, die sich NICHT auf die Zeilen der Liste
     * beziehen: Herkunft der Daten (Zeitraum, „Aktualisieren"), Ansicht
     * („Einstellungen…", Anzeige-Schalter) und das Anlegen eines neuen
     * Eintrags („Neue Zählliste"). Alles, was auf die gezeigten Zeilen wirkt,
     * gehört in die `Aktionsleiste` unter die Tabelle.
     *
     * Responsiv (#16600): auf dem Handy nimmt der Kopf weniger Höhe ein, über
     * die Tailwind-Container-Variante `@max-3xl/content:` auf dem
     * Shell-Container `content` (< 48rem) — additiv, breit bleibt exakt wie
     * zuvor.
     * - Titel etwas kleiner (`text-xl` statt `text-2xl`).
     * - Meta-Text auf eine Zeile geklemmt (`line-clamp-1`). Die 16 Verwender
     *   rendern `meta` als freien Mix aus Text/Spans/`<br>` (teils, z. B.
     *   Journal.svelte, mit einem inneren `flex flex-wrap`-Absatz); eine
     *   generische Lösung kann darauf nicht Wort für Wort Rücksicht nehmen.
     *   `line-clamp-1` ist trotzdem die richtige Wahl, weil in praktisch allen
     *   Verwendern „Stand: …" der ERSTE Inhalt ist — geklemmt bleibt genau das
     *   sichtbar, der Rest verschwindet wie gefordert. Eine aufklappbare
     *   Variante (`<details>`) wurde verworfen: sie hätte für 16 beliebig
     *   strukturierte Snippets keinen verlässlichen „Kurztext" für den
     *   geschlossenen Zustand liefern können.
     * - Aktionen erzwungenermaßen in eigener voller Zeile unter Titel/Meta
     *   (`w-full` im Aktionen-Container bricht den `flex-wrap` der Kopfzeile
     *   gezielt um, statt nur bei Platzmangel). Eine generische Icon-only-
     *   Umstellung (Text ausblenden, Icon behalten) ist NICHT umgesetzt: die
     *   Verwender rendern ihre Button-Beschriftung als eigenen Textknoten
     *   neben dem Icon (teils per `use:localize={{ text }}` auf genau diesem
     *   Knoten), das lässt sich nicht generisch per CSS treffen, ohne Text in
     *   ein eigenes Element zu verschieben — das müsste jeder Verwender selbst
     *   tun. Muster dafür: `wareneingang/Wareneingang.svelte`
     *   (`actions`-Snippet), dort exemplarisch umgesetzt.
     * - Kompakt bleibt die volle Aktionszeile jetzt zusätzlich EINZEILIG
     *   (`flex-nowrap` statt `flex-wrap`) — Vorgabe: „Aktualisieren",
     *   „Einstellungen", „Sortieren" und „Filter" stehen dort als
     *   gleich große Icon-Knöpfe nebeneinander, kein Umbruch mehr.
     *
     * Neues optionales Snippet `filter` (#16600): dieselbe Filterleiste einer
     * Ansicht (z. B. `PositionenFilterBar`) für BEIDE Breiten — es gibt nur
     * EINE Stelle im Markup, die `{@render filter()}` aufruft (per
     * `{#if isCompact()}`/`{:else}`-Zweig entschieden), damit nie zwei Kopien
     * der Filterfelder gleichzeitig im DOM stehen (doppelter `$state`,
     * kaputtes Outside-Click-Handling — siehe `./lib/layoutLevel.svelte.js`).
     * Breit/mittel wird sie unter dem Kopf gerendert, mit einem `mt-1`-
     * Ausgleich: der Kopf selbst hat `gap-3`, die Ansichtswurzel bisher
     * `gap-4` zwischen Seitenkopf und Filterleiste — `mt-1` (0,25rem) gleicht
     * die Differenz zu `gap-3` (0,75rem) aus, damit sich der Abstand nicht
     * ändert. Kompakt steht sie stattdessen als letztes Element in der
     * Aktionszeile (die Filterleiste selbst reduziert sich dort auf einen
     * Icon-Knopf, siehe `FilterBar.svelte`).
     *
     * @type {{
     *   title: string,
     *   meta?: import('svelte').Snippet | null,
     *   actions?: import('svelte').Snippet | null,
     *   filter?: import('svelte').Snippet | null,
     *   children?: import('svelte').Snippet | null,
     *   main?: boolean,
     * }}
     * `main`: der Kopf der Reiteransicht selbst (Lager, Stammdaten) — zeigt
     * seinen Titel immer, auch wenn er im Kontext ohne Titel steht.
     */
    let { title, meta = null, actions = null, filter = null, children = null, main = false } = $props();
    const ohneTitel = $derived(imReiter && !main);
</script>

<div class="flex flex-col gap-3">
    <div class="flex items-start justify-between gap-4 flex-wrap">
        <div>
            {#if !ohneTitel}
                <h1 class="text-2xl font-semibold @max-3xl/content:text-xl" use:moduleLocalize={{ text: title }}>{title}</h1>
            {/if}
            {#if meta}
                <div class="text-sm opacity-70 @max-3xl/content:line-clamp-1">{@render meta()}</div>
            {/if}
        </div>
        {#if actions || filter}
            <div class="flex items-center gap-2 flex-wrap @max-3xl/content:w-full @max-3xl/content:flex-nowrap">
                {@render actions?.()}
                {#if filter && isCompact()}
                    {@render filter()}
                {/if}
            </div>
        {/if}
    </div>
    {#if filter && !isCompact()}
        <div class="mt-1">{@render filter()}</div>
    {/if}
    {#if children}
        {@render children()}
    {/if}
</div>
