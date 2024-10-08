namespace Gandalan.IDAS.WebApi.Client.MessageQueue;

public class FeedbackStatusChangeMessagePayload : ValueChangedMessagePayload
{
    public string HotlineTicketNummer { get; set; }
}
