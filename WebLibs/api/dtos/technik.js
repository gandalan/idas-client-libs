/**
 * Technik DTOs - JSDoc Type Definitions
 * Converted from C# DTOs in Gandalan.IDAS.WebApi.Client/DTOs/Technik/
 */

/**
 * @typedef {Object} SchnittDTO
 * @property {string} SchnittGuid
 * @property {string} Name
 * @property {Array<OperationsPunktDTO>} OperationsPunkte
 * @property {Array<SchnittKonturDTO>} SchnittKonturZuordnungen
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} BauteilDTO
 * @property {string} BauteilGuid
 * @property {string} BauteilKategorieGuid
 * @property {string} Name
 * @property {string} Art
 * @property {boolean} IstRotationsKoerper
 * @property {string} ConstructScript
 * @property {string} UpdateScript
 * @property {string} ValidateScript
 * @property {string} EtikettenKuerzel
 * @property {boolean} IstSichtbar
 * @property {string} ArtikelNummer
 * @property {SchnittDTO} Schnitt
 * @property {string} MaterialGuid
 * @property {string} ZugehoerigerKatalogArtikelGuid
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} KomponenteDTO
 * @property {string} KomponenteGuid
 * @property {string} BauteilGuid
 * @property {string} GehoertZuKomponenteGuid
 * @property {string} KomponenteArtGuid
 * @property {string} KomponenteKategorieGuid
 * @property {string} Name
 * @property {string} AnzeigeName
 * @property {string} Bild
 * @property {boolean} Bestellbar
 * @property {boolean} IstSichtbar
 * @property {string} AenderungsInfoWeiterleitungen
 * @property {Array<string>} gehoerenZuKomponente
 * @property {string} ConstructScript
 * @property {string} UpdateScript
 * @property {string} ValidateScript
 * @property {string} ReconstructScript
 * @property {string} BearbeitungenScript
 * @property {string} FeatureErkennungScript
 * @property {string} ZugehoerigerKatalogArtikelGuid
 * @property {number} Version
 * @property {Date} ChangedDate
 * @property {Array<KomponenteVariableDTO>} Variablen
 * @property {Array<KomponenteVerknuepfungDTO>} Verknuepfungen
 */

/**
 * @typedef {Object} KomponenteVerknuepfungDTO
 * @property {string} KomponenteVerknuepfungGuid
 * @property {string} QuellKomponenteGuid
 * @property {string} ZielKomponenteGuid
 * @property {string} Name
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} OperationsPunktDTO
 * @property {string} OperationsPunktGuid
 * @property {string} Name
 * @property {number} X
 * @property {number} Y
 * @property {number} Z
 * @property {string} Kommentar
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} KonturDTO
 * @property {string} KonturGuid
 * @property {Array<KonturElementDTO>} KonturElemente
 * @property {string} Name
 * @property {number} Schluessel_1
 * @property {number} Schluessel_2
 * @property {number} Schluessel_3
 * @property {string} Schluessel_4
 * @property {string} Schluessel_5
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} KonturElementDTO
 * @property {string} KonturElementGuid
 * @property {number} AX
 * @property {number} AY
 * @property {number} AZ
 * @property {number} EX
 * @property {number} EY
 * @property {number} EZ
 * @property {number} MX
 * @property {number} MY
 * @property {number} MZ
 * @property {number} KreisRichtung
 * @property {string} MakroName
 * @property {string} MakroParameter
 * @property {string} OperationArt
 * @property {number} OperationNr
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} SchnittKonturDTO
 * @property {string} SchnittKonturGuid
 * @property {number} Reihenfolge
 * @property {boolean} Verschmelzen
 * @property {number} Vorzeichen
 * @property {string} KonturGuid
 * @property {Array<SchnittKonturOperationDTO>} Operationen
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} SchnittKonturOperationDTO
 * @property {string} SchnittKonturOperationGuid
 * @property {string} Operation
 * @property {number} P1
 * @property {number} P2
 * @property {number} P3
 * @property {number} P4
 * @property {number} P5
 * @property {number} Reihenfolge
 * @property {number} Version
 * @property {Date} ChangedDate
 */

/**
 * @typedef {Object} KomponenteVariableDTO
 * @property {string} KomponenteVariableGuid
 * @property {boolean | null} Anpassbar
 * @property {string} AnzeigeText
 * @property {number} Datentyp
 * @property {boolean} EingabeFeldAnzeigen
 * @property {string} EingabeFeldArt
 * @property {string} EingabeFeldP1
 * @property {string} EingabeFeldP2
 * @property {string} EingabeFeldP3
 * @property {string} Name
 * @property {string} WerteListe
 * @property {number} Version
 * @property {Date} ChangedDate
 */

export {};
