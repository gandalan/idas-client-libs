<script>
    import { Button } from 'svelte-chota';
    import { mdiTrashCan } from '@mdi/js'
    
    export let Handler;
    export let disabled;
    export let title;
</script>

<Button error title={title} on:click={Handler} icon={mdiTrashCan} {disabled}>
</Button>
