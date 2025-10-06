using System.Collections.Generic;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Settings;

public interface IProduktionSettings
{
    List<IProduktionProduktfamilieSettings> ProduktionProduktfamilieSettingList { get; set; }
    bool SprossenfreiEnabled { get; set; }
    bool VorbiegenEnabled { get; }
    string VorbiegenSprossenfrei { get; set; }
    string IstAusserhalbGewaehrleistung { get; set; }
    string VorbiegenGrenzwert { get; set; }
    List<string> SonderGewebe { get; set; }
    bool SaegedatenAufEtiketten { get; set; }
    bool PacklistenEtikettenZusammengefasst { get; set; }
    bool PacklistenEtikettenZusammengefasstZuschnitteExtra { get; set; }
    string EtikettSerienkennzeichen { get; set; }
    string PackEtikettSerienkennzeichen { get; set; }
    bool PrintPCode { get; set; }
    bool PrintPCodeASQRCode { get; set; }
    bool Schutzplattenmontage { get; set; }
    bool WeisserKeder { get; set; }
    string SerienkennzeichenDruck { get; set; }
    bool PositionskommissionAufReport { get; set; }
    bool SortierungMitPositionsbezug { get; set; }
    bool HaendlerNameAufEtikett { get; set; }
    bool HaendlerKommAufEtikett { get; set; }
    bool VorgangKommAufEtikett { get; set; }
    bool PositionKommAufEtikett { get; set; }
    bool EinbauOrtAufEtikett { get; set; }
    bool SettingsFuerHaendler { get; set; }
    bool SaegemaßeOhneKorrektur { get; set; }
    bool EtikettenZugehoerigkeit { get; set; }
    bool Saegeliste4590Zusammenfassen { get; set; }
    bool ZeitvorgabeAnzeigen { get; set; }
    bool SaegelisteAblagefachAnzeigen { get; set; }
    bool EtikettNewStyleSonderkennzeichen { get; set; }
    bool Buegelgriffe_10_22 { get; set; }
    bool RO4_Buerste { get; set; }
    bool Montagelehre_ST_164802 { get; set; }
    bool Kunststoffbohrlehre_ST_164851 { get; set; }
    bool Inbussschluessel_lang_ST_170625_25 { get; set; }
    bool Schraubeckwinkel_1601 { get; set; }
    bool LI1_Sickenstanze_auf_Etikett { get; set; }
    bool Griffmulde_ST3_134850 { get; set; }
    bool AnbauteileP2_G6 { get; set; }
    bool SP_Z_Mass_inkl_Buerstendichtung { get; set; }
    bool NichtSaegenAnzeigen { get; set; }
    bool SP5_Sprosse_ausklinken { get; set; }
    bool ST3_BeidseitigeGriffleiste_GL_B { get; set; }
    bool Gewebeeinzugsarm_122415 { get; set; }
    bool RO4_143908 { get; set; }
    bool PacklisteZusammengefasst { get; set; }
    string FarbersetzungsTabelleModel { get; set; }
    bool Drehbandmontage { get; set; }
    int STmitLSo_LSu_Mbv_Mass { get; set; }
    bool SP_WL_mit_Schraube_150329 { get; set; }
    bool LI_TE_Winkelprofil_mit_Schraube_150329_06 { get; set; }
    string ProdukteMitc3Berechnen { get; set; }
    bool DF4_DT4_133604 { get; set; }
    bool ZR_Schraubeckwinkel { get; set; }
    bool ZR_Verstanzen { get; set; }
    int? ZR_Verstanzen_Mass { get; set; }
    bool ZR_Eckwinkel { get; set; }
    bool Magnetposition_DT3_DT6 { get; set; }
    event PropertyChangedEventHandler PropertyChanged;
}
