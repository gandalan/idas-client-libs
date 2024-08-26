using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts;

public interface IArtikelLookup : ILookupDialog<IArtikelLookupResult, IArtikelLookupParams>
{
}

public interface IArtikelLookupParams
{
    KatalogArtikelDTO[] ArtikelListe { get; }
    VarianteDTO[] VariantenListe { get; }
    VarianteDTO[] Sondervarianten { get; }
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
    public VarianteDTO[] Sondervarianten { get; set; }
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