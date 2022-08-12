<script>
    import SvelteTable from 'svelte-table';

    export let columns;
    /** @type {any[]} */
    export let rows;
    /** @type {string} */
    export let sortBy = '';
    /** @type {(string | number)[]} */
    export let expanded = [];
    /** @type {(string | number)[]} */
    export let selected = [];
    /** @type {string | null} */
    export let rowKey = null;
    /** @type {boolean} */
    export let expandSingle = false;
    /** @type {boolean} */
    export let selectSingle = false;
    /** @type {boolean} */
    export let selectOnClick = false;
    /** @type {boolean} */
    export let showExpandIcon = false;

    // Events
    /** @type {function | null} */
    export let clickCol = null;
    /** @type {function | null} */
    export let clickRow = null;
    /** @type {function | null} */
    export let clickExpand = null;
    /** @type {function | null} */
    export let clickCell = null;

    // CSS Classes
    export let classNameTable = 'border-2 border-collapse my-4';
    export let classNameThead = '';
    export let classNameTbody = '';
    export let classNameSelect = '';
    export let classNameInput = '';
    export let classNameRow = 'border-2 border-collapse odd:bg-gray-100 hover:bg-gray-300';
    export let classNameCell = '';
    export let classNameRowSelected = '!bg-gray-400';
    export let classNameRowExpanded = 'bg-gray-400';
    export let classNameExpandedContent = '';
    export let classNameCellExpand = '';

    const asStringArray = v =>
        []
        .concat(v)
        .filter(v => v !== null && typeof v === 'string' && v !== '')
        .join(' ');
</script>

<SvelteTable
    bind:columns
    bind:rows
    bind:sortBy
    bind:expanded
    bind:selected
    bind:rowKey
    bind:expandSingle
    bind:selectSingle
    bind:selectOnClick
    bind:showExpandIcon
    on:clickCol={clickCol}
    on:clickRow={clickRow}
    on:clickExpand={clickExpand}
    on:clickCell={clickCell}
    classNameTable={asStringArray(['gan-table', classNameTable])}
    classNameThead={asStringArray(['gan-thead', classNameThead])}
    classNameTbody={asStringArray(['gan-tbody', classNameTbody])}
    classNameSelect={asStringArray(['custom-select', classNameSelect])}
    classNameInput={asStringArray(['custom-input', classNameInput])}
    classNameRow={asStringArray(['gan-row', classNameRow])}
    classNameCell={asStringArray(['gan-cell', classNameCell])}
    classNameRowSelected={asStringArray(['row-selected', classNameRowSelected])}
    classNameRowExpanded={asStringArray(['row-expanded', classNameRowExpanded])}
    classNameExpandedContent={asStringArray(['expanded-content', classNameExpandedContent])}
    classNameCellExpand={asStringArray(['cell-expand', classNameCellExpand])}>

        <!-- Wait for better workaround. See: https://github.com/sveltejs/svelte/issues/5604 -->

        <!--<svelte:fragment slot="header" let:sortOrder let:sortBy>
            <slot name="header" {sortOrder} {sortBy}></slot>
        </svelte:fragment>

        {#if $$slots.row}
            <svelte:fragment slot="row" let:row let:n>
                <slot name="row" {row} {n}></slot>
            </svelte:fragment>
        {/if}-->

        <svelte:fragment slot="expanded" let:row let:n>
            <slot name="expanded" {row} {n} />
        </svelte:fragment>

    </SvelteTable>

<style>
    :global(.custom-select) {
        font-weight: 400;
        color: #495057;
        vertical-align: middle;
        border: 1px solid #ced4da;
        border-radius: .25rem;
    }

    :global(.custom-input) {
        font-weight: 400;
        color: #495057;
        vertical-align: middle;
        border: 1px solid #ced4da;
        border-radius: .25rem;
    }
</style>
