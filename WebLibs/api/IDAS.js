import { jwtTokenInvalid } from "./authUtils";
import { RESTClient } from "./RESTClient";

export function IDASFactory(settings = {
        appToken : localStorage.getItem("IDAS_AppToken"),
        mandantGuid : localStorage.getItem("IDAS_MandantGuid"),
        apiBaseurl : localStorage.getItem("IDAS_ApiBaseUrl"),
        jwtRefreshToken : localStorage.getItem("IDAS_AuthJwtRefreshToken"),
        jwtCallbackPath : localStorage.getItem("IDAS_AuthJwtCallbackPath")
      }) 
{
    let idas = undefined;
    if (!jwtTokenInvalid(settings)) 
    { 
        console.log("init: with JWT token");
        idas = new IDAS(settings);
    } 
    else throw("Invalid settings: call setup first to obtain a valid JWT token!");
    return idas;
}

class IDAS 
{
    restClient = undefined;
    mandantGuid = localStorage.getItem("IDAS_MandantGuid");

    constructor(settings) 
    {
        this.settings = settings;
        this.restClient = new RESTClient(settings);
    }

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
