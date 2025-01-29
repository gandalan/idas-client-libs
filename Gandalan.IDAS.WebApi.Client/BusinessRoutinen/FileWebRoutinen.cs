using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
        => await GetDataAsync($"StaticFile/?name={name}");

    [Obsolete("Please use GetFileListAsync()")]
    public async Task<FileInfoDTO[]> GetFileListAsync(Guid? mandantGuid = null)
    {
        return await GetFileListAsync();
    }

    public async Task<FileInfoDTO[]> GetFileListAsync()
    {
        return await GetAsync<FileInfoDTO[]>("StaticFile");
    }

    public async Task<byte[]> GetFilesZippedAsync(List<string> fileNames)
    {
        var json = JsonSerializer.Serialize(fileNames);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return await PutDataAsync("StaticFile", content);
    }
}
