using System;

namespace Gandalan.IDAS.WebApi.Client.Discovery
{
    public class NetworkMessage
    {
        public Guid MessageGuid { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Content { get; set; }

        public NetworkMessage()
        {
            MessageGuid = Guid.NewGuid();
        }
    }
}
