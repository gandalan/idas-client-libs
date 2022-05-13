import { API } from './api';
import { get } from 'svelte/store'
import { MandantGuid } from "./AuthStore";

const niceContextNames = new Map();
niceContextNames.set("position", "Positionserfassung");
niceContextNames.set("start", "Programmstart");

export async function getAll()
{
    let api = getNewAPI();
    let result = await api.get('/NachrichtenKonfig?besitzerMandantGuid=' + get(MandantGuid));     
    result = result || [];
    result.forEach(n => {
        n.anzeigeText = n.nachricht && n.nachricht.length > 30 ? n.nachricht.substr(0,30) + "..." : n.nachricht;
        if (n.context && niceContextNames.has(n.context))
        {            
            n.anzeigeText += " (Anzeige bei " + niceContextNames.get(n.context) + ")";
        }        
    });
    return result;
}

export async function addNachricht(nachricht)
{
    nachricht.besitzerMandantGuid = get(MandantGuid);
    if (!nachricht.gueltigAb) nachricht.gueltigAb = null;
    if (!nachricht.gueltigBis) nachricht.gueltigBis = null;

    let api = getNewAPI();
    console.log(nachricht);
    return await api.post('/NachrichtenKonfig', nachricht);        
}

export async function removeNachricht(nachricht)
{
    let api = getNewAPI();
    return await api.delete('/NachrichtenKonfig?nachrichtGuid=' + nachricht.nachrichtGuid);
}

function getNewAPI()
{
    let api = new API();
    api.baseurl = "";
    return api;
}