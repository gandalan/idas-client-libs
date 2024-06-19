using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts;

public interface IKundeLookup : ILookupDialog<IKundeLookupResult, IKundeLookupParams>
{
}

public interface IKundeLookupParams
{
    Task<KontaktListItemDTO[]> KundenListe { get; }
}

public interface IKundeLookupResult
{
    KontaktListItemDTO Kunde { get; }
    bool IsValid { get; }
}

public class KundeLookupParams : IKundeLookupParams
{
    public Task<KontaktListItemDTO[]> KundenListe { get; set; }
}

public class KundeLookupResult : IKundeLookupResult
{
    public static IKundeLookupResult Empty => new KundeLookupResult();

    public KontaktListItemDTO Kunde { get; }
    public bool IsValid { get; set; }

    public KundeLookupResult()
    {
    }

    public KundeLookupResult(KontaktListItemDTO kunde)
    {
        Kunde = kunde;
        IsValid = true;
    }
}