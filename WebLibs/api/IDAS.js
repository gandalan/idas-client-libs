import { RESTClient } from "./RESTClient";

let appToken = localStorage.getItem("IDAS_AppToken") || "66B70E0B-F7C4-4829-B12A-18AD309E3970";
let authToken = localStorage.getItem("IDAS_AuthToken");
let apiBaseUrl = localStorage.getItem("IDAS_ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api/";

const url = new URL(apiBaseUrl);
url.pathname = "/SSO";
url.search = "?a=" + appToken + "&r=%target%%3Ft=%token%%26m=%mandant%";
let ssoAuthUrl = url.toString();

let restClient = new RESTClient(apiBaseUrl, authToken);
restClient.onError = (error, message) => {
    if (message.indexOf("401") || message.indexOf("403"))
    {    
        //console.log(message+" would remove Token");
        localStorage.removeItem("IDAS_AuthToken");
        var ssoURL = ssoAuthUrl.replace("%target%", encodeURIComponent(window.location.href));
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
            var ssoURL = ssoAuthUrl.replace("%target%", encodeURIComponent(window.location.href));
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

    feedback = {
        async getAll() { return await restClient.get("/Feedback/"); },
        async get(guid) { return await restClient.get("/Feedback/" + guid); },
        async save(m) { await restClient.put("/Feedback", m); },
        async comment(m) { await restClient.put("/FeedbackKommentar", m); },
        async attachFile(m) { await restClient.put("/FeedbackAttachment", m); },
        async deleteFile(guid) { await restClient.delete("/FeedbackAttachment/" + guid); }
    };

    rollen = {
        async getAll() { return await restClient.get("/Rollen"); },
        async save(m) { await restClient.put("/Rollen", m); }
    };
}