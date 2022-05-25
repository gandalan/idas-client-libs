import { get, writable } from "svelte/store";
import { RESTClient } from "./RESTClient";

let appToken = localStorage.getItem("IDAS_AppToken") || "66B70E0B-F7C4-4829-B12A-18AD309E3970";
let authToken = localStorage.getItem("IDAS_AuthToken");
let mandantGuid = localStorage.getItem("IDAS_MandantGuid");
let apiBaseUrl = localStorage.getItem("IDAS_ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api";
let siteBaseUrl = localStorage.get("SiteBaseUrl") || window.location.protocol + "//" + window.location.host;
let ssoAuthUrl = apiBaseUrl.replace("/api", "") + "/SSO?a=" + appToken + "&r=%target%?t=%token%%26m=%mandant%";
let restClient = new RESTClient(apiBaseUrl, authToken);

export class IDAS 
{
    async authenticate(authDTO) { 
        authDTO.AppToken = appToken;
        var { data } = await restClient.post("/Login/Authenticate", authDTO); 
        if (data?.Token)
        {
            authToken = data.Token;
            restClient = new RESTClient(apiBaseUrl, authToken);
        }
        return data;
    }

    async authenticateWithSSO() { 
        var ssoURL = get(ssoAuthUrl).replace("%target%", get(siteBaseUrl)).replace("%mandant%", get(mandantGuid));
        window.location = ssoURL;
    }

    mandanten = {
        async getAll() { return await restClient.get("/Mandanten"); },
        async save(m) { await restClient.put("/Mandanten", m); }
    };

    benutzer = {
        async getAll() { return await restClient.get("/BenutzerListe"); },
        async get(guid) { return await restClient.get("/Benutzer/" + guid); },
        async save(m) { await restClient.put("/Benutzer", m); }
    };

    rollen = {
        async getAll() { return await restClient.get("/Rollen"); },
        async save(m) { await restClient.put("/Rollen", m); }
    };
}