import { get, writable } from "svelte/store";
import { RESTClient } from "./RESTClient";

export const APP_TOKEN = "66B70E0B-F7C4-4829-B12A-18AD309E3970";
export const AuthToken = writable(localStorage.getItem("AuthToken"));
export const MandantGuid = writable(localStorage.getItem("MandantGuid"));
export const ApiBaseUrl = writable(localStorage.getItem("ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api");
export const SiteBaseUrl = writable(window.location.protocol + "//" + window.location.host);
export const SSOAuthUrl = writable(get(ApiBaseUrl).replace("/api", "") + "/SSO?a=" + APP_TOKEN + "&r=%target%?t=%token%%26m=%mandant%");

export class IDAS 
{
    authToken = {};
    api = new RESTClient(get(ApiBaseUrl), get(AuthToken));

    async authenticate(authDTO) { 
        var { data } = await this.api.post("/Login/Authenticate", authDTO); 
        this.authToken = data;
        return data;
    }

    async authenticateWithSSO() { 
        var ssoURL = get(SSOAuthUrl).replace("%target%", get(SiteBaseUrl)).replace("%mandant%", get(MandantGuid));
        window.location = ssoURL;
    }

    mandanten = {
        async getAll() { return await this.api.get("/Mandanten"); },
        async save(m) { await this.api.put("/Mandanten", m); }
    };

    benutzer = {
        async getAll() { return await this.api.get("/Benutzer"); },
        async save(m) { await this.api.put("/Benutzer", m); }
    };

    rollen = {
        async getAll() { return await this.api.get("/Rollen"); },
        async save(m) { await this.api.put("/Rollen", m); }
    };
}