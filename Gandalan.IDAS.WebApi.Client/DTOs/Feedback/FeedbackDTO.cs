using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class FeedbackDTO
{
    public Guid FeedbackGuid { get; set; }
    public DateTime ChangedDate { get; set; }
    public long Version { get; set; }
    public string PCode { get; set; }
    public string Jahr { get; set; }
    public string Vorgangsnummer { get; set; }
    public string Positionsnummer { get; set; }
    public string Benutzername { get; set; }
    public MandantDTO Mandant { get; set; }
    public Guid BelegPositionGuid { get; set; }
    public BelegPositionDTO BelegPosition { get; set; }
    public IList<BelegPositionAVDTO> AVPositionen { get; set; }
    public ProduktionsSettingsDTO ProduktionsSettings { get; set; }
    public string Beschreibung { get; set; }
    public IList<FeedbackAttachmentDTO> Anhaenge { get; set; }
    public IList<FeedbackKommentarDTO> Kommentare { get; set; }
    public string Status { get; set; }
    public string LoesungsVersion { get; set; }
    public string HotlineTicketNummer { get; set; }
}

public class FeedbackKommentarDTO
{
    public Guid FeedbackKommentarGuid { get; set; }
    public DateTime Zeitstempel { get; set; }
    public string Benutzer { get; set; }
    public string Inhalt { get; set; }
}

public class FeedbackAttachmentDTO
{
    public Guid FeedbackAttachmentGuid { get; set; }
    public DateTime Zeitstempel { get; set; }
    public string Filename { get; set; }
    public string URL { get; set; }
}

public class FeedbackNotifyItemDTO
{
    public Guid FeedbackNotifyItemGuid { get; set; }
    public string Type { get; set; }
    public string Benutzer { get; set; }
    public Guid FeedbackGuid { get; set; }
    public Guid FeedbackKommentarGuid { get; set; }
    public bool Gelesen { get; set; }
    public DateTime ChangedDate { get; set; }
}
