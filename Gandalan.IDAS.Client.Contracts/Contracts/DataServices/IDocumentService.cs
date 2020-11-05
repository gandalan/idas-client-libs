using Gandalan.IBOS3.Module.Lookups.Document;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.DataServices
{
    public interface IDocumentService
    {
        Task<IDocument[]> GetAllAsync(); //gets all available with variants with its guids GET /v3/ibos/assets
        Task<IDocument[]> GetAllByVarianteAsync(Guid varianteGuid); //gets all available assets by variant POST /v3/ibos/assets { "guid": "VarianteGuid" }
        Task<byte[]> GetAsync(Guid assetGuid, string type); //downloads asset POST /v3/ibos/asset {Guid: "AssetGuid", Type: ""}
        Task<IList<byte[]>> GetAllBegleitpapiere(IList<string> varianten);
    }
}
