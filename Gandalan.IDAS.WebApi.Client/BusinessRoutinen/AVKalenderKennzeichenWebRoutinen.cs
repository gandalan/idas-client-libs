using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVKalenderKennzeichenWebRoutinen : WebRoutinenBase
    {
        public AVKalenderKennzeichenWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public List<AVKalenderKennzeichenDTO> GetAllKennzeichen(DateTime fromDate, DateTime toDate)
        {
            if (Login())
            {
                return Get<List<AVKalenderKennzeichenDTO>>($"AVKalenderkennzeichen/?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}");
            }
            return null;
        }

        public AVKalenderKennzeichenDTO SaveKennzeichen(AVKalenderKennzeichenDTO kennzeichen)
        {
            if (Login())
            {
                return Put<AVKalenderKennzeichenDTO>("AVKalenderkennzeichen", kennzeichen);
            }
            return null;
        }

        public string DeleteKennzeichen(Guid guid)
        {
            if (Login())
            {
                return Delete($"AVKalenderkennzeichen/{guid}");
            }
            return "Not logged in";
        }

        

        public async Task<List<AVKalenderKennzeichenDTO>> GetAllKennzeichenAsync(DateTime fromDate, DateTime toDate)
        {
            return await Task.Run(() => GetAllKennzeichen(fromDate, toDate));
        }

        
        public async Task<AVKalenderKennzeichenDTO> SaveKennzeichenAsync(AVKalenderKennzeichenDTO kennzeichen)
        {
            return await Task.Run(() => SaveKennzeichen(kennzeichen));
        }

        public async Task<string> DeleteKennzeichenAsync(Guid guid)
        {
            return await Task.Run(() => DeleteKennzeichen(guid));
        }
    }
}
