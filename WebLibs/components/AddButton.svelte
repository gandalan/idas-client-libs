<script>
    import { Button } from 'svelte-chota';
    import { mdiMessageAlert } from '@mdi/js'
    
    export let Handler;
    export let disabled;
    export let title;
</script>

<Button primary outline title={title} on:click={Handler} icon={mdiMessageAlert} {disabled}>
    {title}
</Button>