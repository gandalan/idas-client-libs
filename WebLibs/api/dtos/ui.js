/**
 * JSDoc Type Definitions for Gandalan.IDAS.WebApi.Client DTOs
 * Auto-generated from C# DTOs in /Gandalan.IDAS.WebApi.Client/DTOs/UI/
 */

// ============================================================================
// Supporting Types from other namespaces
// ============================================================================

/**
 * @typedef {Object} PropertyValueCollection
 * @description Collection of property values for application-specific and additional properties
 */

/**
 * @typedef {Object} KatalogArtikelFarbZuordnungDTO
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbItemGuid
 * @property {number} Preis
 * @property {boolean} Freigabe_IBOS
 * @property {boolean} Freigabe_BestellFix
 * @property {boolean} Freigabe_ARTOS
 * @property {FarbArt} FarbArt
 * @property {boolean} WirdAlsStandardFarbeBestellt
 * @property {number} VEMenge
 * @property {number} MengeGrossVE
 * @property {number} MengeGrossVE2
 * @property {number} MeldeSchwelleGrossVEs
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {number} Version
 * @property {string} ChangedDate
 * @property {number} MaxBestellMenge
 */

/**
 * @typedef {Object} KatalogArtikelDTO
 * @property {string} KatalogArtikelGuid
 * @property {string} KatalogNummer
 * @property {string} Bezeichnung
 * @property {string} Art - Einer der Werte aus der KatalogArtikelArt-Enum
 * @property {string} WarenGruppeGuid
 * @property {string} ImageFileName
 * @property {string} Einheit
 * @property {boolean} MengeMussGanzZahligSein
 * @property {boolean} NurAlsVEBestellbar
 * @property {boolean} IstZuschnittArtikel
 * @property {boolean} IstBestellfixSonderfarbBestellbar
 * @property {boolean} IstIbosSonderfarbBestellbar
 * @property {boolean} IstArtosSonderfarbBestellbar
 * @property {boolean} IstBestellfixTrendfarbBestellbar
 * @property {boolean} IstIbosTrendfarbBestellbar
 * @property {boolean} IstArtosTrendfarbBestellbar
 * @property {boolean} IstFarbeOptional
 * @property {boolean} NichtRabattfaehig
 * @property {boolean} IstEKPArtikel
 * @property {boolean} IstGewebeArtikel
 * @property {boolean} IstSaegbar
 * @property {number} GewichtInKg - Gewicht pro Mengeneinheit
 * @property {string} MaterialGuid
 * @property {Array<KatalogArtikelFarbZuordnungDTO>} MoeglicheFarben
 * @property {number} ProfilLaengeMM - Für Art = ProfilArtikel
 * @property {boolean} Freigabe_IBOS
 * @property {boolean} Freigabe_BestellFix
 * @property {boolean} Freigabe_ARTOS
 * @property {number} Preis - Preis des Artikels (pro VE?)
 * @property {number} StaffelPreis
 * @property {number} StaffelMenge
 * @property {number} VEMenge
 * @property {number} VEPreis
 * @property {number} MengeGrossVE
 * @property {number} MengeGrossVE2
 * @property {number} MeldeSchwelleGrossVEs
 * @property {number} MaxBestellMenge
 * @property {string} Status
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {Array<string>} ErsatzArtikel - Mögliche Ersatzartikel für diesen Artikel
 * @property {string} VarianteGuid - Für Art = FertigElementArtikel
 * @property {string} ChangedDate
 * @property {number} Version
 * @property {boolean} IstTechnischerArtikel
 * @property {number} BasisBestellMenge
 * @property {string | null} FrontendLogikGuid
 * @property {boolean} IsIndiArtikel
 * @property {boolean} IstEigenartikel
 * @property {boolean} ErsetztNeherArtikel
 * @property {string | null} OriginalArtikelGuid
 */

/**
 * @typedef {Object} WarenGruppeDTO
 * @property {string} WarenGruppeGuid
 * @property {number} Nummer
 * @property {string} Bezeichnung
 * @property {boolean} IstEKPWarengruppe
 * @property {Array<KatalogArtikelDTO>} Artikel
 * @property {number} Version
 * @property {string} ChangedDate
 * @property {string} FrontendLogik
 */

// ============================================================================
// Enums
// ============================================================================

/**
 * @typedef {0 | 1 | 2 | 3 | 4 | 5 | 6 | 7} FarbArt
 * @description FarbArt enum values
 * - 0 = Unbekannt
 * - 1 = StandardFarbe
 * - 2 = SonderFarbe
 * - 3 = TrendFarbe
 * - 4 = LivFarbe
 * - 5 = SonderEloxalFarbe
 * - 6 = RALSonderFarbe
 * - 7 = Roh
 */

/**
 * @typedef {0 | 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128} UIEingabeFeldRegelNames
 * @description UIEingabeFeldRegelNames enum values
 * - 0 = Unbekannt
 * - 1 = Frei
 * - 2 = NurGanzZahlen
 * - 4 = NurZahlen
 * - 8 = NurListenWerte
 * - 16 = NichtLeer
 * - 32 = Vierfachauswahl
 * - 64 = LangText
 * - 128 = ArtikelFarbe
 */

// ============================================================================
// UI DTOs
// ============================================================================

/**
 * @typedef {Object} GuidListDTO
 * @property {Array<string>} GuidList
 */

/**
 * @typedef {Object} InfoScreenConfigDTO
 * @description DTO für Konfiguration der InfoScreens
 * @property {string} InfoScreenGuid
 * @property {string} ChangedDate
 * @property {string} Caption
 * @property {string} Layout - Default: "einspaltig"
 * @property {string} Initiator
 * @property {any} ParamType
 * @property {Array<InfoScreenRowDTO>} Rows
 */

/**
 * @typedef {Object} InfoScreenInitTypeDTO
 * @description DTO für die Dateninitialisierung der InfoScreens. Es wird festgelegt, mit welchen Daten der InfoScreen initialisiert wird und welcher Datentyp als Basis für den Screen genutzt wird. Wird in den IInfoScreenDataInitiator Implementierungen genutzt
 * @property {string} Name
 * @property {any} Type
 * @property {any} Data
 */

/**
 * @typedef {Object} InfoScreenModulSettingsDTO
 * @description DTO zur Ablage der Einstellungen einzelner InfoScreen Module innerhalb eines InfoScreens. Modulspezifische Einstellungen werden in den ApplicationSpecificProperties abgelegt.
 * @property {string} ModuleGuid
 * @property {InfoScreenInitTypeDTO} InitType
 * @property {Array<InfoScreenInitTypeDTO>} AllowedTypes
 * @property {boolean} NeedsInit
 * @property {boolean} IsValid
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 */

/**
 * @typedef {Object} InfoScreenRowDTO
 * @description DTO für die Zeilen in der InfoScreen Konfiguration
 * @property {Array<InfoScreenModulSettingsDTO>} InfoScreenModule - Array of 2 elements (for 2 columns)
 * @property {number} RowNum
 */

/**
 * @typedef {Object} KonfigSatzDTO
 * @property {string} ChangedDate
 * @property {Array<KonfigSatzEintragDTO>} Eintraege
 * @property {string} KonfigSatzGuid
 * @property {number} Version
 */

/**
 * @typedef {Object} KonfigSatzEintragDTO
 * @property {string} DatenTyp
 * @property {string} KonfigName
 * @property {string} KonfigSatzEintragGuid
 * @property {string} UnterkomponenteName
 * @property {string} Wert
 * @property {string} ChangedDate
 */

/**
 * @typedef {Object} KonfigSatzInfoDTO
 * @property {string} KonfigSatzGuid
 * @property {string} VarianteGuid
 * @property {string} LM_Hoehe
 * @property {string} LM_Breite
 * @property {string} LM_Breite2
 */

/**
 * @typedef {Object} OberflaecheDTO
 * @property {string} OberflaecheGuid
 * @property {string} Bezeichnung
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {number} Version
 * @property {string} ChangedDate
 */

/**
 * @typedef {Object} ProduktFamilieDTO
 * @property {string} ProduktFamilieGuid
 * @property {string} ProduktGruppeGuid
 * @property {string} WarengruppenGuid
 * @property {string} Bezeichnung
 * @property {string} PreisErmittlung
 * @property {string} StandardFarbe
 * @property {string} KurzBezeichnung
 * @property {boolean} HatRabatt2
 * @property {boolean} HatRabatt3
 * @property {Array<VarianteDTO>} Varianten
 * @property {Array<string>} StandardFarbKuerzelGuids
 * @property {Array<ProduktFamilieErsatzFarbZuordnungDTO>} ErsatzFarbZuordnungen
 * @property {string} ChangedDate
 * @property {number} Version
 */

/**
 * @typedef {Object} ProduktFamilieErsatzFarbZuordnungDTO
 * @property {string} ProduktFamilieErsatzFarbZuordnungGuid
 * @property {string} ChangedDate
 * @property {number} Version
 * @property {string} FarbItemGuid
 * @property {string} ErsatzFarbItemGuid
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 */

/**
 * @typedef {Object} ProduktFamilieFarbZuordnungDTO
 * @property {string} Kuerzel
 * @property {string} ProduktFamilieFarbZuordnungGuid
 * @property {string} ChangedDate
 * @property {number} Version
 * @property {string} FarbItemGuid
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 */

/**
 * @typedef {Object} ProduktFamilienDTOListe
 * @description ObservableCollection of ProduktFamilieDTO
 * @extends {Array<ProduktFamilieDTO>}
 */

/**
 * @typedef {Object} TagInfoDTO
 * @property {string} ObjectGuid
 * @property {string} Text
 * @property {boolean} CanRemove
 * @property {boolean} IsDefaultTag
 * @property {string} ToolTip
 * @property {string} IconName
 * @property {string} BackgroundColorCode
 * @property {string} TextColorCode
 * @property {boolean} IsDeleted
 * @property {number} Version
 * @property {string} ChangedDate
 */

/**
 * @typedef {Object} TagVorlageDTO
 * @property {string} TagVorlageGuid
 * @property {string} Text
 * @property {string} ToolTip
 * @property {string} BackgroundColorCode
 * @property {string} TextColorCode
 * @property {number} Version
 * @property {string} ChangedDate
 */

/**
 * @typedef {Object} UIEingabeFeldDTO
 * @property {number} Reihenfolge
 * @property {string} Caption
 * @property {string} Tag
 * @property {string} Regel
 * @property {number} MinWert
 * @property {boolean} MinWertWeichPruefen
 * @property {number} MaxWert
 * @property {boolean} MaxWertWeichPruefen
 * @property {string} VorgabeWert
 * @property {string} HilfeText
 * @property {string} WarnText
 * @property {string} FehlerText
 * @property {string} WerteListeName
 * @property {boolean} PreisFeldAnzeigen
 * @property {number} MindestBreite
 * @property {number} Version
 * @property {string} ChangedDate
 * @property {string} UIEingabeFeldGuid
 * @property {string} BelegBlattText
 * @property {string} AngebotsText
 * @property {number} EingabeLevel
 * @property {number | null} ZusatzFeldGruppeId
 * @property {number | null} GehoertZuZusatzFeldGruppeId
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {boolean} IstKonfiguratorFeld
 */

/**
 * @typedef {Object} UIEingabeFeldInfoDTO
 * @property {string} UIEingabeFeldGuid
 * @property {Array<string>} VariantenGuids
 * @property {string} Caption
 * @property {number} MinWert
 * @property {boolean} MinWertWeichPruefen
 * @property {number} MaxWert
 * @property {boolean} MaxWertWeichPruefen
 * @property {string} HilfeText
 * @property {string} WarnText
 * @property {string} FehlerText
 * @property {string} VorgabeWert
 */

/**
 * @typedef {Object} UIDefinitionDTO
 * @property {string} UIDefinitionGuid
 * @property {string} Kategorie
 * @property {string} BezeichnungKurz
 * @property {string} BezeichnungLang
 * @property {string} BildHorizontal
 * @property {string} BildVertikal
 * @property {string} Bild3D
 * @property {Array<UIEingabeFeldDTO>} EingabeFelder
 * @property {Array<UIKonfiguratorFeldDTO>} KonfiguratorFelder
 * @property {number} Version
 * @property {string} ChangedDate
 */

/**
 * @typedef {Object} UIKonfiguratorFeldDTO
 * @property {number} EingabeLevel
 * @property {number} Reihenfolge
 * @property {string} Caption
 * @property {string} Tag
 * @property {string} Kuerzel
 * @property {string} WerteListeName
 * @property {string} VorgabeWert
 * @property {string} BelegBlattText
 * @property {string} AngebotsText
 * @property {number | null} ProfilId
 * @property {number | null} GehoertZuProfilId
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {number} Version
 * @property {string} ChangedDate
 * @property {string} UIKonfiguratorFeldGuid
 */

/**
 * @typedef {Object} UIScriptDTO
 * @property {string} ScriptDefinitionGuid
 * @property {string} Context
 * @property {string} Code
 * @property {number} Version
 * @property {string} ChangedDate
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {string | null} MandantGuid
 */

/**
 * @typedef {Object} VarianteDTO
 * @property {string} VarianteGuid
 * @property {string} UIDefinitionGuid
 * @property {string} ProduktFamilieGuid
 * @property {string} WarengruppeGuid
 * @property {string} KomponenteGuid
 * @property {string} Kuerzel
 * @property {string} Name
 * @property {string} ElementArt
 * @property {string} ElementTyp
 * @property {string} Beschreibung
 * @property {string} PreisErmittlung
 * @property {string} Preisliste
 * @property {string} PreisVorschrift
 * @property {string} GrenzVorschrift
 * @property {number} PreislistenFaktor
 * @property {boolean} MasterKatalog
 * @property {boolean} HauptKatalog
 * @property {boolean} ExtraKatalog
 * @property {boolean} ErfassungIBOS2Moeglich
 * @property {boolean} ErfassungIBOS1Moeglich
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 * @property {string} ChangedDate
 * @property {number} Version
 * @property {UIDefinitionDTO} UIDefinition
 * @property {string} KonfigSatzGuid - Achtung, KonfigSatz-Klasse wird NICHT direkt gemappt!
 * @property {Array<KonfigSatzEintragDTO>} KonfigSatz
 * @property {boolean} IstTechnischeVariante
 */

/**
 * @typedef {Object} VarianteDTOListe
 * @description ObservableCollection of VarianteDTO
 * @extends {Array<VarianteDTO>}
 */

/**
 * @typedef {Object} WarenGruppeDTOListe
 * @description ObservableCollection of WarenGruppeDTO
 * @extends {Array<WarenGruppeDTO>}
 */

/**
 * @typedef {Object} WerteListeDTO
 * @property {string} Name
 * @property {number} Version
 * @property {string} ChangedDate
 * @property {string} WerteListeGuid
 * @property {Array<WerteListeItemDTO>} Items
 * @property {string} GueltigAb
 */

/**
 * @typedef {Object} WerteListeDTOListe
 * @description ObservableCollection of WerteListeDTO
 * @extends {Array<WerteListeDTO>}
 */

/**
 * @typedef {Object} WerteListeItemDTO
 * @property {string} BelegBlattText
 * @property {string} AngebotsText
 * @property {string} Beschreibung
 * @property {string} ChangedDate
 * @property {string} Kuerzel
 * @property {number} Reihenfolge
 * @property {number} Version
 * @property {string} WerteListeItemGuid
 * @property {string | null} GueltigAb
 * @property {string | null} GueltigBis
 */

// Export all type names for reference
export const DTO_TYPES = {
    // Supporting types
    PropertyValueCollection: "PropertyValueCollection",
    KatalogArtikelFarbZuordnungDTO: "KatalogArtikelFarbZuordnungDTO",
    KatalogArtikelDTO: "KatalogArtikelDTO",
    WarenGruppeDTO: "WarenGruppeDTO",
  
    // Enums
    FarbArt: "FarbArt",
    UIEingabeFeldRegelNames: "UIEingabeFeldRegelNames",
  
    // UI DTOs
    GuidListDTO: "GuidListDTO",
    InfoScreenConfigDTO: "InfoScreenConfigDTO",
    InfoScreenInitTypeDTO: "InfoScreenInitTypeDTO",
    InfoScreenModulSettingsDTO: "InfoScreenModulSettingsDTO",
    InfoScreenRowDTO: "InfoScreenRowDTO",
    KonfigSatzDTO: "KonfigSatzDTO",
    KonfigSatzEintragDTO: "KonfigSatzEintragDTO",
    KonfigSatzInfoDTO: "KonfigSatzInfoDTO",
    OberflaecheDTO: "OberflaecheDTO",
    ProduktFamilieDTO: "ProduktFamilieDTO",
    ProduktFamilieErsatzFarbZuordnungDTO: "ProduktFamilieErsatzFarbZuordnungDTO",
    ProduktFamilieFarbZuordnungDTO: "ProduktFamilieFarbZuordnungDTO",
    ProduktFamilienDTOListe: "ProduktFamilienDTOListe",
    TagInfoDTO: "TagInfoDTO",
    TagVorlageDTO: "TagVorlageDTO",
    UIEingabeFeldDTO: "UIEingabeFeldDTO",
    UIEingabeFeldInfoDTO: "UIEingabeFeldInfoDTO",
    UIDefinitionDTO: "UIDefinitionDTO",
    UIKonfiguratorFeldDTO: "UIKonfiguratorFeldDTO",
    UIScriptDTO: "UIScriptDTO",
    VarianteDTO: "VarianteDTO",
    VarianteDTOListe: "VarianteDTOListe",
    WarenGruppeDTOListe: "WarenGruppeDTOListe",
    WerteListeDTO: "WerteListeDTO",
    WerteListeDTOListe: "WerteListeDTOListe",
    WerteListeItemDTO: "WerteListeItemDTO",
};
