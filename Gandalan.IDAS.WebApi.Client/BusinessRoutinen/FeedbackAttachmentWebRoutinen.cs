using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FeedbackAttachmentWebRoutinen : WebRoutinenBase
    {
        public FeedbackAttachmentWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] GetAttachement(Guid attachmentGuid)
        {
            if (Login())
            {
                return GetData($"FeedbackAttachment/{attachmentGuid}");
            }
            return null;
        }
                        
        public void SaveAttachement(Guid feedbackGuid, string fileName, byte[] data)
        {
            if (Login())
            {
                PutData($"FeedbackAttachment/?feedbackGuid={feedbackGuid}&filename={fileName}", data);
            }
        }

        public string DeleteAttachement(Guid attachmentGuid)
        {
            if (Login())
            {
                return Delete($"FeedbackAttachment/{attachmentGuid}");
            }
            return "Not logged in";
        }

        public async Task SaveAttachementAsync(Guid feedbackGuid, string fileName, byte[] data)
        {
            await Task.Run(() => SaveAttachement(feedbackGuid, fileName, data));
        }

        public async Task<byte[]> GetAttachementAsync(Guid attachmentGuid)
        {
            return await Task.Run(() => GetAttachement(attachmentGuid));
        }

        public async Task<string> DeleteAttachementAsync(Guid attachmentGuid)
        {
            return await Task.Run(() => DeleteAttachement(attachmentGuid));
        }
    }
}