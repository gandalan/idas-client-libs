using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.DTO;

public class ProduktionsSettingsDTO
{
    public List<ProduktionProduktfamilieSettingsDTO> ProduktionProduktfamilieSettingList { get; set; }
    public bool SprossenfreiEnabled { get; set; }
    public bool VorbiegenEnabled { get; set; }
    public string VorbiegenSprossenfrei { get; set; }
    public string IstAusserhalbGewaehrleistung { get; set; }
    public string VorbiegenGrenzwert { get; set; }
    public List<string> SonderGewebe { get; set; }
    public bool SaegedatenAufEtiketten { get; set; }
    public bool PacklistenEtikettenZusammengefasst { get; set; } = true;
    public string EtikettSerienkennzeichen { get; set; } = "Ohne";
    public string PackEtikettSerienkennzeichen { get; set; } = "Kürzel";
    public bool PrintPCode { get; set; } = true;
    public bool PrintPCodeASQRCode { get; set; } = true;
    public bool Schutzplattenmontage { get; set; }
    public bool WeisserKeder { get; set; }
    public bool SortierungMitPositionsbezug { get; set; }
    public bool HaendlerNameAufEtikett { get; set; }
    public bool HaendlerKommAufEtikett { get; set; }
    public bool VorgangKommAufEtikett { get; set; } = true;
    public bool PositionKommAufEtikett { get; set; }
    public bool EinbauOrtAufEtikett { get; set; } = true;
    public bool SettingsFuerHaendler { get; set; }
    public bool SaegemaßeOhneKorrektur { get; set; } = true;
    public bool EtikettenZugehoerigkeit { get; set; }
    public bool Saegeliste4590Zusammenfassen { get; set; } = true;
    public DateTime ChangedDate { get; set; }
    public bool EtikettNewStyleSonderkennzeichen { get; set; }
    public bool Buegelgriffe_10_22 { get; set; }
    public bool RO4_Buerste { get; set; } = true;
    public bool Montagelehre_ST_164802 { get; set; } = true;
    public bool Kunststoffbohrlehre_ST_164851 { get; set; } = true;
    public bool Inbussschluessel_lang_ST_170625_25 { get; set; } = true;
    public bool Schraubeckwinkel_1601 { get; set; } = true;
    public bool LI1_Sickenstanze_auf_Etikett { get; set; }
    public bool Griffmulde_ST3_134850 { get; set; }
    public bool AnbauteileP2_G6 { get; set; }
    public bool SP_Z_Mass_inkl_Buerstendichtung { get; set; } = true;
    public bool SP5_Sprosse_ausklinken { get; set; }
    public bool ST3_BeidseitigeGriffleiste_GL_B { get; set; }
    public bool Gewebeeinzugsarm_122415 { get; set; }
    public bool RO4_143908 { get; set; }
    public bool PacklisteZusammengefasst { get; set; }
    public string FarbersetzungsTabelleModel { get; set; }
    public bool Drehbandmontage { get; set; } = true;
    public int STmitLSo_LSu_Mbv_Mass { get; set; } = 50;
    public bool SP_WL_mit_Schraube_150329 { get; set; } = true;
    public bool LI_TE_Winkelprofil_mit_Schraube_150329_06 { get; set; } = true;
    public string ProdukteMitc3Berechnen { get; set; }
    public bool DF4_DT4_133604 { get; set; } = true;

    //ZusatzRahmen
    public bool ZR_Schraubeckwinkel { get; set; } = true;
    public bool ZR_Verstanzen { get; set; }
    public int? ZR_Verstanzen_Mass { get; set; }
    public bool ZR_Eckwinkel { get; set; }

    public bool Magnetposition_DT3_DT6 { get; set; }
}
