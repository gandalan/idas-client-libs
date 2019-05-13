using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Discovery
{
    public class ServerDiscovery
    {
        public static string WebAPIBaseURL { get; private set; }

        public static async Task<bool> ExecuteUDP(int timeout = 3000)
        {
            bool responseReceived = false;
            DateTime startTime = DateTime.Now;
            
            try
            {
                UdpClient client = new UdpClient();
                client.ExclusiveAddressUse = false;
                IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 5437);
                client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                client.ExclusiveAddressUse = false;
                client.Client.Bind(localEp);
                IPAddress multicastaddress = IPAddress.Parse("239.0.0.222");
                client.JoinMulticastGroup(multicastaddress);

                await Task.Run(() =>
                {
                    Task<UdpReceiveResult> receiveTask = client.ReceiveAsync();
                    while (!responseReceived && DateTime.Now < startTime.AddMilliseconds(timeout))
                    {
                        if (receiveTask.IsCompleted)
                        {
                            Byte[] data = receiveTask.Result.Buffer;
                            string strData = Encoding.Unicode.GetString(data);
                            if (!string.IsNullOrEmpty(strData))
                            {
                                NetworkMessage response = JsonConvert.DeserializeObject<NetworkMessage>(strData);
                                if (response != null)
                                {
                                    processMessage(response);
                                    if (!string.IsNullOrEmpty(WebAPIBaseURL))
                                    {
                                        responseReceived = true;
                                    }
                                }
                            }
                        }
                        Thread.Sleep(500);
                    }
                });

                client.DropMulticastGroup(multicastaddress);
                client.Close();
                client.Dispose();

                return responseReceived;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void processMessage(NetworkMessage response)
        {
            if (response.Content.StartsWith("IDASv17:"))
            {
                WebAPIBaseURL = response.Content.Replace("IDASv17:", "");
            }
            else
            {
                // Fallback, eig unnötig
                WebAPIBaseURL = $"https://{response.Sender}/api/";
            }
        }
    }
}