using System;

namespace Gandalan.IDAS.WebApi.Data.DTOs.WebJob
{
    public class WebJobHistorieDTO
    {
        public Guid WebJobHistorieGuid { get; set; }

        public string WebJobName { get; set; }

        public DateTime Timestamp { get; set; }

        public string Status { get; set; }

        public string Text { get; set; }
    }
}
