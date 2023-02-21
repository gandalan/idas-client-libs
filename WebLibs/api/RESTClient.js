import axios from "axios";
import { isInvalid, tryRenew } from "./authUtils";

export class RESTClient {
    lastError = "";
    settings = {};
    axiosInstance = null;

    constructor(settings) {
        this.settings = settings;

        this.axiosInstance = axios.create({
            baseURL: settings.apiBaseurl,
            headers: {
                "Authorization" : `Bearer ${ settings.jwtToken }`
            }
        });

        this.axiosInstance.interceptors.request.use(async (config) => {
            await this.checkTokenBeforeRequest(config);
            return config;
        });
    }

    async checkTokenBeforeRequest(config) {
        if (this.settings.jwtToken && isInvalid(this.settings)) { // ignore custom/different JWT tokens
            await tryRenew(this.settings);
            console.log(`Updating Header with new JWT Token: ${this.settings.jwtToken}`);
            this.axiosInstance.headers = {
                "Authorization" : `Bearer ${ this.settings.jwtToken }`
            }
        }
    }

    getUrlOptions() {
        return { withCredentials: false };
    }

    async get(uri) {
        try {
            const response = await this.axiosInstance.get(uri, this.getUrlOptions());
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

    async getRaw(uri) {
        let response = {};
        try {
            response = await this.axiosInstance.get(uri, this.getUrlOptions())
            this.lastError = "";
        } catch (error) {
            this.handleError(error);
        }
        return response;
    }

    async post(uri, formData) {
        try {
            const response = await this.axiosInstance.post(uri, formData, this.getUrlOptions());
            this.lastError = "";
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    async put(uri, formData) {
        try {
            const response = await this.axiosInstance.put(uri, formData, this.getUrlOptions());
            this.lastError = "";
            return response;
        } catch (error) {
            this.handleError(error);
        }
    }

    async delete(uri) {
        try {
            const response = await this.axiosInstance.delete(uri, this.getUrlOptions());
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
