using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts
{
    public interface ISaldoLookup : ILookupDialog<ISaldoLookupResult, ISaldoLookupParams>
    {
    }

    public interface ISaldoLookupParams
    {
        BelegSaldoDTO BelegSaldo { get; }
    }

    public interface ISaldoLookupResult
    {
        BelegSaldoDTO Saldo { get; }
        bool IsValid { get; }
    }

    public class SaldoLookupParams : ISaldoLookupParams
    {
        public BelegSaldoDTO BelegSaldo { get; set; }
    }

    public class SaldoLookupResult : ISaldoLookupResult
    {
        public static ISaldoLookupResult Empty => new SaldoLookupResult();

        public BelegSaldoDTO Saldo { get; }
        public bool IsValid { get; set; }

        public SaldoLookupResult()
        {
        }

        public SaldoLookupResult(BelegSaldoDTO saldo)
        {
            Saldo = saldo;
            IsValid = true;
        }
    }
}
