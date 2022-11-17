import axios from 'axios';
import jwt_decode from 'jwt-decode';

/*export let AppToken = "66B70E0B-F7C4-4829-B12A-18AD309E3970";
export let AuthToken = localStorage.getItem("AuthToken");
export let MandantGuid = localStorage.getItem("MandantGuid");
export let ApiBaseUrl = localStorage.getItem("ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api";
export let SiteBaseUrl = window.location.origin;
export let SSOAuthUrl = ApiBaseUrl.replace("/api", '') + "/SSO?a=" + AppToken + "&r=%target%?t=%token%%26m=%mandant%";*/

let authJwtRefreshToken = localStorage.getItem('IDAS_AuthJwtRefreshToken');

export class RESTClient {
    lastError = '';
    token = '';
    baseurl = '';

    constructor(url, token, isJWT = false) {
        this.lastError = '';
        this.baseurl = url;
        this.token = token;
        this.isJWT = isJWT;

        if (this.token && !isJWT) {
            axios.defaults.headers.common['X-Gdl-AuthToken'] = this.token;
        }

        if (this.token && isJWT) {
            this.updateJwtToken(token);
        }

        axios.interceptors.request.use(async (config) => {
            await this.checkAuthorizationHeader(config);
            return config;
        });
    }

    async checkAuthorizationHeader(config) {
        let authHeader = config.headers['Authorization'];
        if (authHeader && authHeader.toString().startsWith('Bearer ')) {
            let parts = authHeader.toString().split(' ');
            let jwt = parts[1];
            if (!this.isJwtTokenExpired(jwt)) {
                // JWT token is not expired
                return;
            }

            // expired token - refresh
            await this.checkRefreshToken(jwt);
        }
    }

    async checkRefreshToken(jwt, authCallback) {
        if (!jwt && authJwtRefreshToken) {
            this.onError = (error, message) => {
                // LoginJwt/Refresh failed, which means "refresh token" is expired/invalid...
                if (message.indexOf('401') != -1 || message.indexOf('403') != -1) {
                    authJwtRefreshToken = undefined;
                    localStorage.removeItem('IDAS_AuthJwtRefreshToken');
                    // ... so repeat authenticate
                    authCallback && authCallback();
                }
            };

            // fetch fresh JWT
            await this.refreshToken();
            return;
        }
        this.token = jwt;
        this.isJWT = true;
    }

    isJwtTokenExpired(jwt) {
        if (!jwt) {
            return true;
        }

        let decoded = jwt_decode(jwt);
        const utcNow = Date.parse(new Date().toUTCString()) / 1000;

        if (decoded && decoded.exp >= utcNow) {
            return false;
        }

        return true;
    }

    updateJwtToken(jwt) {
        let decoded = jwt_decode(jwt);
        let refreshToken = decoded['refreshToken'] || '';
        localStorage.setItem('IDAS_AuthJwtRefreshToken', refreshToken);
        authJwtRefreshToken = refreshToken;
        this.token = jwt;
        this.isJWT = true;
    }

    async refreshToken() {
        try {
            await axios.put(`${this.baseurl}/LoginJwt/Refresh`, { token: localStorage.getItem('IDAS_AuthJwtRefreshToken') })
                .then(resp => {
                    this.updateJwtToken(resp.data);
                });
        } catch (error) {
            this.handleError(error);
        }
    }

    updateToken(token) {
        this.token = token;
    }

    getUrlOptions(noJWT = false) {
        let options = { withCredentials: false }
        if (this.isJWT && !noJWT) {
            options.headers = { Authorization: `Bearer ${this.token}` }
        }

        return options
    }

    async get(uri, noJWT = false) {
        try {
            const response = await axios.get(this.baseurl + uri, this.getUrlOptions(noJWT));
            this.lastError = '';
            return response.data;
        } catch (error) {
            this.handleError(error);
        }
    }

    async getFile(uri) {
        try {
            const response = await axios.get(this.baseurl + uri, { responseType: 'blob' });
            let fileName = '1000.pdf';
            if (response.headers['content-disposition']) {
                fileName = response.headers['content-disposition'].split(';')[1];
                fileName = fileName.replace('filename=', '').trim();
            }
            this.lastError = '';
            return { data: response.data, filename: fileName, contentType: 'application/pdf' };
        } catch (error) {
            this.handleError(error);
        }
    }

    async getRaw(uri, noJWT = false) {
        let response = {};
        try {
            response = await axios.get(this.baseurl + uri, this.getUrlOptions(noJWT))
            this.lastError = '';
        } catch (error) {
            this.handleError(error);
        }
        return response;
    }

    async post(uri, formData, noJWT = false) {
        try {
            const response = await axios.post(this.baseurl + uri, formData, this.getUrlOptions(noJWT));
            this.lastError = '';
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    async put(uri, formData, noJWT = false) {
        try {
            const response = await axios.put(this.baseurl + uri, formData, this.getUrlOptions(noJWT));
            this.lastError = '';
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    async delete(uri, noJWT = false) {
        try {
            const response = await axios.delete(this.baseurl + uri, this.getUrlOptions(noJWT));
            this.lastError = '';
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    // eslint-disable-next-line no-unused-vars
    onError = (error, message) => { };

    handleError(error) {
        let message = error ? error.message : '?';
        // eslint-disable-next-line no-console
        console.log(`API Error: ${message}`);
        this.lastError = message;
        this.onError(error, message);
        throw error;
    }
}
