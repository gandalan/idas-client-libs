using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client;
using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.Data.DTOs.Update;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ChangeWebRoutinen : WebRoutinenBase
    {
        public ChangeWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public ChangeDTO[] GetChanges(string typeName, DateTime changedSince)
        {
            if (Login())
            {
                return Get<ChangeDTO[]>($"Change/?typeName={typeName}&changedSince={changedSince.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }
            return null;
        }

        public async Task<ChangeDTO[]> GetChangesAsync(string typeName, DateTime changedSince)
        {
            return await Task.Run(() => GetChanges(typeName, changedSince));
        }
    }
}