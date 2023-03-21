namespace Gandalan.IDAS.WebApi.Data.Visitor
{
    /// <summary>
    /// Einfaches Visitor-Pattern. Wir implementieren aber hier noch eine Variante der Visit-Methode, die 
    /// ein dynamic akzeptiert, weil wir in ExpandoObject und anderen dynamic-Klassen nicht IVisitable implementieren
    /// können (sind sealed)
    /// </summary>
    public interface IVisitor
    {
        void Visit(IVisitable target);
        void Visit(dynamic target);
    }
}
