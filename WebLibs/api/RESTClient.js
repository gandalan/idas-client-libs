import axios from 'axios';

/*export let AppToken = "66B70E0B-F7C4-4829-B12A-18AD309E3970";
export let AuthToken = localStorage.getItem("AuthToken");
export let MandantGuid = localStorage.getItem("MandantGuid");
export let ApiBaseUrl = localStorage.getItem("ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api";
export let SiteBaseUrl = window.location.origin;
export let SSOAuthUrl = ApiBaseUrl.replace("/api", '') + "/SSO?a=" + AppToken + "&r=%target%?t=%token%%26m=%mandant%";*/

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

        axios.interceptors.request.use(req => {
            return req;
        });
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
        console.error(`API Error: ${message}`);
        this.lastError = message;
        this.onError(error, message);
        throw error;
    }
}
