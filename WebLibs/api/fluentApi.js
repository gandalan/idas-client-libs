import { jwtDecode } from "jwt-decode";

const envs = {};

export async function fetchEnv(env = "") 
{
    if (!(env in envs))
    {
        const hubUrl = `https://connect.idas-cloudservices.net/api/Endpoints?env=${env}`;
        const r = await fetch(hubUrl);
        const data = await r.json();
        envs[env] = data;
    }
    return envs[env];
}

export function getRefreshToken(token)
{
    const decoded = jwtDecode(token);
    return decoded.refreshToken;
}

export function authBuilder()
{
    return {
        authUrl : "",
        appToken : "",
        token : "",
        refreshToken : "",

        useAppToken(appToken = "") { this.appToken = appToken; return this; },
        useBaseUrl(authUrl = "") { this.authUrl = authUrl; return this; },
        useToken(jwtToken = "") { this.token = jwtToken; return this; },
        useRefreshToken(storedRefreshToken = "") { this.refreshToken = storedRefreshToken; return this; },

        async authenticate(username = "", password = "") 
        {
            console.log("authenticating:", this.token ? "token set, exp: " + (jwtDecode(this.token).exp-(Date.now()/1000)) : "no token,", this.refreshToken);

            if (this.token)
            {
                try
                {
                    const decoded = jwtDecode(this.token);
                    if (!decoded)
                        throw new Error("Invalid token");

                    if (decoded.exp - 60 > Date.now() / 1000)
                        return this.token;

                    if (decoded.refreshToken && !this.refreshToken)
                        this.refreshToken = decoded.refreshToken;
                } 
                catch (e)
                {
                    console.error("Error decoding token", e);
                    return null;
                }
            }

            if (this.refreshToken)
            {
                try
                {   
                    const temptoken = await this.tryRefreshToken(this.refreshToken);
                    if (temptoken) 
                    {
                        this.token = temptoken;
                        this.refreshToken = getRefreshToken(temptoken);
                    }
                } catch {
                    // if refresh failed, we'll return the current token 
                    // - should still be valid for a while
                }
                return this.token;
                
            }

            if (username && password)
            {
                const payload = { "Email": username, "Password": password, "AppToken": this.appToken };
                const res = await fetch(`${this.authUrl}/LoginJwt`, 
                    { method: "POST", body: JSON.stringify(payload), headers: { "Content-Type": "application/json" } });
                const temptoken = await res.json();
                if (temptoken)
                {
                    this.token = temptoken;
                    return this.token;
                }
            }

            throw new Error("not authenticated");
        },

        async tryRefreshToken(refreshToken = "") {
            const payload = { "Token": refreshToken };
            const res = await fetch(`${this.authUrl}/LoginJwt/Refresh`,
                { 
                    method: "PUT", 
                    body: JSON.stringify(payload), 
                    headers: { "Content-Type": "application/json" } 
                });
            return res.ok ? await res.json() : null;
        }
    }
}

export function api()
{
    return {
        baseUrl : "",
        authUrl : "",
        env : "",
        appToken : "",
        storageEntry : "",
        token : "",
        refreshToken : "",
        
        useEnvironment(env = "") { this.env = env; return this; },
        useAppToken(newApptoken = "") { this.appToken = newApptoken; return this; },
        useBaseUrl(url = "") { this.baseUrl = url; return this; },
        useAuthUrl(url = "") { this.authUrl = url; return this; },
        useToken(jwtToken = "") { this.token = jwtToken; return this; },
        useRefreshToken(storedRefreshToken = "") { this.refreshToken = storedRefreshToken; return this; },
        useGlobalAuth() { this.token = globalThis.idas.token; this.refreshToken = globalThis.idas.refreshToken; return this; },
        
        async get(url = "") { 
            console.log("get", url);
            await this.ensureAuthenticated();
            const headers = this.token ? { "Authorization": `Bearer ${this.token}` } : {};
            const res = await fetch(`${this.baseUrl}/${url}`, { method: "GET", headers });
            return await res.json();
        },

        async put(url = "", payload = {}) {
            console.log("put", url, payload);
            await this.ensureAuthenticated();

            const headers = this.token ? { "Authorization": `Bearer ${this.token}`, "Content-Type": "application/json" } : {};
            const res = await fetch(`${this.baseUrl}/${url}`,
                { method: "PUT", body: JSON.stringify(payload), headers });
            return await res.json();
        },

        async post(url = "", payload = {}) {
            console.log("post", url, payload);
            await this.ensureAuthenticated();

            const headers = this.token ? { "Authorization": `Bearer ${this.token}`, "Content-Type": "application/json" } : {};
            const res = await fetch(`${this.baseUrl}/${url}`,
                { method: "POST", body: JSON.stringify(payload), headers });
            return await res.json();
        },

        async delete(url = "") {
            console.log("delete", url);
            await this.ensureAuthenticated();

            const headers = this.token ? { "Authorization": `Bearer ${this.token}` } : {};
            const res = await fetch(`${this.baseUrl}/${url}`, { method: "DELETE", headers });
            return await res.json();
        },
        
        async ensureAuthenticated() { 
            await this.ensureBaseUrlIsSet();
            if (!this.token && !this.refreshToken)
                return;
            try
            {
                const temptoken = await authBuilder()
                    .useToken(this.token)
                    .useRefreshToken(this.refreshToken)
                    .useAppToken(this.appToken)
                    .useBaseUrl(this.authUrl)
                    .authenticate() || "";

                if (!temptoken)
                    throw new Error("not authenticated");

                this.token = temptoken;
                this.refreshToken = getRefreshToken(temptoken);
                globalThis.idas.token = this.token;
                globalThis.idas.refreshToken = this.refreshToken;
                localStorage.setItem("idas-refresh-token", this.refreshToken);
            } catch (e) {
                this.redirectToLogin();
            }   
        },

        async ensureBaseUrlIsSet() {
            if (this.env && (!this.baseUrl || !this.authUrl))
            {
                const envInfo = await fetchEnv(this.env);
                this.baseUrl = envInfo.idas;
                this.authUrl = envInfo.idas;
            }   

            if (!this.baseUrl)
                throw new Error("apiBaseurl not set");
        },

        redirectToLogin(authPath = "")
        {
            if (!window)
                return;

            const authEndpoint = (new URL(window.location.href).origin) + authPath;
            let authUrlCallback = `${authEndpoint}?r=%target%&j=%jwt%&m=%mandant%`;
            authUrlCallback = authUrlCallback.replace("%target%", encodeURIComponent(window.location.href));

            const url = new URL(this.authUrl);
            url.pathname = "/Session";
            url.search = `?a=${this.appToken}&r=${encodeURIComponent(authUrlCallback)}`;
            let loginUrl = url.toString();

            window.location = loginUrl;
        }
    };
}

export function idasApi(appToken = "") 
{
    return api()
        .useGlobalAuth()
        .useAppToken(appToken)
        .useEnvironment("dev");
}