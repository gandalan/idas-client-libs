﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class KatalogArtikelIndiDatenDTO
    {
        public Guid KatalogArtikelGuid { get; set; }
        public bool IsPassiv { get; set; }
        public bool IsInventurPflichtig { get; set; }
        public bool BestellMengeAufVERunden { get; set; }
        public string KundenArtikelNummer { get; set; }
        public IList<IndiFarbDatenDTO> FarbDaten { get; set; }
    }

    public class IndiFarbDatenDTO 
    {
        public string FarbKuerzel { get; }
        public bool BestellMengeAufVERunden { get; set; }
        public decimal SonderPreis { get; set; }
        public bool IsInventurpflichtig { get; set; }
        public bool Lagerfuehrung { get; set; }
    }
}
