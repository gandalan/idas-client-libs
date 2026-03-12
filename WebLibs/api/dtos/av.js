/**
 * @fileoverview JSDoc type definitions for AV (Arbeitsvorbereitung) DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/AV/
 */

/** @typedef {import('./belege.js').BelegPositionDTO} BelegPositionDTO */
/** @typedef {import('./produktion.js').ProduktionsDatenDTO} ProduktionsDatenDTO */
/** @typedef {import('./index.js').MaterialbedarfDTO} MaterialbedarfDTO */

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
 * @typedef {Object} VirtualSerieWithAuslastungDTO
 * @property {string} SerieGuid - Eindeutige ID der Serie
 * @property {string} Name - Name der Serie (Langform)
 * @property {string} Kuerzel - Serienkürzel für Ausdrucke, Kurzanzeige usw.
 * @property {string} Start - Beginn der Produktion (erster Produktionstag) - ISO date string
 * @property {string} Ende - Ende der Produktion (letzter Produktionstag) - ISO date string
 * @property {SerieAuslastungDTO[]} Auslastungen
 */

/**
 * @typedef {Object} SerienMaterialEditDTO
 * @property {string} SerieGuid
 * @property {MaterialbedarfDTO[]} MaterialListe
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
 * @typedef {Object} ProfilKuerzelDTO
 * @property {string} ProfilKuerzel
 * @property {string} Beschreibung
 * @property {string[]} VerfuegbarFuer
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
 * @typedef {Object} PCodeStatistikDTO
 * @property {string} MandantGuid
 * @property {string} MandantName
 * @property {number} UsedPCodes
 */

export {};
