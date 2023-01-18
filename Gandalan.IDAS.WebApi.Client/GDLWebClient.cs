using System;
using System.Text;
using System.Net;

namespace Gandalan.IDAS.Web
{
    internal class GDLWebClient : WebClient
    {
        public GDLWebClient() : base()
        {
            Headers[HttpRequestHeader.ContentType] = "application/json;+charset=UTF-8";
            Headers[HttpRequestHeader.Accept] = "application/json";
            Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// Timeout in ms, Default: 60.000ms
        /// </summary>
        public int Timeout { get; set; } = 60000;
        public bool UseCompression { get; internal set; }

        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            if (UseCompression && w is HttpWebRequest request)
                request.AutomaticDecompression = DecompressionMethods.GZip;
            w.Timeout = Timeout;
            return w;
        }

    }
}
