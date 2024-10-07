using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

/// <summary>
/// Interface für die Implementierung einer Klasse zum Zugriff auf die Ablagen
/// </summary>
public interface IAblageManager
{
    /// <summary>
    /// Ruft das AblageDTO zum übergebenen AblageFach ab.
    /// </summary>
    /// <param name="ablageFach">AblageFachDTO</param>
    /// <returns>AblageDTO</returns>
    AblageDTO GetAblage(AblageFachDTO ablageFach);

    /// <summary>
    /// Ruft ein freies Ablagefach am übergebenen Standort ab,
    /// das den/die übergebenen Materialtypen aufnehmen kann.
    /// </summary>
    /// <param name="position">Position, aus der Material abgelegt werden soll</param>
    /// <param name="material">Material, das abgelegt werden soll</param>
    /// <param name="standort">Standort der Ablage</param>
    /// <returns>AblageFachDTO</returns>
    AblageFachDTO GetEmptyAblageFach(BelegPositionAVDTO position, MaterialbedarfDTO material, string standort = "Werkstatt");

    /// <summary>
    /// Sucht das Ablagefach für ein übergebenes MaterialbedarfDTO. Liefert ein Ablagefach zurück, sofern
    /// bereits ein MaterialbedarfDTO der gleichen Position in einem Fach abgelegt ist. Wird kein Fach gefunden, wird null zurückgeliefert.
    /// </summary>
    /// <param name="position">Position, aus der Material abgelegt werden soll</param>
    /// <param name="material">MaterialbedarfDTO</param>
    /// <returns>AbalgeFachDTO, sofern bereits ein MaterialbedarfDTO der gleichen Position in einem Fach lagert</returns>
    AblageFachDTO SearchAblageFach(BelegPositionAVDTO position, MaterialbedarfDTO material);

    /// <summary>
    /// Sucht alle Ablagefach für die übergebene BelegPositionAV.
    /// </summary>
    /// <param name="position">Position, aus der Material abgelegt werden soll</param>
    /// <returns>Liste von AbalgeFachDTO</returns>
    List<AblageFachDTO> SearchAblageFach(BelegPositionAVDTO position);

    /// <summary>
    /// Legt eine Materialliste in mehreren Ablagefächern ab
    /// </summary>
    /// <param name="positionen">Liste von Positionen, die das abzulegende Material enthalten</param>
    /// <param name="materialListe">Liste von MaterialbedarfDTOs, die abgelegt werden sollen</param>
    /// <param name="standort">Standort der Ablagen, die berücksichtigt werden</param>
    Task PutMaterialAsync(List<BelegPositionAVDTO> positionen, List<MaterialbedarfDTO> materialListe, string standort = "Werkstatt");

    /// <summary>
    /// Legt Material für eine Serie in mehreren Ablagefächern ab
    /// </summary>
    /// <param name="serie">Sortiert alles Material in der Serie und weist allem Fächer zu</param>
    /// <param name="standort">Standort der Ablagen, die berücksichtigt werden</param>
    Task PutMaterialAsync(SerieDTO serie, string standort = "Werkstatt");

    /// <summary>
    /// Entfernt übergebene MaterialbedarfDTOs aus ihren Fächern
    /// </summary>
    /// <param name="materialListe">Liste von MaterialbedarfDTOs, die aus ihren Fächern entfernt werden sollen</param>
    void RemoveMaterial(List<MaterialbedarfDTO> materialListe);

    /// <summary>
    /// Kombination aus GetEmptyAblageFach und SearchAblageFach.
    /// </summary>
    /// <param name="position"></param>
    /// <param name="material"></param>
    /// <param name="standort">Standort der Ablage</param>
    /// <returns>Material, das abgelegt werden soll</returns>
    AblageFachDTO GetCurrentOrNewAblageFach(BelegPositionAVDTO position, MaterialbedarfDTO material, string standort = "Werkstatt");

    /// <summary>
    /// Liefert alle registrierten Ablagen zu einem Standort
    /// </summary>
    /// <param name="standort">Standort für den die Ablagen geliefert werden.</param>
    List<AblageDTO> GetAblageListe(string standort);

    /// <summary>
    /// Ändert den Standort einer Ablage
    /// </summary>
    /// <param name="ablageGuid">Ablage</param>
    /// <param name="standort">Neuer Ablagestandort</param>
    void ChangeAblageStandort(Guid ablageGuid, string standort);

    /// <summary>
    /// Verschiebt das Material von einem Ablagefach in ein anderes.
    /// </summary>
    /// <param name="sourceFach">Ablagefach in dem sich das Material befindet</param>
    /// <param name="targetFach">Ablagefach in das Material verschoben werden soll</param>
    void MoveMaterial(AblageFachDTO sourceFach, AblageFachDTO targetFach);

    /// <summary>
    /// Liefert die Fachbezeichnung für ein MaterialbedarfDTO
    /// </summary>
    /// <param name="position">Position, aus der Material abgelegt werden soll</param>
    /// <param name="material"></param>
    string GetFachBezeichnung(BelegPositionAVDTO position, MaterialbedarfDTO material);
}
