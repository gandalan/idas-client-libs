import { RESTClient } from './RESTClient';

let appToken = localStorage.getItem('IDAS_AppToken') || '66B70E0B-F7C4-4829-B12A-18AD309E3970';
let authToken = localStorage.getItem('IDAS_AuthToken');
let authJwtToken = localStorage.getItem('IDAS_AuthJwtToken');
let apiBaseUrl = localStorage.getItem('IDAS_ApiBaseUrl') || 'https://api.dev.idas-cloudservices.net/api/';
let authJwtCallbackPath = localStorage.getItem('IDAS_AuthJwtCallbackPath') || '/auth/';

let restClient = new RESTClient(apiBaseUrl, authToken);
restClient.onError = (error, message) => {
    if (message.indexOf("401") != -1 || message.indexOf("403") != -1) {
        localStorage.removeItem('IDAS_AuthToken');
        localStorage.removeItem('IDAS_AuthJwtToken');
        if (restClient.isJWT) {
            new IDAS().authenticateWithJwt(authJwtCallbackPath);
        } else {
            new IDAS().authenticateWithSSO(true);
        }
    }
}

export class IDAS {
    async authenticate(authDTO) {
        authDTO.AppToken = appToken;
        let { data } = await restClient.post('/Login/Authenticate', authDTO);
        if (data?.Token) {
            authToken = data.Token;
            localStorage.setItem('IDAS_AuthToken', authToken);
            restClient = new RESTClient(apiBaseUrl, authToken);
        }
        return data;
    }

    authorizeWithJwt(jwtToken, mandant = '') {
        localStorage.setItem('IDAS_AuthJwtToken', jwtToken);
        mandant && localStorage.setItem('IDAS_MandantGuid', mandant);
        restClient = new RESTClient(apiBaseUrl, jwtToken, true);
    }

    async authenticateWithSSO(forceRenew = false) { 
        return new Promise((resolve, reject) => {
            if (!authToken) {
                const url = new URL(apiBaseUrl);
                url.pathname = "/SSO";
                url.search = "?a=" + appToken;
                if (forceRenew) {
                    url.search = url.search + "&forceRenew=true";
                }
                    
                url.search = url.search + "&r=%target%%3Ft=%token%%26m=%mandant%";
                let ssoAuthUrl = url.toString();

                var ssoURL = ssoAuthUrl.replace("%target%", encodeURIComponent(window.location.href));
                window.location = ssoURL;
                reject('not authenticated yet');
            } else {
                resolve(restClient);
            }
        });
    }

    async authenticateWithJwt(authPath) {
        return new Promise((resolve, reject) => {
            if (!authJwtToken) {
                localStorage.setItem('IDAS_AuthJwtCallbackPath', authPath);
                const authEndpoint = (new URL(window.location.href).origin) + authPath;
                let authUrlCallback = `${authEndpoint}?r=%target%&t=%jwt%&m=%mandant%`;
                authUrlCallback = authUrlCallback.replace('%target%', encodeURIComponent(window.location.href));
    
                const url = new URL(apiBaseUrl);
                url.pathname = "/Session";
                url.search = `?a=${appToken}&r=${encodeURIComponent(authUrlCallback)}`;
                let jwtUrl = url.toString();
    
                window.location = jwtUrl;
                reject('not authenticated yet');
            } else {
                restClient = new RESTClient(apiBaseUrl, authJwtToken, true);
                resolve(restClient);
            }    
        });
    }

    mandantGuid = localStorage.getItem('IDAS_MandantGuid');

    auth = {
        async getCurrentAuthToken() {
            return await restClient.put('/Login/Update/', { Token: authToken })
        },
    };

    mandanten = {
        async getAll() {
            return await restClient.get('/Mandanten');
        },
        async get(guid) {
            return await restClient.get(`/Mandanten/${guid}`);
        },
        async save(m) {
            await restClient.put('/Mandanten', m);
        },
    };

    benutzer = {
        async getAll(mandantGuid) {
            return await restClient.get(`/BenutzerListe/${mandantGuid }/?mitRollenUndRechten=true`);
        },
        async get(guid) {
            return await restClient.get(`/Benutzer/${guid}`);
        },
        async save(m) {
            await restClient.put('/Benutzer', m);
        },
    };

    feedback = {
        async getAll() {
            return await restClient.get('/Feedback/');
        },
        async get(guid) {
            return await restClient.get(`/Feedback/${guid}`);
        },
        async save(m) {
            await restClient.put('/Feedback', m);
        },
        async comment(guid, commentData) {
            await restClient.put(`/FeedbackKommentar/${guid}`, commentData);
        },
        async attachFile(guid, filename, data) {
            await restClient.put(`/FeedbackAttachment/?feedbackGuid=${guid}&filename=${filename}`, data);
        },
        async deleteFile(guid) {
            await restClient.delete(`/FeedbackAttachment/${guid}`);
        },
    };

    rollen = {
        async getAll() {
            return await restClient.get('/Rollen');
        },
        async save(m) {
            await restClient.put('/Rollen', m);
        },
    };

    vorgaenge = {
        async getByVorgangsnummer(vorgangsNummer, jahr) {
            return await restClient.get(`/Vorgang/${vorgangsNummer}/${jahr}`);
        },
    };

    positionen = {
        async getByPcode(pcode) {
            return await restClient.get(`/BelegPositionen/GetByPcode/${pcode}`);
        },
        async get(guid) {
            return await restClient.get(`/BelegPositionen/Get/${guid}`);
        },
    };
}
