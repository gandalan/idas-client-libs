import { API } from './api';
import { AuthToken } from "./AuthStore";
//import mandanten from '../data/mandanten.json';

export function getAll()
{
    //return mandanten;
    if (AuthToken)
        return new API().get('/Mandanten');
    else
        return [];
}
