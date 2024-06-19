import { jwtDecode } from "jwt-decode";

const envs = {};

const JWT_SAFE_RENEWAL = 30; // seconds before token expiry to renew

export async function fetchEnv(env = "") {
    if (!(env in envs)) {
        const hubUrl = `https://connect.idas-cloudservices.net/api/Endpoints?env=${env}`;
        console.log("fetching env", hubUrl);
        const r = await fetch(hubUrl);
        const data = await r.json();
        envs[env] = data;
    }
    return envs[env];
}

export function getRefreshToken(token) {
    const decoded = jwtDecode(token);
    return decoded.refreshToken;
}

export function isTokenValid(token) 
{
    try
    {
        const decoded = jwtDecode(token);
        if (!decoded) 
            throw new Error("Invalid token");
        return (decoded.exp - JWT_SAFE_RENEWAL > Date.now() / 1000);
    }
    catch {
        return false;
    }
}

export function authBuilder() {
    return {
        authUrl: "",
        appToken: "",
        token: "",
        refreshToken: "",

        useAppToken(appToken = "") {
            this.appToken = appToken; return this;
        },

        useBaseUrl(authUrl = "") {
            this.authUrl = authUrl; return this;
        },

        useToken(jwtToken = "") {
            this.token = jwtToken; return this;
        },

        useRefreshToken(storedRefreshToken = "") {
            this.refreshToken = storedRefreshToken; return this;
        },

        async authenticate(username = "", password = "") 
        {
            console.log("authenticating:", this.token ? `token set, exp: ${jwtDecode(this.token).exp - (Date.now() / 1000)}` : "no token,", this.refreshToken);

            if (this.token && isTokenValid(this.token)) 
                return this.token;

            if (this.token && !this.refreshToken)
                this.refreshToken = getRefreshToken(this.token);

            if (this.refreshToken) {
                try {
                    const temptoken = await this.tryRefreshToken(this.refreshToken);
                    if (temptoken) {
                        this.token = temptoken;
                        this.refreshToken = getRefreshToken(temptoken);
                    }
                } catch {
                    // if refresh failed, we'll return the current token
                    // - should still be valid for a while
                }
                return this.token;
            }

            if (username && password) {
                const payload = { "Email": username, "Password": password, "AppToken": this.appToken };
                const res = await fetch(`${this.authUrl}/LoginJwt`,
                    { method: "POST", body: JSON.stringify(payload), headers: { "Content-Type": "application/json" } });
                const temptoken = await res.json();
                if (temptoken) {
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
                    headers: { "Content-Type": "application/json" },
                });
            return res.ok ? await res.json() : null;
        },
    }
}

export function restClient()
{
    return {
        baseUrl: "",
        token: "",

        useBaseUrl(url = "") {
            this.baseUrl = url; return this;
        },

        useToken(jwtToken = "") {
            this.token = jwtToken; return this;
        },

        async get(url = "", auth = true) {
            const finalUrl = `${this.baseUrl}/${url}`;
            const headers = this.token ? { "Authorization": `Bearer ${this.token}` } : {};
            const res = await fetch(finalUrl, { method: "GET", headers });
            if (res.ok)
                return await res.json();
            throw new Error(`GET ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        async put(url = "", payload = {}) {
            const finalUrl = `${this.baseUrl}/${url}`;
            const headers = this.token ? { "Authorization": `Bearer ${this.token}`, "Content-Type": "application/json" } : {};
            const res = await fetch(finalUrl, { method: "PUT", body: JSON.stringify(payload), headers });
            if (res.ok)
                return await res.json();
            throw new Error(`PUT ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        async post(url = "", payload = {}) {
            const finalUrl = `${this.baseUrl}/${url}`;
            const headers = this.token ? { "Authorization": `Bearer ${this.token}`, "Content-Type": "application/json" } : {};
            const res = await fetch(finalUrl, { method: "POST", body: JSON.stringify(payload), headers });
            if (res.ok)
                return await res.json();
            throw new Error(`POST ${finalUrl} failed: ${res.status} ${res.statusText}`);
        },

        async delete(url = "") {
            const finalUrl = `${this.baseUrl}/${url}`;
            const headers = this.token ? { "Authorization": `Bearer ${this.token}` } : {};
            const res = await fetch(finalUrl, { method: "DELETE", headers });
            if (res.ok)
                return await res.json();
            throw new Error(`DELETE ${finalUrl} failed: ${res.status} ${res.statusText}`);
        }
    }
}

export function api() {
    return {
        baseUrl: "",
        authUrl: "",
        env: "",
        appToken: "",
        storageEntry: "",
        token: "",
        refreshToken: "",

        useEnvironment(env = "") {
            this.env = env; return this;
        },

        useAppToken(newApptoken = "") {
            this.appToken = newApptoken; return this;
        },

        useBaseUrl(url = "") {
            this.baseUrl = url; return this;
        },

        useAuthUrl(url = "") {
            this.authUrl = url; return this;
        },

        useToken(jwtToken = "") {
            this.token = jwtToken; return this;
        },

        useRefreshToken(storedRefreshToken = "") {
            this.refreshToken = storedRefreshToken; return this;
        },

        useGlobalAuth() {
            // eslint-disable-next-line no-undef
            this.token = globalThis.idasTokens.token; this.refreshToken = globalThis.idasTokens.refreshToken; return this;
        },

        async get(url = "", auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).get(url);
        },

        async put(url = "", payload = {}, auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).put(url, payload);
        },

        async post(url = "", payload = {}, auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).post(url, payload);
        },

        async delete(url = "", auth = true) {
            if (auth) 
                await this.ensureAuthenticated();
            return restClient().useBaseUrl(this.baseUrl).useToken(this.token).delete(url);
        },

        async ensureAuthenticated() {
            if (this.token && isTokenValid(this.token))
                return;

            await this.ensureBaseUrlIsSet();

            try {
                const temptoken = await authBuilder()
                    .useAppToken(this.appToken)
                    .useBaseUrl(this.authUrl)
                    .useToken(this.token)
                    .useRefreshToken(this.refreshToken)
                    .authenticate() || "";

                if (!temptoken) {
                    throw new Error("not authenticated");
                }

                this.token = temptoken;
                this.refreshToken = getRefreshToken(temptoken);
                // eslint-disable-next-line no-undef
                globalThis.idasTokens.token = this.token;
                // eslint-disable-next-line no-undef
                globalThis.idasTokens.refreshToken = this.refreshToken;
                localStorage.setItem("idas-refresh-token", this.refreshToken);
            } catch (e) {
                this.redirectToLogin();
            }
        },

        async ensureBaseUrlIsSet() {
            if (this.env && (!this.baseUrl || !this.authUrl)) {
                const envInfo = await fetchEnv(this.env);
                this.baseUrl = this.baseUrl || envInfo.idas;
                this.authUrl = this.authUrl || envInfo.idas;
                console.log("envInfo", envInfo);
            }

            if (!this.baseUrl) {
                throw new Error("apiBaseurl not set");
            }

            if (!this.authUrl) {
                throw new Error("authUrl not set");
            }
        },

        redirectToLogin(authPath = "") {
            if (!window) {
                return;
            }

            const authEndpoint = (new URL(window.location.href).origin) + authPath;
            let authUrlCallback = `${authEndpoint}?r=%target%&j=%jwt%&m=%mandant%`;
            authUrlCallback = authUrlCallback.replace("%target%", encodeURIComponent(window.location.href));

            const url = new URL(this.authUrl);
            url.pathname = "/Session";
            url.search = `?a=${this.appToken}&r=${encodeURIComponent(authUrlCallback)}`;
            let loginUrl = url.toString();

            window.location = loginUrl;
        },
    };
}

export function idasApi(appToken = "") {
    return api()
        .useGlobalAuth()
        .useAppToken(appToken)
        .useEnvironment("dev");
}
