<script>
    /**
     * Leiste UNTER einer Datentabelle: links ein kurzer Status zur Liste,
     * rechts die Aktionen auf den Daten, darunter über die volle Breite ein
     * Zusatzbereich — die Meldung der letzten Aktion oder ein aufklappbarer
     * Nebenweg (Wareneingang ohne Bestellung).
     *
     * Warum unten und nicht in der Kopfkarte: die Kopfkarte beschreibt, WAS
     * man sieht und woher es kommt (Titel, Zähler, Stand, Zeitraum,
     * Aktualisieren, Einstellungen); gehandelt wird am Ende der Liste, dort wo
     * der Blick nach dem Durchsehen der Zeilen ankommt. Vorbild ist die
     * Direkteingabe, die das schon immer so hatte.
     *
     * @type {{
     *   status?: import('svelte').Snippet | null,
     *   actions?: import('svelte').Snippet | null,
     *   extra?: import('svelte').Snippet | null,
     * }}
     */
    let { status = null, actions = null, extra = null } = $props();
</script>

<!-- Kompakt (< 48rem, Container-Variante @max-3xl/content auf der Shell-
     Wurzel `content`) scrollt künftig die ganze Seite statt nur die Tabelle
     — die Leiste bleibt dabei per `sticky bottom-0` am unteren Rand des
     sichtbaren Bereichs hängen, damit die Hauptaktion immer erreichbar ist.
     Voraussetzung dafür: KEIN Vorfahr zwischen dieser Leiste und dem
     scrollenden Shell-Container `#container` darf `overflow` ≠ visible
     setzen, sonst greift `sticky` nicht. Die deckende Fläche `bg-base-100`
     ist derselbe Token, auf dem auch DatenTabelle ruht (siehe dort) — die
     Leiste hängt sich damit optisch an die weiße Fläche der Tabelle an,
     die sie sonst beim Scrollen verdecken würde.

     `#container` der Shell hat je nach Viewport unterschiedlich viel
     Innenabstand (NeherApp3 „Handy-Ansicht: kein Padding um den
     Modulbereich": `p-0 sm:p-4` — unter 640 px kein Padding, ab 640 px
     1 rem). `sticky bottom-0` klemmt an der Innenkante des Containers, die
     damit mal die echte Unterkante ist (kein Padding) und mal 1 rem darüber
     liegt (Padding) — ein fester `-bottom-4`-Ausgleich passte nur für einen
     der beiden Fälle. Statt dem Padding hinterherzurechnen, deckt ein
     massiver Schatten nach unten ohne Weichzeichnung/Ausbreitung
     (`shadow-[0_1rem_0_0_var(--color-base-100)]`, gleiche Farbe wie die
     Leiste) eine etwaige 1-rem-Lücke ab: ohne Padding wird der Schatten am
     Scrollport einfach abgeschnitten, mit Padding füllt er genau die
     Lücke bis zur echten Unterkante. -->
<div
    class="flex flex-col items-end gap-2 @max-3xl/content:sticky @max-3xl/content:bottom-0 @max-3xl/content:z-10 @max-3xl/content:bg-base-100 @max-3xl/content:border-t @max-3xl/content:border-base-300 @max-3xl/content:py-2 @max-3xl/content:shadow-[0_1rem_0_0_var(--color-base-100)]"
>
    {#if status || actions}
        <div class="flex items-center justify-between gap-3 w-full flex-wrap">
            <div class="text-sm opacity-70 @max-3xl/content:line-clamp-2">
                {#if status}{@render status()}{/if}
            </div>
            <div class="flex items-center gap-2 flex-wrap @max-3xl/content:w-full @max-3xl/content:[&_.btn]:flex-1">
                {#if actions}{@render actions()}{/if}
            </div>
        </div>
    {/if}
    {#if extra}
        <div class="w-full">{@render extra()}</div>
    {/if}
</div>
