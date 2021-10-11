using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace Gandalan.IDAS.Web
{
    [Serializable]
    public class ApiException : Exception
    {
        public string Payload { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ExceptionString { get; set; }

        public ApiException()
        {
        }

        public ApiException(string message) : base(message)
        {
        }

        public ApiException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public ApiException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ApiException(string message, HttpStatusCode statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }

        public ApiException(string message, object payload) : base(message)
        {
            Payload = JsonConvert.SerializeObject(payload);
        }

        public ApiException(string message, HttpStatusCode statusCode, object payload) : base(message)
        {
            StatusCode = statusCode;
            Payload = JsonConvert.SerializeObject(payload);
        }

        public ApiException(string message, Exception innerException, object payload) : base(message, innerException)
        {
            Payload = JsonConvert.SerializeObject(payload);
        }

        public ApiException(string message, HttpStatusCode statusCode, Exception innerException, object payload) : base(message, innerException)
        {
            StatusCode = statusCode;
            Payload = JsonConvert.SerializeObject(payload);
        }

        protected ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }


    }
}
