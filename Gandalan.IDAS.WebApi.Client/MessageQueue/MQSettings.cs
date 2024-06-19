using System;

namespace Gandalan.IDAS.WebApi.Client.MessageQueue;

public class MQSettings
{
    public string Host { get; private set; }
    public string User { get; private set; }
    public string Password { get; private set; }
    public string Exchange { get; private set; }
    public string RoutingKey { get; private set; }

    public MQSettings(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Message Queue settings must not be null/empty");
        }

        Host = "";
        User = "";
        Password = "";
        Exchange = "";
        RoutingKey = "";
        try
        {
            var uri = new Uri(connectionString);
            Host = uri.Host;
            if (!string.IsNullOrEmpty(uri.UserInfo))
            {
                User = (uri.UserInfo + ":").Split(':')[0];
                Password = (uri.UserInfo + ":").Split(':')[1];
            }

            Exchange = uri.PathAndQuery.Substring(1); // skip leading slash
            RoutingKey = "";
        }
        catch
        {
            throw new InvalidOperationException("Invalid trace settings in web.config, invalid URI!");
        }
    }
}
