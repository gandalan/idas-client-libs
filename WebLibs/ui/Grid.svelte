<!-- <script>
    let {
        data,
        hideCols = [],
        onclick=(row, col) => {},
        dataCell = defaultDataCell,
        headerCell = defaultHeaderCell
    } = $props();
</script>

{#if data.length}
<table class="w-full">
    <thead>
        <tr>
            {#each Object.keys(data[0]) as key}
            {#if hideCols.indexOf(key) === -1}
            <th>{@render headerCell(key)}</th>
            {/if}
            {/each}
        </tr>
    </thead>
    <tbody class="overflow-auto">
        {#each data as row}
        <tr class="hover:bg-gray-300" class:cursor-pointer={onclick}>
            {#each Object.keys(data[0]) as key}
            {#if hideCols.indexOf(key) === -1}
            <td onclick={(e) => { e.preventDefault(); onclick(row, key); }}>{@render dataCell(row[key])}</td>
            {/if}
            {/each}
        </tr>
        {/each}
    </tbody>
</table>
{:else}
<progress>Loading</progress>
{/if}

{#snippet defaultHeaderCell(content)}
<b>{content}</b>
{/snippet}

{#snippet defaultDataCell(content)}
{content}
{/snippet} -->
