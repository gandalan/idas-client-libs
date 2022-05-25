import axios from 'axios';

/*export let AppToken = "66B70E0B-F7C4-4829-B12A-18AD309E3970";
export let AuthToken = localStorage.getItem("AuthToken");
export let MandantGuid = localStorage.getItem("MandantGuid");
export let ApiBaseUrl = localStorage.getItem("ApiBaseUrl") || "https://api.dev.idas-cloudservices.net/api";
export let SiteBaseUrl = window.location.origin;
export let SSOAuthUrl = ApiBaseUrl.replace("/api", "") + "/SSO?a=" + AppToken + "&r=%target%?t=%token%%26m=%mandant%";*/

export class RESTClient 
{
    lastError = '';
    token = "";
    baseurl = "";

    constructor(url, token)
    {
        this.lastError = "";
        this.baseurl = url;
        this.token = token;
        console.log("Base: " + this.baseurl + " Token: " + this.token);

        if (this.token) {
            axios.defaults.headers.common['X-Gdl-AuthToken'] = this.token;
        }

        axios.interceptors.request.use(req => {
            console.log(`${req.method} ${req.url}`);
            return req;
        });
    }

    async get(uri)
    {
        try {
            const response = await axios.get(this.baseurl + uri);
            this.lastError = '';
            return response.data;
        }
        catch (error) {
            this.handleError(error);
        }
    }

    async getFile(uri)
    {
        try {
            const response = await axios.get(this.baseurl + uri, { responseType: 'blob' });
            let fileName = "1000.pdf";
            if (response.headers["content-disposition"]) {
                fileName = response.headers["content-disposition"].split(';')[1];
                fileName = fileName.replace("filename=", "").trim();
            }
            this.lastError = '';
            return { data: response.data, filename: fileName, contentType: "application/pdf" };
        }
        catch (error) {
            this.handleError(error);
        }
    }

    async getRaw(uri)
    {
        let response = {};
        try {
            response = await axios.get(this.baseurl + uri, { withCredentials: true })
            this.lastError = '';
        }
        catch (error) {
            this.handleError(error);
        }
        return response;
    }

    async post(uri, formData) 
    {
        try {
            const response = await axios.post(this.baseurl + uri, formData, { withCredentials: true });
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.handleError(error);
        }
    }

    async put(uri, formData) 
    {
        try {
            const response = await axios.put(this.baseurl + uri, formData, { withCredentials: true });
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.handleError(error);
        }
    }

    async delete(uri)
    {
        try
        {
            const response = await axios.delete(this.baseurl + uri, { withCredentials: true });
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.handleError(error);
        }
    }

    handleError(error)
    {
        let status = error && error.response ? error.response.status : -1;
        let message = error ? error.message : "?";
        console.log("API Error " + status + ": " + message);
        this.lastError = message;
        throw error;
    }
}