import { RESTClient } from "./RESTClient";
import jwt_decode from "jwt-decode";

export async function setup(settings)
{
    console.log("Setup");
    if (settings.jwtRefreshToken && jwtTokenInvalid(settings))
    {
        const payload = { "Token" : settings.jwtRefreshToken };
        // Fetch Token from IDAS API
        let api = new RESTClient(settings);
        const response = await api.put("Login/Update", payload);
        const iat = response.data;
        console.log("Got IDAS token: ", iat);

        // If valid, check roles and authenticate against JWT API
        if (iat)
            await jwtTokenRenew(settings);
        
        if (jwtTokenInvalid(settings))
            console.log("Attention: no valid JWT token!");

    } else {
        console.log("Settings already have a valid JWT token, nothing to do");
    }
    console.log("Setup finished", settings);
}

export function jwtTokenInvalid(settings)
{
    if (!settings.jwtToken) 
        return true;
    let decoded = jwt_decode(settings.jwtToken);
    const utcNow = Date.parse(new Date().toUTCString()) / 1000;
    if (decoded && decoded.exp > utcNow) 
        return false;
    return true;
}

export async function jwtTokenRenew(settings) 
{
    const renewSettings = { ...settings, jwtToken : undefined };
    let api = new RESTClient(renewSettings);
    const payload = { "Token" : settings.jwtRefreshToken };
    const response = await api.put("LoginJwt/Refresh", payload);
    settings.jwtToken = response.data;
    console.log("Got JWT token:", response.data);

    let decoded = jwt_decode(settings.jwtToken);
    let refreshToken = decoded["refreshToken"] || "";
    if (refreshToken)
    {
        console.log("Got new refresh token:", refreshToken);
        settings.jwtRefreshToken = refreshToken;
    }

    if (jwtTokenInvalid(settings))
        console.log("Token is already expired!");
}

export function jwtAuthenticateOnBackend(settings, authPath) 
{
    localStorage.setItem("IDAS_AuthJwtCallbackPath", authPath || "");
    const authEndpoint = (new URL(window.location.href).origin) + authPath;
    let authUrlCallback = `${authEndpoint}?r=%target%&j=%jwt%&m=%mandant%`;
    authUrlCallback = authUrlCallback.replace("%target%", encodeURIComponent(window.location.href));

    const url = new URL(settings.apiBaseurl);
    url.pathname = "/Session";
    url.search = `?a=${settings.appToken}&r=${encodeURIComponent(authUrlCallback)}`;
    let jwtUrl = url.toString();

    window.location = jwtUrl;
}

    