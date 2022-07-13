using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FeedbackAttachementWebRoutinen : WebRoutinenBase
    {
        public FeedbackAttachementWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] GetAttachement(string filename)
        {
            if (Login())
            {
                return GetData("FeedbackAttachement/?filename=" + filename);
            }
            return null;
        }

        public FeedbackAttachmentDTO[] GetAttachementList(Guid feedbackGuid)
        {
            if (Login())
            {
                return Get<FeedbackAttachmentDTO[]>($"FeedbackAttachement/?feedbackGuid={feedbackGuid}");
            }
            return null;
        }
                
        public void SaveAttachement(Guid feedbackGuid, string fileName, byte[] data)
        {
            if (Login())
            {
                PutData($"FeedbackAttachement/?feedbackGuid={feedbackGuid}&filename={fileName}", data);
            }
        }

        public string DeleteAttachement(Guid feedbackGuid, string fileName)
        {
            if (Login())
            {
                return Delete($"FeedbackAttachement/?feedbackGuid={feedbackGuid}&filename={fileName}");
            }
            return "Not logged in";
        }

        public async Task SaveAttachementAsync(Guid feedbackGuid, string fileName, byte[] data)
        {
            await Task.Run(() => SaveAttachement(feedbackGuid, fileName, data));
        }

        public async Task<FeedbackAttachmentDTO[]> GetAttachementListAsync(Guid feedbackGuid)
        {
            return await Task.Run(() => GetAttachementList(feedbackGuid));
        }

        public async Task<byte[]> GetAttachementAsync(string filename)
        {
            return await Task.Run(() => GetAttachement(filename));
        }

        public async Task<string> DeleteAttachementAsync(Guid feedbackGuid, string fileName)
        {
            return await Task.Run(() => DeleteAttachement(feedbackGuid, fileName));
        }
    }
}