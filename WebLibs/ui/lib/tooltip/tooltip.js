// Svelte-Action für einfache Text-Tooltips (Ticket 15879):
//
//     <button use:tooltip={'Hilfetext'}>…</button>
//     <button use:tooltip={{ text: 'Hilfetext', placement: 'bottom' }}>…</button>
//
// Rendert dieselbe TooltipBubble wie die Tooltip-Komponente. Die Blase wird in
// den Root des Ankers gemountet (ShadowRoot des Moduls bzw. document.body im
// Dev-Harness), damit die Theme-Styles greifen und kein Portal nötig ist.
// Für Rich-Content (Snippets) die Komponente ./Tooltip.svelte nehmen.

import { mount, unmount } from "svelte";
import TooltipBubble from "./TooltipBubble.svelte";

/**
 * Wohin die Blase gemountet wird: in den Root des Ankers — liegt der Anker
 * aber in einem geöffneten `<dialog>`, in diesen Dialog. Ein modaler Dialog
 * liegt im Top-Layer; eine Blase im Root läge trotz z-50 unsichtbar dahinter
 * (#16410, Hinweis-Icon im Bestelldialog). Der Dialog selbst (daisyUI
 * `.modal`: fixed, inset 0, ohne Transform) taugt als Bezug für die
 * `position: fixed` der Blase — die `.modal-box` nicht, ihr `translate`
 * machte sie zum Bezugsrahmen.
 * @param {Element} anker
 * @returns {Element | ShadowRoot}
 */
export function bubbleTarget(anker) {
    const dialog = anker.closest("dialog[open]");
    if (dialog) return dialog;
    const root = anker.getRootNode();
    return root instanceof ShadowRoot ? root : document.body;
}

/**
 * @typedef {Object} TooltipOptions
 * @property {string} text
 * @property {'top' | 'bottom'} [placement]
 * @property {string} [maxWidth]
 * @property {number} [openDelay]
 * @property {number} [closeDelay]
 */

/** @param {string | TooltipOptions | null | undefined} param */
function normalize(param) {
    const o = typeof param === "string" ? { text: param } : (param ?? { text: "" });
    return {
        text: o.text ?? "",
        placement: o.placement ?? /** @type {'top'} */ ("top"),
        maxWidth: o.maxWidth ?? "max-w-xs",
        openDelay: o.openDelay ?? 200,
        closeDelay: o.closeDelay ?? 250
    };
}

/**
 * @param {HTMLElement} node
 * @param {string | TooltipOptions} param
 */
export function tooltip(node, param) {
    let opts = normalize(param);
    /** @type {Record<string, any> | null} */
    let instance = null;
    let openTimer = 0;
    let closeTimer = 0;

    function mountTarget() {
        return bubbleTarget(node);
    }

    function show() {
        if (instance || !opts.text) return;
        instance = mount(TooltipBubble, {
            target: mountTarget(),
            props: {
                anchor: node,
                text: opts.text,
                placement: opts.placement,
                maxWidth: opts.maxWidth,
                onenter: cancelClose,
                onleave: scheduleClose,
                onclose: hide
            }
        });
    }

    function hide() {
        clearTimeout(openTimer);
        clearTimeout(closeTimer);
        if (instance) {
            unmount(instance);
            instance = null;
        }
    }

    function scheduleOpen() {
        clearTimeout(closeTimer);
        clearTimeout(openTimer);
        openTimer = setTimeout(show, opts.openDelay);
    }

    function cancelClose() {
        clearTimeout(closeTimer);
    }

    function scheduleClose() {
        clearTimeout(openTimer);
        clearTimeout(closeTimer);
        closeTimer = setTimeout(hide, opts.closeDelay);
    }

    node.addEventListener("mouseenter", scheduleOpen);
    node.addEventListener("mouseleave", scheduleClose);
    node.addEventListener("focusin", scheduleOpen);
    node.addEventListener("focusout", scheduleClose);

    return {
        /** @param {string | TooltipOptions} p */
        update(p) {
            opts = normalize(p);
        },
        destroy() {
            hide();
            node.removeEventListener("mouseenter", scheduleOpen);
            node.removeEventListener("mouseleave", scheduleClose);
            node.removeEventListener("focusin", scheduleOpen);
            node.removeEventListener("focusout", scheduleClose);
        }
    };
}
