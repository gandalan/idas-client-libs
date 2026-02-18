/**
 * UI Components module for WebLibs
 * @module @gandalan/weblibs/ui
 * @description
 * This module exports Svelte UI components for use in Gandalan applications.
 * Currently includes the Grid component for displaying tabular data.
 * 
 * @example
 * import { Grid } from "@gandalan/weblibs/ui";
 * 
 * // In a Svelte component:
 * <Grid data={myData} columns={myColumns} />
 */

import Grid from "./Grid.svelte";

/**
 * Grid component for displaying tabular data
 * @type {import('svelte').ComponentType}
 * @export
 */
export { Grid };
