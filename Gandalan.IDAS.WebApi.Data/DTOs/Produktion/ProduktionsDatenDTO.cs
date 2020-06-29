using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// Produktionsdaten für ein Fertigelement
    /// </summary>
    public class ProduktionsDatenDTO
    {
        /// <summary>
        /// Eindeutige ID
        /// </summary>
        public Guid ProduktionsDatenGuid { get; set; }
        /// <summary>
        /// Gesamtliste des benötigten Materials (immer für Stückzahl 1)
        /// </summary>
        public List<MaterialbedarfDTO> Material { get; set; } = new List<MaterialbedarfDTO>();
        /// <summary>
        /// Produktionsetiketten
        /// </summary>
        public List<EtikettDTO> Etiketten { get; set; } = new List<EtikettDTO>();
        /// <summary>
        /// CNC-Bearbeitungen
        /// </summary>
        public List<BearbeitungDTO> Bearbeitungen { get; set; } = new List<BearbeitungDTO>();
        /// <summary>
        /// Daten der Original-Belegposition
        /// </summary>
        public PositionsDatenDTO PositionsDaten { get; set; }

        /// <summary>
        /// Gibt Artikel aus dem Materialbedarf zurück, die KEINE Zuschnitte sind
        /// </summary>
        /// <returns>Materialliste</returns>
        public List<MaterialbedarfDTO> GetMaterialbedarf()
        {
            return Material == null ? new List<MaterialbedarfDTO>() : Material.Where(m => m.IstZuschnitt == false || m.ZuschnittLaenge == 0).ToList();
        }

        /// <summary>
        /// Gibt NUR Artikel aus dem Materialbedarf zurück, die Zuschnitte sind
        /// </summary>
        /// <returns></returns>
        public List<MaterialbedarfDTO> GetSaegeliste()
        {
            return Material == null ? new List<MaterialbedarfDTO>() : Material.Where(m => m.IstZuschnitt == true && m.ZuschnittLaenge > 0).ToList();
        }
    }
}
