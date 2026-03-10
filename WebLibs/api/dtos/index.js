/**
 * JSDoc Type Definitions for Gandalan.IDAS.WebApi.Client DTOs
 * Auto-generated from C# DTOs in /Gandalan.IDAS.WebApi.Client/DTOs/
 */

// ============================================================================
// AV (Arbeitsvorbereitung) DTOs
// ============================================================================

/**
 * @typedef {Object} AVReserviertItemDTO
 * @property {string} Variante
 * @property {string} ArtikelNummer
 * @property {number} Menge
 * @property {string} Kommission
 * @property {string} Kunde
 * @property {number} VorgangsNummer
 * @property {string} VorgangGuid
 * @property {number} BelegNummer
 */

/**
 * @typedef {Object} BearbeitungsKuerzelDTO
 * @property {string} BearbeitungsKuerzel
 * @property {string} Beschreibung
 * @property {string[]} VerfuegbarFuer
 * @property {string} FarbCode
 * @property {string} RegularExpression
 */

/**
 * @typedef {Object} BelegPositionAVDTO
 * @property {string} BelegPositionAVGuid
 * @property {string} SerieGuid
 * @property {string} BelegPositionGuid
 * @property {string} VorgangGuid
 * @property {string} BelegGuid
 * @property {string} Bereitgestellt - ISO date string
 * @property {string | null} Berechnet - ISO date string
 * @property {boolean} IstBerechnet
 * @property {number} FailedCalculationsCount - Counter for failed calculations
 * @property {boolean} IstProduziert
 * @property {boolean} IstGeloescht
 * @property {boolean} IstStorniert
 * @property {boolean} HatSonderwuensche
 * @property {string} SonderwunschText
 * @property {string} Variante
 * @property {string} ArtikelNummer
 * @property {string} Kommission
 * @property {string} Kunde
 * @property {string} Pcode
 * @property {string} Fehlerlog
 * @property {string} FakturaKennzeichen - "NichtFreigegeben", "Freigegeben", "Abgerechnet"
 * @property {boolean} IstAusserhalbGewaehrleistung
 * @property {number} KapazitaetsBedarf
 * @property {BelegPositionDTO | null} Position
 * @property {ProduktionsDatenDTO | null} ProduktionsDaten
 * @property {boolean} IstGedruckt
 * @property {string} ErfassungsDatum - ISO date string
 * @property {string} ChangedDate - ISO date string
 * @property {string | null} CalculatedForTimestamp - ISO date string
 */

/**
 * @typedef {Object} BelegPositionAVListItemDTO
 * @property {string} BelegPositionAVGuid
 * @property {string | null} BelegPositionGuid
 * @property {string} PCode
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} PCodeStatistikDTO
 * @property {string} MandantGuid
 * @property {string} MandantName
 * @property {number} UsedPCodes
 */

/**
 * @typedef {Object} PositionSerieItemDTO
 * @property {string} BelegPositionGuid
 * @property {string} Position
 * @property {number} Menge
 * @property {number} Vorlauf
 * @property {string} SerieAuslastung
 * @property {string} SerieGuid
 * @property {string} ProduktionsDatum - ISO date string
 * @property {string} LieferDatum - ISO date string
 * @property {string} PositionInfo
 * @property {number} KapBedarf
 * @property {number} KapBedarfGes
 * @property {boolean} HatNachfolgeBelegPosition
 * @property {boolean} VeschiedeneSerien - currently only used in client
 * @property {string[] | null} SerienGuids - only set when VeschiedeneSerien is true
 */

/**
 * @typedef {Object} ProfilKuerzelDTO
 * @property {string} ProfilKuerzel
 * @property {string} Beschreibung
 * @property {string[]} VerfuegbarFuer
 */

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
 * @property {BeleganschriftDTO | null} BelegAdresse
 * @property {BeleganschriftDTO | null} VersandAdresse
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

/**
 * @typedef {Object} SerieAuslastungDTO
 * @property {boolean} IstSumme
 * @property {string} Produktfamilie
 * @property {number} Anzahl
 * @property {number} Reserviert
 * @property {number} Arbeitsminuten
 * @property {number} ArbeitsminutenReserviert
 * @property {number} Elementgewicht
 * @property {number} ElementgewichtReserviert
 * @property {number} AnzahlMax
 * @property {number} KapazitaetBelegt
 * @property {number} KapazitaetMax
 */

/**
 * @typedef {Object} SerieDTO
 * @property {string} SerieGuid - Eindeutige ID der Serie
 * @property {string} Name - Name der Serie (Langform)
 * @property {string} Kuerzel - Serienkürzel für Ausdrucke, Kurzanzeige usw.
 * @property {string} Start - Beginn der Produktion (erster Produktionstag) - ISO date string
 * @property {string} Ende - Ende der Produktion (letzter Produktionstag) - ISO date string
 * @property {boolean} StaendigeSerie - Ständige Serie
 * @property {string[]} AVBelegPositionen - AV-Positionen in dieser Serie
 * @property {number} Kapazitaet - Kapazität in neutralen Kapazitätseinheiten (alt)
 * @property {number} KapazitaetInMin - Kapazität der Serie in Minuten
 * @property {number} KapazitaetReserviert - Belegung in neutralen Kapazitätseinheiten
 * @property {string} MaterialBedarfStatus - "NichtBerechnet", "BerechnungGestartet", "Berechnet"
 * @property {boolean} IstGesperrt - Serie ist gesperrt
 * @property {SerieDruckInfoDTO[]} DruckInfos
 * @property {string} ChangedDate - ISO date string
 */

/**
 * @typedef {Object} SerieDruckInfoDTO
 * @property {string} SerieDruckInfoGuid
 * @property {string} Benutzername
 * @property {string} DokumentArt
 * @property {string} Zeitstempel - ISO date string (UTC)
 */

/**
 * @typedef {Object} SerieHistorieDTO
 * @property {string} SerieHistorieGuid
 * @property {string} SerieGuid
 * @property {string} SerienName
 * @property {string} Text
 * @property {string} Zeitstempel - ISO date string
 * @property {string} Benutzer
 */

/**
 * @typedef {Object} SerienMaterialEditDTO
 * @property {string} SerieGuid
 * @property {MaterialbedarfDTO[]} MaterialListe
 */

/**
 * @typedef {Object} VirtualSerieWithAuslastungDTO
 * @property {string} SerieGuid - Eindeutige ID der Serie
 * @property {string} Name - Name der Serie (Langform)
 * @property {string} Kuerzel - Serienkürzel für Ausdrucke, Kurzanzeige usw.
 * @property {string} Start - Beginn der Produktion (erster Produktionstag) - ISO date string
 * @property {string} Ende - Ende der Produktion (letzter Produktionstag) - ISO date string
 * @property {SerieAuslastungDTO[]} Auslastungen
 */

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
// Benutzer DTOs
// ============================================================================

/**
 * @typedef {Object} BenutzerDTO
 * @property {RolleDTO[]} Rollen
 * @property {string} BenutzerGuid
 * @property {string} Benutzername
 * @property {string} Vorname
 * @property {string} Nachname
 * @property {string | null} MandantGuid
 * @property {string} Passwort
 * @property {string} PasswortBCrypt
 * @property {boolean | null} MasterKatalog
 * @property {boolean | null} HauptKatalog
 * @property {number | null} NewsletterId
 * @property {boolean} IstAktiv
 * @property {string[]} GesperrteVarianten
 * @property {string} ChangedDate - ISO date string
 * @property {string} EmailAdresse
 * @property {string} TelefonNummer
 * @property {string} Art
 * @property {boolean} IstSicSynchronized
 * @property {string} LastSicMessage
 */

/**
 * @typedef {Object} BerechtigungDTO
 * @property {string} Code
 * @property {string} ErklaerungsText
 * @property {string} Level
 */

/**
 * @typedef {Object} LoginAttemptDTO
 * @property {string} UserGuid
 * @property {number} FailCount
 * @property {string | null} RequestTime - ISO date string
 */

/**
 * @typedef {Object} LoginAttemptResultDTO
 * @property {number} FailCount
 * @property {string | null} LastFailedLogin - ISO date string
 */

/**
 * @typedef {Object} LoginDTO
 * @property {string} Email
 * @property {string} Password
 * @property {string} Mandant
 * @property {string} AppToken
 */

/**
 * @typedef {Object} PasswortAendernDTO
 * @property {string} Benutzername
 * @property {string} AltesPasswort
 * @property {string} NeuesPasswort
 */

/**
 * @typedef {Object} RefreshTokenDTO
 * @property {string} Token
 * @property {string} Expires - ISO date string
 * @property {string} UserTokenGuid
 * @property {UserAuthTokenDTO | null} UserToken
 * @property {string} AppToken
 */

/**
 * @typedef {Object} RolleDTO
 * @property {BerechtigungDTO[]} Berechtigungen
 * @property {string} Name
 * @property {string} Beschreibung
 * @property {string} RolleGuid
 */

/**
 * @typedef {Object} UserAuthTokenDTO
 * @property {string} AppToken
 * @property {string} Expires - ISO date string
 * @property {string} Token
 * @property {BenutzerDTO | null} Benutzer
 * @property {string} MandantGuid
 * @property {MandantDTO | null} Mandant
 */

/**
 * @typedef {Object} ZustimmungsInfoDTO
 * @property {string} Dokument
 * @property {string} Version
 * @property {string} Zeitstempel - ISO date string
 * @property {string} Plattform
 */

// ============================================================================
// Druck DTOs
// ============================================================================

/**
 * @typedef {Object} ILayoutBelegDruck
 * @property {boolean} ShowLogo
 * @property {number} LogoPositionX
 * @property {number} LogoPositionY
 * @property {number} LogoSizeWidth
 * @property {number} LogoSizeHeight
 * @property {number} TabellePositionX
 * @property {number} TabellePositionY_Seite1
 * @property {number} TabellePositionY_AbSeite2
 * @property {number} TabelleHoehe_Seite1
 * @property {number} TabelleHoehe_AbSeite2
 * @property {number} TabelleBreite
 * @property {number} BriefkopfPositionX
 * @property {number} BriefkopfPositionY
 * @property {number} FusszeilePositionX
 * @property {number} FusszeilePositionY
 * @property {number} SeitenrandLinks
 * @property {number} SeitenrandRechts
 * @property {number} SeitenrandUnten
 * @property {number} SeitenrandOben
 * @property {number} KommissionPositionY
 * @property {number} SeitenzaehlerPositionX
 * @property {number} SeitenzaehlerPositionY_Seite1
 * @property {number} SeitenzaehlerPositionY_AbSeite2
 * @property {number} AnschriftPositionX
 * @property {number} AnschriftPositionY
 * @property {number} MicroAnschriftPositionX
 * @property {number} MicroAnschriftPositionY
 * @property {boolean} ShowMicroAnschrift
 * @property {number} BelegKopfPositionX
 * @property {number} BelegKopfPositionY
 * @property {number} BelegKopfPositionY_AbSeite2
 * @property {boolean} ShowHistorie
 * @property {boolean} IsBlankoDruck
 * @property {boolean} IsBestellfixBeleg
 * @property {boolean} IsDiagnoseDruck
 */

/**
 * @typedef {Object} LayoutBelegDruckDTO
 * @extends ILayoutBelegDruck
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
 * @property {MandantDTO | null} Mandant
 * @property {string} BelegPositionGuid
 * @property {BelegPositionDTO | null} BelegPosition
 * @property {BelegPositionAVDTO[] | null} AVPositionen
 * @property {ProduktionsSettingsDTO | null} ProduktionsSettings
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
// Update DTOs
// ============================================================================

/**
 * @typedef {Object} ChangeDTO
 * @property {string} ChangedGuid
 * @property {string} ChangedWhen - ISO date string
 * @property {string} ChangeType
 * @property {string} ChangeOperation
 * @property {number | null} MandantId
 * @property {string | null} MandantGuid
 * @property {string} Data
 */

/**
 * @typedef {Object} ChangeInfoDTO
 * @property {string} Kontakte - ISO date string
 * @property {string} Vorgaenge - ISO date string
 * @property {string} Serien - ISO date string
 * @property {string} BelegPositionenAV - ISO date string
 * @property {string} Settings - ISO date string
 * @property {string} Lagerbestand - ISO date string
 * @property {string} BelegPositionen - ISO date string
 * @property {string} ProduktionsStati - ISO date string
 * @property {string} TagInfos - ISO date string
 */

/**
 * @typedef {Object} DevOpsStatusDTO
 * @property {string} Env
 * @property {string} DbInfo
 * @property {string} CurrentMigration
 * @property {string[]} PendingMigrations
 */

/**
 * @typedef {Object} UpdateInfoDTO
 * @property {string} KatalogArtikel - ISO date string
 * @property {string} ProduktFamilien - ISO date string
 * @property {string} ProduktGruppen - ISO date string
 * @property {string} Varianten - ISO date string
 * @property {string} UI - ISO date string
 * @property {string} WerteListen - ISO date string
 * @property {string} Farben - ISO date string
 * @property {string} Scripts - ISO date string
 * @property {string} FarbKuerzel - ISO date string
 * @property {string} Oberflaechen - ISO date string
 * @property {string} FarbGruppen - ISO date string
 */

// ============================================================================
// API DTOs
// ============================================================================

/**
 * @typedef {Object} ApiVersionDTO
 * @property {string} Version
 * @property {string} Environment
 * @property {string} BuildTime
 * @property {string} ReleaseTime - Deprecated: Use BuildTime instead
 */

/**
 * @typedef {Object} ExtendedStatusCodeDTO
 * @property {Error | null} Exception
 * @property {string} Info
 */

// ============================================================================
// Contracts DTOs
// ============================================================================

/**
 * @typedef {Object} ContractDTO
 * @property {string} ContractGuid
 * @property {string} Owner
 * @property {string} Partner
 * @property {string} Context
 * @property {string} Value
 * @property {number} Version
 * @property {string} ChangedDate - ISO date string
 * @property {string} OwnerName
 * @property {string} PartnerName
 * @property {boolean} IsEditable
 * @property {boolean} Inherit
 */

// ============================================================================
// LoginJwt DTOs
// ============================================================================

/**
 * @typedef {Object} CreateServiceTokenRequestDTO
 * @property {string} AppTokenGuid
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
 * @property {MaterialbedarfStatiDTO | null} AktuellerStatus
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
// Type Exports (JSDoc Types)
// ============================================================================
// Note: JSDoc @typedef definitions are not real JavaScript exports.
// They are only available for type checking and documentation.
// To use these types, import them via JSDoc: @typedef {import('./dtos/index.js').TypeName}
// No actual JavaScript exports here - this file is for documentation only.
