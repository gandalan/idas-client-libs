using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Rechnungen
{
    public interface IRechnungErstellenModul
    {
        Task ShowRechnungErstellen();
    }

    public interface IRechnungAusgabeModul
    {
        Task ShowRechnungAusgabe();
    }
}