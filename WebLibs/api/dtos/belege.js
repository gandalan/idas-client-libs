/**
 * @fileoverview JSDoc type definitions for Belege DTOs from Gandalan.IDAS.WebApi.Client
 * Auto-generated from C# DTO files in Gandalan.IDAS.WebApi.Client/DTOs/Belege/
 */

/**
 * BelegArt enum values
 * @typedef {0|1|2|3|4|5|6|7|8|9|10|11|12|13} BelegArt
 * 0: Unbekannt
 * 1: Angebot
 * 2: AB (Auftragsbestätigung)
 * 3: Rechnung
 * 4: Lieferschein
 * 5: Bestellschein
 * 6: ProduktionsAuftrag
 * 7: ZuschnittAuftrag
 * 8: VersandAuftrag
 * 9: MaterialBestellschein
 * 10: ReklamationsBestellschein
 * 11: Gutschrift
 * 12: Storno
 * 13: FremdfertigungsAuftrag
 */

/**
 * @typedef {Object} BelegWorkflow
 * @property {Array<BelegArt>} Steps - Workflow steps array
 */

/**
 * BelegStatus enum values
 * @typedef {0|10|20|30|40|50|60|70|80|90|100|110|120|130|140|150|160} BelegStatus
 * 0: Unbekannt
 * 10: Erfasst
 * 20: Gelöscht
 * 30: Angebot angefragt
 * 40: Bestellt
 * 50: Auftrag bestätigt
 * 60: In Produktion
 * 70: Produktion abgeschlossen
 * 80: Versand vorbereitet
 * 90: Versand ausgeführt
 * 100: Ware ausgeliefert
 * 110: Reklamation
 * 120: Bestellung abgeschlossen
 * 130: Fakturiert
 * 140: Storniert
 * 150: Importiert
 * 160: Beleg kopiert
 */

/**
 * @typedef {Object} BaseListItemDTO
 * @property {string} VorgangGuid - Eindeutige GUID des Vorgangs
 * @property {string} BelegGuid - Eindeutige GUID des Bestellscheins
 * @property {number} VorgangsNummer - Sichtbare Vorgangsnummer/zur Info für Kunden usw.
 * @property {number} BelegNummer
 * @property {number} BelegJahr
 * @property {Date} ErstellDatum - Erstelldatum des Vorgangs
 * @property {Date} AenderungsDatum - Datum der letzten Änderung
 * @property {string} Kundenname - Name des Kunden für Anzeige
 * @property {string} URL - Adresse des detaillierten Beleg-Objektes (gSQL)
 * @property {string} Status
 * @property {number} AnzahlNachrichten
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 */

/**
 * @typedef {Object} BestellungListItemDTO
 * @extends {BaseListItemDTO}
 */

/**
 * @typedef {Object} MaterialBestellungListItemDTO
 * @extends {BaseListItemDTO}
 */

/**
 * @typedef {Object} BelegartWechselDTO
 * @property {string} BelegGuid
 * @property {Array<string>} BelegPositionGuids
 * @property {BelegArt} NeueBelegArt
 * @property {boolean} SaldenKopieren
 * @property {RechnungsNummer} RechnungsNummer
 * @property {boolean} UpdateErfassungsdatum
 */

/**
 * @typedef {Object} AdresseDruckDTO
 * @property {string} Anrede
 * @property {string} Nachname
 * @property {string} Vorname
 * @property {string} Firmenname
 * @property {string} Zusatz
 * @property {string} AdressZusatz1
 * @property {string} Strasse
 * @property {string} Hausnummer
 * @property {string} Postleitzahl
 * @property {string} Ort
 * @property {string} Ortsteil
 * @property {string} Land
 * @property {boolean} IstInland
 */

/**
 * @typedef {Object} BelegPositionDruckDTO
 * @property {string} PositionsKommission
 * @property {number} LaufendeNummer
 * @property {string} ArtikelNummer
 * @property {string} Variante
 * @property {boolean} IstAlternativPosition
 * @property {boolean} IstAktiv
 * @property {number} Menge
 * @property {string} EinzelpreisOhneFarbzuschlag
 * @property {string} Einzelpreis
 * @property {string} Rabatt
 * @property {string} Gesamtpreis
 * @property {string} Farbzuschlag
 * @property {string} MengenEinheit
 * @property {string} Text
 * @property {string} AngebotsText
 * @property {string} PulverCode
 * @property {string} SonderwunschText
 * @property {string} SonderwunschAngebotsText
 * @property {string} ProduktionZusatzInfo
 * @property {boolean} ProduktionZusatzInfoPrintOnReport
 * @property {boolean} ProduktionZusatzInfoPrintZusatzEtikett
 * @property {boolean} IstVE
 * @property {number|null} VE_Menge
 * @property {Array<ZusatztextDTO>} Zusatztexte
 * @property {string} BelegPositionGuid
 */

/**
 * @typedef {Object} BelegSaldoDruckDTO
 * @property {number} Reihenfolge
 * @property {string} Text
 * @property {string} Betrag
 * @property {string} Rabatt
 * @property {boolean} IsLastElement
 */

/**
 * @typedef {Object} BelegDruckDTO
 * @property {string} BelegGuid
 * @property {string} VorgangGuid
 * @property {string} Kopfzeile
 * @property {string} Fusszeile
 * @property {string} BelegArt
 * @property {number} BelegNummer
 * @property {number} VorgangsNummer
 * @property {Date} BelegDatum
 * @property {string} VorgangErstellDatum
 * @property {Date} AenderungsDatum
 * @property {number} BelegJahr
 * @property {string} Schlusstext
 * @property {string} BelegTitelUeberschrift
 * @property {string} BelegTitelZeile1
 * @property {string} BelegTitelZeile2
 * @property {string} TextFuerAnschreiben
 * @property {string} Kommission
 * @property {string} Ausfuehrungsdatum
 * @property {string} AnsprechpartnerKunde
 * @property {string} Ansprechpartner
 * @property {string} Telefonnummer
 * @property {string} Bestelldatum
 * @property {string} Belegdatum
 * @property {AdresseDruckDTO} BelegAdresse
 * @property {string} BelegAdresseString
 * @property {AdresseDruckDTO} VersandAdresse
 * @property {string} VersandAdresseString
 * @property {Array<BelegPositionDruckDTO>} PositionsObjekte
 * @property {Array<BelegSaldoDruckDTO>} Salden
 * @property {number} CountValuePositionen
 * @property {number} CountValueSalden
 * @property {string} Lieferzeit
 * @property {boolean} IsEndkunde
 * @property {boolean} IsRabatt
 * @property {boolean} IstSelbstabholer
 * @property {number|null} SammelbelegNummer
 * @property {string} Kontrollkuerzel
 */

/**
 * @typedef {Object} BelegDTO
 * @property {string} BelegGuid
 * @property {string} BelegArt
 * @property {number} BelegNummer
 * @property {number} BelegJahr
 * @property {Date} BelegDatum
 * @property {Date} AenderungsDatum
 * @property {BeleganschriftDTO} BelegAdresse
 * @property {BeleganschriftDTO} VersandAdresse
 * @property {boolean} VersandAdresseGleichBelegAdresse
 * @property {string} AusfuehrungsDatum
 * @property {string} Terminwunsch
 * @property {string} InterneNotiz
 * @property {string} BemerkungFuerKunde
 * @property {boolean} IstSelbstabholer
 * @property {string} BelegTitelUeberschrift
 * @property {string} BelegTitelZeile1
 * @property {string} BelegTitelZeile2
 * @property {string} Schlusstext
 * @property {string} AktuellerStatusCode
 * @property {string} AktuellerStatusText
 * @property {string} Ansprechpartner
 * @property {string} AnsprechpartnerKunde
 * @property {Array<string>} Positionen
 * @property {Array<BelegSaldoDTO>} Salden
 * @property {Array<BelegHistorieDTO>} Historie
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 * @property {Array<BelegPositionDTO>} PositionsObjekte
 * @property {string} TextFuerAnschreiben
 * @property {boolean} IstGesperrt
 * @property {string} FakturaKennzeichen - Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
 * @property {string} ExterneReferenznummer
 * @property {string|null} ExterneMandantenGuid
 * @property {number|null} SammelbelegNummer
 * @property {string|null} SammelbelegGuid
 */

/**
 * @typedef {Object} BelegHistorieDTO
 * @property {string} BelegHistorieGuid
 * @property {string} Status
 * @property {string} Text
 * @property {Date} Zeitstempel
 * @property {string} Benutzer
 */

/**
 * @typedef {Object} BelegHistorienDTO
 * @property {Array<BelegHistorieDTO>} BelegHistorien
 * @property {Object<string, Array<BelegPositionHistorieDTO>>} BelegPositionHistorien
 */

/**
 * @typedef {Object} BelegNummerSettingDTO
 * @property {string} BelegArt
 * @property {number} Startwert
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} BelegPositionDatenDTO
 * @property {string} UnterkomponenteName
 * @property {string} KonfigName
 * @property {string} Wert
 * @property {string} DatenTyp
 * @property {string} BelegPositionDatenGuid
 */

/**
 * @typedef {Object} BelegPositionDTO
 * @property {string} BelegPositionGuid
 * @property {string} NachfolgeBelegPositionGuid
 * @property {Date} ErfassungsDatum
 * @property {number} LaufendeNummer - Die fortlaufende Nummer für jede Position innerhalb des Beleges. Über diese Nummer wird auch die Ausgabenreihenfolge bestimmt.
 * @property {string} PositionsNummer - Die sichtbare PositionsNummer, sie kann auch leer sein, z.Bsp. bei Titeln, Text- oder alternativen Positionen. Sie sollte nicht mehr als max. 4 Zeichen lang sein, damit die Pos.-Splate auf dem Beleg nicht zu breit wird.
 * @property {string} ArtikelNummer
 * @property {string} Variante
 * @property {string} VarianteGuid
 * @property {string} Einbauort
 * @property {string} PositionsKommission
 * @property {boolean} IstAlternativPosition
 * @property {boolean} IstAktiv
 * @property {boolean} IstFehlerhaft
 * @property {boolean} IstStorniert
 * @property {boolean} IstFehlerhaftSFOhnePreis
 * @property {boolean} IstGesperrt
 * @property {number} Menge
 * @property {number} Listenpreis
 * @property {number} Einzelpreis
 * @property {number} Rabatt
 * @property {number} AufAbschlag
 * @property {number} Gesamtpreis
 * @property {number} Steuersatz
 * @property {string} MengenEinheit
 * @property {string} Text
 * @property {Array<BelegPositionDatenDTO>} Daten
 * @property {number} SonderWuenscheModelVersion - Die Version des Sonderanpassungen-Tabs in der i3 Belegpositionserfassung, mit der die Position zuletzt bearbeitet wurde.
 * @property {Array<BelegPositionSonderwunschDTO>} Sonderwuensche
 * @property {Array<BelegPositionHistorieDTO>} Historie
 * @property {Array<ZusatztextDTO>} Zusatztexte
 * @property {string} Besonderheiten
 * @property {string} ProduktionZusatzInfo
 * @property {boolean} ProduktionZusatzInfoPrintOnReport
 * @property {boolean} ProduktionZusatzInfoPrintZusatzEtikett
 * @property {boolean} IstBruttoGesamtpreis
 * @property {boolean} IstBruttoEinzelpreis
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 * @property {boolean} IstSonderfarbPosition
 * @property {number} Farbzuschlag
 * @property {boolean} IstFarbzuschlagManuell
 * @property {string} AngebotsText
 * @property {string} SonderwunschText
 * @property {string} SonderwunschAngebotsText
 * @property {Date|null} ProduktionsDatum
 * @property {Date|null} LieferDatum
 * @property {Date|null} ProduktionsAuftragErstellt
 * @property {string|null} GeplanteSerieGuid
 * @property {string|null} VorgaengerBelegPositionGuid
 * @property {string} FakturaKennzeichen - Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
 * @property {boolean} IstAusserhalbGewaehrleistung
 * @property {boolean} IstVE
 * @property {number|null} VE_Menge
 * @property {string|null} FrontendLogikGuid
 * @property {boolean} IstFremdfertigung
 * @property {string|null} FremdfertigungMandantGuid
 * @property {number|null} Arbeitsminuten
 * @property {number|null} Elementgewicht
 * @property {boolean} PreisAufAnfrage
 * @property {Date|null} CalculationRequestTimestamp
 * @property {Date|null} CalculatedForTimestamp
 */

/**
 * @typedef {Object} BelegPositionHistorieDTO
 * @property {string} BelegPositionHistorieGuid
 * @property {string} Text
 * @property {Date} Zeitstempel
 * @property {string} Benutzer
 */

/**
 * @typedef {Object} BelegPositionHistorienDTO
 * @property {Array<BelegPositionHistorieDTO>} BelegPositionHistorien
 */

/**
 * @typedef {Object} BelegSaldoDTO
 * @property {string} BelegSaldoGuid
 * @property {number} Reihenfolge
 * @property {string} Text - Text für die Anzeige
 * @property {number} Betrag - Der eigentlich Saldenwert.
 * @property {number} Wert - Der Wert, den der Anwender eingegeben hat, z.B. 5%
 * @property {string} Typ - Zulässige Werte: "Abschlag", "Zuschlag", "Betrag"
 * @property {string} Art - Zulässige Werte: "Prozentual", "Absolut"
 * @property {string} Name - Zulässige Werte: "Saldo", "StandardSaldo", "Warenwert", "Mehrwertsteuer", "Gesamtbetrag", "Endbetrag", "Farbe"
 * @property {string} SaldenStatus - Zulässige Werte: "Unbekannt", "ManuelleEingabe", "AutoEingabe", "AufAnfrage"
 * @property {boolean} IstInaktiv
 * @property {string} Tag - In diesem Tag können belibige interne Informationen als String gespeichert werden.
 * @property {number} Rabatt - Rabatt, der in der Salde verrechnet wurde
 * @property {string} TemplateText - TemplateText mit z.B. Platzhalter aus der Standardsalde der benötigt wird um beim ändern einer Salde den Text neu zu generieren.
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 */

/**
 * @typedef {Object} SerieInfoDTO
 * @property {string} SerieGuid
 * @property {string} Name
 * @property {string} Kuerzel
 * @property {Date} Start
 * @property {Date} Ende
 * @property {boolean} StaendigeSerie
 * @property {number} Kapazitaet
 * @property {number} KapazitaetInMin
 * @property {number} KapazitaetReserviert
 */

/**
 * @typedef {Object} BelegSerienInfoDTO
 * @property {string} BelegGuid
 * @property {Array<SerieInfoDTO>} SerienInfos
 */

/**
 * @typedef {Object} BelegStatusDTO
 * @property {string} VorgangGuid - Eindeutige GUID
 * @property {string} BelegGuid
 * @property {number} VorgangsNummer - Sichtbare Vorgangsnummer/zur Info für Kunden usw.
 * @property {number} BelegNummer
 * @property {string} AktuellerStatus - Statuscode
 * @property {Date} AenderungsDatum - Datum der letzten Änderung des Vorgangs
 * @property {string} NeuerStatus
 * @property {string} NeuerStatusText
 * @property {string} AktuellerStatusText
 */

/**
 * @typedef {Object} CalculationInfoDTO
 * @property {number} MandantId
 * @property {string} BelegPositionGuid
 * @property {Date|null} CalculationRequestTimestamp - The timestamp when the calculation was requested.
 * @property {Date|null} CalculatedForTimestamp - The timestamp indicating for which request timestamp the calculation was performed.
 */

/**
 * @typedef {Object} Kapazitaetsvorgabe
 * @property {string} GroupName
 * @property {string} Label
 * @property {Array<string>} Produktgruppe
 * @property {Array<string>} Artikelliste
 * @property {Array<string>} Bearbeitungen
 * @property {Array<string>} Etikettentext
 * @property {KapaFarbArt} FarbArt
 * @property {number} Zeitvorgabe
 * @property {number} Gewicht
 * @property {boolean} IstBasisregel
 * @property {number} Order
 */

/**
 * KapaFarbArt enum values
 * @typedef {0|1|2|3} KapaFarbArt
 * 0: Alle
 * 1: Standardfarbe
 * 2: Sonderfarbe
 * 3: Trendfarbe
 */

/**
 * @typedef {Object} KapazitaetsvorgabenDTO
 * @extends {Array<Kapazitaetsvorgabe>}
 * @property {number} Version
 */

/**
 * @typedef {Object} VorgangDTO
 * @property {string} VorgangGuid - Eindeutige GUID
 * @property {number} VorgangsNummer - Sichtbare Vorgangsnummer/zur Info für Kunden usw.
 * @property {string} KundenNummer - Kundennummer (aus Kontakt-Objekt)
 * @property {boolean} IstEndkunde - End- oder Firmenkunde (aus Kontakt-Objekt)
 * @property {string} Kommission - Standard-Kommission des Vorgangs
 * @property {string} Kommission2 - Kommission2 des Vorgangs
 * @property {Date} ErstellDatum - Erstelldatum des Vorgangs
 * @property {Date} AenderungsDatum - Letztes Änderungsdatum des Vorgangs
 * @property {Array<BelegDTO>} Belege - Liste und Daten der Belege zu diesem Vorgang
 * @property {Array<BelegPositionDTO>} Positionen - Liste und Daten der Postionen in diesem Vorgang
 * @property {Array<string>} Nachrichten
 * @property {Array<VorgangHistorieDTO>} Historie
 * @property {BenutzerDTO} Besitzer - Ersteller-/Besitzerbenutzer des Vorgangs
 * @property {KontaktDTO} Kunde - Kontakt für diese Vorgang (Dummy-Kontakt, falls noch nicht erfasst)
 * @property {string} KundeGuid
 * @property {string} AktuellerStatus
 * @property {string} FakturaKennzeichen - Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet"
 * @property {string} TextStatus
 * @property {boolean} IstTestbeleg
 * @property {string} WaehrungsSymbol
 * @property {number} WaehrungsFaktor
 * @property {boolean} IstBrutto
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 * @property {boolean} IstZustimmungErteilt
 * @property {string} InterneNotiz
 * @property {string} BemerkungFuerKunde
 * @property {string} OriginalVorgangGuid
 * @property {string} OriginalMandantGuid
 * @property {number|null} OriginalVorgangsNummer
 * @property {string} OriginalAppGuid
 * @property {boolean} InnergemeinschaftlichOhneMwSt
 * @property {string} ZielVorgangGuid
 */

/**
 * @typedef {Object} VorgangExtendedDTO
 * @property {VorgangDTO} Vorgang
 * @property {MandantDTO} Mandant
 * @property {number} MandantId
 */

/**
 * @typedef {Object} VorgangHistorieDTO
 * @property {string} VorgangHistorieGuid
 * @property {string} Text
 * @property {Date} Zeitstempel
 * @property {string} Benutzer
 */

/**
 * @typedef {Object} VorgangHistorienDTO
 * @property {Array<VorgangHistorieDTO>} VorgangHistorien
 * @property {Object<string, Array<BelegHistorieDTO>>} BelegHistorien
 * @property {Object<string, Array<BelegPositionHistorieDTO>>} BelegPositionHistorien
 */

/**
 * @typedef {Object} VorgangListItemDTO
 * @property {string} VorgangGuid - Eindeutige GUID
 * @property {number} VorgangsNummer - Sichtbare Vorgangsnummer/zur Info für Kunden usw.
 * @property {number|null} OriginalVorgangsNummer - Vorgangsnummer vom Originalbeleg
 * @property {Date} ErstellDatum - Erstelldatum des Vorgangs
 * @property {Date} AenderungsDatum - Datum der letzten Änderung
 * @property {string} AktuelleBelegArt - Art des aktuellsten Belegs
 * @property {string} Kommission - Eingegebene Kommission des Händlers
 * @property {string} Kommission2 - Eingegebene Kommission2 des Händlers
 * @property {string} VorgangsNotitz - Eingegebene Notitzen zum Vorgang vom Produzenten
 * @property {string} AktuelleBelegNummer - Aktuelle Belegnummer
 * @property {string} AktuelleRechnungsNummer - Aktuelle Rechnungsnummer
 * @property {string} AlleBelegNummern - Alle Belegnummern, getrennt mit ", "
 * @property {string} AktuelleBelegGuid - Die GUID des aktuellen Beleges.
 * @property {string} KundenNummer - Kundennummer des Kunden
 * @property {string} Kundenname - Name des Kunden für Anzeige
 * @property {string} KundeGuid - Guide des Kunden für Filter
 * @property {string} URL - Adresse des detaillierten Vorgangs-Objektes
 * @property {Object<string, PropertyValueCollection>} ApplicationSpecificProperties
 * @property {Object<string, PropertyValueCollection>} AdditionalProperties
 * @property {string} Status
 * @property {number} AnzahlNachrichten
 * @property {boolean} IsArchiv
 * @property {boolean} HatFehlerhaftenBeleg
 * @property {boolean} PreisAufAnfrage
 * @property {boolean} KundeFehlt
 * @property {string} TextStatus
 * @property {string} Besitzer - Email des Besitzer
 * @property {string} Besteller - Falls Benutzer null und 1. Beleg ist Bestellschein -> Bestellfix -> Besitzer aus OriginalVorgangGuid aus Vorgang
 * @property {string} Bearbeiter - Der Ansprechpartner vom letzten Beleg des Vorgangs
 * @property {string} ExterneReferenznummer
 * @property {string|null} ExterneMandantenGuid
 * @property {string} ExternerFirmenname
 * @property {string} RelatedGuids - Guids von "zugehörigen Objekten" (Belegen/BelegPositionen) als JSON-object. Zum Laden von Tags.
 * @property {string} MandantGuid
 * @property {boolean} IstBerechnet
 */

/**
 * @typedef {Object} VorgangNachrichtAnhangDTO
 * @property {string} VorgangNachrichtAnhangGuid
 * @property {string} FileName
 * @property {number} FileSize
 * @property {string} URL
 */

/**
 * @typedef {Object} VorgangNachrichtDTO
 * @property {string} VorgangNachrichtGuid
 * @property {string} VorgangGuid
 * @property {string} Absender
 * @property {string} Empfaenger
 * @property {string} Betreff
 * @property {string} Text
 * @property {Array<VorgangNachrichtAnhangDTO>} Anhaenge
 * @property {Date} Gesendet
 */

/**
 * @typedef {Object} VorgangStatusDTO
 * @property {string} VorgangGuid - Eindeutige GUID
 * @property {number} VorgangsNummer - Sichtbare Vorgangsnummer/zur Info für Kunden usw.
 * @property {string} AktuellerStatus - Statuscode
 * @property {Date} AenderungsDatum - Datum der letzten Änderung des Vorgangs
 * @property {string} NeuerStatus
 */

/**
 * @typedef {Object} VorgangStatusTableDTO
 * @property {string} VorgangGuid - Eindeutige GUID des Vorgangs
 * @property {string|null} KontaktGuid - Eindeutige GUID des Kontaktes im Vorgang
 * @property {boolean} KundeGeaendert - Ob der Kunde geändert wurde, auch bei Neuanlöage = true
 * @property {Date} AenderungsDatum - Datum der letzten Änderung des Vorgangs
 * @property {number} MandantId - Die ID des Mandanten wird für die Functions benötigt
 */

/**
 * @typedef {Object} VorgangTextStatusDTO
 * @property {Array<string>} VorgangGuids - Liste von eindeutigen GUIDs
 * @property {string} NeuerTextStatus - Status der in das Feld TextStatus für alle Vorgänge gesetzt werden soll.
 */

// Export all type names for use in TypeScript declaration files
module.exports = {};
