using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.Client.Contracts.Contracts.ProduktionsServices
{
    /// <summary>
    /// Abrufen von profilabhängigen Sägemaßkorrekturen
    /// </summary>
    public interface ISaegemassKorrekturService
    {
        /// <summary>
        /// Ruft das (summierte) Korrekturmaß für ein MaterialbedarfDTO, abhängig von Winkel links/rechts, ab.
        /// </summary>
        /// <param name="korrekturSatz">Korrektursatz der genutzt werden soll</param>
        /// <param name="material">MaterialbedarfDTO, für das das Korrekturmaß abgerufen werden soll</param>
        /// <returns></returns>
        float GetKorrekturmass(string korrekturSatz, MaterialbedarfDTO material);

        /// <summary>
        /// Ruft das (summierte) Korrekturmaß für ein MaterialbedarfDTO, abhängig von Winkel links/rechts, ab. Nutzt den Korrektursatz, der an der Säge "Serie" hinterlegt ist-
        /// </summary>
        /// <param name="material">MaterialbedarfDTO, für das das Korrekturmaß abgerufen werden soll</param>
        /// <returns></returns>
        float GetKorrekturmass(MaterialbedarfDTO material);

        /// <summary>
        /// Ruft das Korrekturmaß für ein Profil beim angegebenen Winkel ab
        /// </summary>
        /// <param name="korrekturSatz">Korrektursatz der genutzt werden soll</param>
        /// <param name="katalogNummer">Katalognummer des Profils</param>
        /// <param name="winkel">Winkel, für den das Korrekturmaß abgerufen werden soll</param>
        /// <returns></returns>
        float GetKorrekturmass(string korrekturSatz, string katalogNummer, int winkel);

        /// <summary>
        /// Ruft das Korrekturmaß für ein Profil beim angegebenen Winkel ab. Nutzt den Korrektursatz, der an der Säge "Serie" hinterlegt ist.
        /// </summary>
        /// <param name="katalogNummer">Katalognummer des Profils</param>
        /// <param name="winkel">Winkel, für den das Korrekturmaß abgerufen werden soll</param>
        /// <returns></returns>
        float GetKorrekturmass(string katalogNummer, int winkel);

        /// <summary>
        /// Liefert das korrigierte Zuschnittsmaß für ein MaterialbedarfDTO (ZuschnittLaenge + Korrekturmaß)
        /// </summary>
        /// <param name="korrekturSatz">Korrektursatz der genutzt werden soll</param>
        /// <param name="material">MaterialbedarfDTO, für das die korrigierte Zuschnittslänge abgerufen werden soll</param>
        /// <returns></returns>
        float GetZuschnittKorrigiert(string korrekturSatz, MaterialbedarfDTO material);

        /// <summary>
        /// Liefert das korrigierte Zuschnittsmaß für ein MaterialbedarfDTO (ZuschnittLaenge + Korrekturmaß). Nutzt den Korrektursatz, der an der Säge "Serie" hinterlegt ist.
        /// </summary>
        /// <param name="material">MaterialbedarfDTO, für das die korrigierte Zuschnittslänge abgerufen werden soll</param>
        /// <returns></returns>
        float GetZuschnittKorrigiert(MaterialbedarfDTO material);
    }
}
