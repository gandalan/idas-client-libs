import axios from "axios";
import { jwtTokenInvalid, jwtTokenRenew } from "./authUtils";

export class RESTClient {
    lastError = "";
    settings = {};
    axiosInstance = null;

    constructor(settings) {
        this.settings = settings;

        if (settings.jwtToken) {
            axios.defaults.headers.common["Authorization"] = `Bearer ${ this.token}`;
            axios.interceptors.request.use(async (config) => {
                await this.checkTokenBeforeRequest(config);
                return config;
            });
        } else {
            // might contain the classic token for fallback
            axios.defaults.headers.common["X-Gdl-AuthToken"] = settings.jwtRefreshToken;
        }

        this.axiosInstance = axios.create({
            baseURL: settings.apiBaseurl,
        });
    }

    async checkTokenBeforeRequest(config) {
        let authHeader = config.headers["Authorization"];
        if (authHeader && authHeader.toString().startsWith("Bearer ")) { // only check requests containing a Bearer token
            let parts = authHeader.toString().split(" ");
            let jwt = parts[1];
            if (this.settings.jwtToken === jwt && jwtTokenInvalid(this.settings)) { // ignore custom/different JWT tokens
                await jwtTokenRenew(this.settings);
            }
        }
    }

    getUrlOptions(noJWT = false) {
        let options = { withCredentials: false }
        /*if (this.isJWT && !noJWT) {
            options.headers = { Authorization: `Bearer ${this.token}` }
        }*/
        return options;
    }

    async get(uri, noJWT = false) {
        try {
            const response = await this.axiosInstance.get(uri, this.getUrlOptions(noJWT));
            this.lastError = "";
            return response.data;
        } catch (error) {
            this.handleError(error);
        }
    }

    async getFile(uri) {
        try {
            const response = await this.axiosInstance.get(uri, { responseType: "blob" });
            let fileName = "1000.pdf";
            if (response.headers["content-disposition"]) {
                fileName = response.headers["content-disposition"].split(";")[1];
                fileName = fileName.replace("filename=", "").trim();
            }
            this.lastError = "";
            return { data: response.data, filename: fileName, contentType: "application/pdf" };
        } catch (error) {
            this.handleError(error);
        }
    }

    async getRaw(uri, noJWT = false) {
        let response = {};
        try {
            response = await this.axiosInstance.get(uri, this.getUrlOptions(noJWT))
            this.lastError = "";
        } catch (error) {
            this.handleError(error);
        }
        return response;
    }

    async post(uri, formData, noJWT = false) {
        try {
            const response = await this.axiosInstance.post(uri, formData, this.getUrlOptions(noJWT));
            this.lastError = "";
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    async put(uri, formData, noJWT = false) {
        try {
            const response = await this.axiosInstance.put(uri, formData, this.getUrlOptions(noJWT));
            this.lastError = "";
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    async delete(uri, noJWT = false) {
        try {
            const response = await this.axiosInstance.delete(uri, this.getUrlOptions(noJWT));
            this.lastError = "";
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    // eslint-disable-next-line no-unused-vars
    onError = (error, message) => { };

    handleError(error) {
        let message = error ? error.message : "?";
        // eslint-disable-next-line no-console
        console.error(`API Error: ${message}`);
        this.lastError = message;
        this.onError(error, message);
        throw error;
    }
}
