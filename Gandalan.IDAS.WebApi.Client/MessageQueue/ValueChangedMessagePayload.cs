namespace Gandalan.IDAS.WebApi.Client.MessageQueue
{
    public class ValueChangedMessagePayload
    {
        public string Empfaenger { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Vorgangsnummer { get; set; }
    }
}
