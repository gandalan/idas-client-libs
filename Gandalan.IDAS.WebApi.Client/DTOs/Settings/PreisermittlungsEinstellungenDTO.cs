using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.Data.Visitor;

namespace Gandalan.IDAS.WebApi.DTO;

public class PreisermittlungsEinstellungenDTO : IVisitable
{
    public string WaehrungsSymbol { get; set; }
    public double WaehrungsFaktor { get; set; }
    public double SteuerSatz { get; set; }
    public string EndpreisRundungsModus { get; set; }
    public string SonderfarbZuschlaege { get; set; }
    public bool BruttoPreisErmitteln { get; set; }
    public Dictionary<Guid, List<AufpreisAnpassungDTO>> AufpreisAnpassungen { get; set; }
    public Dictionary<Guid, decimal> PreisfaktorAnpassungen { get; set; }
    public Dictionary<Guid, decimal> ZuschnittpreisfaktorAnpassungen { get; set; }
    public Dictionary<Guid, decimal> AufpreisfaktorAnpassungen { get; set; }
    public Dictionary<Guid, bool> GrenzfreigabeAnpassungen { get; set; }
    public decimal MbAufpreis { get; set; }
    public decimal? Mb_v_Fix_Aufpreis { get; set; }
    public decimal? Mb_Klebeband_Aufpreis { get; set; }
    public DateTime ChangedDate { get; set; }

    public void Accept(IVisitor visitor)
    {
            visitor.Visit(this);
        }
}