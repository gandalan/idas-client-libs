using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

public interface ICalcAblageFachBedarf
{
    /// <summary>
    /// Berechnet den Gesamtbedarf an Ablagefächern für eine Position
    /// </summary>
    /// <param name="position"></param>
    int CalcBedarf(BelegPositionAVDTO position);

    /// <summary>
    /// Berechnet die positionsbezogene Fachnummer für ein Material (z.B. {Fr} = 1, {Fr}2 = 2, etc.)
    /// </summary>
    /// <param name="position"></param>
    /// <param name="material"></param>
    int GetPositionRelatedFachNr(BelegPositionAVDTO position, MaterialbedarfDTO material);
}