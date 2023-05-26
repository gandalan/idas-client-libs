using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class AVKalenderKennzeichenWebRoutinen : WebRoutinenBase
    {
        public AVKalenderKennzeichenWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<List<AVKalenderKennzeichenDTO>> GetAllKennzeichenAsync(DateTime fromDate, DateTime toDate)
        {
            return await GetAsync<List<AVKalenderKennzeichenDTO>>($"AVKalenderkennzeichen/?fromDate={fromDate:yyyy-MM-dd}&toDate={toDate:yyyy-MM-dd}");
        }

        public async Task<AVKalenderKennzeichenDTO> SaveKennzeichenAsync(AVKalenderKennzeichenDTO kennzeichen)
        {
            return await PutAsync<AVKalenderKennzeichenDTO>("AVKalenderkennzeichen", kennzeichen);
        }

        public async Task DeleteKennzeichen(Guid guid)
        {
            await DeleteAsync($"AVKalenderkennzeichen/{guid}");
        }
    }
}
