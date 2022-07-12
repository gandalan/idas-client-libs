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
