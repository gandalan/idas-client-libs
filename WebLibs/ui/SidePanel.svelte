<script>
    import PanelPage from "./PanelPage.svelte";
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";

    /**
     * Drawer (#18053), übernommen aus dem IDASUserManager
     * (`IDAS/Source/Microservices/IDASUserManager/frontend/src/lib/components/SidePanel.svelte`):
     * Detailpanel rechts, schmal als Blatt von unten, auf nativem `<dialog>` —
     * Escape und Klick daneben schließen.
     *
     * - `busy` (z. B. beim Speichern): bleibt offen, damit die Antwort nicht
     *   ein später geöffnetes Panel schließt.
     * - Mit `header` und `footer` eine Seite (`PanelPage`), ohne sie bringt
     *   `children` eigene Seiten mit (Unterseiten im Panel).
     * - `onescape`: Escape führt dorthin statt das Panel zu schließen, z. B.
     *   von einer Unterseite zurück.
     * - `pinned`: schmal scrollt sonst das ganze Blatt samt Kopf; so bleibt der
     *   Kopf auch dort stehen.
     * - `oncancel` (m3-Ergänzung): X, Escape und Klick daneben schließen
     *   nicht selbst, sondern rufen diese Funktion — der Aufrufer kann z. B.
     *   erst nachfragen und setzt dann selbst `open = false`.
     *
     * Lage unter der Titelleiste der Shell (`--shell-titlebar-height`) und
     * Fly-in: Klasse `side-panel` in app.css. `font-sans` wie EditDialog: die
     * Schrift nicht aus dem Mount-Kontext erben.
     *
     * @type {{
     *   open: boolean,
     *   label: string,
     *   onclose: () => void,
     *   onescape?: () => void,
     *   oncancel?: () => void,
     *   busy?: boolean,
     *   scroll?: boolean,
     *   pinned?: boolean,
     *   header?: import("svelte").Snippet,
     *   children: import("svelte").Snippet,
     *   footer?: import("svelte").Snippet
     * }}
     */
    let { open, label, onclose, onescape, oncancel, busy = false, scroll = true, pinned = false, header, children, footer } = $props();

    /** @type {HTMLDialogElement | undefined} */
    let dialog = $state();

    $effect(() => {
        if (open && !dialog?.open) {
            dialog?.showModal();
        } else if (!open && dialog?.open) {
            dialog.close();
        }
    });

    /** @param {Event} e */
    function cancel(e) {
        if (busy || onescape || oncancel) {
            e.preventDefault();
        }
        if (!busy) {
            if (onescape) onescape();
            else oncancel?.();
        }
    }
</script>

<dialog
    bind:this={dialog}
    class="modal modal-bottom sm:modal-end side-panel font-sans"
    aria-label={label}
    use:moduleLocalize={{ attrs: { "aria-label": label } }}
    {onclose}
    oncancel={cancel}
>
    <!-- Abstand zur Shell: breit 1rem Luft oben und unten, rechts bündig am
         Rand, nur die linken Ecken gerundet; schmal ein Blatt von unten in voller
         Breite, höchstens 80 % hoch. `!`, weil die Lage-Regeln in app.css
         ungelayert sind. -->
    <div class="modal-box flex flex-col p-0 w-full sm:w-[35rem] sm:my-4 sm:h-[calc(100%-2rem)]! sm:max-h-[calc(100%-2rem)]! sm:rounded-l-box! sm:rounded-r-none! max-sm:h-auto! max-sm:max-h-[80%]! max-sm:max-w-none max-sm:rounded-t-box! max-sm:rounded-b-none! {pinned ? '' : 'max-sm:overflow-y-auto'}">
        {#if header && footer}
            <PanelPage {busy} {scroll} {pinned} {header} {footer} onclose={oncancel}>{@render children()}</PanelPage>
        {:else}
            {@render children()}
        {/if}
    </div>
    {#if oncancel}
        <div class="modal-backdrop"><button type="button" tabindex="-1" disabled={busy} onclick={oncancel} use:localize>Schließen</button></div>
    {:else}
        <form method="dialog" class="modal-backdrop"><button tabindex="-1" disabled={busy} use:localize>Schließen</button></form>
    {/if}
</dialog>
