<script>
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";

    // label/ariaLabel: deutscher Quelltext, die Komponente übersetzt selbst
    // per use:localize (siehe Progress.svelte) — Aufrufer übergeben Deutsch.
    /** @type {{ label: string, ariaLabel?: string }} */
    let { label, ariaLabel } = $props();
</script>

<!-- Abdunklung ist bewusst themeunabhängig dunkel, kein Theme-Token -->
<div
    class="fixed inset-0 z-50 flex items-center justify-center bg-black/40"
    role="dialog"
    aria-modal="true"
    aria-label={ariaLabel ?? label}
    use:moduleLocalize={{ attrs: { 'aria-label': ariaLabel ?? label } }}
>
    <!-- Kompakt (#16600): px-24 + text-xl-Label wären auf 390 px breiter als
         der Bildschirm — Innenabstand verkleinern, Rand lassen, Text umbrechen. -->
    <div class="bg-base-100 rounded-lg shadow-xl border border-base-300 flex flex-col items-center gap-6 py-16 px-24 @max-3xl/content:mx-4 @max-3xl/content:py-10 @max-3xl/content:px-8 @max-3xl/content:text-center">
        <span class="loading loading-spinner loading-lg text-primary" style="width:4rem;height:4rem"></span>
        <span class="text-xl font-medium" use:moduleLocalize={{ text: label }}>{label}</span>
    </div>
</div>
