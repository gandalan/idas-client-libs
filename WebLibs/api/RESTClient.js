import axios from "axios";
import { currentToken } from "./authUtils";

export class RESTClient
{
    lastError = "";
    settings = {};
    axiosInstance = null;

    constructor(settings)
    {
        this.settings = settings;

        this.axiosInstance = axios.create({
            baseURL: settings.apiBaseurl,
            headers: {
                "Authorization": `Bearer ${currentToken}`,
            },
        });

        /*this.axiosInstance.interceptors.request.use(async (config) =>
        {
            console.log("intercept", config.baseURL, config.url);
            await this.checkTokenBeforeRequest(config);
            return config;
        });*/
    }

    /*async checkTokenBeforeRequest(config)
    {
        if (currentToken && isInvalid(this.settings))
        { // ignore custom/different JWT tokens
            await tryRenew(this.settings);
            console.log(`Updating Header with new JWT Token: ${currentToken}`);
            this.axiosInstance.headers = {
                "Authorization": `Bearer ${currentToken}`,
            }
        }
    }*/

    getUrlOptions()
    {
        return { withCredentials: false };
    }

    async get(uri)
    {
        try
        {
            this.axiosInstance = this.getNewAxiosInstance();
            const response = await this.axiosInstance.get(uri, this.getUrlOptions());
            this.lastError = "";
            return response.data;
        }
        catch (error)
        {
            this.handleError(error);
        }
    }

    async getFile(uri)
    {
        try
        {
            this.axiosInstance = this.getNewAxiosInstance();
            const response = await this.axiosInstance.get(uri, { responseType: "blob" });
            let fileName = "1000.pdf";
            if (response.headers["content-disposition"])
            {
                fileName = response.headers["content-disposition"].split(";")[1];
                fileName = fileName.replace("filename=", "").trim();
            }
            this.lastError = "";
            return { data: response.data, filename: fileName, contentType: "application/pdf" };
        }
        catch (error)
        {
            this.handleError(error);
        }
    }

    async getRaw(uri)
    {
        let response = {};
        try
        {
            this.axiosInstance = this.getNewAxiosInstance();
            response = await this.axiosInstance.get(uri, this.getUrlOptions())
            this.lastError = "";
        }
        catch (error)
        {
            this.handleError(error);
        }
        return response;
    }

    async post(uri, formData)
    {
        try
        {
            this.axiosInstance = this.getNewAxiosInstance();
            const response = await this.axiosInstance.post(uri, formData, this.getUrlOptions());
            this.lastError = "";
            return response;
        }
        catch (error)
        {
            this.handleError(error);
        }
    }

    async put(uri, formData)
    {
        try
        {
            this.axiosInstance = this.getNewAxiosInstance();
            const response = await this.axiosInstance.put(uri, formData, this.getUrlOptions());
            this.lastError = "";
            return response;
        }
        catch (error)
        {
            this.handleError(error);
        }
    }

    async delete(uri)
    {
        try
        {
            this.axiosInstance = this.getNewAxiosInstance();
            const response = await this.axiosInstance.delete(uri, this.getUrlOptions());
            this.lastError = "";
            return response;
        }
        catch (error)
        {
            this.handleError(error);
        }
    }

    getNewAxiosInstance()
    {
        return axios.create({
            baseURL: this.settings.apiBaseurl,
            headers: {
                "Authorization": `Bearer ${currentToken}`,
            },
        });
    }

    handleError(error)
    {
        if (error.response)
        {
            // The request was made and the server responded with a status code
            // that falls out of the range of 2xx
            // eslint-disable-next-line
            console.error(error.response.data, error.response.status, error.response.headers);
        }
        else if (error.request)
        {
            // The request was made but no response was received
            // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
            // http.ClientRequest in node.js
            // eslint-disable-next-line
            console.error("Request", error.request);
        }
        else
        {
            // Something happened in setting up the request that triggered an Error
            // eslint-disable-next-line
            console.error("Error", error.message);
        }

        console.info("Config", error.config);
        this.lastError = error;
    }
}
