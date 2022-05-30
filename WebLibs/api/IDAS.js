import { RESTClient } from "./RESTClient";

if (window.location.search) {
    var urlParams = new URLSearchParams(location.search);
    if (urlParams.has("t")) 
        localStorage.setItem("IDAS_AuthToken", urlParams.get("t"));
    if (urlParams.has("m")) 
        localStorage.setItem("IDAS_MandantGuid", urlParams.get("m"));
    if (urlParams.has("a")) 	
        localStorage.setItem("IDAS_ApiBaseUrl", urlParams.get("a"));
    window.location = window.location.origin;
}

let appToken = localStorage.getItem("IDAS_AppToken") || "66B70E0B-F7C4-4829-B12A-18AD309E3970";
let authToken = localStorage.getItem("IDAS_AuthToken");
//let mandantGuid = localStorage.getItem("IDAS_MandantGuid");
let apiBaseUrl = localStorage.getItem("IDAS_ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api";
//let siteBaseUrl = localStorage.getItem("SiteBaseUrl") || window.location.protocol + "//" + window.location.host;
let ssoAuthUrl = apiBaseUrl.replace(/\/api$/, "") + "/SSO?a=" + appToken + "&r=%target%?t=%token%%26m=%mandant%";
let restClient = new RESTClient(apiBaseUrl, authToken);
restClient.onError = (error, message) => {
    if (message.indexOf("401") || message.indexOf("403"))
    {    
        //console.log(message+" would remove Token");
        localStorage.removeItem("IDAS_AuthToken");
        var ssoURL = ssoAuthUrl.replace("%target%", window.location.origin);
        window.location = ssoURL;
    }
}

export class IDAS 
{
    async authenticate(authDTO) { 
        authDTO.AppToken = appToken;
        var { data } = await restClient.post("/Login/Authenticate", authDTO); 
        console.log(data);
        if (data?.Token)
        {
            authToken = data.Token;
            localStorage.setItem("IDAS_AuthToken", authToken);
            restClient = new RESTClient(apiBaseUrl, authToken);
        }
        return data;
    }

    async authenticateWithSSO() { 
        if (!authToken)
        {
            var ssoURL = ssoAuthUrl.replace("%target%", window.location.origin);
            window.location = ssoURL;
        }
    }

    mandantGuid = localStorage.getItem("IDAS_MandantGuid");

    mandanten = {
        async getAll() { return await restClient.get("/Mandanten"); },
        async get(guid) { return await restClient.get("/Mandanten/" + guid); },
        async save(m) { await restClient.put("/Mandanten", m); }
    };

    benutzer = {
        async getAll(mandantGuid) { return await restClient.get("/BenutzerListe/" + mandantGuid + "/?mitRollenUndRechten=true"); },
        async get(guid) { return await restClient.get("/Benutzer/" + guid); },
        async save(m) { await restClient.put("/Benutzer", m); }
    };

    rollen = {
        async getAll() { return await restClient.get("/Rollen"); },
        async save(m) { await restClient.put("/Rollen", m); }
    };
}