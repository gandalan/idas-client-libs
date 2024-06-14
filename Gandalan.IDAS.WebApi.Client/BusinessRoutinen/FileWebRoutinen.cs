using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen;

public class FileWebRoutinen : WebRoutinenBase
{
    public FileWebRoutinen(IWebApiConfig settings) : base(settings)
    {
        }

    public async Task<byte[]> GetFileAsync(string name)
        => await GetDataAsync("StaticFile/?name=" + name);

    public async Task<FileInfoDTO[]> GetFileListAsync(Guid? mandantGuid = null)
    {
            var mandantURI = "";
            if (mandantGuid.HasValue)
            {
                mandantURI = "?mandantGuid=" + mandantGuid;
            }
            return await GetAsync<FileInfoDTO[]>("StaticFile" + mandantURI);
        }

    public async Task SaveFileAsync(string fileName, byte[] data)
        => await PutDataAsync("StaticFile/?name=" + fileName, data);
}