using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.ProduktionsServices
{
    /// <summary>
    /// Contract für die Schnitt-Optimierung, d.h. möglichst optimale Verteilung
    /// von Teilstücken auf Rohmaterial
    /// </summary>
    public interface ISchnittOptimierung
    {
        /// <summary>
        /// Berechnet eine möglichst optimale Verteilung von Teilstücken auf eine
        /// möglichst geringe Anzahl von Rohmaterial-Teilen. Alle Längenangaben in mm!
        /// </summary>
        /// <param name="rohmaterialLaenge">Maximal zu belegende Länge. Endabschnitte müssen vom Aufrufer bereits abgezogen sein.</param>
        /// <param name="teilstueckLaengen">Liste aller gewünschten Teilstücke</param>
        /// <param name="zugabe">Sägezugabe zwischen den Teilstücken (nicht am Anfang/Ende)</param>
        /// <returns></returns>
        IList<ZuschnittStangenInfo> Optimize(int rohmaterialLaenge, int[] teilstueckLaengen, int zugabe = 100);
    }

    /// <summary>
    /// Info über eine Stange mit Teilstücken
    /// </summary>
    public class ZuschnittStangenInfo
    {
        private readonly int _laenge;
        private readonly int _zugabe;

        /// <summary>
        /// Wie viele MM sind belegt?
        /// </summary>
        public int BelegungInMM { get; private set; } = 0;
        /// <summary>
        /// Wie viele Prozent sind belegt?
        /// </summary>
        public int BelegungInProzent { get; private set; } = 0;
        /// <summary>
        /// Wie viele Prozent sind Verschnitt?
        /// </summary>
        public int VerschnittInProzent { get; private set; } = 100;
        /// <summary>
        /// Welche Längen in welcher Reihenfolge liegen auf der Stange?
        /// </summary>
        public IList<int> Laengen { get; } = new List<int>();

        public Guid MaterialbedarfGuid { get; }

        /// <summary>
        /// "Eröffnet" eine neue Stange mit der angegebenen Gesamtlänge und
        /// dem Zugabe-Parameter für Teilstückzwischenräume
        /// </summary>
        /// <param name="laenge"></param>
        /// <param name="zugabe"></param>
        /// <param name="materialbedarfGuid"></param>
        public ZuschnittStangenInfo(int laenge, int zugabe, Guid materialbedarfGuid = default)
        {
            _laenge = laenge;
            _zugabe = zugabe;
            MaterialbedarfGuid = materialbedarfGuid;
        }

        /// <summary>
        /// Prüft, ob ein Teilstück mit der angegebenen Länge noch Platz hat
        /// </summary>
        /// <param name="laenge"></param>
        /// <returns>true/false</returns>
        public bool CanAdd(int laenge)
        {
            return BelegungInMM + _zugabe + laenge <= _laenge;
        }

        /// <summary>
        /// Fügt ein Teilstück an.
        /// </summary>
        /// <param name="laenge">Länge des Teilstücks</param>
        public void Add(int laenge)
        {
            if (CanAdd(laenge))
            {
                Laengen.Add(laenge);
                BelegungInMM += _zugabe + laenge;
                BelegungInProzent = (int)Math.Floor(((float)BelegungInMM / (float)_laenge) * 100);
                VerschnittInProzent = 100 - BelegungInProzent;
            }
            else throw new InvalidOperationException("Kein Platz mehr für dieses Teilstück!");
        }
    }

    public class MaterialbedarfCutOptimization
    {
        public MaterialbedarfDTO[] Materialbedarfs;
        public ZuschnittStangenInfo[] ZuschnittStangenInfos;
    }
}
