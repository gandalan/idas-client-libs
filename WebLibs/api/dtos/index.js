/**
 * JSDoc Type Definitions for Gandalan.IDAS.WebApi.Client DTOs
 * Auto-generated from C# DTOs in /Gandalan.IDAS.WebApi.Client/DTOs/
 */

/** @typedef {import('./av.js').AVReserviertItemDTO} AVReserviertItemDTO */
/** @typedef {import('./av.js').BearbeitungsKuerzelDTO} BearbeitungsKuerzelDTO */
/** @typedef {import('./av.js').BelegPositionAVDTO} BelegPositionAVDTO */
/** @typedef {import('./av.js').BelegPositionAVListItemDTO} BelegPositionAVListItemDTO */
/** @typedef {import('./av.js').PCodeStatistikDTO} PCodeStatistikDTO */
/** @typedef {import('./av.js').PositionSerieItemDTO} PositionSerieItemDTO */
/** @typedef {import('./av.js').ProfilKuerzelDTO} ProfilKuerzelDTO */
/** @typedef {import('./av.js').SerieAuslastungDTO} SerieAuslastungDTO */
/** @typedef {import('./av.js').SerieDTO} SerieDTO */
/** @typedef {import('./av.js').SerieDruckInfoDTO} SerieDruckInfoDTO */
/** @typedef {import('./av.js').SerieHistorieDTO} SerieHistorieDTO */
/** @typedef {import('./av.js').SerienMaterialEditDTO} SerienMaterialEditDTO */
/** @typedef {import('./av.js').VirtualSerieWithAuslastungDTO} VirtualSerieWithAuslastungDTO */

/** @typedef {import('./benutzer.js').BenutzerDTO} BenutzerDTO */
/** @typedef {import('./benutzer.js').BerechtigungDTO} BerechtigungDTO */
/** @typedef {import('./benutzer.js').RolleDTO} RolleDTO */
/** @typedef {import('./benutzer.js').LoginDTO} LoginDTO */
/** @typedef {import('./benutzer.js').LoginAttemptDTO} LoginAttemptDTO */
/** @typedef {import('./benutzer.js').LoginAttemptResultDTO} LoginAttemptResultDTO */
/** @typedef {import('./benutzer.js').PasswortAendernDTO} PasswortAendernDTO */
/** @typedef {import('./benutzer.js').RefreshTokenDTO} RefreshTokenDTO */
/** @typedef {import('./benutzer.js').UserAuthTokenDTO} UserAuthTokenDTO */
/** @typedef {import('./benutzer.js').ZustimmungsInfoDTO} ZustimmungsInfoDTO */

/** @typedef {import('./druck.js').ILayoutBelegDruck} ILayoutBelegDruck */
/** @typedef {import('./druck.js').LayoutBelegDruckDTO} LayoutBelegDruckDTO */

/** @typedef {import('./mandanten.js').MandantDTO} MandantDTO */
/** @typedef {import('./mandanten.js').MandantFreigabeDTO} MandantFreigabeDTO */
/** @typedef {import('./mandanten.js').ProduzentAktivierenDTO} ProduzentAktivierenDTO */
/** @typedef {import('./mandanten.js').FreigabeLevel} FreigabeLevel */
/** @typedef {import('./mandanten.js').FreigabeArt} FreigabeArt */

/** @typedef {import('./lager.js').LagerbestandDTO} LagerbestandDTO */
/** @typedef {import('./lager.js').LagerbuchungDTO} LagerbuchungDTO */
/** @typedef {import('./lager.js').LagerReservierungDTO} LagerReservierungDTO */

/** @typedef {import('./faktura.js').SetFakturaDTO} SetFakturaDTO */
/** @typedef {import('./faktura.js').BelegeInfoDTO} BelegeInfoDTO */
/** @typedef {import('./faktura.js').SammelrechnungDTO} SammelrechnungDTO */
/** @typedef {import('./faktura.js').SammelrechnungListItemDTO} SammelrechnungListItemDTO */
/** @typedef {import('./faktura.js').SammelrechnungPositionenDTO} SammelrechnungPositionenDTO */
/** @typedef {import('./faktura.js').SammelrechnungSaldenDTO} SammelrechnungSaldenDTO */
/** @typedef {import('./faktura.js').CreateSammelrechnungDTO} CreateSammelrechnungDTO */
/** @typedef {import('./faktura.js').AddRechnungSammelrechnungDTO} AddRechnungSammelrechnungDTO */
/** @typedef {import('./faktura.js').Lieferungstyp} Lieferungstyp */

/** @typedef {import('./farben.js').FarbeDTO} FarbeDTO */
/** @typedef {import('./farben.js').FarbGruppeDTO} FarbGruppeDTO */
/** @typedef {import('./farben.js').FarbKuerzelDTO} FarbKuerzelDTO */
/** @typedef {import('./farben.js').FarbKuerzelGruppeDTO} FarbKuerzelGruppeDTO */
/** @typedef {import('./farben.js').FarbgruppenaufpreiseDTO} FarbgruppenaufpreiseDTO */
/** @typedef {import('./farben.js').FarbgruppeSettingsDTO} FarbgruppeSettingsDTO */
/** @typedef {import('./farben.js').ProduzentenFarbGruppeDTO} ProduzentenFarbGruppeDTO */

/** @typedef {import('./allgemein.js').ContractDTO} ContractDTO */
/** @typedef {import('./allgemein.js').TemplateDTO} TemplateDTO */
/** @typedef {import('./allgemein.js').ChangeDTO} ChangeDTO */
/** @typedef {import('./allgemein.js').ChangeInfoDTO} ChangeInfoDTO */
/** @typedef {import('./allgemein.js').UpdateInfoDTO} UpdateInfoDTO */
/** @typedef {import('./allgemein.js').DevOpsStatusDTO} DevOpsStatusDTO */
/** @typedef {import('./allgemein.js').WebJobHistorieDTO} WebJobHistorieDTO */
/** @typedef {import('./allgemein.js').CreateServiceTokenRequestDTO} CreateServiceTokenRequestDTO */
/** @typedef {import('./allgemein.js').ApiVersionDTO} ApiVersionDTO */
/** @typedef {import('./allgemein.js').ExtendedStatusCodeDTO} ExtendedStatusCodeDTO */

// ============================================================================
// Anpassungen DTOs
// ============================================================================

/**
 * @typedef {Object} AnpassungArtDTO
 * @description Enum values: Unbekannt=0, ZusatzArtikel=1, ArtikelSperre=2, Produktion=4,
 *              Standardfarben=8, Anbauteilfarben=16, Preisfaktoren=32, Aufpreise=64,
 *              MbAufpreise=256, Grenzenfreigabe=512, FarbGruppen=1024, MbAufpreiseKlebe=2048
 * @property {number} value
 */

/**
 * @typedef {Object} AnpassungDTO
 * @property {string} AnpassungGuid
 * @property {string} Art
 * @property {boolean} GiltFuerBesitzer
 * @property {boolean} GiltFuerAlleUntermandanten
 * @property {boolean} GiltFuerZielMandant
 * @property {string} ZielMandantGuid
 * @property {string} Content
 * @property {string} WarengruppeGuid
 * @property {string} ArtikelGuid
 * @property {number} Version
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} AnpassungVorlageDTO
 * @property {string} AnpassungVorlageGuid
 * @property {string} Art
 * @property {string} Name
 * @property {string} Beschreibung
 * @property {string} Content
 * @property {number} Version
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} AufpreisAnpassungDTO
 * @property {string} Bezeichnung
 * @property {string} FeldName
 * @property {string} FeldWert
 * @property {number} Aufpreis
 */

/**
 * @typedef {Object} PreisfaktorDTO
 * @property {number} Faktor
 * @property {number} AufpreisFaktor
 * @property {number | null} ZuschnittFaktor
 */

// ============================================================================
// AV Report DTOs
// ============================================================================

/**
 * @typedef {Object} AvReportVorgangRequestDto
 * @property {string[]} VorgangGuids
 */

/**
 * @typedef {Object} AvReportVorgangDto
 * @description Minimalistic DTO for Vorgang in AV reports
 * @property {string} VorgangGuid
 * @property {number} VorgangsNummer
 * @property {string} Kommission
 * @property {string} Kommission2
 * @property {AvReportBelegDto[]} Belege
 * @property {AvReportKontaktDto} Kunde
 */

/**
 * @typedef {Object} AvReportBelegDto
 * @description Minimalistic DTO for Beleg in AV reports
 * @property {string} BelegGuid
 * @property {import("./kunden.js").BeleganschriftDTO | null} BelegAdresse
 * @property {import("./kunden.js").BeleganschriftDTO | null} VersandAdresse
 * @property {boolean} VersandAdresseGleichBelegAdresse
 * @property {string} BelegArt
 * @property {string} Terminwunsch
 * @property {boolean} IstSelbstabholer
 */

/**
 * @typedef {Object} AvReportKontaktDto
 * @description Minimalistic DTO for Kontakt information in AvReportVorgangDto
 * @property {string} KundenNummer
 * @property {string} Land
 */

// ============================================================================
// Feedback DTOs
// ============================================================================

/**
 * @typedef {Object} FeedbackDTO
 * @property {string} FeedbackGuid
 * @property {string} ChangedDate - ISO date string
 * @property {number} Version
 * @property {string} PCode
 * @property {string} Jahr
 * @property {string} Vorgangsnummer
 * @property {string} Positionsnummer
 * @property {string} Benutzername
 * @property {import("./settings.js").MandantDTO | null} Mandant
 * @property {string} BelegPositionGuid
 * @property {import("./belege.js").BelegPositionDTO | null} BelegPosition
 * @property {BelegPositionAVDTO[] | null} AVPositionen
 * @property {import("./produktion.js").ProduktionsSettingsDTO | null} ProduktionsSettings
 * @property {string} Beschreibung
 * @property {string} ProgramInfos
 * @property {FeedbackAttachmentDTO[] | null} Anhaenge
 * @property {FeedbackKommentarDTO[] | null} Kommentare
 * @property {string} Status
 * @property {string} LoesungsVersion
 * @property {string} HotlineTicketNummer
 */

/**
 * @typedef {Object} FeedbackKommentarDTO
 * @property {string} FeedbackKommentarGuid
 * @property {string} Zeitstempel - ISO date string
 * @property {string} Benutzer
 * @property {string} Inhalt
 */

/**
 * @typedef {Object} FeedbackAttachmentDTO
 * @property {string} FeedbackAttachmentGuid
 * @property {string} Zeitstempel - ISO date string
 * @property {string} Filename
 * @property {string} URL
 */

/**
 * @typedef {Object} FeedbackNotifyItemDTO
 * @property {string} FeedbackNotifyItemGuid
 * @property {string} Type
 * @property {string} Benutzer
 * @property {string} FeedbackGuid
 * @property {string} FeedbackKommentarGuid
 * @property {boolean} Gelesen
 * @property {string} ChangedDate - ISO date string
 */

// ============================================================================
// Filter DTOs
// ============================================================================

/**
 * @typedef {Object} FilterItemDTO
 * @property {string} FilterGuid
 * @property {string} MandantGuid
 * @property {string} BenutzerGuid
 * @property {string} Title
 * @property {string} Context
 * @property {string} SerializedFilterSetting
 * @property {number} Version
 * @property {string} ChangedDate - ISO date string
 * @property {boolean} IsDeleted
 * @property {number} Reihenfolge
 */

/**
 * @typedef {Object} ListItemPropertyFilterDTO
 * @property {string} PropertyName
 * @property {boolean} IsChecked
 * @property {string} PropertyType
 * @property {string} Filter
 * @property {string} Operator
 * @property {boolean} IsActive
 */

// ============================================================================
// PositionsDaten DTOs
// ============================================================================

/**
 * @typedef {Object} PositionsDatenDTO
 * @property {string} PositionsDatenGuid
 * @property {string} VariantenName
 * @property {string} ArtikelNummer
 * @property {number} PositionsNummer
 * @property {number} AlternativPositionZuNummer
 * @property {string} Besonderheiten
 * @property {string} Einbauort
 * @property {number} Menge
 * @property {string} MengenEinheit
 * @property {string} BelegKommission
 * @property {string} PositionsKommission
 * @property {string} Text
 * @property {string} AngebotsText
 * @property {string} SonderwunschText
 * @property {string} SonderwunschAngebotsText
 * @property {string} ErfassungsDatum - ISO date string
 * @property {number} BmBreite
 * @property {number} BmHoehe
 * @property {string} FarbKuerzel
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbItem
 * @property {string} FarbItemGuid
 * @property {string} FarbCode
 * @property {string} FarbBezeichnung
 * @property {string} FarbZusatzText
 * @property {string} OberflaecheBezeichnung
 * @property {string} OberflaecheGuid
 * @property {string} PulverCode
 * @property {boolean} IstSonderFarbPosition
 * @property {string} Gewebe
 * @property {string} LieferDatum - ISO date string
 * @property {string} Serie
 * @property {string} PCode
 * @property {string} VorgangsNummer
 * @property {string} DruckDatum
 * @property {string} VersandAdresse
 * @property {string} DataErstellDatum
 * @property {string} BelegNummer
 * @property {string} BelegJahr
 * @property {string} Breite
 * @property {string} Hoehe
 * @property {string} Oeffnungsrichtung
 * @property {string} Farbe
 */

// ============================================================================
// Salden DTOs
// ============================================================================

/**
 * @typedef {Object} StandardSaldoDTO
 * @property {string} StandardSaldoGuid
 * @property {number} Wert - Der Wert, den der Anwender eingegeben hat, z.B. 5%
 * @property {string} Typ - "Abschlag", "Zuschlag", "Betrag"
 * @property {string} Art - "Prozentual", "Absolut"
 * @property {string} Name - "Saldo", "StandardSaldo", "Warenwert", "Mehrwertsteuer", "Gesamtbetrag", "Endbetrag", "Farbe"
 * @property {boolean} IsNettoSaldo
 * @property {string} Text
 * @property {string | null} GueltigAb - ISO date string
 * @property {string | null} GueltigBis - ISO date string
 * @property {number} Order
 * @property {boolean} UseKundenrabatt
 */

// ============================================================================
// Scripts DTOs
// ============================================================================

/**
 * @typedef {Object} FileInfoDTO
 * @property {string} FileName
 * @property {number} FileSize
 * @property {string} Modified - ISO date string
 * @property {string} Created - ISO date string
 * @property {string | null} GueltigBis - ISO date string
 * @property {string | null} MandantGuid
 */

/**
 * @typedef {Object} ResourceResolution
 * @property {boolean} Found
 * @property {string} Path
 */

/**
 * @typedef {Object} ResourceEntry
 * @property {string} GueltigAb - ISO date string
 * @property {string} Pfad
 */

/**
 * @typedef {Object} ResourceRegistry
 * @property {string} Version
 * @property {Object.<string, Object.<string, ResourceEntry[]>>} Ressourcen
 */

// ============================================================================
// Produktion (Materialbedarf) DTOs
// ============================================================================

/**
 * @typedef {Object} MaterialbedarfDTO
 * @property {string} MaterialBedarfGuid
 * @property {string} Kennzeichen - Eindeutiges Kennzeichen des Items
 * @property {string} InternerName
 * @property {string} InternerName_Backup
 * @property {string} KatalogNummer - Neher-Katalognummer
 * @property {string} Bezeichnung - Artikelbezeichnung
 * @property {string} Einheit - lfm=Laufmeter, Stk=Stück, qm=Quadratmeter
 * @property {boolean} Beipacken
 * @property {string} Vorgangsnummer - Für Sonderfarbartikel
 * @property {number} Stueckzahl
 * @property {number} Laufmeter
 * @property {boolean} IstVE
 * @property {number | null} VE_Menge
 * @property {string} FarbBezeichnung
 * @property {string} FarbZusatzText - Trend-Farbkürzel (z.B. B7)
 * @property {string} FarbKuerzel - Neher-Kürzel oder Sonderfarbton
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbCode
 * @property {string} FarbeItem
 * @property {string} FarbItemGuid
 * @property {string} OberflaecheBezeichnung
 * @property {string} OberFlaecheGuid
 * @property {string} PulverCode
 * @property {boolean} IstZuschnitt
 * @property {number} ZuschnittLaenge
 * @property {string} ZuschnittWinkel
 * @property {string} PositionsAngabe
 * @property {string} MaterialBezeichnung
 * @property {boolean} MaterialBearbeitungSaegen
 * @property {boolean} MaterialBearbeitungFraesen
 * @property {boolean} MaterialBearbeitungStanzen
 * @property {boolean} MaterialBearbeitungBeschichten
 * @property {boolean} MaterialBearbeitungBohren
 * @property {boolean} MaterialBearbeitungEloxieren
 * @property {boolean} AufPackListe
 * @property {string} CADKennung
 * @property {string} EtikettenSonderS
 * @property {string} IndiSonderInfo1
 * @property {string} IndiSonderInfo2
 * @property {string} IndiSonderInfo3
 * @property {string} PIText
 * @property {boolean} SchraegElement
 * @property {string} SonderFormInfo
 * @property {string} ZusatzEtikettText
 * @property {boolean} AufMaterialListe
 * @property {boolean} NurLieferscheinAnzeige
 * @property {boolean} FromSonderWunsch
 * @property {boolean} IstBeschichtbar
 * @property {string} KatalogArtikelArt
 * @property {import("./produktion.js").MaterialbedarfStatiDTO | null} AktuellerStatus
 * @property {boolean} ProfilGedrehtSaegen
 * @property {boolean} IstSonderfarbe
 * @property {string} MaterialPCode
 * @property {string} Bemerkung
 * @property {string | null} AVPositionGuid
 * @property {string} ZielKennzeichen
 * @property {string | null} AblageGuid
 * @property {string | null} AblageFachGuid
 * @property {string} Lagerfach
 */

// ============================================================================
// Re-export all DTO modules for JSDoc type imports
// ============================================================================
// Usage example (package import): VorgangDTO from @gandalan/idas-weblibs/api/dtos

/**
 * Cross-module DTO aliases so type imports via this index module resolve reliably.
 */

/** @typedef {import("./belege.js").BaseListItemDTO} BaseListItemDTO */
/** @typedef {import("./belege.js").BelegDTO} BelegDTO */
/** @typedef {import("./belege.js").BelegHistorieDTO} BelegHistorieDTO */
/** @typedef {import("./belege.js").BelegHistorienDTO} BelegHistorienDTO */
/** @typedef {import("./belege.js").BelegPositionHistorieDTO} BelegPositionHistorieDTO */
/** @typedef {import("./belege.js").BelegPositionHistorienDTO} BelegPositionHistorienDTO */
/** @typedef {import("./belege.js").BelegStatusDTO} BelegStatusDTO */
/** @typedef {import("./belege.js").BelegartWechselDTO} BelegartWechselDTO */
/** @typedef {import("./belege.js").CalculationInfoDTO} CalculationInfoDTO */
/** @typedef {import("./belege.js").VorgangHistorieDTO} VorgangHistorieDTO */
/** @typedef {import("./belege.js").VorgangHistorienDTO} VorgangHistorienDTO */
/** @typedef {import("./belege.js").VorgangDTO} VorgangDTO */
/** @typedef {import("./belege.js").VorgangListItemDTO} VorgangListItemDTO */
/** @typedef {import("./belege.js").VorgangStatusDTO} VorgangStatusDTO */
/** @typedef {import("./belege.js").VorgangStatusTableDTO} VorgangStatusTableDTO */

/** @typedef {import("./produktion.js").AblageDTO} AblageDTO */
/** @typedef {import("./produktion.js").BearbeitungDTO} BearbeitungDTO */
/** @typedef {import("./produktion.js").BerechnungParameterDTO} BerechnungParameterDTO */
/** @typedef {import("./produktion.js").FachzuordnungResultDTO} FachzuordnungResultDTO */
/** @typedef {import("./produktion.js").ProduktionsDatenDTO} ProduktionsDatenDTO */
/** @typedef {import("./produktion.js").ProduktionsInfoDTO} ProduktionsInfoDTO */
/** @typedef {import("./produktion.js").ProduktionsStatusDTO} ProduktionsStatusDTO */
/** @typedef {import("./produktion.js").ProduktionsStatusHistorieDTO} ProduktionsStatusHistorieDTO */
/** @typedef {import("./produktion.js").ProduktionsfreigabeItemDTO} ProduktionsfreigabeItemDTO */
/** @typedef {import("./produktion.js").SaegeDatenHistorieDTO} SaegeDatenHistorieDTO */
/** @typedef {import("./produktion.js").SaegeDatenResultDTO} SaegeDatenResultDTO */

/** @typedef {import("./ui.js").KatalogArtikelDTO} KatalogArtikelDTO */
/** @typedef {import("./ui.js").KonfigSatzInfoDTO} KonfigSatzInfoDTO */
/** @typedef {import("./ui.js").OberflaecheDTO} OberflaecheDTO */
/** @typedef {import("./ui.js").ProduktFamilieDTO} ProduktFamilieDTO */
/** @typedef {import("./ui.js").TagInfoDTO} TagInfoDTO */
/** @typedef {import("./ui.js").TagVorlageDTO} TagVorlageDTO */
/** @typedef {import("./ui.js").UIDefinitionDTO} UIDefinitionDTO */
/** @typedef {import("./ui.js").UIEingabeFeldInfoDTO} UIEingabeFeldInfoDTO */
/** @typedef {import("./ui.js").UIScriptDTO} UIScriptDTO */
/** @typedef {import("./ui.js").VarianteDTO} VarianteDTO */
/** @typedef {import("./ui.js").WarenGruppeDTO} WarenGruppeDTO */
/** @typedef {import("./ui.js").WerteListeDTO} WerteListeDTO */

/** @typedef {import("./technik.js").KomponenteDTO} KomponenteDTO */
/** @typedef {import("./technik.js").KonturDTO} KonturDTO */
/** @typedef {import("./technik.js").SchnittDTO} SchnittDTO */

/** @typedef {import("./settings.js").PreisermittlungsEinstellungenDTO} PreisermittlungsEinstellungenDTO */

/** @typedef {import("./mail.js").JobStatusEntryDTO} JobStatusEntryDTO */
/** @typedef {import("./mail.js").JobStatusResponseDTO} JobStatusResponseDTO */
/** @typedef {import("./mail.js").MailJobInfo} MailJobInfo */
/** @typedef {import("./artikel.js").KatalogArtikelIndiDatenDTO} KatalogArtikelIndiDatenDTO */
/** @typedef {import("./webjob.js").MandantAndBelegPosGuidDTO} MandantAndBelegPosGuidDTO */
/** @typedef {import("./artikel.js").MaterialBearbeitungsMethodeDTO} MaterialBearbeitungsMethodeDTO */
/** @typedef {import("./nachrichten.js").NachrichtenDTO} NachrichtenDTO */
/** @typedef {import("./produktGruppen.js").ProduktGruppeDTO} ProduktGruppeDTO */

// Re-export modules so their JSDoc types are accessible via the index
export * from "./allgemein.js";
export * from "./artikel.js";
export * from "./av.js";
export * from "./belege.js";
export * from "./benutzer.js";
export * from "./druck.js";
export * from "./farben.js";
export * from "./faktura.js";
export * from "./kunden.js";
export * from "./lager.js";
export * from "./mail.js";
export * from "./mandanten.js";
export * from "./nachrichten.js";
export * from "./produktion.js";
export * from "./produktGruppen.js";
export * from "./settings.js";
export * from "./technik.js";
export * from "./ui.js";
export * from "./webjob.js";
