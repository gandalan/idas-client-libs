import { get, writable } from "svelte/store";

export const APP_TOKEN = "66B70E0B-F7C4-4829-B12A-18AD309E3970";
export const AuthToken = writable(localStorage.getItem("AuthToken"));
export const MandantGuid = writable(localStorage.getItem("MandantGuid"));
export const ApiBaseUrl = writable(localStorage.getItem("ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api");
export const SiteBaseUrl = writable(window.location.protocol + "//" + window.location.host);
export const SSOAuthUrl = writable(get(ApiBaseUrl).replace("/api", "") + "/SSO?a=" + APP_TOKEN + "&r=%target%?t=%token%%26m=%mandant%");