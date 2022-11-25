import { RESTClient } from "./RESTClient";
import jwt_decode from "jwt-decode";

let appToken = localStorage.getItem("IDAS_AppToken") || "66B70E0B-F7C4-4829-B12A-18AD309E3970";
let authToken = localStorage.getItem("IDAS_AuthToken");
let apiBaseUrl = localStorage.getItem("IDAS_ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api/";
let authJwtCallbackPath = localStorage.getItem("IDAS_AuthJwtCallbackPath") || "";
let authJwtToken;

export let IDASFactory = {
    async create(settings = {
        appToken : localStorage.getItem("IDAS_AppToken"),
        mandantGuid : localStorage.getItem("IDAS_MandantGuid"),
        apiBaseurl : localStorage.getItem("IDAS_ApiBaseUrl"),
        jwtRefreshToken : localStorage.getItem("IDAS_AuthJwtRefreshToken"),
        jwtCallbackPath : localStorage.getItem("IDAS_AuthJwtCallbackPath")
      }) 
    {
        apiBaseUrl = settings.apiBaseurl;
        let idas = undefined;

        if (settings.jwtToken) // it is JWT
        { 
            console.log("init: with JWT token");
            idas = new IDAS();
            idas.initWithJWTtoken(settings.jwtToken);
        } 
        else if (settings.jwtRefreshToken) // it is authToken
        { 
            console.log("init: with refresh/classic token");
            let refreshClient = new RESTClient(apiBaseUrl, "");
            await refreshClient.refreshToken();
            idas = new IDAS();
            await idas.authenticateWithJwt(authJwtCallbackPath);
        }
        
        return idas;
    }
}

class IDAS 
{
    restClient = undefined;

    initWithJWTtoken(jwtToken) 
    {
        authJwtToken = jwtToken;
        this.restClient = new RESTClient(apiBaseUrl, jwtToken, true);
    }

    async authenticateWithJwt(authPath) 
    {
        let refreshClient = new RESTClient(apiBaseUrl, "");
        await refreshClient.checkRefreshToken(authJwtToken, () => {
            authJwtToken = undefined;
            // ... so repeat authenticate (should lead to /Session login page)
            new IDAS().authenticateWithJwt(authPath);
        });

        // still not valid JWT -> authenticate
        if (!refreshClient.token) {
            localStorage.setItem("IDAS_AuthJwtCallbackPath", authPath || "");
            const authEndpoint = (new URL(window.location.href).origin) + authPath;
            let authUrlCallback = `${authEndpoint}?r=%target%&j=%jwt%&m=%mandant%`;
            authUrlCallback = authUrlCallback.replace("%target%", encodeURIComponent(window.location.href));

            const url = new URL(apiBaseUrl);
            url.pathname = "/Session";
            url.search = `?a=${appToken}&r=${encodeURIComponent(authUrlCallback)}`;
            let jwtUrl = url.toString();

            window.location = jwtUrl;
        } else {
            this.initWithJWTtoken(refreshClient.token);
        }
    }

    mandantGuid = localStorage.getItem("IDAS_MandantGuid");

    claims = {
        hasClaim(key) {
            if (!authJwtToken) {
                return false;
            }

            try {
                let decoded = jwt_decode(authJwtToken);
                let val = decoded[key];
                return val !== undefined;
            // eslint-disable-next-line no-empty
            } catch {}

            return false;
        },

        getClaim(key) {
            if (!authJwtToken) {
                return;
            }

            try {
                let decoded = jwt_decode(authJwtToken);
                return decoded[key];
            // eslint-disable-next-line no-empty
            } catch {}

            return;
        },
    }

    auth = {
        _self: this,
        async getCurrentAuthToken() {
            return await this._self.restClient.put("/Login/Update/", { Token: authToken })
        },
    };

    mandanten = {
        _self: this,
        async getAll() {
            return await this._self.restClient.get("/Mandanten");
        },
        async get(guid) {
            return await this._self.restClient.get(`/Mandanten/${guid}`);
        },
        async save(m) {
            await this._self.restClient.put("/Mandanten", m);
        },
    };

    benutzer = {
        _self: this,
        async getAll(mandantGuid) {
            return await this._self.restClient.get(`/BenutzerListe/${mandantGuid }/?mitRollenUndRechten=true`);
        },
        async get(guid) {
            return await this._self.restClient.get(`/Benutzer/${guid}`);
        },
        async save(m) {
            await this._self.restClient.put("/Benutzer", m);
        },
    };

    feedback = {
        _self: this,
        async getAll() {
            return await this._self.restClient.get("/Feedback/");
        },
        async get(guid) {
            return await this._self.restClient.get(`/Feedback/${guid}`);
        },
        async save(m) {
            await this._self.restClient.put("/Feedback", m);
        },
        async comment(guid, commentData) {
            await this._self.restClient.put(`/FeedbackKommentar/${guid}`, commentData);
        },
        async attachFile(guid, filename, data) {
            await this._self.restClient.put(`/FeedbackAttachment/?feedbackGuid=${guid}&filename=${filename}`, data);
        },
        async deleteFile(guid) {
            await this._self.restClient.delete(`/FeedbackAttachment/${guid}`);
        },
    };

    rollen = {
        _self: this,
        async getAll() {
            return await this._self.restClient.get("/Rollen");
        },
        async save(m) {
            await this._self.restClient.put("/Rollen", m);
        },
    };

    vorgaenge = {
        _self: this,
        async getByVorgangsnummer(vorgangsNummer, jahr) {
            return await this._self.restClient.get(`/Vorgang/${vorgangsNummer}/${jahr}`);
        },
        async getByGuid(guid) {
            return await this._self.restClient.get(`/Vorgang/${guid}`);
        },
    };

    positionen = {
        _self: this,
        async getByPcode(pcode) {
            return await this._self.restClient.get(`/BelegPositionen/GetByPcode/${pcode}`);
        },
        async get(guid) {
            return await this._self.restClient.get(`/BelegPositionen/Get/${guid}`);
        },
    };
}
