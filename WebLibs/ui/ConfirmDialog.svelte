<script>
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";

    /**
     * Allgemeine Ja/Nein-Sicherheitsabfrage (Einheit X17) — Mechanik 1:1 von
     * `EditDialog.svelte` übernommen (natives `<dialog>`, `showModal()`/
     * `close()` über einen `$effect` auf das gebundene `open`, Schließen über
     * `onclose` statt an jeder einzelnen Stelle einzeln). Weiß bewusst nichts
     * über den Warenkorb oder irgendeinen anderen Aufrufer.
     *
     * Inhalt: `text` für den häufigen Fall eines einfachen Fragesatzes UND
     * ein optionales `children`-Snippet für reicheren Inhalt (z. B. mit
     * hervorgehobenen Werten oder mehreren Absätzen) — `children` hat
     * Vorrang, wenn übergeben. So bleiben simple Aufrufer (nur ein String)
     * knapp, ohne dass komplexere Fälle auf ein eigenes Snippet-Prop
     * ausweichen müssten.
     *
     * `onConfirm` wird nur nach einem expliziten "Ja"-Klick gerufen. "Nein",
     * Escape und ein Klick auf den Backdrop bedeuten alle dasselbe: abbrechen.
     * Alle drei Wege laufen — wie in EditDialog — durch den nativen
     * `onclose`-Handler des Dialogs (Escape und der Backdrop-`<form
     * method="dialog">` schließen den Dialog nativ; der "Nein"-Knopf setzt
     * nur `open = false`, was der `$effect` ebenfalls in ein `dialog.close()`
     * übersetzt). Der native `close`-Event feuert dabei IMMER, auch wenn
     * `dialog.close()` als Folge eines "Ja"-Klicks läuft — ohne
     * Gegenmaßnahme würde `onclose` dann zusätzlich zum "Ja"-Pfad feuern und
     * fälschlich auch `onCancel` auslösen. Deshalb merkt sich `handleConfirm` die
     * Aktion kurz im lokalen Flag `confirmed`, bevor es `open` auf false
     * setzt; `handleClose` liest das Flag einmalig aus und ruft je nach Wert
     * entweder `onConfirm` oder `onCancel` — nie beide, nie doppelt.
     *
     * Fokus liegt auf "Nein" (nicht auf "Ja", wie sonst bei EditDialog auf
     * dem primären Knopf): die Abfrage schützt gerade vor unbeabsichtigten,
     * teils zerstörerischen Aktionen — ein versehentliches Enter (z. B. nach
     * einem Tab-Sprung oder weil der Dialog kurz nach einer anderen Eingabe
     * aufgeht) darf nicht bestätigen, sondern abbrechen.
     *
     * `danger` stellt den "Ja"-Knopf in der destruktiven Optik dar
     * (`btn-error`, siehe WarenkorbReiter.svelte), Standard ist die normale
     * primäre Optik wie "Speichern" in EditDialog. Bewusst ein einzelnes
     * Bool-Prop statt eines Farbsystems — die Komponente kennt nur "normale"
     * und "gefährliche" Aktionen.
     *
     * `confirmText`/`cancelText` (#16600) überschreiben die Beschriftung der beiden
     * Knöpfe für Aufrufer, denen "Ja"/"Nein" zu unspezifisch ist (z. B.
     * "Buchen"/"Abbrechen"). Deutscher Quelltext wie `title`, die Komponente
     * übersetzt selbst per `use:localize`; ohne Angabe bleibt es bei "Ja"/
     * "Nein".
     * @type {{ open: boolean, title: string, text?: string, onConfirm: () => void, onCancel?: () => void, danger?: boolean, confirmText?: string, cancelText?: string, children?: import('svelte').Snippet }}
     */
    // title/text: deutscher Quelltext, die Komponente übersetzt selbst per
    // use:localize (siehe Progress.svelte) — Aufrufer übergeben Deutsch.
    let {
        open = $bindable(),
        title,
        text = '',
        onConfirm,
        onCancel,
        danger = false,
        confirmText = 'Ja',
        cancelText = 'Nein',
        children
    } = $props();

    /** @type {HTMLDialogElement | null} */
    let dialog = $state(null);

    const uid = $props.id();

    // Siehe Doc-Kommentar oben: unterscheidet im gemeinsamen `handleClose`
    // (native `close`-Event) zwischen dem "Ja"-Pfad und allen Abbruch-Wegen.
    let confirmed = false;

    $effect(() => {
        if (!dialog) return;
        if (open && !dialog.open) dialog.showModal();
        else if (!open && dialog.open) dialog.close();
    });

    function handleClose() {
        open = false;
        if (confirmed) {
            confirmed = false;
            onConfirm();
        } else {
            onCancel?.();
        }
    }

    function handleCancel() {
        open = false;
    }

    function handleConfirm() {
        confirmed = true;
        open = false;
    }
</script>

<dialog
    bind:this={dialog}
    class="modal font-sans"
    onclose={handleClose}
    aria-labelledby="{uid}-title"
    aria-describedby="{uid}-inhalt"
>
    <div class="modal-box">
        <h3 id="{uid}-title" class="text-lg font-bold mb-4" use:moduleLocalize={{ text: title }}>{title}</h3>
        <div id="{uid}-inhalt" class="flex flex-col gap-3">
            {#if children}
                {@render children()}
            {:else}
                <p use:moduleLocalize={{ text }}>{text}</p>
            {/if}
        </div>
        <!-- flex-wrap (#16600): lange Knopftexte (confirmText/cancelText, Übersetzungen)
             brechen auf schmalen Bildschirmen in eine zweite Zeile um, statt
             aus der Modal-Box zu ragen; solange Platz ist, unverändert. -->
        <div class="modal-action flex-wrap">
            <!-- svelte-ignore a11y_autofocus -->
            <button class="btn btn-ghost" onclick={handleCancel} type="button" autofocus use:moduleLocalize={{ text: cancelText }}>{cancelText}</button>
            <button class="btn {danger ? 'btn-error' : 'btn-primary'}" onclick={handleConfirm} type="button" use:moduleLocalize={{ text: confirmText }}>{confirmText}</button>
        </div>
    </div>
    <form method="dialog" class="modal-backdrop">
        <button>close</button>
    </form>
</dialog>
