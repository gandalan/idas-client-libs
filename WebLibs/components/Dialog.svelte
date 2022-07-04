<script>
    export let isOpen = false;
</script>

{#if isOpen}
    <div class="z-10 absolute w-screen h-screen bg-black left-0 top-0 bg-opacity-50">        
    </div>

    <div class="z-10 absolute left-[20vw] top-[10vw] w-[60vw] shadow-xl shadow-slate-700 bg-white p-8">
        <div>
            <h3 class="text-lg font-bold mb-2"><slot name="title"/></h3>
        </div>
        <div>
            <slot />
        </div>
        <div class="mt-8">
            <button class="float-right bg-gray-600 text-white p-4" on:click={() => isOpen = false}>Schließen</button>
        </div>
    </div>
{/if}