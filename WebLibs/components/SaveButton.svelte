<script>
    import { Button } from 'svelte-chota';
    import { mdiCheck } from '@mdi/js'
    
    export let Handler;
    export let disabled;
    export let title;
</script>

<Button primary title={title} on:click={Handler} icon={mdiCheck} {disabled}>
    {title}
</Button>
