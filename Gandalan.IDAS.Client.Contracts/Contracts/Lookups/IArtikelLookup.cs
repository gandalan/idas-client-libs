using Gandalan.Client.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts
{
    public interface ArtikelDBItemLookup : ILookupDialog<ArtikelDBItemLookupResult, ArtikelDBItemLookupParams>
    {
    }

    public interface ArtikelDBItemLookupParams
    {
        KatalogArtikelDTO[] ArtikelListe { get; }
        VarianteDTO[] VariantenListe { get; }
    }

    public interface ArtikelDBItemLookupResult
    {
        KatalogArtikelDTO Artikel { get; }
        VarianteDTO Variante { get; }
    }

    public class ArtikelLookupParams : ArtikelDBItemLookupParams
    {
        public KatalogArtikelDTO[] ArtikelListe { get; set; }

        public VarianteDTO[] VariantenListe { get; set; }
    }

    public class ArtikelLookupResult : ArtikelDBItemLookupResult
    {
        public ArtikelLookupResult(VarianteDTO varianteDTO)
        {
            Variante = varianteDTO;
        }
        public ArtikelLookupResult(KatalogArtikelDTO artikelDTO)
        {
            Artikel = artikelDTO;
        }
        public KatalogArtikelDTO Artikel { get; set; }
        public VarianteDTO Variante { get; set; }
        public bool IsValid => Variante != null || Artikel != null;
        public static ArtikelLookupResult Empty { get; }
    }
}
