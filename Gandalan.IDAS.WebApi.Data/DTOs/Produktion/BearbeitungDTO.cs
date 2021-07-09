using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BearbeitungDTO
    {
        public Guid BearbeitungGuid { get; set; }
        /// <summary>
        /// Eindeutiges Kennzeichen der Bearbeitung (aus GUID)
        /// </summary>
        public string Kennzeichen { get; set; }
        /// <summary>
        /// Ziel der Bearbeitung
        /// </summary>
        public Guid ZielKennzeichen { get; set; }
        /// <summary>
        /// Artikelbezeichnung
        /// </summary>
        public string BearbeitungsName { get; set; }                
        /// <summary>
        /// Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Laufmeter!)
        /// </summary>
        public decimal X { get; set; }
        /// <summary>
        /// Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt 
        /// sich aus mit Stückzahl!)
        /// </summary>
        public decimal Y { get; set; }
        public string ProfilName { get; set; }
        public decimal ProfilLaenge { get; set; }
        public decimal ProfilBreite { get; set; }
        public string KatalogNummer { get; set; }
        public string StammdatenDateiFuerBearbeitung { get; set; }
        public string Spannsituation { get; set; }
        public string SpannSituationAlternativ { get; set; }
        public string StartXRegel { get; set; }
        public string FraesBild { get; set; }
        public string TextHP { get; set; }
        public string TextNP { get; set; }
        public decimal LLBreite { get; set; }
        public decimal LLBreiteAmBildschirm { get; set; }
        public decimal LLHoehe { get; set; }
        public decimal DurchmesserBohrung { get; set; }
        public decimal LochAbstand { get; set; }
        public decimal LochAbstandAmBildschirm { get; set; }
        public decimal Winkel { get; set; }
        public bool ManuellGeloescht { get; set; }
        public bool Passiv { get; set; }
        public bool NichtFreigegeben { get; set; }
        public bool MassXEditierbar { get; set; }
        public bool GroesseEditierbar { get; set; }

        public decimal plusVirtuelle_ProfilLaenge { get; set; }
        public decimal ProfilBreite_vonOben { get; set; }
        public decimal BohrbildVersatz_unten_gesamt { get; set; }
        public string ProfilFarbe { get; set; }
        public string BearbeitungsTyp_IDAS_Original { get; set; }
        public string Bearbeitung__B_BeideProfile__H_HauptProfil__N_NebenProfil { get; set; }
        public decimal ProfilPosition_im_Element { get; set; }
        public string Einz_KurzZeichen { get; set; }
        public decimal Einz_Nummer { get; set; }
        public decimal Einz_Nummer_Bruder_fuer_paarweises_Spannen { get; set; }
        public string BelegJahr_Nummer_Position { get; set; }
        public string PositionsBeschreibungsText { get; set; }
        public bool Positions_Sonder_S { get; set; }
        public decimal Start_X_gerundet_Reihenfolge { get; set; }
        public decimal Start_X_ReihenfolgenKorrektur { get; set; }
        public decimal Winkel_am_Nullpunkt { get; set; }
        public decimal Winkel_am_ProfilEnde { get; set; }
        public decimal Start_Z { get; set; }
        public decimal Y_Versatz_des_EinzelProfiles_bei_Paarbearbeitung { get; set; }
        public decimal Breite_HauptProfil { get; set; }
        public decimal Breite_NebenProfil { get; set; }
        public decimal ProfilBreite_Bruder { get; set; }
        public bool Mass_X_wird_automatisch_ermittelt { get; set; }
        public bool Mass_X_wurde_manuell_veraendert { get; set; }
        public decimal Start_X_Maschinen_Absolutwert { get; set; }
        public decimal Start_Y_Maschinen_Absolutwert { get; set; }
        public decimal Start_Y_Maschinen_Absolutwert_HauptProfil { get; set; }
        public string BearbeitungsBildMitte_X { get; set; }
        public string BearbeitungsBildMitte_Y { get; set; }
        public decimal Gespiegelt_X { get; set; }
        public decimal Gespiegelt_Y { get; set; }
        public decimal BildschirmKorrekturFaktor_LochAbstand { get; set; }
        public decimal EintauchTiefe { get; set; }
        public string Kommentar { get; set; }
        public string ZusatzInfo { get; set; }
        public string ZusatzInfo_2 { get; set; }
        public string ZusatzInfo_3 { get; set; }
        public decimal Bildschirm_X_Start { get; set; }
        public decimal Bildschirm_X_Ende { get; set; }
        public decimal Bildschirm_Y_Start { get; set; }
        public decimal Bildschirm_Y_Ende { get; set; }
        public decimal Bearbeitungsplatz_Nummer { get; set; }
        public string ElementInfo { get; set; }
        public string Variante { get; set; }
        public decimal FraeserNummer { get; set; }
        public decimal FraeserNummer_alternativ { get; set; }
        public bool FraeserNummer_alternativ_wird_verwendet { get; set; }
        public decimal FraeserNummer_nicht_anmeckern_wenn_FraeserX_verwendet_wird { get; set; }
        public decimal FraeserDurchmesser { get; set; }
        public decimal FraeserDurchmesser_AlternativFraeser { get; set; }
        public decimal FraeserLaenge { get; set; }
        public decimal IDAS_Spannsituation { get; set; }
        public decimal Aufspannung__0_HP_hinten__1_HP_vorne__2_HP_hinten_gerade__3_HP_vorne_gerade__plus10_HP_einzel__plus20_NP_einzel__plus100_SS_spitz_gedreht { get; set; }
        public decimal Aufspannung_hinzuAddieren { get; set; }
        public string BearbeitungsName_WerkzeugBezeichnung { get; set; }
        public string BearbeitungsBeschreibung { get; set; }
        public decimal FraesOberkante_bezueglich_Z_Achse { get; set; }
        public bool FraesOberkante_bezueglich_Z_Achse_Korrekur { get; set; }
        public decimal Fraeser_EintauchTiefe_ab_FraesOberkante { get; set; }
        public decimal Fraeser_EintauchTiefe_ab_FraesOberkante_AlternativFraeser { get; set; }
        public decimal maximale_UeberfahrHoehe_bezueglich_Z_Achse { get; set; }
        public decimal FraesbildKorrektur_in_Y_Richtung { get; set; }
        public decimal Beilage_zwischen_den_Profilen { get; set; }
        public decimal Mass_zwischen_Profil_und_hinterem_Spanner { get; set; }
        public decimal Mass_zwischen_Profil_und_vorderem_Spanner { get; set; }
        public string ProfilNullPunktLage_HauptProfil_1 { get; set; }
        public string ProfilNullPunktLage_HauptProfil_2 { get; set; }
        public string ProfilNullPunktLage_NebenProfil_1 { get; set; }
        public string ProfilNullPunktLage_NebenProfil_2 { get; set; }
        public decimal keinSpanner_X_Breite_FraesBild { get; set; }
        public decimal keinSpanner_X_Mitte_FraesBild { get; set; }
        public decimal festeSpannerPosition_1 { get; set; }
        public decimal festeSpannerPosition_2 { get; set; }
        public bool AnschlagAbklappen { get; set; }
        public string BeilagenName { get; set; }
        public decimal Fraeser_EintauchGeschwindigkeit { get; set; }
        public decimal Fraeser_EintauchGeschwindigkeit_AlternativFraeser { get; set; }
        public decimal Fraeser_VorschubGeschwindigkeit { get; set; }
        public decimal Fraeser_VorschubGeschwindigkeit_AlternativFraeser { get; set; }
        public decimal Fraeser_Drehzahl { get; set; }
        public decimal Fraeser_Drehzahl_AlternativFraeser { get; set; }
        public string MurxxxInfos_1 { get; set; }
        public string IDAS_InfoFeld { get; set; }
        public bool IDAS_Bearbeitung { get; set; }
        public decimal IDAS_EF_Index { get; set; }
        public decimal IDAS_SLK_BearbeitungsNummer { get; set; }
        public string UniDExGuid { get; set; }
        public bool QuelleUniDEx { get; set; }
        public string IDAS_BearbeitungsPlatz_Ausschluss { get; set; }
        public string IDAS_BearbeitungsPlatz_Ausschluss_Text { get; set; }
        public bool BruderHatKeineBearbeitung { get; set; }
        public string Einz_KurzZeichen_Bruder { get; set; }
        public string GruppenPartner { get; set; }
        public decimal ProfilWinkel_links { get; set; }
        public decimal ProfilWinkel_rechts { get; set; }
    }
}
