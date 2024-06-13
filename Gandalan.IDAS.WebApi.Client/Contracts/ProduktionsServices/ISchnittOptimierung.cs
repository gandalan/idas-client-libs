using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;

namespace Gandalan.Client.Contracts.ProduktionsServices;

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
    /// <param name="materialbedarfTeilstueckLaengen">Liste aller gewünschten Teilstücke mit MaterialBedarfGuid</param>
    /// <param name="zugabe">Sägezugabe zwischen den Teilstücken (nicht am Anfang/Ende)</param>
    IList<ZuschnittStangenInfo> Optimize(int rohmaterialLaenge, List<GuidKeyIntValue> materialbedarfTeilstueckLaengen, int zugabe = 100);
}

/// <summary>
/// Info über eine Stange mit Teilstücken
/// </summary>
public class ZuschnittStangenInfo
{
    private readonly int _zugabe;

    /// <summary>
    /// In most cases, this is KatalogArtikel.ProfilLaengeMM
    /// </summary>
    public int Laenge { get; set; }

    /// <summary>
    /// Wie viele MM sind belegt?
    /// </summary>
    public int BelegungInMM { get; set; }

    /// <summary>
    /// Wie viele Prozent sind belegt?
    /// </summary>
    public int BelegungInProzent { get; set; }

    /// <summary>
    /// Wie viele Prozent sind Verschnitt?
    /// </summary>
    public int VerschnittInProzent { get; set; } = 100;

    /// <summary>
    /// Welche Längen in welcher Reihenfolge liegen auf der Stange?
    /// </summary>
    public IList<int> Laengen { get; } = [];

    public List<Guid> MaterialBedarfGuids { get; } = [];

    /// <summary>
    /// "Eröffnet" eine neue Stange mit der angegebenen Gesamtlänge und
    /// dem Zugabe-Parameter für Teilstückzwischenräume
    /// </summary>
    /// <param name="laenge"></param>
    /// <param name="zugabe"></param>
    public ZuschnittStangenInfo(int laenge, int zugabe)
    {
            Laenge = laenge;
            _zugabe = zugabe;
        }

    /// <summary>
    /// Prüft, ob ein Teilstück mit der angegebenen Länge noch Platz hat
    /// </summary>
    /// <param name="laenge"></param>
    /// <returns>true/false</returns>
    public bool CanAdd(int laenge)
    {
            return BelegungInMM + _zugabe + laenge <= Laenge;
        }

    /// <summary>
    /// Fügt ein Teilstück an.
    /// </summary>
    /// <param name="laenge">Länge des Teilstücks</param>
    /// <param name="materialBedarfGuid"></param>
    public void Add(int laenge, Guid materialBedarfGuid = default)
    {
            if (CanAdd(laenge))
            {
                Laengen.Add(laenge);
                MaterialBedarfGuids.Add(materialBedarfGuid);
                BelegungInMM += _zugabe + laenge;
                BelegungInProzent = (int)Math.Floor(((float)BelegungInMM / (float)Laenge) * 100);
                VerschnittInProzent = 100 - BelegungInProzent;
            }
            else
            {
                throw new InvalidOperationException("Kein Platz mehr für dieses Teilstück!");
            }
        }
}

public class MaterialbedarfCutOptimization
{
    public MaterialbedarfDTO[] Materialbedarfs;
    public ZuschnittStangenInfo[] ZuschnittStangenInfos;
}

public class GuidKeyIntValue
{
    public Guid Key { get; set; }
    public int Value { get; set; }
}