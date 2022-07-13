using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class FeedbackKommentarWebRoutinen : WebRoutinenBase
    {
        public FeedbackKommentarWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

                
        public void AddKommentar(Guid feedbackGuid, FeedbackKommentarDTO dto)
        {
            if (Login())
            {
                Put($"FeedbackKommentar/?feedbackGuid={feedbackGuid}", dto);
            }
        }

        public async Task AddKommentarAsync(Guid feedbackGuid, FeedbackKommentarDTO dto)
        {
            await Task.Run(() => AddKommentar(feedbackGuid, dto));
        }
    }
}