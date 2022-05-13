<script>
    import { createEventDispatcher } from 'svelte';
    const dispatch = createEventDispatcher();
    import { Icon } from 'svelte-chota';

    export let items = [];
    export let selectedItem = {};
    export let standardItem;
    export let displayProperty = "";
    export let header = "Überschrift";
    export let key = "Guid";
    export let marker = null;
    export let markerField = "";

    function setCurrent(item)
    {
        selectedItem = item;
        console.log(item);
        dispatch("selectedItemChanged", item);
    }
</script>

<div class="datagrid">    
    <div class="dgheader">
        {header}
    </div>
    <div>
        {#if standardItem}
        <div class="dgrow" on:click={setCurrent(standardItem)} class:selected="{selectedItem[key] === standardItem[key]}">{standardItem[displayProperty]}</div>
        {/if}
        {#each items as d}
        <div class="dgrow" on:click={setCurrent(d)} class:selected="{selectedItem[key] === d[key]}">
            {d[displayProperty]}
            {#if marker && markerField && d[markerField] === true}
            <Icon src={marker} />
            {/if}
        </div>
        {/each}
    </div>
</div>

<style>
.datagrid {
    border: 1px solid var(--color-darkGrey);
    background-color: var(--color-grey);
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    align-content: flex-start;
    cursor: pointer;
}

.dgheader {
    background-color: var(--color-grey);
    padding: 4px 4px 4px 8px;
    flex: 1;
}
 
.dgrow {
    margin-left: 8px;
    border-bottom: 1px solid var(--color-darkGrey);
    background-color: #fff;
    padding: 4px;
    flex: 1;
}

.selected {
    background-color: var(--color-selected); 
    color: var(--color-selected-text);    
}

</style>