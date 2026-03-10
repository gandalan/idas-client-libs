/**
 * @typedef {Object} ProduktionsSettingsDTO
 * @property {ProduktionProduktfamilieSettingsDTO[]} ProduktionProduktfamilieSettingList
 * @property {boolean} SprossenfreiEnabled - Aktiviert Sprossenfrei global. Die Produktionsberechnung prüft sowohl SprossenfreiEnabled als auch die Aktivierung in der jeweiligen Produktfamilie. Wenn gesetzt, ist außerdem die Bearbeitung der Familien-Settings erlaubt.
 * @property {boolean} VorbiegenEnabled - Aktiviert Vorbiegen global. Die Produktionsberechnung prüft sowohl VorbiegenEnabled als auch die Aktivierung in der jeweiligen Produktfamilie. Wenn gesetzt, ist außerdem die Bearbeitung der Familien-Settings erlaubt.
 * @property {string} VorbiegenSprossenfrei
 * @property {string} IstAusserhalbGewaehrleistung
 * @property {string} VorbiegenGrenzwert
 * @property {string[]} SonderGewebe
 * @property {boolean} SaegedatenAufEtiketten
 * @property {boolean} PacklistenEtikettenZusammengefasst
 * @property {string} EtikettSerienkennzeichen
 * @property {string} PackEtikettSerienkennzeichen
 * @property {boolean} PrintPCode
 * @property {boolean} PrintPCodeASQRCode
 * @property {boolean} Schutzplattenmontage
 * @property {boolean} WeisserKeder
 * @property {boolean} SortierungMitPositionsbezug
 * @property {boolean} HaendlerNameAufEtikett
 * @property {boolean} HaendlerKommAufEtikett
 * @property {boolean} VorgangKommAufEtikett
 * @property {boolean} PositionKommAufEtikett
 * @property {boolean} EinbauOrtAufEtikett
 * @property {boolean} SettingsFuerHaendler
 * @property {boolean} SaegemaßeOhneKorrektur
 * @property {boolean} EtikettenZugehoerigkeit
 * @property {boolean} Saegeliste4590Zusammenfassen
 * @property {string} ChangedDate - ISO 8601 date string
 * @property {boolean} EtikettNewStyleSonderkennzeichen
 * @property {boolean} Buegelgriffe_10_22
 * @property {boolean} RO4_Buerste
 * @property {boolean} Montagelehre_ST_164802
 * @property {boolean} Kunststoffbohrlehre_ST_164851
 * @property {boolean} Inbussschluessel_lang_ST_170625_25
 * @property {boolean} Schraubeckwinkel_1601
 * @property {boolean} LI1_Sickenstanze_auf_Etikett
 * @property {boolean} Griffmulde_ST3_134850
 * @property {boolean} AnbauteileP2_G6
 * @property {boolean} SP_Z_Mass_inkl_Buerstendichtung
 * @property {boolean} SP5_Sprosse_ausklinken
 * @property {boolean} ST3_BeidseitigeGriffleiste_GL_B
 * @property {boolean} Gewebeeinzugsarm_122415
 * @property {boolean} RO4_143908
 * @property {boolean} PacklisteZusammengefasst
 * @property {string} FarbersetzungsTabelleModel
 * @property {boolean} Drehbandmontage
 * @property {number} STmitLSo_LSu_Mbv_Mass
 * @property {boolean} SP_WL_mit_Schraube_150329
 * @property {boolean} LI_TE_Winkelprofil_mit_Schraube_150329_06
 * @property {string} ProdukteMitc3Berechnen
 * @property {boolean} DF4_DT4_133604
 * @property {boolean} PT2_Griff_Innen_Knopf
 * @property {boolean} ZR_Schraubeckwinkel
 * @property {boolean} ZR_Verstanzen
 * @property {number|null} ZR_Verstanzen_Mass
 * @property {boolean} ZR_Eckwinkel
 * @property {boolean} Magnetposition_DT3_DT6
 */

/**
 * @typedef {Object} ProduktionProduktfamilieSettingsDTO
 * @property {string} GroupName
 * @property {string} ProduktfamilienName
 * @property {boolean} SprossenFrei
 * @property {boolean} Vorbiegen
 * @property {string[]} MoeglicheVariantenVorbiegen
 * @property {string} Buerste
 * @property {boolean} FederkraftErhoeht
 * @property {boolean} IndividuelleSeitenarretierung
 * @property {number|null} HoeheFuerSeitenarretierung
 */

/**
 * @typedef {Object} SLKServerSettingsDTO
 * @property {boolean} SLKNichtAktiv
 */

/**
 * @typedef {Object} ArtosStartSettingsDTO
 * @property {MaterialBedarfLogik} MaterialBedarfLogik
 * @property {UserAuthTokenDTO} UserAuthToken
 * @property {string} Environment
 */

/**
 * MaterialBedarfLogik enum values
 * @typedef {('Serienbezogen'|'Stichtagbezogen')} MaterialBedarfLogik
 */

/**
 * @typedef {Object} UserAuthTokenDTO
 * @property {string} AppToken - UUID string
 * @property {string} Expires - ISO 8601 date string
 * @property {string} Token - UUID string
 * @property {BenutzerDTO} Benutzer
 * @property {string} MandantGuid - UUID string
 * @property {MandantDTO} Mandant
 */

/**
 * @typedef {Object} BenutzerDTO
 */

/**
 * @typedef {Object} MandantDTO
 */

/**
 * @typedef {Object} PreisermittlungsEinstellungenDTO
 * @property {string} WaehrungsSymbol
 * @property {number} WaehrungsFaktor
 * @property {number} SteuerSatz
 * @property {string} EndpreisRundungsModus
 * @property {string} SonderfarbZuschlaege
 * @property {boolean} BruttoPreisErmitteln
 * @property {Object.<string, AufpreisAnpassungDTO[]>} AufpreisAnpassungen - Dictionary with UUID keys
 * @property {Object.<string, number>} PreisfaktorAnpassungen - Dictionary with UUID keys
 * @property {Object.<string, number>} ZuschnittpreisfaktorAnpassungen - Dictionary with UUID keys
 * @property {Object.<string, number>} AufpreisfaktorAnpassungen - Dictionary with UUID keys
 * @property {Object.<string, boolean>} GrenzfreigabeAnpassungen - Dictionary with UUID keys
 * @property {number} MbAufpreis
 * @property {number|null} Mb_v_Fix_Aufpreis
 * @property {number|null} Mb_Klebeband_Aufpreis
 * @property {string} ChangedDate - ISO 8601 date string
 */

/**
 * @typedef {Object} AufpreisAnpassungDTO
 * @property {string} Bezeichnung
 * @property {string} FeldName
 * @property {string} FeldWert
 * @property {number} Aufpreis
 */

/**
 * @typedef {Object} MaterialbedarfExportSettingsDTO
 * @property {MaterialbedarfExportType} NeherArtikelStandardFarbe
 * @property {MaterialbedarfExportType} NeherArtikelTrendFarbe
 * @property {MaterialbedarfExportType} NeherArtikelSonderFarbe
 * @property {MaterialbedarfExportType} UeberschriebenerArtikelStandardFarbe
 * @property {MaterialbedarfExportType} UeberschriebenerArtikelTrendFarbe
 * @property {MaterialbedarfExportType} UeberschriebenerArtikelSonderFarbe
 * @property {MaterialbedarfExportType} EigenArtikelStandardFarbe
 * @property {MaterialbedarfExportType} EigenArtikelTrendFarbe
 * @property {MaterialbedarfExportType} EigenArtikelSonderFarbe
 * @property {CsvExportCombinationDTO[]} CsvExportCombinations
 * @property {boolean} WriteLieferzusageOnCsvExport
 */

/**
 * MaterialbedarfExportType enum values
 * @typedef {('CSV'|'Schnittstelle')} MaterialbedarfExportType
 */

/**
 * @typedef {Object} MaterialbedarfExportUserSettings
 * @property {string} CsvExportPath
 */

/**
 * Defines the combination of ArtikelArten + FarbArten which will be exported together in a CSV file.
 * @typedef {Object} CsvExportCombinationDTO
 * @property {ExportArtikelArt[]} ExportArtikelArten
 * @property {ExportFarbArt[]} ExportFarbArten
 */

/**
 * ExportArtikelArt enum values
 * @typedef {('Neher'|'Ueberschriebene'|'Eigene')} ExportArtikelArt
 */

/**
 * ExportFarbArt enum values
 * @typedef {('Standardfarbe'|'Trendfarbe'|'Sonderfarbe')} ExportFarbArt
 */

export {};