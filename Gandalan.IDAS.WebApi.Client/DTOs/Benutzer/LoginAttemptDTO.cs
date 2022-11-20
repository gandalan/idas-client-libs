using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Benutzer
{
    public class LoginAttemptDTO
    {
        public Guid UserGuid { get; set; }
        public int FailCount { get; set; }
        public DateTime? RequestTime { get; set; }
    }
}
