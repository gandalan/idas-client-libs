using System;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Benutzer
{
    public class LoginAttemptResultDTO
    {
        public int FailCount { get; set; }
        public DateTime? RequestTime { get; set; }
    }
}
