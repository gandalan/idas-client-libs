<script>
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";
    import { isCompact } from "./lib/layoutLevel.svelte.js";

    /**
     * `boxClass` ergänzt die Klassen der Modal-Box — gedacht für eine abweichende
     * Breite (z. B. `max-w-3xl`), wenn der Inhalt eine Tabelle enthält. Ohne
     * Angabe bleibt es bei der Standardbreite von DaisyUI.
     *
     * `overflowVisible` schaltet das Clipping der Modal-Box ab (Inline-Style,
     * weil DaisyUIs unlayered `.modal-box { overflow-y: auto }` jede
     * Tailwind-Utility schlägt): für Dialoge mit aufklappenden Dropdown-Menüs,
     * die sonst an der Box-Kante abgeschnitten würden. Nur für kompakte Inhalte
     * verwenden — die Box scrollt dann nicht mehr.
     * In kompakter Inhaltsbreite (< 48rem, `isCompact()` aus
     * `./lib/layoutLevel.svelte.js`) wirkt der Schalter bewusst nicht (#16600):
     * hohe Inhalte (z. B. die Regel-Editoren) ragten auf dem Handy sonst aus
     * dem Bild; dort bleibt die Box scrollbar, Aufrufer müssen `isCompact()`
     * nicht selbst prüfen.
     *
     * `cancelText` beschriftet den linken Knopf (deutscher Quelltext) — für
     * Dialoge, die nach dem Speichern offen bleiben und dann nichts mehr zu
     * verwerfen haben (Artikel-Dialog, #17296: „Schließen").
     *
     * `busy`: ein Speichern läuft noch, das der Aufrufer selbst
     * verfolgt (onSave lieferte false). Solange sperrt der Dialog beide Knöpfe
     * und lässt sich nicht schließen — weder per Escape noch über den
     * Hintergrund —, damit ein Fehler nicht ungesehen verschwindet.
     * @type {{ open: boolean, title?: string, onSave: () => void | boolean | Promise<any>, onCancel?: () => void, canSave?: boolean, busy?: boolean, cancelText?: string, boxClass?: string, overflowVisible?: boolean, header?: import('svelte').Snippet, children?: import('svelte').Snippet }}
     */
    // title: deutscher Quelltext, die Komponente übersetzt selbst per
    // use:localize (siehe Progress.svelte) — Aufrufer übergeben Deutsch.
    let { open = $bindable(), title = '', onSave, onCancel, canSave = true, busy = false, cancelText = 'Abbrechen', boxClass = '', overflowVisible = false, header, children } = $props();

    // Überlauf nur außerhalb von isCompact (#16600, siehe Doc-Kommentar oben).
    let overflowActive = $derived(overflowVisible && !isCompact());

    /** @type {HTMLDialogElement | null} */
    let dialog = $state(null);

    $effect(() => {
        if (!dialog) return;
        if (open && !dialog.open) dialog.showModal();
        else if (!open && dialog.open) dialog.close();
    });

    /** Escape: während `busy` abfangen. @param {Event} e */
    function handleCancel(e) {
        if (busy) e.preventDefault();
    }

    function handleClose() {
        // Chrome schließt beim zweiten Escape trotz preventDefault (Close
        // Watcher ohne Benutzeraktivierung) — dann sofort wieder öffnen.
        if (busy && open) {
            dialog?.showModal();
            return;
        }
        open = false;
        onCancel?.();
    }

    function handleSave() {
        if (!canSave || busy) return;
        // Ein onSave, das synchron false liefert, hält den Dialog offen — der
        // Aufrufer schließt dann selbst über das gebundene `open` (z. B. der
        // BuchenDialog nach erfolgreichem async-Speichern; Fehler bleiben im
        // Dialog sichtbar). Async-Handler (Promise ≠ false) schließen wie bisher.
        if (onSave() === false) return;
        open = false;
    }
</script>

<!-- font-sans: defensiver Reset, falls der Dialog künftig in einem
     technischen Mono-Kontext (z. B. ein Regex-Feld im Regel-Editor)
     gemountet wird; die Schrift soll dann nicht vererbt werden. -->
<dialog bind:this={dialog} class="modal font-sans" oncancel={handleCancel} onclose={handleClose}>
    <div class="modal-box {boxClass}" style={overflowActive ? 'overflow: visible' : undefined}>
        {#if header}
            {@render header()}
        {:else}
            <h3 class="text-lg font-bold mb-4" use:moduleLocalize={{ text: title }}>{title}</h3>
        {/if}
        <div class="flex flex-col gap-3">
            {@render children?.()}
        </div>
        <!-- flex-wrap (#16600): lange Knopftexte (Übersetzungen)
             brechen auf schmalen Bildschirmen in eine zweite Zeile um, statt
             aus der Modal-Box zu ragen; solange Platz ist, unverändert. -->
        <div class="modal-action flex-wrap">
            <button class="btn btn-ghost" onclick={handleClose} disabled={busy} type="button" use:moduleLocalize={{ text: cancelText }}>{cancelText}</button>
            <button class="btn btn-primary" onclick={handleSave} disabled={!canSave || busy} type="button">
                {#if busy}<span class="loading loading-spinner loading-sm"></span>{/if}
                <span use:localize>Speichern</span>
            </button>
        </div>
    </div>
    <form method="dialog" class="modal-backdrop">
        <button disabled={busy}>close</button>
    </form>
</dialog>
