using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{

    public class LagerbestandWebRoutinen : WebRoutinenBase
    {
        public LagerbestandWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public LagerbestandDTO Get(Guid guid)
        {
            if (Login())
            {
                return Get<LagerbestandDTO>("Lagerbestand/?id=" + guid.ToString());
            }
            return null;
        }

        public List<LagerbestandDTO> GetAll(DateTime? changedSince)
        {
            if (Login())
            {
                if (changedSince.HasValue && changedSince.Value > DateTime.MinValue)
                {
                    return Get<List<LagerbestandDTO>>("Lagerbestand?changedSince=" + changedSince.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                }
                else
                {
                    return Get<List<LagerbestandDTO>>("Lagerbestand");
                }
            }
            return null;
        }

        public LagerbestandDTO Lagerbuchung(LagerbuchungDTO buchung)
        {
            if(Login())
            {
                return Put<LagerbestandDTO>("Lagerbuchung", buchung);
            }
            return null;
        }
                
        public string Save(LagerbestandDTO dto)
        {
            if (Login())
            {
                return Put("Lagerbestand/", dto);
            }
            return null;
        }

        public string Delete(Guid guid)
        {
            if (Login())
            {
                return Delete("Lagerbestand/?id=" + guid.ToString());
            }
            return "Not logged in";
        }

        // neue methode für lagerhistorie abholen
        public List<LagerbuchungHistorieDTO> GetLagerhistorie(DateTime vonDatum, DateTime bisDatum)
        {
            // DateTime[] vonBisDatum = { vonDatum, bisDatum };

            if (Login())
                return Get<List<LagerbuchungHistorieDTO>>("Lagerhistorie");

            return null;
        }
        public async Task<LagerbestandDTO> GetAsync(Guid guid)
        {
            return await Task.Run(() => Get(guid));
        }

        public async Task<List<LagerbestandDTO>> GetAllAsync(DateTime? changedSince)
        {
            return await Task.Run(() => GetAll(changedSince));
        }

        public async Task SaveAsync(LagerbestandDTO dto)
        {
            await Task.Run(() => Save(dto));
        }

        public async Task<string> DeleteAsync(Guid guid)
        {
            return await Task.Run(() => Delete(guid));
        }
    }
}