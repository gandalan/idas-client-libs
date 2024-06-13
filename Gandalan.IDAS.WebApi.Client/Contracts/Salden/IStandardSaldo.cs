using Gandalan.IDAS.WebApi.Data.DTOs.Salden;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.Salden;

public interface IStandardSaldo
{
    string Name { get; }

    /// <summary>
    /// Prüft ob der StandardSaldo den Vorgang/Beleg betrifft
    /// und gibt das entsprechende <see cref="BelegSaldoDTO"/> zurück.
    /// </summary>
    /// <param name="vorgang">Vorgang</param>
    /// <param name="beleg">Beleg</param>
    /// <param name="dto">Werte des Standard Saldo.
    /// StandardSaldoDTO.Name muss hier IStandardSaldo.Name entsprechen.</param>
    /// <returns><see cref="BelegSaldoDTO"/>, das dem zu erstellenden Standardsaldo entspricht.
    /// null, wenn der StandardSaldo nicht den Vorgang/Beleg betrifft.</returns>
    BelegSaldoDTO Apply(VorgangDTO vorgang, BelegDTO beleg, StandardSaldoDTO dto);
}