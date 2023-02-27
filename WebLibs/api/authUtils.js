import jwt_decode from "jwt-decode";

export let currentToken = undefined;
export let currentRefreshToken = undefined;

export async function initIDAS(appToken) {
    
    let jwtToken = "";
    let mandantGuid = "";
    let apiBaseurl = "https://api.dev.idas-cloudservices.net/api/";
    let authUrl = apiBaseurl;
    let jwtRefreshToken = localStorage.getItem("IDAS_AuthJwtRefreshToken");

    let urlParams = new URLSearchParams(location.search);
    if (urlParams.has("m")) mandantGuid = urlParams.get("m");
    if (urlParams.has("a")) apiBaseurl = urlParams.get("a");
    if (urlParams.has("j")) jwtToken = urlParams.get("j");
    if (urlParams.has("t")) jwtRefreshToken = urlParams.get("t");

    authUrl = apiBaseurl;
    currentToken = jwtToken;
    currentRefreshToken = jwtRefreshToken;
    localStorage.setItem("IDAS_AuthJwtRefreshToken", jwtRefreshToken);

    let settings = { appToken, mandantGuid, apiBaseurl, authUrl };
    try {
        await setup(settings);
        if (isInvalid(settings))
            redirectToLogin(settings, "/");
    }
    catch
    {
        redirectToLogin(settings, "/");
    }
    return settings;
}

export async function setup(settings)
{
    console.log("Setup IDAS");
    if (!currentToken && !currentRefreshToken)
        throw("Either currentToken or currentRefreshToken must be set to authenticate");

    if (currentRefreshToken && isInvalid(settings))
    {
        await tryRenew(settings);
        if (isInvalid(settings))
            console.log("Refresh failed, invalid JWT token!");

    } else {
        console.log("Settings already have a valid JWT token, nothing to do");
        let decoded = jwt_decode(currentToken);
        let refreshToken = decoded["refreshToken"] || "";
        if (refreshToken)
        {
            console.log("Got new refresh token:", refreshToken);
            localStorage.setItem("IDAS_AuthJwtRefreshToken", refreshToken);
            currentRefreshToken = refreshToken;
            startRefreshTimer(settings);
        }
        let mandantGuid = decoded["mandantGuid"] || "";
        if (mandantGuid)
            settings.mandantGuid = mandantGuid;
    }
    console.log("Setup finished", settings);
}

let timerRef = undefined;
function startRefreshTimer(settings)
{
    if (timerRef)
        clearInterval(timerRef);
    timerRef = setInterval(() => {
        if (currentToken) 
        {
            let decoded = jwt_decode(currentToken);
            const utcNow = Date.parse(new Date().toUTCString()) / 1000;
            if (decoded && utcNow > decoded.exp - 120) 
            {
                tryRenew(settings); // fire & forget/don't await --pr
            }
        }
    }, 5000);
}

export function isInvalid(settings)
{
    if (!currentToken) 
        return true;
    let decoded = jwt_decode(currentToken);
    const utcNow = Date.parse(new Date().toUTCString()) / 1000;
    if (decoded && decoded.exp > utcNow) 
        return false;
    return true;
}

export async function tryRenew(settings) 
{
    console.log("try to refresh");

    const url = settings.authUrl || settings.apiBaseurl;
    const payload = { "Token" : currentRefreshToken };    
    const response = await fetch(url+"LoginJwt/Refresh", {
            method : "PUT",
            body : JSON.stringify(payload),
            headers: { 'Content-Type': 'application/json' }
        });
    const token = await response.json();
    currentToken = token;
    //console.log("Got JWT token:", currentToken);

    let decoded = jwt_decode(currentToken);
    let refreshToken = decoded["refreshToken"] || "";
    if (refreshToken)
    {
        console.log("Got new refresh token:", refreshToken);
        currentRefreshToken = refreshToken;
        localStorage.setItem("IDAS_AuthJwtRefreshToken", refreshToken);
        startRefreshTimer(settings);
    }

    let mandantGuid = decoded["mandantGuid"] || "";
    if (mandantGuid)
        settings.mandantGuid = mandantGuid;

    if (isInvalid(settings))
        console.log("Token is already expired!");
}

export function redirectToLogin(settings, authPath) 
{
    const authEndpoint = (new URL(window.location.href).origin) + authPath;
    let authUrlCallback = `${authEndpoint}?r=%target%&j=%jwt%&m=%mandant%`;
    authUrlCallback = authUrlCallback.replace("%target%", encodeURIComponent(window.location.href));

    const url = new URL(settings.authUrl || settings.apiBaseurl);
    url.pathname = "/Session";
    url.search = `?a=${settings.appToken}&r=${encodeURIComponent(authUrlCallback)}`;
    let jwtUrl = url.toString();

    window.location = jwtUrl;
}

    