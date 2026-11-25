<script>
    import { onMount } from 'svelte';
    import Tabs from './Tabs.svelte';
    import { uiLocalize as localize, moduleLocalize } from "./lib/i18n.svelte.js";

    /**
     * @typedef {Object} Tab
     * @property {string} id - Eindeutige ID des Tabs (wird für die Route verwendet)
     * @property {string} name - Anzeigename des Tabs; deutscher Quelltext, die
     *   Komponente übersetzt selbst per use:localize (siehe Progress.svelte)
     * @property {import('svelte').Component} [component] - Die Svelte-Komponente
     *   für diesen Tab (entfällt bei einer Gruppe)
     * @property {Tab[]} [tabs] - Unterreiter: statt `component` bildet der Tab
     *   eine Gruppe, die sich als zweite, schlankere Reiterebene unter
     *   `${basePath}/${id}/<unter>` rendert. Bei genau einem Unterreiter
     *   entfällt die Unterleiste.
     */

    /** @type {{ tabs: Tab[], basePath: string, nested?: boolean, redirects?: Record<string, string> }} */
    let { tabs, basePath, nested = false, redirects = {} } = $props();

    /** @type {string} */
    let currentTabId = $state('');

    /** @type {Record<string, string>} */
    let queryParams = $state({});

    /** @type {Tab | undefined} */
    let currentTab = $derived(tabs.find(t => t.id === currentTabId));

    // Unterleiste nur ab zwei Unterreitern (nested: eine Gruppe mit einem
    // einzigen Unterreiter zeigt direkt dessen Inhalt).
    let showBar = $derived(!(nested && tabs.length < 2));

    /**
     * Parst die Query-Parameter aus dem Hash
     * @param {string} hash
     * @returns {Record<string, string>}
     */
    function parseQueryParams(hash) {
        const queryIndex = hash.indexOf('?');
        if (queryIndex === -1) {
            return {};
        }
        
        const queryString = hash.slice(queryIndex + 1);
        const params = new URLSearchParams(queryString);
        /** @type {Record<string, string>} */
        const result = {};
        
        for (const [key, value] of params) {
            result[key] = value;
        }
        
        return result;
    }

    /**
     * Extrahiert den Tab-ID aus der aktuellen Hash-URL (ohne Query-Parameter)
     * @returns {string}
     */
    function getTabIdFromHash() {
        const hash = window.location.hash;
        const prefix = basePath + '/';
        
        // Query-Parameter entfernen für die Tab-Ermittlung
        const hashWithoutQuery = hash.split('?')[0];
        
        if (hashWithoutQuery.startsWith(prefix)) {
            // Nur das erste Segment: weitere gehören der Unterebene.
            const first = hashWithoutQuery.slice(prefix.length).split('/')[0];
            return tabs.some(t => t.id === first) ? first : (tabs[0]?.id || '');
        }
        
        // Wenn nur der basePath ohne Tab angegeben ist, ersten Tab verwenden
        if (hashWithoutQuery === basePath) {
            return tabs[0]?.id || '';
        }
        
        // Fallback: ersten Tab verwenden
        return tabs[0]?.id || '';
    }

    /**
     * Aktualisiert die URL beim Tab-Wechsel
     * @param {string} tabId
     */
    function navigateToTab(tabId) {
        const newHash = `${basePath}/${tabId}`;
        if (window.location.hash !== newHash) {
            window.location.hash = newHash;
        }
    }

    /**
     * Leitet alte Adressen (Schlüssel in `redirects`, relativ zum basePath)
     * per replaceState um; Query-Parameter bleiben erhalten. Nur oberste Ebene.
     */
    function applyRedirects() {
        if (nested) return;
        const hash = window.location.hash;
        const qi = hash.indexOf('?');
        const path = qi === -1 ? hash : hash.slice(0, qi);
        const query = qi === -1 ? '' : hash.slice(qi);
        const prefix = basePath + '/';
        if (!path.startsWith(prefix)) return;
        const target = redirects[path.slice(prefix.length)];
        if (target) {
            history.replaceState(history.state, '', `${basePath}/${target}${query}`);
        }
    }

    /**
     * Steht nur der basePath ohne Tab in der Adresse, wird sie per
     * replaceState auf den angezeigten (ersten) Tab vervollständigt — beim
     * Mounten wie bei jeder Hash-Änderung. Letzteres braucht die Unterebene
     * (#17300): ein Klick auf den bereits aktiven Gruppenreiter setzt
     * `…/lager`, die Gruppe bleibt gemountet und zeigt ihren ersten
     * Unterreiter — ohne Normalisierung bliebe die Adresse unvollständig.
     * @param {string} tabId
     */
    function vervollstaendigeAdresse(tabId) {
        const hashWithoutQuery = window.location.hash.split('?')[0];
        if (hashWithoutQuery === basePath && tabId) {
            history.replaceState(history.state, '', `${basePath}/${tabId}${window.location.hash.slice(hashWithoutQuery.length)}`);
        }
    }

    /**
     * Handler für Hash-Änderungen
     */
    function handleHashChange() {
        applyRedirects();
        currentTabId = getTabIdFromHash();
        vervollstaendigeAdresse(currentTabId);
        queryParams = parseQueryParams(window.location.hash);
    }

    onMount(() => {
        applyRedirects();
        // Initialen Tab aus URL laden
        const tabId = getTabIdFromHash();
        currentTabId = tabId;
        queryParams = parseQueryParams(window.location.hash);
        vervollstaendigeAdresse(tabId);
        
        // Auf Hash-Änderungen hören
        window.addEventListener('hashchange', handleHashChange);
        
        return () => {
            window.removeEventListener('hashchange', handleHashChange);
        };
    });
</script>

<!-- Höhenkette (#16600): in isCompact (< 48rem) scrollt die Seite statt des
     Reiterinhalts — Wurzel und Inhaltsbereich geben ihre Resthöhe und ihr
     Clipping frei, sonst klebt die Aktionsleiste der Reiter nicht unten
     (sticky braucht Vorfahren ohne overflow ≠ visible). Die Unterebene
     (nested) übernimmt dieselbe Kette. -->
<div class="flex flex-col overflow-hidden h-full @max-3xl/content:h-auto @max-3xl/content:overflow-visible">
    <!-- Umschaltung Reiter/Auswahlliste am Container `content` statt am
         Viewport (#16600): Reiter ab 48rem (mittel/breit), darunter eine
         Auswahlliste. Bewusst nicht die Shell-Schwelle @2xl und keine
         waagerecht scrollende Reiterleiste: die reinen Textreiter der
         Stammdaten brauchen zusammen ~800–930 px — bei 390 px wie bei 750 px
         Inhaltsbreite wäre der Großteil hinter dem Rand versteckt und nur
         durch Wischen auffindbar, die Auswahlliste zeigt dagegen alle
         Bereiche mit einem Tipp. Mittel verdichtet das Padding und scrollt
         nur als Rückfallebene. -->
    <!-- Kompakt (#16600): die Shell polstert den Modulbereich auf dem Handy
         nicht mehr (`#container p-0 sm:p-4`), und die Auswahlliste liegt
         außerhalb der `p-4` der Reiterinhalte — deshalb hier dieselben
         Seitenabstände; der Inhaltsbereich verzichtet dafür auf sein `mt-4`,
         weil die `p-4` des Reiters den Abstand schon stellt. Die Unterleiste
         (#17300) ist kleiner (text-sm, dünnerer Balken, Trennlinie) und hat
         auf schmalen Breiten ein zweites, kleines Auswahlfeld. -->
    {#if showBar}
        <nav class={nested ? '@max-3xl/content:px-4 @max-3xl/content:pt-2' : '@max-3xl/content:px-4 @max-3xl/content:pt-4'}>
            <div
                class="hidden @3xl/content:flex @3xl/content:@max-5xl/content:overflow-x-auto {nested ? 'border-b border-base-300 px-4 text-sm' : ''}"
                role="tablist"
            >
                {#each tabs as tab (tab.id)}
                    <button
                        type="button"
                        role="tab"
                        aria-selected={currentTabId === tab.id}
                        class="rounded-none bg-transparent transition-colors hover:bg-base-200 @3xl/content:@max-5xl/content:shrink-0 @3xl/content:@max-5xl/content:whitespace-nowrap {nested ? 'px-3 py-1 @3xl/content:@max-5xl/content:px-2' : 'p-2 px-4 @3xl/content:@max-5xl/content:px-3'}"
                        class:border-b-[3px]={!nested && currentTabId === tab.id}
                        class:border-b-2={nested && currentTabId === tab.id}
                        class:border-b-action={currentTabId === tab.id}
                        class:text-secondary={currentTabId === tab.id}
                        class:cursor-pointer={currentTabId !== tab.id}
                        onclick={() => navigateToTab(tab.id)}
                        use:moduleLocalize={{ text: tab.name }}
                    >
                        {tab.name}
                    </button>
                {/each}
            </div>

            <select
                class="select w-full @3xl/content:hidden {nested ? 'select-sm' : ''}"
                value={currentTabId}
                aria-label="Bereich"
                use:localize={{ attrs: { 'aria-label': 'Bereich' } }}
                onchange={(e) => {
                    const target = /** @type {HTMLSelectElement} */ (e.target);
                    navigateToTab(target.value);
                }}
            >
                {#each tabs as tab (tab.id)}
                    <option value={tab.id} use:moduleLocalize={{ text: tab.name }}>{tab.name}</option>
                {/each}
            </select>
        </nav>
    {/if}

    <div class="{nested ? 'mt-0' : 'mt-4'} flex-1 min-h-0 overflow-auto @max-3xl/content:mt-0 @max-3xl/content:flex-none @max-3xl/content:overflow-visible">
        {#if currentTab?.tabs}
            {#key currentTab.id}
                <Tabs tabs={currentTab.tabs} basePath={`${basePath}/${currentTab.id}`} nested={true} />
            {/key}
        {:else if currentTab?.component}
            <currentTab.component {...queryParams} />
        {/if}
    </div>
</div>
