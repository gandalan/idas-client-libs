using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.MessageQueue
{
    public class NewFeedbackKommentarMessagePayload
    {
        public FeedbackDTO Feedback { get; set; }
        public FeedbackKommentarDTO FeedbackKommentar { get; set; }
    }
}
