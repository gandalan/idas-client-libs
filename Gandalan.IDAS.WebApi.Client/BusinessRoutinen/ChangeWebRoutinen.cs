using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.Data.DTOs.Update;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class ChangeWebRoutinen : WebRoutinenBase
    {
        public ChangeWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public ChangeDTO[] GetChanges(string typeName, DateTime changedSince)
        {
            if (Login())
            {
                return Get<ChangeDTO[]>($"Change/?typeName={typeName}&changedSince={changedSince.ToString("o")}");
            }
            return null;
        }

        public async Task<ChangeDTO[]> GetChangesAsync(string typeName, DateTime changedSince)
        {
            return await Task.Run(() => GetChanges(typeName, changedSince));
        }

        public string DeleteOldChanges()
        {
            return Delete("Change");
        }
    }
}