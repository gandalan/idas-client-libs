using System;
using System.Net;

namespace Gandalan.IDAS.WebApi.Client
{
    public class ApiErrorArgs : EventArgs
    {
        public HttpStatusCode StatusCode;
        public string Message;

        public ApiErrorArgs(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
    }
}
