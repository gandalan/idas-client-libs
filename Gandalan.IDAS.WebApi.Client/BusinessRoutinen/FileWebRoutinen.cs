using System;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FileWebRoutinen : WebRoutinenBase
    {
        public FileWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] GetFile(string name)
        {
            if (Login())
            {
                return GetData("StaticFile/?name=" + name);
            }
            return null;
        }

        public FileInfoDTO[] GetFileList(Guid? mandantGuid = null)
        {
            if (Login())
            {
                var mandantURI = "";
                if (mandantGuid.HasValue)
                {
                    mandantURI = "?mandantGuid=" + mandantGuid;
                }
                return Get<FileInfoDTO[]>("StaticFile" + mandantURI);
            }
            return null;
        }

        public byte[] SaveFile(string fileName, byte[] data)
        {
            if (Login())
            {
                return PutData("StaticFile/?name=" + fileName, data);
            }
            return null;
        }


        public async Task SaveFileAsync(string fileName, byte[] data)
        {
            await Task.Run(() => SaveFile(fileName, data));
        }

        public async Task<FileInfoDTO[]> GetFileListAsync(Guid? mandantGuid = null)
        {
            return await Task.Run(() => GetFileList(mandantGuid));
        }

        public async Task<byte[]> GetFileAsync(string name)
        {
            return await Task.Run(() => GetFile(name));
        }
    }
}