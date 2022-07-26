<script>
    import SvelteTable from "svelte-table";

    export let columns;
    /** @type {any[]} */
    export let rows;
    /** @type {string} */
    export let sortBy = "";
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
    classNameTable="gan-table border-2 border-collapse mt-4 mb-4"
    classNameThead="gan-thead"
    classNameTbody="gan-tbody"
    classNameSelect="custom-select"
    classNameInput="custom-input"
    classNameRow="gan-row border-2 border-collapse cursor-pointer odd:bg-gray-100 hover:bg-gray-300"
    classNameCell="gan-cell pr-4"
    classNameRowSelected="row-selected !bg-gray-400"
    classNameRowExpanded="row-expanded bg-gray-400"
    classNameExpandedContent="expanded-content"
    classNameCellExpand="cell-expand">

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
