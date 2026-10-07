using System;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Data.DTO;

namespace Gandalan.IDAS.Client.Contracts.Contracts.DataServices;

public interface ISonderanpassungService
{
    /// <summary>
    /// Die am Stichtag gültigen Sonderanpassungen einer Variante, in der Reihenfolge ihrer Imports.
    /// Liefert <c>null</c>, wenn die Variante nicht bekannt ist.
    /// </summary>
    Task<VarianteSonderWunschDTO> GetAllSonderanpassungenForVariante(string variantenName, DateTime stichTag);
}
