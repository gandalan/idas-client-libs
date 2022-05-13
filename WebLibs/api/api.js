import axios from 'axios';
import { AuthToken, ApiBaseUrl } from "./AuthStore";
import { get } from 'svelte/store';

export class API 
{
    lastError = '';
    token = "";
    baseurl = "";

    constructor()
    {
        this.lastError = "";
        this.baseurl = get(ApiBaseUrl);
        this.token = get(AuthToken);
        console.log("Base: " + this.baseurl + " Token: " + this.token);

        if (this.token) {
            axios.defaults.headers.common['X-Gdl-AuthToken'] = this.token;
        }
    }

    async get(uri)
    {
        try {
            console.log("GET " + this.baseurl + uri);
            const response = await axios.get(this.baseurl + uri);
            this.lastError = '';
            return response.data;
        }
        catch (error) {
            this.checkError(error);
        }
    }

    async getFile(uri)
    {
        try {
            const response = await axios.get(this.baseurl + uri, { responseType: 'blob' });
            console.log(response);

            let fileName = "1000.pdf";
            if (response.headers["content-disposition"]) {
                fileName = response.headers["content-disposition"].split(';')[1];
                fileName = fileName.replace("filename=", "").trim();
            }

            this.lastError = '';
            return { data: response.data, filename: fileName, contentType: "application/pdf" };
        }
        catch (error) {
            this.checkError(error);
        }
    }

    async getRaw(uri)
    {
        let response = {};
        try {
            response = await axios.get(this.baseurl + uri, { withCredentials: true })
            console.log(response);
            this.lastError = '';
        }
        catch (error) {
            this.checkError(error);
        }
        return response;
    }

    async post(uri, formData) 
    {
        try {
            const response = await axios.post(this.baseurl + uri, formData, { withCredentials: true });
            //console.log(JSON.stringify(response));
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.checkError(error);
        }
    }

    async put(uri, formData) 
    {
        try {
            console.log(`PUT to ${this.baseurl}${uri}`);
            const response = await axios.put(this.baseurl + uri, formData, { withCredentials: true });
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.checkError(error);
        }
    }

    async delete(uri)
    {
        try
        {
            console.log(`DELETE to ${this.baseurl}${uri}`);
            const response = await axios.delete(this.baseurl + uri, { withCredentials: true });
            this.lastError = '';
            return response;
        }
        catch (error) {
            this.checkError(error);
        }
    }

    checkError(error)
    {
        let status = error && error.response ? error.response.status : -1;
        let message = error ? error.message : "?";
        console.log("API Error " + status + ": " + message);
        this.lastError = message;
        if (status === 401 || status === 403) {
            AuthToken.set(null);
            localStorage.setItem("AuthToken", null);
        }
    }
}