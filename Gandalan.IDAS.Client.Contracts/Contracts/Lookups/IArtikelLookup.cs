using Gandalan.Client.Contracts;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.IBOS3.Module.Lookups.Artikel
{
    public interface IArtikelLookup : ILookupDialog<IArtikelLookupResult, IArtikelLookupParams>
    {
    }

    public interface IArtikelLookupParams
    {
        KatalogArtikelDTO[] ArtikelListe { get; }
        VarianteDTO[] VariantenListe { get; }
    }

    public interface IArtikelLookupResult
    {
        KatalogArtikelDTO Artikel { get; }
        VarianteDTO Variante { get; }
    }

    public class ArtikelLookupParams : IArtikelLookupParams
    {
        public KatalogArtikelDTO[] ArtikelListe { get; set; }

        public VarianteDTO[] VariantenListe { get; set; }
    }

    public class ArtikelLookupResult : IArtikelLookupResult
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
