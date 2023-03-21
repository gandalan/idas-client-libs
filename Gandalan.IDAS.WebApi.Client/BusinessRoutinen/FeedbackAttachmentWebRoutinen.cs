using Gandalan.IDAS.Client.Contracts.Contracts;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FeedbackAttachmentWebRoutinen : WebRoutinenBase
    {
        public FeedbackAttachmentWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public byte[] GetAttachment(Guid attachmentGuid)
        {
            if (Login())
            {
                return GetData($"FeedbackAttachment/{attachmentGuid}");
            }
            return null;
        }
                        
        public void SaveAttachment(Guid feedbackGuid, string fileName, byte[] data)
        {
            if (Login())
            {
                PutData($"FeedbackAttachment/?feedbackGuid={feedbackGuid}&filename={fileName}", data);
            }
        }

        public string DeleteAttachment(Guid attachmentGuid)
        {
            if (Login())
            {
                return Delete($"FeedbackAttachment/{attachmentGuid}");
            }
            return "Not logged in";
        }

        public async Task SaveAttachmentAsync(Guid feedbackGuid, string fileName, byte[] data)
        {
            await Task.Run(() => SaveAttachment(feedbackGuid, fileName, data));
        }

        public async Task<byte[]> GetAttachementAsync(Guid attachmentGuid)
        {
            return await Task.Run(() => GetAttachment(attachmentGuid));
        }

        public async Task<string> DeleteAttachmentAsync(Guid attachmentGuid)
        {
            return await Task.Run(() => DeleteAttachment(attachmentGuid));
        }
    }
}