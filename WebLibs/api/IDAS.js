import { isInvalid } from "./authUtils";
import { RESTClient } from "./RESTClient";
import jwt_decode from 'jwt-decode';

export function IDASFactory(settings)
{
    if (!isInvalid(settings))
    { 
        return new IDAS(settings);
    } 
    else throw("Invalid settings: call initIDAS() first to obtain a valid settings!");
}

class IDAS 
{
    restClient = undefined;
    mandantGuid = undefined;

    constructor(settings) 
    {
        this.settings = settings;
        this.mandantGuid = settings.mandantGuid; // for backwards compatiblity only
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
