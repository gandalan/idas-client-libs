/**
 * HTTP client for making REST API requests using axios.
 * Handles GET, POST, PUT, DELETE operations with authentication.
 * @class
 * @example
 * const client = new RESTClient({
 *   apiBaseurl: 'https://api.example.com',
 *   token: 'jwt-token-here'
 * });
 * const data = await client.get('/users');
 */
import axios from "axios";
import { currentToken } from "./authUtils";

export class RESTClient
{
    /**
     * Last error message from a failed request
     * @type {string}
     */
    lastError = "";

    /**
     * Configuration settings for the client
     * @type {Object}
     */
    settings = {};

    /**
     * Axios instance for making HTTP requests
     * @type {import('axios').AxiosInstance}
     */
    axiosInstance = null;

    /**
     * Creates a new RESTClient instance
     * @param {Object} settings - Client configuration
     * @param {string} settings.apiBaseurl - Base URL for API requests
     * @param {string} [settings.token] - JWT authentication token
     */
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

    /**
     * Gets default URL options for requests
     * @returns {Object} Options object with withCredentials set to false
     */
    getUrlOptions()
    {
        return { withCredentials: false };
    }

    /**
     * Performs a GET request
     * @async
     * @param {string} uri - The URI to request (relative to baseURL)
     * @returns {Promise<any>} The response data
     * @throws {Error} If the request fails
     */
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

    /**
     * Downloads a file from the given URI
     * @async
     * @param {string} uri - The URI to request
     * @returns {Promise<Object>} Object containing data, filename, and contentType
     * @returns {Blob} return.data - The file data as a Blob
     * @returns {string} return.filename - The filename from Content-Disposition header
     * @returns {string} return.contentType - The content type (always "application/pdf")
     * @throws {Error} If the request fails
     */
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

    /**
     * Performs a GET request and returns the raw axios response
     * @async
     * @param {string} uri - The URI to request
     * @returns {Promise<import('axios').AxiosResponse>} The full axios response object
     * @throws {Error} If the request fails
     */
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

    /**
     * Performs a POST request
     * @async
     * @param {string} uri - The URI to post to
     * @param {Object} formData - The data to send
     * @returns {Promise<import('axios').AxiosResponse>} The axios response
     * @throws {Error} If the request fails
     */
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

    /**
     * Performs a PUT request
     * @async
     * @param {string} uri - The URI to put to
     * @param {Object} formData - The data to send
     * @returns {Promise<import('axios').AxiosResponse>} The axios response
     * @throws {Error} If the request fails
     */
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

    /**
     * Performs a DELETE request
     * @async
     * @param {string} uri - The URI to delete
     * @returns {Promise<import('axios').AxiosResponse>} The axios response
     * @throws {Error} If the request fails
     */
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

    /**
     * Creates a new axios instance with current authentication
     * @private
     * @returns {import('axios').AxiosInstance} A new axios instance
     */
    getNewAxiosInstance()
    {
        return axios.create({
            baseURL: this.settings.apiBaseurl,
            headers: {
                "Authorization": `Bearer ${currentToken}`,
            },
        });
    }

    /**
     * Handles errors from axios requests
     * @private
     * @param {Error} error - The error object from axios
     */
    handleError(error)
    {
        if (error.response)
        {
            // The request was made and the server responded with a status code
            // that falls out of the range of 2xx
            console.error(error.response.data, error.response.status, error.response.headers);
        }
        else if (error.request)
        {
            // The request was made but no response was received
            // `error.request` is an instance of XMLHttpRequest in the browser and an instance of
            // http.ClientRequest in node.js
            console.error("Request", error.request);
        }
        else
        {
            // Something happened in setting up the request that triggered an Error
            console.error("Error", error.message);
        }

        console.info("Config", error.config);
        this.lastError = error;
    }
}
