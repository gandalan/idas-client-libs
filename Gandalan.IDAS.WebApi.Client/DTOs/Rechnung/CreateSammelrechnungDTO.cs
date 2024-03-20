using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IDAS.WebApi.Client.DTOs.Rechnung
{
    public class CreateSammelrechnungDTO
    {
        public CreateSammelrechnungDTO()
        {
            BelegGuids = new List<Guid>();
        }

        public IList<Guid> BelegGuids { get; set; }
        public Guid KontaktGuid { get; set; }
        public string Ansprechpartner { get; set; }
        public string Liefertermin { get; set; }
        public string Schlusstext { get; set; }
        public string ZahlungsBedingungen { get; set; }
        public BeleganschriftDTO RechnungsAdresse { get; set; }
    }
}
