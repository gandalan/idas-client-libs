using Gandalan.IDAS.WebApi.DTO;
using System;
using Gandalan.Client.Common.Contracts.Lookups;

namespace Gandalan.Client.Common.Contracts
{
    public interface IFarbLookup : IFeldEditor<IFarbLookupResult, IFarbLookupParams>
    {
    }

    public interface IFarbLookupParams
    {
        FarbGruppeDTO[] FarbGruppen { get; }
        OberflaecheDTO[] Oberflaechen { get; }
        FarbKuerzelDTO[] FarbKuerzelListe { get; }
        FarbeDTO[] Farben { get; set; }
        bool NurStandardfarben { get; }
    }

    public interface IFarbLookupResult
    {
        FarbeDTO Farbe { get; }
        OberflaecheDTO Oberflaeche { get; }
        bool IstStandardFarbKuerzel { get; }
        FarbKuerzelDTO FarbKuerzel { get; }
        bool IsValid { get; }
    }

    public class FarbLookupParams : IFarbLookupParams
    {
        public FarbeDTO[] Farben { get; set; }
        public FarbGruppeDTO[] FarbGruppen { get; set; }
        public OberflaecheDTO[] Oberflaechen { get; set; }
        public FarbKuerzelDTO[] FarbKuerzelListe { get; set; }       
        public bool NurStandardfarben { get; set; }
    }

    public class FarbLookupResult : IFarbLookupResult
    {
        public static IFarbLookupResult Empty => new FarbLookupResult();

        public FarbeDTO Farbe { get; }
        public OberflaecheDTO Oberflaeche { get; }
        public bool IstStandardFarbKuerzel { get; }
        public FarbKuerzelDTO FarbKuerzel { get; }
        public bool IsValid { get; set; }

        public FarbLookupResult()
        {
        }

        public FarbLookupResult(FarbeDTO farbe, OberflaecheDTO oberflaeche, FarbKuerzelDTO kuerzel, bool istStandardFarbKuerzel)
        {
            IsValid = true;
            Farbe = farbe;
            Oberflaeche = oberflaeche;
            FarbKuerzel = kuerzel;
            IstStandardFarbKuerzel = istStandardFarbKuerzel;
        }
    }
}
