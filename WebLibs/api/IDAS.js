import { jwtTokenInvalid } from "./authUtils";
import { RESTClient } from "./RESTClient";
import jwt_decode from 'jwt-decode';

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

    auth = {
        _self: this,
        getCurrentAuthToken() {
            return this._self.settings.jwtToken;
        },
        getRights() {
            const token = this._self.settings.jwtToken;
            if (!token)
                return [];
            const decoded = jwt_decode(token);
            return decoded.rights;
        },
        getRoles() {
            const token = this._self.settings.jwtToken;
            if (!token)
                return [];
            const decoded = jwt_decode(token);
            return decoded.role;
        },
        hasRight(code)
        {
            return this.getRights().some(r => r === code);
        },
        hasRole(code)
        {
            return this.getRoles().some(r => r === code);
        },
        getUsername() {
            const token = this._self.settings.jwtToken;
            if (!token)
                return undefined;
            const decoded = jwt_decode(token);
            return decoded.id;
        }
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
