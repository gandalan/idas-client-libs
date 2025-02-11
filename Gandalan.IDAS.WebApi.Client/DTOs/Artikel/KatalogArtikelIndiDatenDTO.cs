using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class KatalogArtikelIndiDatenDTO
{
    public Guid KatalogArtikelIndiDatenGuid { get; set; }

    public Guid KatalogArtikelGuid { get; set; }
    public bool IsPassiv { get; set; }
    public bool IsInventurPflichtig { get; set; }
    public bool IsLagerartikel { get; set; }
    public bool BestellMengeAufVERunden { get; set; }
    public string KundenArtikelNummer { get; set; }
    public IList<IndiFarbDatenDTO> FarbDaten { get; set; }
    public bool Freigabe_IBOS { get; set; }
    public bool Freigabe_BestellFix { get; set; }
    public bool Freigabe_ARTOS { get; set; }
    public int InventurBewertung { get; set; }

    public DateTime ChangedDate { get; set; }
    public string SerializedOptions { get; set; }
}

public class IndiFarbDatenDTO
{
    public Guid IndiFarbDatenGuid { get; set; }
    public bool IsPassiv { get; set; }
    public string FarbKuerzel { get; set; }
    public bool BestellMengeAufVERunden { get; set; }
    public decimal SonderPreis { get; set; }
    public bool IsInventurpflichtig { get; set; }
    public bool Lagerfuehrung { get; set; }
    public bool Freigabe_IBOS { get; set; }
    public bool Freigabe_BestellFix { get; set; }
    public bool Freigabe_ARTOS { get; set; }
}
