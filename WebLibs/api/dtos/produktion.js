// This file was auto-generated from C# DTOs in Gandalan.IDAS.WebApi.Client/DTOs/Produktion/
// Do not modify manually - changes will be overwritten

// ============================================================================
// Enums
// ============================================================================

/**
 * @typedef {('Unbekannt'|'Angefragt'|'Beschafft'|'NachSaege'|'NachSLK'|'Abgeschlossen')} MaterialbedarfStatiDTO
 */

/**
 * @typedef {('Unbekannt'|'FuerAVBereitgestellt'|'AVBerechnet'|'AVAbgeschlossen'|'SerieZugeordnet'|'InProduktion'|'ProduktionAbgeschlossen'|'VersandVorbereitung'|'VersandAbgeschlossen'|'ProduktionUnterbrochen'|'Fehler')} ProduktionsStatiWerteDTO
 */

/**
 * @typedef {('Unbekannt'|'Lieferdatum'|'Serienzuordnung'|'ArtikelnummerFrabeOberflaeche'|'Vorgang'|'FarbeOberflaeche'|'Keine')} ZusammenfassungsOptionen
 */

/**
 * @typedef {('Keine'|'Lieferdatum'|'Serie'|'FarbeOberflaeche')} SchnittoptimierungsOptionen
 */

// ============================================================================
// DTOs
// ============================================================================

/**
 * DTO für die IBOS3 Ablageverwaltung
 * @typedef {Object} AblageDTO
 * @property {string} AblageGuid
 * @property {Date} ChangedDate
 * @property {Array<AblageFachDTO>} AblageFaecher
 * @property {string} Standort
 * @property {string} Bezeichnung
 * @property {string} Kuerzel
 */

/**
 * DTO für die IBOS3 Ablageverwaltung
 * @typedef {Object} AblageFachDTO
 * @property {string} AblageFachGuid
 * @property {boolean} Belegt - Fach ist belegt wenn BelegPositionAVGuid nicht leer ist
 * @property {number} FachNr
 * @property {Array<string>} ProduktGruppenGuids - GUIDs der ProduktGruppenDTOs, die im Ablagefach abgelegt werden können
 * @property {Array<string>} MaterialBedarfGuids - GUIDs der aktuell im Ablagefach abgelegten MaterialbedarfDTOs
 * @property {string} BelegPositionAVGuid - Guid der BelegPositionAV - Ist diese Guid schon gesetzt, aber noch kein Material zugeordnet, dann ist das Fach für die Position reserviert
 */

/**
 * @typedef {Object} BearbeitungDTO
 * @property {string} BearbeitungGuid
 * @property {string} Kennzeichen - Eindeutiges Kennzeichen der Bearbeitung (aus GUID)
 * @property {string} ZielKennzeichen - Ziel der Bearbeitung
 * @property {string} BearbeitungsName - Artikelbezeichnung
 * @property {number} X - Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Laufmeter!)
 * @property {number} Y - Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Stückzahl!)
 * @property {string} ProfilName
 * @property {number} ProfilLaenge
 * @property {number} ProfilBreite
 * @property {string} KatalogNummer
 * @property {string} StammdatenDateiFuerBearbeitung
 * @property {string} Spannsituation
 * @property {string} SpannSituationAlternativ
 * @property {string} StartXRegel
 * @property {string} FraesBild
 * @property {string} TextHP
 * @property {string} TextNP
 * @property {number} LLBreite
 * @property {number} LLBreiteAmBildschirm
 * @property {number} LLHoehe
 * @property {number} DurchmesserBohrung
 * @property {number} LochAbstand
 * @property {number} LochAbstandAmBildschirm
 * @property {number} Winkel
 * @property {boolean} ManuellGeloescht
 * @property {boolean} Passiv
 * @property {boolean} NichtFreigegeben
 * @property {boolean} MassXEditierbar
 * @property {boolean} GroesseEditierbar
 */

/**
 * @typedef {Object} BerechnungParameterDTO
 * @property {string} MandantGuid
 * @property {boolean} SaveResultData - Default: true
 * @property {BelegPositionAVDTO} BelegPositionAVDTO
 * @property {ProduktionsSettingsDTO} ProduktionsSettingsDTO
 * @property {number} VorgangsNummer - Default: -999
 * @property {number} BelegNummer - Default: -999
 * @property {boolean} IgnoreSonderwuensche
 * @property {boolean} ReturnRawDataFile
 * @property {string} RawDataFileContent
 */

/**
 * @typedef {Object} BerechnungResultDTO
 * @property {BelegPositionDTO} OriginalBelegPosition
 * @property {string} BelegPositionGuid
 * @property {string} RawDataFileContent
 * @property {ProduktionsDatenDTO} ProduktionsDaten
 */

/**
 * @typedef {Object} EtikettDatenDTO
 * @property {string} EtikettDatenGuid
 * @property {string} Position
 * @property {string} Typ
 * @property {string} Inhalt
 */

/**
 * @typedef {Object} EtikettDTO
 * @property {string} EtikettGuid
 * @property {string} Kuerzel
 * @property {string} Text
 * @property {string} ZielKennzeichen
 * @property {boolean} IstSonderEtikett
 * @property {boolean} IstZusatzEtikett - Zusatzetiketten sind manuell angelegte Etiketten, welche über die AppSpecificProperties gepflegt wurden und sich nun in den AdditionalProperties befinden.
 * @property {string} Typ - Default: "Produktionsetikett"
 * @property {Array<EtikettDatenDTO>} EtikettDaten
 * @property {boolean} EtikettenProfilVorbiegen
 * @property {string} EtikettenSonderKuerzel
 */

/**
 * @typedef {Object} FachzuordnungResultDTO
 * @property {Array<string>} ProduktfamilienOverCapacity
 * @property {boolean} OverCapacity
 */

/**
 * @typedef {Object} GesamtLieferzusageBuchungDTO
 * @property {string} GesamtLieferzusageBuchungGuid
 * @property {string} MandantGuid
 * @property {string} GesamtMaterialbedarfGuid
 * @property {number} Stueckzahl
 * @property {number} Laufmeter
 * @property {Date} Buchungsdatum
 */

/**
 * @typedef {Object} GesamtLieferzusageDTO
 * @property {string} GesamtLieferzusageGuid
 * @property {string} MandantGuid
 * @property {Date} Liefertermin
 * @property {string} KatalogNummer
 * @property {string} BestellNummer
 * @property {string} Einheit
 * @property {number} Stueckzahl
 * @property {number} UngedeckteStueckzahl
 * @property {number} Laufmeter
 * @property {number} UngedeckteLaufmeter
 * @property {string} FarbBezeichnung
 * @property {string} FarbZusatzText
 * @property {string} FarbKuerzel
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbCode
 * @property {string} PulverCode
 * @property {string} FarbeItem
 * @property {string} FarbItemGuid
 * @property {string} OberFlaeche
 * @property {string} OberFlaecheGuid
 * @property {boolean} IstSonderfarbe
 * @property {boolean} IstVE
 * @property {number} [VE_Menge]
 * @property {Array<GesamtLieferzusageBuchungDTO>} Buchungen
 */

/**
 * @typedef {Object} GesamtMaterialbedarfDTO
 * @property {string} GesamtMaterialbedarfGuid
 * @property {string} MandantGuid
 * @property {boolean} IsGruppe
 * @property {Array<GesamtMaterialbedarfDTO>} Children
 * @property {string} ProduktionsMaterialbedarfGuid
 * @property {MaterialbedarfDTO} ProduktionsMaterialbedarf
 * @property {string} SerieGuid
 * @property {SerieDTO} Serie
 * @property {string} SerienName
 * @property {string} BelegPositionGuid
 * @property {BelegPositionDTO} BelegPosition
 * @property {string} BelegPositionAVGuid
 * @property {BelegPositionAVDTO} BelegPositionAV
 * @property {Date} Liefertermin
 * @property {string} KatalogNummer
 * @property {string} Vorgangsnummer
 * @property {string} ArtikelBezeichnung
 * @property {string} Einheit
 * @property {number} Stueckzahl
 * @property {number} GedeckteStueckzahl
 * @property {number} UngedeckteStueckzahl
 * @property {number} Laufmeter
 * @property {number} GedeckteLaufmeter
 * @property {number} UngedeckteLaufmeter
 * @property {string} FarbBezeichnung
 * @property {string} FarbZusatzText
 * @property {string} FarbKuerzel
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbCode
 * @property {string} FarbeItem
 * @property {string} FarbItemGuid
 * @property {string} OberFlaeche
 * @property {string} OberFlaecheGuid
 * @property {string} PulverCode
 * @property {boolean} IstZuschnitt
 * @property {number} ZuschnittLaenge
 * @property {boolean} IstStangenoptimiert
 * @property {string} ZuschnittWinkel
 * @property {boolean} IstSonderfarbe
 * @property {KatalogArtikelArt} KatalogArtikelArt
 * @property {number} DeckungInPercent
 * @property {boolean} IstVE
 * @property {number} [VE_Menge]
 */

/**
 * @typedef {Object} GesamtMaterialbedarfGetReturn
 * @property {Array<GesamtMaterialbedarfDTO>} Bedarfe
 * @property {Array<GesamtMaterialbedarfDTO>} Fehlliste
 * @property {Array<GesamtLieferzusageDTO>} Ueberliste
 * @property {Array<GesamtLieferzusageDTO>} Zusagen
 */

/**
 * @typedef {Object} ILagerLogikDTO
 * @property {string} KatalogArtikelGuid
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbGuid - Deprecated: FarbKuerzelGuid verwenden
 * @property {string} LagerbestandGuid
 */

/**
 * DTO für die Lagerverwaltung
 * @typedef {Object} LagerbestandDTO
 * @property {string} LagerbestandGuid
 * @property {string} KatalogArtikelGuid
 * @property {string} KatalogNummer
 * @property {string} FarbGuid - Deprecated: FarbKuerzelGuid verwenden
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbKuerzel
 * @property {number} Lagerbestand
 * @property {number} Bestellbestand
 * @property {number} Mindestbestand
 * @property {number} Reserviert
 * @property {number} Maximalbestand
 * @property {number} EisernerBestand
 * @property {string} Einheit
 * @property {string} Lagerplatz
 * @property {string} Charge
 * @property {boolean} IstAktiv
 * @property {string} Seriennummer
 * @property {Date} ChangedDate
 * @property {string} WindowsUser
 */

/**
 * DTO für eine Lagerbuchung
 * @typedef {Object} LagerbuchungDTO
 * @property {string} KatalogArtikelGuid
 * @property {string} FarbGuid - Deprecated: FarbKuerzelGuid verwenden
 * @property {string} FarbKuerzelGuid
 * @property {string} LagerbestandGuid
 * @property {number} Betrag
 * @property {boolean} IstReservierung
 * @property {string} Einheit
 * @property {string} Hinweis
 * @property {string} ArtosUser
 * @property {string} WindowsUser
 * @property {Date} ChangedDate
 * @property {number} BestandAlt
 * @property {number} BestandNeu
 */

/**
 * DTO für die LagerReservierungen
 * @typedef {Object} LagerReservierungDTO
 * @property {string} LagerReservierungGuid
 * @property {string} [MaterialbedarfGuid]
 * @property {string} [LieferzusageGuid]
 * @property {string} [GesamtLieferzusageGuid]
 * @property {string} Artikelnummer
 * @property {string} FarbKuerzel
 * @property {string} FarbCode
 * @property {string} Oberflaeche
 * @property {string} Bezug
 * @property {number} Menge
 * @property {string} Einheit
 * @property {Date} ErstellDatum
 * @property {string} WindowsUser
 * @property {string} ArtosUser
 * @property {Date} ChangedDate
 * @property {number} Version
 */

/**
 * @typedef {Object} LieferzusageDTO
 * @property {string} LieferzusageGuid
 * @property {string} MaterialBedarfGuid
 * @property {number} Stueckzahl
 * @property {number} Laufmeter
 * @property {string} Lieferant
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} MaterialbedarfDTO
 * @property {string} MaterialBedarfGuid
 * @property {string} Kennzeichen - Eindeutiges Kennzeichen des Items (aus GUID)
 * @property {string} InternerName
 * @property {string} InternerName_Backup - InternerName wird derzeit an vielen Stellen verwendet weshalb wir jetzt die Backup Property hinzufügen welche den echten InternenNamen aus dem Modell beinhaltet
 * @property {string} KatalogNummer - Neher-Katalognummer des Artikels
 * @property {string} Bezeichnung - Artikelbezeichnung
 * @property {string} Einheit - Einheit des Artikels (lfm=Laufmeter, Stk=Stück, qm=Quadratmeter)
 * @property {boolean} Beipacken
 * @property {string} Vorgangsnummer - Vorgangsnummer die gesetzt ist, wenn es sich um Sonderfarbartikel handelt die nicht zusammengefasst wurden.
 * @property {number} Stueckzahl - Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Laufmeter!)
 * @property {number} Laufmeter - Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Stückzahl!)
 * @property {boolean} IstVE
 * @property {number} [VE_Menge]
 * @property {string} FarbBezeichnung - FarbBezeichnung (Bezeichnung der Farbe)
 * @property {string} FarbZusatzText - FarbZusatzText, hauptsächlich für (Trend-)Farbkürzel (z.B. B7)
 * @property {string} FarbKuerzel - FarbeKuerzel (Neher-Kürzel oder Sonderfarbton)
 * @property {string} FarbKuerzelGuid
 * @property {string} FarbCode - FarbeCode der Farbe
 * @property {string} FarbeItem
 * @property {string} FarbItemGuid
 * @property {string} OberflaecheBezeichnung
 * @property {string} OberFlaecheGuid
 * @property {string} PulverCode
 * @property {boolean} IstZuschnitt - Kennzeichen für Zuschnittartikel
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
 * @property {KatalogArtikelArt} KatalogArtikelArt
 * @property {MaterialbedarfStatiDTO} AktuellerStatus
 * @property {boolean} ProfilGedrehtSaegen - Kennzeichen, ob das Profil gedreht gesägt wird (z.B. bei PT2/46)
 * @property {boolean} IstSonderfarbe
 * @property {string} MaterialPCode
 * @property {string} Bemerkung
 * @property {string} [AVPositionGuid]
 * @property {string} ZielKennzeichen
 * @property {string} [AblageGuid]
 * @property {string} [AblageFachGuid]
 * @property {string} Lagerfach
 */

/**
 * Produktionsdaten für ein Fertigelement
 * @typedef {Object} ProduktionsDatenDTO
 * @property {string} ProduktionsDatenGuid - Eindeutige ID
 * @property {Array<MaterialbedarfDTO>} Material - Gesamtliste des benötigten Materials (immer für Stückzahl 1)
 * @property {Array<EtikettDTO>} Etiketten - Produktionsetiketten
 * @property {Array<BearbeitungDTO>} Bearbeitungen - CNC-Bearbeitungen
 * @property {PositionsDatenDTO} PositionsDaten - Daten der Original-Belegposition
 * @property {Array<SonderwuenscheDTO>} Sonderwuensche
 * @property {Array<string>} Log
 */

/**
 * @typedef {Object} ProduktionsfreigabeItemDTO
 * @property {string} VorgangGuid
 * @property {number} VorgangsNummer
 * @property {string} BelegGuid
 * @property {Date} Belegdatum
 * @property {Date} FreigabeDatum
 * @property {string} Kundenname
 * @property {string} Kommission
 * @property {string} Besitzer
 * @property {string} Besteller
 * @property {string} Bearbeiter
 * @property {ProduktionsInfoDTO} ProduktionsInfos
 */

/**
 * @typedef {Object} ProduktionsInfoDTO
 * @property {number} VorgangsNummer
 * @property {string} VorgangsGuid
 * @property {Array<ProduktionsInfoBelegDTO>} BelegInfos
 */

/**
 * @typedef {Object} ProduktionsInfoBelegDTO
 * @property {string} BelegGuid
 * @property {string} BelegTitel - z.B. 'AB vom 17.07.2021'
 * @property {Date} ErstellDatum
 * @property {Array<ProduktionsInfoBelegPositionDTO>} PositionenInfos
 */

/**
 * @typedef {Object} ProduktionsInfoBelegPositionDTO
 * @property {string} BelegPosGuid
 * @property {string} NachfolgeBelegPosGuid
 * @property {number} BelegPositionsNummer
 * @property {string} VariantenName
 * @property {string} Katalognummer
 * @property {number} Menge
 * @property {string} BelegPositionInfos
 * @property {string} [SerieGuid]
 * @property {boolean} IstGeplanteSerie
 * @property {string} SerieName
 * @property {boolean} IsAktiv
 * @property {boolean} IstAlternativPosition
 * @property {Date} [LieferDatum]
 * @property {Date} [ProduktionsDatum]
 * @property {Array<ProduktionsInfoBelegPositionAVDTO>} AvBelegPositionenInfos
 */

/**
 * @typedef {Object} ProduktionsInfoBelegPositionAVDTO
 * @property {string} AvBelegPositionGuid
 * @property {string} PCode
 * @property {string} [ZugeodneteSerie]
 * @property {string} ZugeodneteSerieName
 * @property {ProduktionsStatiWerteDTO} AktuellerStatus
 * @property {boolean} IstFuerAVBereitgestellt
 * @property {boolean} IstAVBerechnet
 * @property {boolean} IstAVAbgeschlossen
 * @property {boolean} IstSerieZugeordnet
 * @property {boolean} IstInProduktion
 * @property {boolean} IstProduktionAbgeschlossen
 * @property {boolean} IstVersandVorbereitung
 * @property {boolean} IstVersandAbgeschlossen
 * @property {boolean} IstProduktionUnterbrochen
 * @property {boolean} IstFehler
 * @property {number} AktuelleProzent
 * @property {string} AktuellerText
 * @property {number} GesamtMinuten
 * @property {Array<ProduktionsStatusHistorieDTO>} Historie
 */

/**
 * @typedef {Object} ProduktionsStatusDTO
 * @property {string} ProduktionsStatusGuid
 * @property {string} BelegPositionAVGuid
 * @property {Date} Erstellt
 * @property {string} Ersteller
 * @property {string} SerieGuid
 * @property {string} SerieBezeichnung
 * @property {ProduktionsStatiWerteDTO} AktuellerStatus
 * @property {number} AktuelleProzent
 * @property {string} AktuellerText
 * @property {number} GesamtMinuten
 * @property {Array<ProduktionsStatusHistorieDTO>} Historie
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} ProduktionsStatusHistorieDTO
 * @property {string} ProduktionsStatusHistorieGuid
 * @property {ProduktionsStatiWerteDTO} Status
 * @property {string} Text
 * @property {number} Produktionsminuten
 * @property {string} ProduktionsStatusInfoText
 * @property {number} ProduktionsStatusInProzent
 * @property {Date} Zeitstempel
 * @property {string} Benutzer
 */

/**
 * @typedef {Object} SaegeDatenHistorieDTO
 * @property {string} SaegeDatenHistorieGuid
 * @property {string} SerieGuid
 * @property {string} SerienName
 * @property {Date} ErstelltAm
 * @property {string} DateiName
 * @property {string} DateiPfad
 * @property {string} SaegeModell
 * @property {string} Benutzername
 * @property {string} SaegeDatei
 * @property {string} Meldungen
 */

/**
 * @typedef {Object} SaegeDatenResultDTO
 * @property {string} Content
 * @property {string} Meldungen
 * @property {string} Modell
 * @property {string} Dateipfad
 * @property {string} Dateiname
 */

/**
 * DTO für die Konfiguration von Sägen in IBOS3
 * @typedef {Object} SaegeKonfigurationDTO
 * @property {string} Bezeichnung - Bezeichnung der Säge
 * @property {string} Modell - Modellbezeichnung des ISaegeDatenGenerator, der genutzt werden soll
 * @property {string} DisplayName - DisplayName des ISaegeDatenGenerator, der genutzt werden soll
 * @property {string} KorrekturSatz - Bezeichnung des SaegemassKorrekturSatzDTO, das genutzt werden soll
 * @property {boolean} DoppelGeradSchnitt - Angabe, ob die Säge Schnitte mit 90-90 Grad sägen kann
 * @property {boolean} DoppelGehrungsSchnitt - Angabe, ob die Säge Schnitte mit 45-45 Grad sägen kann
 * @property {boolean} GeradGehrungsSchnitt - Angabe, ob die Säge Schnitte mit 45-90 Grad sägen kann
 * @property {boolean} FreierSchnitt - Angabe, ob die Säge Schnitte mit anderen Winkeln sägen kann
 * @property {string} Ausgabeverzeichnis_Geradschnitt - Ausgabeverzeichnis für die Datei mit Geradschnitten (90-90)
 * @property {string} Ausgabeverzeichnis_GeradGehrung - Ausgabeverzeichnis für die Datei mit GeradGehrungsschnitten (45-90; 90-45)
 * @property {string} Ausgabeverzeichnis_DoppelGehrung - Ausgabeverzeichnis für die Datei mit Doppelgehrungsschnitten (45-45)
 * @property {boolean} KombinierteSaegeDatei - Kennzeichen, ob alle Schnitte in einer Datei ausgegeben werden sollen
 * @property {string} Ausgabverzeichnis_kombiniert - Ausgabeverzeichnis für kombinierte Sägedatei
 * @property {string} FarbKuerzel_SF - FarbKuerzel für Sonderfarbschnitte - Default: "SF"
 */

/**
 * DTO für die Verwaltung der Sägemaßkorrekturen
 * @typedef {Object} SaegemassKorrekturDTO
 * @property {string} KatalogNummer - Katalognummer des Profils, für das die Sägemaßkorrektur gilt
 * @property {number} Korrektur90Grad - Korrekturmaß bei 90° Schnitt (in mm)
 * @property {number} Korrektur45Grad - Korrekturmaß bei 45° Schnitt (in mm)
 * @property {number} WinkelKorrektur45Grad - Winkelkorrektur bei 45° Schnitt (in °)
 * @property {number} WinkelKorrektur90Grad - Winkelkorrektur bei 90° Schnitt (in °)
 */

/**
 * DTO für die Verwaltung der Sägemaßkorrekturen
 * @typedef {Object} SaegemassKorrekturSatzDTO
 * @property {string} Bezeichnung - Bezeichnung des Sägemaßkorrektursatzes
 * @property {Array<SaegemassKorrekturDTO>} SaegemassKorrekturen - Liste mit profilbezogenen Sägemaßkorrekturen
 */

/**
 * @typedef {Object} SonderwuenscheDTO
 * @property {string} Bezeichnung
 * @property {string} Wert
 */

// ============================================================================
// Placeholder types (defined in other DTO files)
// ============================================================================

/**
 * @typedef {Object} BelegPositionAVDTO
 */

/**
 * @typedef {Object} BelegPositionDTO
 */

/**
 * @typedef {Object} SerieDTO
 */

/**
 * @typedef {Object} ProduktionsSettingsDTO
 */

/**
 * @typedef {Object} PositionsDatenDTO
 */

/**
 * @typedef {Object} KatalogArtikelArt
 */

/**
 * Represents optimization output for one material item.
 * Keys and values are backend-defined and may vary by optimization strategy.
 * @typedef {Object.<string, any>} MaterialbedarfCutOptimization
 */

export {};
