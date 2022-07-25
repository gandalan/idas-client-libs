using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FeedbackWebRoutinen : WebRoutinenBase
    {
        public FeedbackWebRoutinen(IWebApiConfig settings) : base(settings)
        {

        }

        public List<FeedbackDTO> GetFeedbacks()
        {
            if(Login())
            {
                return Get<List<FeedbackDTO>>("Feedback");
            }
            return null;
        }

        public async Task<List<FeedbackDTO>> GetFeedbacksAsync()
        {
            return await Task.Run(() => GetFeedbacks());
        }
        public FeedbackDTO GetFeedback(Guid feedbackGuid)
        {
            if (Login())
            {
                return Get<FeedbackDTO>($"Feedback/{feedbackGuid}");
            }
            return null;
        }

        public async Task<FeedbackDTO> GetFeedbackAsync(Guid feedbackGuid)
        {
            return await Task.Run(() => GetFeedback(feedbackGuid));
        }

        public string SetFeedback(FeedbackDTO dto)
        {
            if (Login())
            {
                return Put<string>("Feedback", dto);
            }
            return "Not logged in";
        }

        public async Task<string> SetFeedbackAsync(FeedbackDTO dto)
        {
            return await Task.Run(() => SetFeedback(dto));
        }

        public string DeleteFeedback(Guid guid)
        {
            if(Login())
            {
                return Delete<string>($"Feedback/{guid}");
            }
            return "Not logged in";
        }

        public async Task<string> DeleteFeedbackAsync(Guid guid)
        {
            return await Task.Run(() => DeleteFeedback(guid));
        }
    }
}
