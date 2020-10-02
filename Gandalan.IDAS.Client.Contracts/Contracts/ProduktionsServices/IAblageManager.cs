using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
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
        /// <param name="standort">Standort der Ablage</param>
        /// <param name="material">Material, das abgelegt werden soll</param>
        /// <returns>AblageFachDTO</returns>
        AblageFachDTO GetEmptyAblageFach(string standort, MaterialbedarfDTO material);

        /// <summary>
        /// Sucht das Ablagefach für ein übergebenes MaterialbedarfDTO. Liefert ein Ablagefach zurück, sofern
        /// bereits ein MaterialbedarfDTO der gleichen Position in einem Fach abgelegt ist. Wird kein Fach gefunden, wird null zurückgeliefert.
        /// </summary>
        /// <param name="material">MaterialbedarfDTO</param>
        /// <returns>AbalgeFachDTO, sofern bereits ein MaterialbedarfDTO der gleichen Position in einem Fach lagert</returns>
        AblageFachDTO SearchAblageFach(MaterialbedarfDTO material);

        /// <summary>
        /// Legt Material in einem Ablagefach ab
        /// </summary>
        /// <param name="ablageFach">AblageFachDTO, in dem das Material abgelegt werden soll</param>
        /// <param name="materialListe">Liste von MaterialbedarfDTOs, die abgelegt werden sollen</param>
        void PutMaterial(AblageFachDTO ablageFach, List<MaterialbedarfDTO> materialListe);

        /// <summary>
        /// Legt Material für eine Serie in mehren Ablagefächern ab
        /// </summary>
        /// <param name="serie">Sortiert alles Material in der Serie und weist allem Fächer zu</param>
        void PutMaterial(SerieDTO serie);

        /// <summary>
        /// Entfernt übergebene MaterialbedarfDTOs aus ihren Fächern
        /// </summary>
        /// <param name="materialListe">Liste von MaterialbedarfDTOs, die aus ihren Fächern entfernt werden sollen</param>
        void RemoveMaterial(List<MaterialbedarfDTO> materialListe);


        /// <summary>
        /// Kombination aus GetEmptyAblageFach und SearchAblageFach.
        /// </summary>
        /// <param name="standort">Standort der Ablage</param>
        /// <param name="material"></param>
        /// <returns>Material, das abgelegt werden soll</returns>
        AblageFachDTO GetCurrentOrNewAblageFach(string standort, MaterialbedarfDTO material);

        /// <summary>
        /// Liefert alle registrierten Ablagen zu einem Standort
        /// </summary>
        /// <param name="standort">Standort für den die Ablagen geliefert werden.</param>
        /// <returns></returns>
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
        /// <param name="targetFach">Ablagefach in das das Material verschoben werden soll</param>
        void MoveMaterial(AblageFachDTO sourceFach, AblageFachDTO targetFach);

    }
}
