namespace Gandalan.IDAS.Contracts
{
    public abstract class ArtikelBase
    {
        public string KatalogNummer { get; set; }
        public string Bezeichnung { get; set; }
        public virtual decimal Preis { get; set; }
    }

    public abstract class NeherInsektenschutzArtikel : ArtikelBase
    {

    }
}
