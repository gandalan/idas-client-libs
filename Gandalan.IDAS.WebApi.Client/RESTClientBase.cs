using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Gandalan.IDAS.Web
{
    public class RESTClientBase
    {
        protected static ApiException TranslateException(WebException ex, object payload)
        {
            if (ex.Response is HttpWebResponse)
            {
                HttpStatusCode code = (ex.Response as HttpWebResponse).StatusCode;
                string info = new StreamReader((ex.Response as HttpWebResponse).GetResponseStream()).ReadToEnd();

                if (!string.IsNullOrWhiteSpace(info))
                {
                    try
                    {
                        Exception original = JsonConvert.DeserializeObject<Exception>(info, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                        return new ApiException(original.Message, code, original, payload);
                    }
                    catch
                    {
                        try
                        {
                            dynamic infoObject = JsonConvert.DeserializeObject<dynamic>(info);
                            string status = infoObject.status;
                            return new ApiException(status, code, payload) { ExceptionString = infoObject.exception.ToString() };
                        }
                        catch
                        {
                            return new ApiException(info, code, payload);
                        }
                    }
                }

                return new ApiException(ex.Message, code, ex, payload);
            }

            return new ApiException(ex.Message, ex, payload);
        }

        protected static ApiException TranslateException(WebException ex)
        {
            if (ex.Response is HttpWebResponse)
            {
                HttpStatusCode code = (ex.Response as HttpWebResponse).StatusCode;
                string info = new StreamReader((ex.Response as HttpWebResponse).GetResponseStream()).ReadToEnd();

                if (!string.IsNullOrWhiteSpace(info))
                {
                    try
                    {
                        Exception original = JsonConvert.DeserializeObject<Exception>(info, new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.All });
                        return new ApiException(original.Message, code, original);
                    }
                    catch
                    {
                        try
                        {
                            dynamic infoObject = JsonConvert.DeserializeObject<dynamic>(info);
                            string status = infoObject.status;
                            return new ApiException(status, code) { ExceptionString = infoObject.exception.ToString() };
                        }
                        catch
                        {
                            return new ApiException(info, code);
                        }
                    }
                }

                return new ApiException(ex.Message, code, ex);
            }

            return new ApiException(ex.Message, ex);
        }
    }
}
