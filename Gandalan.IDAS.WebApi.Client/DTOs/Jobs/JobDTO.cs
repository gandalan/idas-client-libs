using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class JobDTO
    {
        public Guid JobId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public virtual List<JobStatusDTO> Stati { get; set; }
        public virtual List<JobParameterDTO> Parameter { get; set; }

        public DateTime Erstellt => Stati != null && Stati.Any() ? Stati.First().Zeitstempel : DateTime.MinValue;
        public DateTime Geaendert => Stati != null && Stati.Any() ? Stati.Last().Zeitstempel : DateTime.MinValue;

        public JobDTO()
        {
            Stati = [];
            Parameter = [];
        }

        public bool CancelWait { get; set; }

        public static JobDTO AddJob(string sender, string recipient)
        {
            var job = new JobDTO { Sender = sender, Recipient = recipient };
            job.Stati.Add(new JobStatusDTO { StatusCode = "N", StatusText = "Eingefügt von " + sender, Zeitstempel = DateTime.UtcNow });
            return job;
        }

        public JobDTO AddStatus(string code, string text)
        {
            Stati.Add(new JobStatusDTO { StatusCode = code, StatusText = text, Zeitstempel = DateTime.UtcNow });
            return this;
        }

        public JobDTO AddParameter(string richtung, string name, object value)
        {
            if (string.IsNullOrEmpty(name) || value == null)
            {
                return this;
            }

            Parameter.Add(new JobParameterDTO { Richtung = richtung, Name = name, Wert = value.ToString(), DatenTyp = value.GetType().Name });
            return this;
        }

        public JobDTO AddParameter(string richtung, Dictionary<string, string> parameter)
        {
            foreach (var k in parameter.Keys)
            {
                AddParameter(richtung, k, parameter[k]);
            }

            return this;
        }

        public List<JobStatusDTO> GetOrderedStati()
        {
            return Stati.ToList().OrderBy(ts => ts.StatusCodeAsInt).ToList();
        }
    }
}
