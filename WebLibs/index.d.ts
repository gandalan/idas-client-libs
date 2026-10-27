export * from "./index.js";
export const AUTH_REFRESHED_EVENT: "idas-auth-refreshed";
export const AUTH_EXPIRED_EVENT: "idas-auth-expired";
export function createApi(): FluentApi;
export function fluentApi(url: string, authManager: FluentAuthManager | null, serviceName: string): FluentApi;
export function createIDASApi(): IDASFluentApi;
export function idasFluentApi(url: string, authManager: FluentAuthManager, serviceName: string): IDASFluentApi;
export function createAuthManager(): FluentAuthManager;
export function fluentIdasAuthManager(appToken: string, authBaseUrl: string): FluentAuthManager;
export function fetchEnvConfig(envConfig?: string): Promise<EnvironmentConfig>;
export function restClient(): FluentRESTClient;
export class AuthError extends Error { code: string; sessionEnded: boolean; status: number | undefined; constructor(code: string, sessionEnded: boolean, message?: string, status?: number, cause?: unknown); }
export class RestError extends Error { method: string; url: string; status: number; statusText: string; body: string | null; detail: string | null; constructor(method: string, url: string, res: Response, body?: string | null); static fromResponse(method: string, url: string, res: Response): Promise<RestError>; static extractDetail(body: string | null, contentType: string | null): string | null; }

export type AblageApi = {
    /** Get storage by GUID */
    get: (guid: string) => Promise<AblageDTO>;
    /** Get all storage locations */
    getAll: (changedSince?: Date, includeDetails?: boolean) => Promise<AblageDTO[]>;
    /** Save storage */
    save: (dto: AblageDTO) => Promise<void>;
    /** Delete storage */
    delete: (guid: string) => Promise<void>;
    /** Distribute serie to bins */
    serienFachverteilung: (serieGuid: string) => Promise<FachzuordnungResultDTO>;
    /** Distribute AV positions to bins */
    fachverteilung: (avGuids: string[]) => Promise<FachzuordnungResultDTO>;
    fach: { get: (guid: string) => Promise<AblageFachDTO>; getAll: (changedSince?: Date, includeDetails?: boolean) => Promise<AblageFachDTO[]>; save: (dto: AblageFachDTO) => Promise<void>; delete: (guid: string) => Promise<void> };
};

/** DTO für die IBOS3 Ablageverwaltung */
export type AblageDTO = {
    AblageGuid: string;
    ChangedDate: Date;
    AblageFaecher: Array<AblageFachDTO>;
    Standort: string;
    Bezeichnung: string;
    Kuerzel: string;
};

/** DTO für die IBOS3 Ablageverwaltung */
export type AblageFachDTO = {
    AblageFachGuid: string;
    /** Fach ist belegt wenn BelegPositionAVGuid nicht leer ist */
    Belegt: boolean;
    FachNr: number;
    /** GUIDs der ProduktGruppenDTOs, die im Ablagefach abgelegt werden können */
    ProduktGruppenGuids: Array<string>;
    /** GUIDs der aktuell im Ablagefach abgelegten MaterialbedarfDTOs */
    MaterialBedarfGuids: Array<string>;
    /** Guid der BelegPositionAV - Ist diese Guid schon gesetzt, aber noch kein Material zugeordnet, dann ist das Fach für die Position reserviert */
    BelegPositionAVGuid: string;
};

export type AddRechnungSammelrechnungDTO = {
    BelegGuid: string;
    SammelrechnungGuid: string;
};

export type AdresseDruckDTO = {
    Anrede: string;
    Nachname: string;
    Vorname: string;
    Firmenname: string;
    Zusatz: string;
    AdressZusatz1: string;
    Strasse: string;
    Hausnummer: string;
    Postleitzahl: string;
    Ort: string;
    Ortsteil: string;
    Land: string;
    IstInland: boolean;
};

export type AdresseDTO = {
    AdressGuid: string;
    /** Akad. Titel/Adelstitel */
    Titel: string;
    /** Namensanrede, z.B. "Herr"/"Frau"/"Firma" */
    Anrede: string;
    /** Für natürliche Personen: Nachname */
    Nachname: string;
    /** Für natürliche Personen: Vorname(n) */
    Vorname: string;
    /** Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH & Co. KG" */
    Firmenname: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz1: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz2: string;
    /** Postalische Straße */
    Strasse: string;
    /** Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)" */
    Hausnummer: string;
    /** Postfach (ersetzt Straße/Hausnummer in der Ausgabe) */
    Postfach: string;
    /** Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse */
    Postleitzahl: string;
    /** Postalische Ortsangabe */
    Ort: string;
    /** Nicht-postalische Angabe zum Ortsteil */
    Ortsteil: string;
    /** Land als Textkürzel */
    Land: string;
    /** Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist */
    IstInland: boolean;
    /** E-Mail-Adresse */
    Mailadresse: string;
    /** Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049]) */
    Landesvorwahl: string;
    /** Ortskennzahl mit führender "0" in Deutschland */
    Vorwahl: string;
    /** Anschlussrufnummer */
    Telefonnummer: string;
    /** Durchwahlzusatz */
    Durchwahl: string;
    /** Internet-/Web-URL mit Protokoll-Präfix (https://...) */
    Webadresse: string;
    /** Ursprunglicher interner Verwendungszweck für diesen Adressdatensatz (nur für Adresse aus IBOS, z.B. "Rechnung", "AB"...) */
    Verwendungszweck: string;
    /** Intern */
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type AnpassungApi = {
    /** Get all adjustments */
    getAll: () => Promise<AnpassungDTO[]>;
    /** Save adjustment */
    save: (dto: AnpassungDTO) => Promise<void>;
    /** Delete adjustment */
    delete: (anpassungGuid: string) => Promise<void>;
    /** Run adjustment web job */
    runWebJob: () => Promise<void>;
    vorlage: { getAll: () => Promise<AnpassungVorlageDTO[]>; get: (guid: string) => Promise<AnpassungVorlageDTO>; save: (dto: AnpassungVorlageDTO) => Promise<void>; delete: (guid: string) => Promise<void> };
};

export type AnpassungDTO = {
    AnpassungGuid: string;
    Art: string;
    GiltFuerBesitzer: boolean;
    GiltFuerAlleUntermandanten: boolean;
    GiltFuerZielMandant: boolean;
    ZielMandantGuid: string;
    Content: string;
    WarengruppeGuid: string;
    ArtikelGuid: string;
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type AnpassungVorlageDTO = {
    AnpassungVorlageGuid: string;
    Art: string;
    Name: string;
    Beschreibung: string;
    Content: string;
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type ApiVersionDTO = {
    /** API-Version */
    Version: string;
    /** Umgebung */
    Environment: string;
    /** Build-Zeitpunkt */
    BuildTime: string;
    /** Veröffentlichungszeitpunkt (veraltet, verwende BuildTime) */
    ReleaseTime: string;
};

export type AppActivationStatusDTO = {
    KundeGuid: string;
    KundenMandantGuid: string;
    KundenMandantIstAktiv: boolean;
};

export type ArtikelApi = {
    /** Get all articles */
    getAll: (changedSince?: Date) => Promise<WarenGruppeDTO[]>;
    /** Save article */
    saveArtikel: (artikel: KatalogArtikelDTO) => Promise<KatalogArtikelDTO>;
    /** Delete article */
    deleteArtikel: (artikel: KatalogArtikelDTO) => Promise<void>;
    /** Get all article individual data */
    getAllIndiDaten: (changedSince?: Date) => Promise<KatalogArtikelIndiDatenDTO[]>;
    /** Save article individual data */
    saveArtikelIndiDaten: (daten: KatalogArtikelIndiDatenDTO) => Promise<void>;
    /** Delete article individual data */
    deleteArtikelIndiDaten: (daten: KatalogArtikelIndiDatenDTO) => Promise<void>;
    /** Get all commodity groups */
    getAllWarenGruppen: (changedSince?: Date, includeArtikel?: boolean) => Promise<WarenGruppeDTO[]>;
    /** Get compact commodity group list (with ArtikelGuids, without full article graph) */
    getWarenGruppenList: (changedSince?: Date) => Promise<WarenGruppeListDTO[]>;
    /** Save commodity group */
    saveWarenGruppe: (dto: WarenGruppeDTO) => Promise<void>;
    /** Get commodity group by GUID */
    getWarenGruppe: (warenGruppeGuid: string, includeArtikel?: boolean) => Promise<WarenGruppeDTO>;
    /** Get articles for a commodity group */
    getArtikelForWarengruppe: (warenGruppeGuid: string) => Promise<KatalogArtikelDTO[]>;
    /** Get all product groups */
    getAllProduktGruppen: (includeFamilien?: boolean) => Promise<ProduktGruppeDTO[]>;
    /** Save product group */
    saveProduktGruppe: (produktGruppe: ProduktGruppeDTO) => Promise<ProduktGruppeDTO>;
    /** Get all product families */
    getAllProduktFamilien: (includeVarianten?: boolean) => Promise<ProduktFamilieDTO[]>;
    /** Save product family */
    saveProduktFamilie: (produktFamilie: ProduktFamilieDTO) => Promise<ProduktFamilieDTO>;
    /** Get all components */
    getAllKomponenten: () => Promise<KomponenteDTO[]>;
    /** Save component */
    saveKomponente: (dto: KomponenteDTO) => Promise<void>;
    /** Get all variants */
    getAllVarianten: () => Promise<VarianteDTO[]>;
    /** Get all variant GUIDs */
    getAllVariantenGuids: () => Promise<string[]>;
    /** Get all variant changes since date */
    getAllVariantenChanges: (changedSince?: Date) => Promise<string[]>;
    /** Get variant by GUID */
    getVariante: (varianteGuid: string, includeUIDefs?: boolean, includeKonfigs?: boolean) => Promise<VarianteDTO>;
    /** Save variant */
    saveVariante: (variante: VarianteDTO) => Promise<VarianteDTO>;
    /** Trigger variant cache web job */
    cacheWebJob: () => Promise<void>;
    /** Get all contours */
    getAllKonturen: () => Promise<KonturDTO[]>;
    /** Save contour */
    saveKontur: (dto: KonturDTO) => Promise<void>;
    /** Get all cuts */
    getAllSchnitte: () => Promise<SchnittDTO[]>;
    /** Save cut */
    saveSchnitt: (dto: SchnittDTO) => Promise<void>;
    /** Calculate special colors for beleg */
    berechneSonderfarben: (belegGuid: string) => Promise<BelegDTO>;
    /** Get user variants */
    getBenutzerVarianten: (benutzerGuid: string, mitSperrliste: boolean) => Promise<VarianteDTO[]>;
    /** Reset variant list cache */
    resetCacheVariantenListen: () => Promise<void>;
};

export type ArtosStartSettingsDTO = {
    MaterialBedarfLogik: MaterialBedarfLogik;
    UserAuthToken: UserAuthTokenDTO;
    Environment: string;
};

export type AufpreisAnpassungDTO = {
    Bezeichnung: string;
    FeldName: string;
    FeldWert: string;
    Aufpreis: number;
};

export type AuthApi = {
    /** Authenticate */
    authenticate: (dto: LoginDTO) => Promise<string>;
    /** Authenticate for function */
    authenticateForFunction: (email: string) => Promise<string>;
    /** Refresh token */
    refreshToken: (token: string) => Promise<string>;
    /** Create service token */
    createServiceToken: (dto?: CreateServiceTokenRequestDTO) => Promise<string>;
    /** Remove expired tokens */
    removeExpiredTokens: () => Promise<void>;
    /** Get external app auth token */
    getFremdAppAuthToken: (fremdApp: string) => Promise<UserAuthTokenDTO>;
};

export type AuthExpiredEventDetail = {
    /** Why the session ended, "refresh-rejected", "no-refresh-token" or "identity-changed". */
    reason: string;
};

export type AuthRefreshedEventDetail = {
    /** Expiry of the new JWT (`exp` claim) in milliseconds since epoch. */
    expiresAt: number;
};

export type AvApi = {
    /** Get all AV positions */
    getAll: (includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    /** Get all AV positions changed since date */
    getAllChangedSince: (changedSince: Date, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    /** Get AV positions by serie */
    getBySerie: (serieGuid: string, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    /** Get AV positions by vorgang */
    getByVorgang: (vorgangGuid: string, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    /** Get AV positions by multiple vorgang GUIDs */
    getByVorgangGuids: (vorgangGuids: string[], includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    /** Get AV positions by beleg position GUID */
    getByBelegPosition: (belegpositionGuid: string) => Promise<BelegPositionAVDTO[]>;
    /** Get single AV position by GUID */
    getById: (avGuid: string) => Promise<BelegPositionAVDTO>;
    /** Get AV positions by PCode */
    getByPCode: (pcode: string, includeOriginalBeleg?: boolean, includeProdDaten?: boolean, includeI3Etiketten?: boolean) => Promise<BelegPositionAVDTO[]>;
    /** Save AV position */
    save: (position: BelegPositionAVDTO) => Promise<void>;
    /** Save multiple AV positions */
    saveList: (positionen: BelegPositionAVDTO[]) => Promise<BelegPositionAVDTO[]>;
    /** Save AV positions to serie */
    saveToSerie: (serieGuid: string, positionGuids: string[]) => Promise<BelegPositionAVDTO[]>;
    /** Calculate AV positions */
    berechnen: (guids: string[]) => Promise<void>;
    /** Delete AV position */
    delete: (guid: string) => Promise<void>;
    /** Delete multiple AV positions */
    deleteList: (guids: string[]) => Promise<void>;
    /** Assign positions to series */
    serienZuordnen: (belegGuid: string, positionSerieItems: PositionSerieItemDTO[]) => Promise<void>;
    /** Pre-process calculation */
    preProcess: (dto: BerechnungParameterDTO) => Promise<BerechnungParameterDTO>;
    /** Post-process calculation */
    postProcess: (dto: BelegPositionAVDTO) => Promise<ProduktionsDatenDTO>;
    reserviert: { getAll: () => Promise<AVReserviertItemDTO[]>; getBySerie: (serieGuid: string) => Promise<AVReserviertItemDTO[]> };
    /** Run AV calculation for position */
    runAvBerechnung: (id: string, mandantId: number) => Promise<void>;
    /** Calculate items */
    calculateItems: () => Promise<void>;
    /** Get calculate item list */
    getCalculateItemList: () => Promise<MandantAndBelegPosGuidDTO[]>;
    /** Check AV position count */
    checkAvPositionCount: (belegPosGuid: string, mandantId: number) => Promise<string[]>;
    /** Process AV calculation in cloud */
    avBerechnungCloudProcess: (parameter: BerechnungParameterDTO) => Promise<BerechnungParameterDTO>;
    /** Calculate AV position */
    calculateAvPosition: (mandantId: number, avPosGuid: string) => Promise<void>;
    /** Put calculation info */
    putCalculationInfo: (calculationInfoDTO: CalculationInfoDTO) => Promise<CalculationInfoDTO>;
    /** Get calculation info */
    getCalculationInfo: (mandantId: number, belegPosGuid: string) => Promise<CalculationInfoDTO>;
    /** Get incomplete calculation infos */
    getIncompleteCalculationInfos: () => Promise<CalculationInfoDTO[]>;
    /** Get in-calculation count */
    getInCalculationCount: () => Promise<number>;
    /** Calculate capacity for function */
    calculateKapazitaetForFunction: (positionGuid: string, mandantID: number) => Promise<void>;
    /** Calculate capacity for AV */
    calculateKapazitaetForAv: (avPositionGuids: string[], mandantID: number) => Promise<void>;
    /** Calculate capacity items */
    calculateKapazitaetItems: () => Promise<void>;
    /** Get AV report vorgaenge */
    getAvReportVorgaenge: (request: AvReportVorgangRequestDto) => Promise<AvReportVorgangDto[]>;
    /** Get saw data history */
    getSaegeDatenHistorie: (saegeDatenHistorieGuid: string, includeSaegeDatei?: boolean, includeMeldungen?: boolean) => Promise<SaegeDatenHistorieDTO>;
    /** Get saw data history for serie */
    getSaegeDatenHistorieForSerie: (serieGuid: string, includeSaegeDatei?: boolean, includeMeldungen?: boolean) => Promise<SaegeDatenHistorieDTO[]>;
    /** Get saw data history since date */
    getSaegeDatenHistorieSince: (sinceWhen: Date, includeSaegeDatei?: boolean, includeMeldungen?: boolean) => Promise<SaegeDatenHistorieDTO[]>;
    /** Save saw data history */
    saveSaegeDatenHistorie: (dto: SaegeDatenHistorieDTO) => Promise<SaegeDatenResultDTO>;
    /** Save saw data history bulk */
    saveSaegeDatenHistorieBulk: (dtos: SaegeDatenHistorieDTO[]) => Promise<void>;
    /** Get all material processing methods */
    getAllMaterialBearbeitungsMethoden: () => Promise<MaterialBearbeitungsMethodeDTO[]>;
    /** Save material processing method */
    saveMaterialBearbeitungsMethode: (dto: MaterialBearbeitungsMethodeDTO) => Promise<void>;
    material: { serieBerechnen: (serieGuid: string) => Promise<void>; getForSerie: (serieGuid: string) => Promise<MaterialbedarfDTO[]>; getOffenerBedarfV2: (serieGuid: string, filterCsvExportedMaterial?: boolean) => Promise<MaterialbedarfDTO[]>; getOffenerBedarf: (serieGuid: string) => Promise<MaterialbedarfDTO[]>; resetForSerie: (serieGuid: string) => Promise<void>; berechnenForFunction: (serieGuid: string, mandantId: number) => Promise<string[]>; resetFromAvPosForFunction: (avPosGuid: string, mandantId: number) => Promise<string[]>; addOrUpdate: (dto: MaterialbedarfDTO) => Promise<SerienMaterialEditDTO>; delete: (materialbedarfGuid: string) => Promise<void> };
};

/** Minimalistic DTO for Beleg in AV reports. */
export type AvReportBelegDto = {
    BelegGuid: string;
    BelegAdresse: BeleganschriftDTO;
    VersandAdresse: BeleganschriftDTO;
    VersandAdresseGleichBelegAdresse: boolean;
    BelegArt: string;
    Terminwunsch: string;
    IstSelbstabholer: boolean;
};

/** Minimalistic DTO for Kontakt information in AvReportVorgangDto. */
export type AvReportKontaktDto = {
    KundenNummer: string;
    Land: string;
};

/** Minimalistic DTO for Vorgang in AV reports. */
export type AvReportVorgangDto = {
    VorgangGuid: string;
    VorgangsNummer: number;
    Kommission: string;
    Kommission2: string;
    Belege: Array<AvReportBelegDto>;
    Kunde: AvReportKontaktDto;
};

export type AvReportVorgangRequestDto = {
    VorgangGuids: Array<string>;
};

export type AVReserviertItemDTO = {
    Variante: string;
    ArtikelNummer: string;
    Menge: number;
    Kommission: string;
    Kunde: string;
    VorgangsNummer: number;
    VorgangGuid: string;
    BelegNummer: number;
};

export type BaseListItemDTO = {
    /** Eindeutige GUID des Vorgangs */
    VorgangGuid: string;
    /** Eindeutige GUID des Bestellscheins */
    BelegGuid: string;
    /** Sichtbare Vorgangsnummer/zur Info für Kunden usw. */
    VorgangsNummer: number;
    BelegNummer: number;
    BelegJahr: number;
    /** Erstelldatum des Vorgangs */
    ErstellDatum: Date;
    /** Datum der letzten Änderung */
    AenderungsDatum: Date;
    /** Name des Kunden für Anzeige */
    Kundenname: string;
    /** Adresse des detaillierten Beleg-Objektes (gSQL) */
    URL: string;
    Status: string;
    AnzahlNachrichten: number;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type BauteilDTO = {
    BauteilGuid: string;
    BauteilKategorieGuid: string;
    Name: string;
    Art: string;
    IstRotationsKoerper: boolean;
    ConstructScript: string;
    UpdateScript: string;
    ValidateScript: string;
    EtikettenKuerzel: string;
    IstSichtbar: boolean;
    ArtikelNummer: string;
    Schnitt: SchnittDTO;
    MaterialGuid: string;
    ZugehoerigerKatalogArtikelGuid: string;
    Version: number;
    ChangedDate: Date;
};

export type BearbeitungDTO = {
    BearbeitungGuid: string;
    /** Eindeutiges Kennzeichen der Bearbeitung (aus GUID) */
    Kennzeichen: string;
    /** Ziel der Bearbeitung */
    ZielKennzeichen: string;
    /** Artikelbezeichnung */
    BearbeitungsName: string;
    /** Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Laufmeter!) */
    X: number;
    /** Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Stückzahl!) */
    Y: number;
    ProfilName: string;
    ProfilLaenge: number;
    ProfilBreite: number;
    KatalogNummer: string;
    StammdatenDateiFuerBearbeitung: string;
    Spannsituation: string;
    SpannSituationAlternativ: string;
    StartXRegel: string;
    FraesBild: string;
    TextHP: string;
    TextNP: string;
    LLBreite: number;
    LLBreiteAmBildschirm: number;
    LLHoehe: number;
    DurchmesserBohrung: number;
    LochAbstand: number;
    LochAbstandAmBildschirm: number;
    Winkel: number;
    ManuellGeloescht: boolean;
    Passiv: boolean;
    NichtFreigegeben: boolean;
    MassXEditierbar: boolean;
    GroesseEditierbar: boolean;
};

export type BearbeitungsKuerzelDTO = {
    BearbeitungsKuerzel: string;
    Beschreibung: string;
    VerfuegbarFuer: string[];
    FarbCode: string;
    RegularExpression: string;
};

export type BeleganschriftDTO = {
    AdressGuid: string;
    /** Art der Adresse - "Anschrift", "Email", "Telefon" (nur relevant bei Adressen aus IBOS) */
    Art: string;
    /** Akad. Titel/Adelstitel */
    Titel: string;
    /** Namensanrede, z.B. "Herr"/"Frau"/"Firma" */
    Anrede: string;
    /** Für natürliche Personen: Nachname */
    Nachname: string;
    /** Für natürliche Personen: Vorname(n) */
    Vorname: string;
    /** Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH & Co. KG" */
    Firmenname: string;
    /** Zusätzliche Information zur Firma */
    Zusatz: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz1: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz2: string;
    /** Postalische Straße */
    Strasse: string;
    /** Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)" */
    Hausnummer: string;
    /** Postfach (ersetzt Straße/Hausnummer in der Ausgabe) */
    Postfach: string;
    /** Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse */
    Postleitzahl: string;
    /** Postalische Ortsangabe */
    Ort: string;
    /** Nicht-postalische Angabe zum Ortsteil */
    Ortsteil: string;
    /** Land als Textkürzel */
    Land: string;
    /** Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist */
    IstInland: boolean;
    /** E-Mail-Adresse */
    Mailadresse: string;
    /** Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049]) */
    Landesvorwahl: string;
    /** Ortskennzahl mit führender "0" in Deutschland */
    Vorwahl: string;
    /** Anschlussrufnummer */
    Telefonnummer: string;
    /** Durchwahlzusatz */
    Durchwahl: string;
    /** Internet-/Web-URL mit Protokoll-Präfix (https://...) */
    Webadresse: string;
    /** Ursprunglicher interner Verwendungszweck für diesen Adressdatensatz (nur für Adresse aus IBOS, z.B. "Rechnung", "AB"...) */
    Verwendungszweck: string;
    /** Priorisierung der Adresse */
    Prioritaet: number;
    /** Intern */
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    /** Intern */
    AdditionalProperties: Record<string, PropertyValueCollection>;
    /** Erzeugt einen Text aus den Namensfeldern für die Anzeige in Überschriften, Anschriftenfeldern usw. */
    AnzeigeName: string;
};

export type BelegApi = {
    /** Get beleg status */
    getBelegStatus: (belegGuid: string) => Promise<BelegStatusDTO>;
    /** Set beleg status */
    setBelegStatus: (belegGuid: string, statusCode: string, statusText?: string) => Promise<BelegStatusDTO>;
    /** Copy beleg with new beleg art */
    belegKopieren: (belegGuid: string, neueBelegArt: string, saldenKopieren?: boolean) => Promise<VorgangDTO>;
    /** Get beleg list */
    belegListe: (jahr: number, belegart: string, kundennummer: string, includeArtikel?: boolean) => Promise<VorgangListItemDTO[]>;
    /** Change beleg art for position */
    belegWechsel: (dto: BelegartWechselDTO) => Promise<VorgangDTO>;
    /** Delete beleg */
    belegLoeschen: (belegGuid: string) => Promise<VorgangDTO>;
    /** Load vorgang list by year */
    ladeVorgangsListeByJahr: (jahr: number, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<VorgangListItemDTO[]>;
    /** Load vorgang list by status and year */
    ladeVorgangsListeByStatus: (status: string, jahr: number, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<VorgangListItemDTO[]>;
    /** Load vorgang list by status, year, and change date */
    ladeVorgangsListeByStatusAndDate: (status: string, jahr: number, changedSince: Date, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<VorgangListItemDTO[]>;
    /** Load vorgang list with full filters */
    ladeVorgangsListe: (jahr: number, status: string, changedSince: Date, art?: string, includeArchive?: boolean, includeOthersData?: boolean, search?: string, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<VorgangListItemDTO[]>;
    /** Load vorgang list by customer */
    ladeVorgangsListeByKunde: (kundeGuid: string) => Promise<VorgangListItemDTO[]>;
    /** Update vorgang status table for function */
    updateVorgangStatusTableForFunction: (dto: VorgangStatusTableDTO) => Promise<void>;
    /** Get not calculated vorgang status table for function */
    getNotCalculatedVorgangStatusTableForFunction: () => Promise<VorgangStatusTableDTO[]>;
    /** Reactivate vorgang */
    vorgangReaktivieren: (dto: BelegartWechselDTO) => Promise<VorgangDTO>;
    /** Load delivery note list by year */
    ladeLieferscheinListeByJahr: (jahr: number) => Promise<BaseListItemDTO[]>;
    /** Load delivery note list by status and year */
    ladeLieferscheinListeByStatus: (status: string, jahr: number) => Promise<BaseListItemDTO[]>;
    /** Load delivery note list by status, year, and change date */
    ladeLieferscheinListeByStatusAndDate: (status: string, jahr: number, changedSince: Date) => Promise<BaseListItemDTO[]>;
    /** Load delivery note list with full filters */
    ladeLieferscheinListe: (jahr: number, status: string, changedSince: Date, art?: string, includeArchive?: boolean, includeOthersData?: boolean, search?: string) => Promise<BaseListItemDTO[]>;
    /** Get vorgang by delivery note GUID */
    getVorgangByLieferscheinGuid: (lieferscheinGuid: string) => Promise<VorgangDTO>;
    /** Get vorgang status */
    getLieferscheinStatus: (vorgangGuid: string) => Promise<VorgangStatusDTO>;
    /** Set vorgang status */
    setLieferscheinStatus: (vorgangGuid: string, statusCode: string) => Promise<VorgangStatusDTO>;
    /** Get vorgang history */
    getVorgangHistorie: (vorgangGuid: string, includeBelege?: boolean, includePositionen?: boolean) => Promise<VorgangHistorienDTO>;
    /** Get beleg history */
    getBelegHistorie: (belegGuid: string, includePositionen?: boolean) => Promise<BelegHistorienDTO>;
    /** Get beleg position history */
    getBelegPositionHistorie: (positionGuid: string) => Promise<BelegPositionHistorienDTO>;
    /** Get serie history since date */
    getSerieHistorieSince: (sinceWhen: Date) => Promise<SerieHistorieDTO[]>;
    /** Get serie history by GUID */
    getSerieHistorie: (serieGuid: string) => Promise<SerieHistorieDTO[]>;
    /** Add vorgang history */
    addVorgangHistorie: (vorgangGuid: string, historyDto: VorgangHistorieDTO) => Promise<void>;
    /** Add beleg history */
    addBelegHistorie: (belegGuid: string, historyDto: BelegHistorieDTO) => Promise<void>;
    /** Add beleg position history */
    addBelegPositionHistorie: (positionGuid: string, historyDto: BelegPositionHistorieDTO) => Promise<void>;
    /** Add serie history */
    addSerieHistorie: (historyDto: SerieHistorieDTO) => Promise<void>;
    /** Add vorgang history from function */
    addVorgangHistorieFromFunction: (vorgangGuid: string, historyDto: VorgangHistorieDTO, mandantID: number) => Promise<void>;
    /** Add beleg position history from function */
    addBelegPositionHistorieFromFunction: (positionGuid: string, historyDto: BelegPositionHistorieDTO, mandantID: number) => Promise<void>;
    /** Add serie history from function */
    addSerieHistorieFromFunction: (historyDto: SerieHistorieDTO, mandantID: number) => Promise<void>;
    /** Get last editor for beleg */
    getLetzterBearbeiter: (belegGuid: string) => Promise<string>;
    /** Get last editors for belege */
    getLetzteBearbeiter: (belegGuids: string[]) => Promise<Record<string, string>>;
    /** Storniere position */
    positionStornieren: (positionGuid: string) => Promise<void>;
    /** Storniere beleg */
    belegStornieren: (belegGuid: string) => Promise<void>;
    /** Order external production */
    fremdfertigungBestellen: (belegGuid: string) => Promise<void>;
};

/** BelegArt enum values */
export type BelegArt = 0|1|2|3|4|5|6|7|8|9|10|11|12|13;

export type BelegartWechselDTO = {
    BelegGuid: string;
    BelegPositionGuids: Array<string>;
    NeueBelegArt: BelegArt;
    SaldenKopieren: boolean;
    RechnungsNummer: RechnungsNummer;
    UpdateErfassungsdatum: boolean;
};

export type BelegDruckDTO = {
    BelegGuid: string;
    VorgangGuid: string;
    Kopfzeile: string;
    Fusszeile: string;
    BelegArt: string;
    BelegNummer: number;
    VorgangsNummer: number;
    BelegDatum: Date;
    VorgangErstellDatum: string;
    AenderungsDatum: Date;
    BelegJahr: number;
    Schlusstext: string;
    BelegTitelUeberschrift: string;
    BelegTitelZeile1: string;
    BelegTitelZeile2: string;
    TextFuerAnschreiben: string;
    Kommission: string;
    Ausfuehrungsdatum: string;
    AnsprechpartnerKunde: string;
    Ansprechpartner: string;
    Telefonnummer: string;
    Bestelldatum: string;
    Belegdatum: string;
    BelegAdresse: AdresseDruckDTO;
    BelegAdresseString: string;
    VersandAdresse: AdresseDruckDTO;
    VersandAdresseString: string;
    PositionsObjekte: Array<BelegPositionDruckDTO>;
    Salden: Array<BelegSaldoDruckDTO>;
    CountValuePositionen: number;
    CountValueSalden: number;
    Lieferzeit: string;
    IsEndkunde: boolean;
    IsRabatt: boolean;
    IstSelbstabholer: boolean;
    SammelbelegNummer: number|null;
    Kontrollkuerzel: string;
};

export type BelegDTO = {
    BelegGuid: string;
    BelegArt: string;
    BelegNummer: number;
    BelegJahr: number;
    BelegDatum: Date;
    AenderungsDatum: Date;
    BelegAdresse: BeleganschriftDTO;
    VersandAdresse: BeleganschriftDTO;
    VersandAdresseGleichBelegAdresse: boolean;
    AusfuehrungsDatum: string;
    Terminwunsch: string;
    InterneNotiz: string;
    BemerkungFuerKunde: string;
    IstSelbstabholer: boolean;
    BelegTitelUeberschrift: string;
    BelegTitelZeile1: string;
    BelegTitelZeile2: string;
    Schlusstext: string;
    AktuellerStatusCode: string;
    AktuellerStatusText: string;
    Ansprechpartner: string;
    AnsprechpartnerKunde: string;
    Positionen: Array<string>;
    Salden: Array<BelegSaldoDTO>;
    Historie: Array<BelegHistorieDTO>;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    PositionsObjekte: Array<BelegPositionDTO>;
    TextFuerAnschreiben: string;
    IstGesperrt: boolean;
    /** Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet" */
    FakturaKennzeichen: string;
    ExterneReferenznummer: string;
    ExterneMandantenGuid: string|null;
    SammelbelegNummer: number|null;
    SammelbelegGuid: string|null;
};

export type BelegeInfoDTO = {
    VorgangGuid: string;
    BelegGuid: string;
    KontaktGuid: string;
    BelegPositionGuids: string[];
    Belegart: string;
    Vorgangsnummer: number;
    BelegNummer: number;
    /** ISO date string */
    BelegDatum: string;
    PosAnzahl: number;
    GesamtBetrag: number;
    Kundennummer: string;
    Kundenname: string;
    Lieferadresse: string;
    IstSammelrechnungsKunde: boolean;
    InnergemeinschaftlichOhneMwSt: boolean;
    SammelrechnungsNummer: number | null;
    /** ISO date string */
    LastPrintDate: string | null;
    /** ISO date string */
    LastExportDate: string | null;
    MwSt: number;
    Lieferungstyp: Lieferungstyp;
    HatRechnungUndRechNrIstVorgangNr: boolean;
};

export type BelegHistorieDTO = {
    BelegHistorieGuid: string;
    Status: string;
    Text: string;
    Zeitstempel: Date;
    Benutzer: string;
};

export type BelegHistorienDTO = {
    BelegHistorien: Array<BelegHistorieDTO>;
    BelegPositionHistorien: Record<string, Array<BelegPositionHistorieDTO>>;
};

export type BelegNummerSettingDTO = {
    BelegArt: string;
    Startwert: number;
    Version: number;
    ChangedDate: Date;
};

export type BelegPositionAVDTO = {
    BelegPositionAVGuid: string;
    SerieGuid: string;
    BelegPositionGuid: string;
    VorgangGuid: string;
    BelegGuid: string;
    /** ISO date string */
    Bereitgestellt: string;
    /** ISO date string */
    Berechnet: string | null;
    IstBerechnet: boolean;
    /** Counter for failed calculations */
    FailedCalculationsCount: number;
    IstProduziert: boolean;
    IstGeloescht: boolean;
    IstStorniert: boolean;
    HatSonderwuensche: boolean;
    SonderwunschText: string;
    Variante: string;
    ArtikelNummer: string;
    Kommission: string;
    Kunde: string;
    Pcode: string;
    Fehlerlog: string;
    /** "NichtFreigegeben", "Freigegeben", "Abgerechnet" */
    FakturaKennzeichen: string;
    IstAusserhalbGewaehrleistung: boolean;
    KapazitaetsBedarf: number;
    Position: BelegPositionDTO | null;
    ProduktionsDaten: ProduktionsDatenDTO | null;
    IstGedruckt: boolean;
    /** ISO date string */
    ErfassungsDatum: string;
    /** ISO date string */
    ChangedDate: string;
    /** ISO date string */
    CalculatedForTimestamp: string | null;
};

export type BelegPositionAVListItemDTO = {
    BelegPositionAVGuid: string;
    BelegPositionGuid: string | null;
    PCode: string;
    /** ISO date string */
    ChangedDate: string;
};

export type BelegPositionDatenDTO = {
    UnterkomponenteName: string;
    KonfigName: string;
    Wert: string;
    DatenTyp: string;
    BelegPositionDatenGuid: string;
};

export type BelegPositionDruckDTO = {
    PositionsKommission: string;
    LaufendeNummer: number;
    ArtikelNummer: string;
    Variante: string;
    IstAlternativPosition: boolean;
    IstAktiv: boolean;
    Menge: number;
    EinzelpreisOhneFarbzuschlag: string;
    Einzelpreis: string;
    Rabatt: string;
    Gesamtpreis: string;
    Farbzuschlag: string;
    MengenEinheit: string;
    Text: string;
    AngebotsText: string;
    PulverCode: string;
    SonderwunschText: string;
    SonderwunschAngebotsText: string;
    ProduktionZusatzInfo: string;
    ProduktionZusatzInfoPrintOnReport: boolean;
    ProduktionZusatzInfoPrintZusatzEtikett: boolean;
    IstVE: boolean;
    VE_Menge: number|null;
    Zusatztexte: Array<ZusatztextDTO>;
    BelegPositionGuid: string;
};

export type BelegPositionDTO = {
    BelegPositionGuid: string;
    NachfolgeBelegPositionGuid: string;
    ErfassungsDatum: Date;
    /** Die fortlaufende Nummer für jede Position innerhalb des Beleges. Über diese Nummer wird auch die Ausgabenreihenfolge bestimmt. */
    LaufendeNummer: number;
    /** Die sichtbare PositionsNummer, sie kann auch leer sein, z.Bsp. bei Titeln, Text- oder alternativen Positionen. Sie sollte nicht mehr als max. 4 Zeichen lang sein, damit die Pos.-Splate auf dem Beleg nicht zu breit wird. */
    PositionsNummer: string;
    ArtikelNummer: string;
    Variante: string;
    VarianteGuid: string;
    Einbauort: string;
    PositionsKommission: string;
    IstAlternativPosition: boolean;
    IstAktiv: boolean;
    IstFehlerhaft: boolean;
    IstStorniert: boolean;
    IstFehlerhaftSFOhnePreis: boolean;
    IstGesperrt: boolean;
    Menge: number;
    Listenpreis: number;
    Einzelpreis: number;
    Rabatt: number;
    AufAbschlag: number;
    Gesamtpreis: number;
    Steuersatz: number;
    MengenEinheit: string;
    Text: string;
    Daten: Array<BelegPositionDatenDTO>;
    /** Die Version des Sonderanpassungen-Tabs in der i3 Belegpositionserfassung, mit der die Position zuletzt bearbeitet wurde. */
    SonderWuenscheModelVersion: number;
    Sonderwuensche: Array<BelegPositionSonderwunschDTO>;
    Historie: Array<BelegPositionHistorieDTO>;
    Zusatztexte: Array<ZusatztextDTO>;
    Besonderheiten: string;
    ProduktionZusatzInfo: string;
    ProduktionZusatzInfoPrintOnReport: boolean;
    ProduktionZusatzInfoPrintZusatzEtikett: boolean;
    IstBruttoGesamtpreis: boolean;
    IstBruttoEinzelpreis: boolean;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    IstSonderfarbPosition: boolean;
    Farbzuschlag: number;
    IstFarbzuschlagManuell: boolean;
    AngebotsText: string;
    SonderwunschText: string;
    SonderwunschAngebotsText: string;
    ProduktionsDatum: Date|null;
    LieferDatum: Date|null;
    ProduktionsAuftragErstellt: Date|null;
    GeplanteSerieGuid: string|null;
    VorgaengerBelegPositionGuid: string|null;
    /** Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet" */
    FakturaKennzeichen: string;
    IstAusserhalbGewaehrleistung: boolean;
    IstVE: boolean;
    VE_Menge: number|null;
    FrontendLogikGuid: string|null;
    IstFremdfertigung: boolean;
    FremdfertigungMandantGuid: string|null;
    Arbeitsminuten: number|null;
    Elementgewicht: number|null;
    PreisAufAnfrage: boolean;
    CalculationRequestTimestamp: Date|null;
    CalculatedForTimestamp: Date|null;
};

export type BelegPositionenApi = {
    /** Set locked status for beleg positions */
    setBelegPositionGesperrtStatus: (gesperrtStatus: boolean, positionen: string[]) => Promise<string[]>;
    /** Get vorgang for function by beleg position GUID and mandant ID */
    getVorgangForFunction: (belegPositionGuid: string, mandantId: number) => Promise<VorgangDTO>;
    /** Get beleg positions from a list of GUIDs */
    getBelegPositionenFromGuidList: (belegPositionGuidList: string[]) => Promise<BelegPositionDTO[]>;
};

export type BelegPositionHistorieDTO = {
    BelegPositionHistorieGuid: string;
    Text: string;
    Zeitstempel: Date;
    Benutzer: string;
};

export type BelegPositionHistorienDTO = {
    BelegPositionHistorien: Array<BelegPositionHistorieDTO>;
};

export type BelegPositionSonderwunschDTO = {
    Wert: string;
    Laenge: number;
    CalculatedLaenge: string;
    Hoehe: number;
    Typ: string;
    Gruppe: string;
    Farbe: string;
    CalculatedFarbe: string;
    Aufpreis: number;
    Bezeichnung: string;
    ExportName: string;
    Kuerzel: string;
    GehoertZuProfilMitKuerzel: string;
    InternerName: string;
    Standard: string;
    ListenName: string;
    NichtSaegenMoeglich: boolean;
    ProfilNichtSaegen: boolean;
    BelegPositionSonderwunschGuid: string;
    IstKorrekturAktiv: boolean;
};

export type BelegSaldoDruckDTO = {
    Reihenfolge: number;
    Text: string;
    Betrag: string;
    Rabatt: string;
    IsLastElement: boolean;
};

export type BelegSaldoDTO = {
    BelegSaldoGuid: string;
    Reihenfolge: number;
    /** Text für die Anzeige */
    Text: string;
    /** Der eigentlich Saldenwert. */
    Betrag: number;
    /** Der Wert, den der Anwender eingegeben hat, z.B. 5% */
    Wert: number;
    /** Zulässige Werte: "Abschlag", "Zuschlag", "Betrag" */
    Typ: string;
    /** Zulässige Werte: "Prozentual", "Absolut" */
    Art: string;
    /** Zulässige Werte: "Saldo", "StandardSaldo", "Warenwert", "Mehrwertsteuer", "Gesamtbetrag", "Endbetrag", "Farbe" */
    Name: string;
    /** Zulässige Werte: "Unbekannt", "ManuelleEingabe", "AutoEingabe", "AufAnfrage" */
    SaldenStatus: string;
    IstInaktiv: boolean;
    /** Die Salde wurde im Vorgang trotz Transportkostenbefreiung manuell aktiviert und wird von der automatischen Befreiungsregel nicht mehr verändert. */
    IstManuellUebersteuert: boolean;
    /** In diesem Tag können belibige interne Informationen als String gespeichert werden. */
    Tag: string;
    /** Rabatt, der in der Salde verrechnet wurde */
    Rabatt: number;
    /** TemplateText mit z.B. Platzhalter aus der Standardsalde der benötigt wird um beim ändern einer Salde den Text neu zu generieren. */
    TemplateText: string;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type BelegSerienInfoDTO = {
    BelegGuid: string;
    SerienInfos: Array<SerieInfoDTO>;
};

/** BelegStatus enum values */
export type BelegStatus = 0|10|20|30|40|50|60|70|80|90|100|110|120|130|140|150|160;

export type BelegStatusDTO = {
    /** Eindeutige GUID */
    VorgangGuid: string;
    BelegGuid: string;
    /** Sichtbare Vorgangsnummer/zur Info für Kunden usw. */
    VorgangsNummer: number;
    BelegNummer: number;
    /** Statuscode */
    AktuellerStatus: string;
    /** Datum der letzten Änderung des Vorgangs */
    AenderungsDatum: Date;
    NeuerStatus: string;
    NeuerStatusText: string;
    AktuellerStatusText: string;
};

export type BelegWorkflow = {
    /** Workflow steps array */
    Steps: Array<BelegArt>;
};

export type BenutzerApi = {
    /** Get list of users for a mandant */
    getBenutzerListe: (mandant: string, mitRollenUndRechten?: boolean) => Promise<BenutzerDTO[]>;
    /** Get a single user by GUID */
    getBenutzer: (benutzer: string, mitRollenUndRechten?: boolean) => Promise<BenutzerDTO>;
    /** Save multiple users */
    saveBenutzerList: (list: BenutzerDTO[]) => Promise<void>;
    /** Save a single user */
    saveBenutzer: (benutzer: BenutzerDTO) => Promise<any>;
    /** Request password reset for a user */
    passwortReset: (benutzerName: string) => Promise<any>;
    /** Change password */
    passwortAendern: (passwortAendernData: PasswortAendernDTO) => Promise<any>;
    /** Trigger SIC sync web job */
    sicSyncWebJob: () => Promise<any>;
    /** Get all roles */
    getRollenAll: () => Promise<RolleDTO[]>;
};

export type BenutzerDTO = {
    Rollen: RolleDTO[];
    BenutzerGuid: string;
    Benutzername: string;
    Vorname: string;
    Nachname: string;
    MandantGuid: string | null;
    Passwort: string;
    PasswortBCrypt: string;
    MasterKatalog: boolean | null;
    HauptKatalog: boolean | null;
    NewsletterId: number | null;
    IstAktiv: boolean;
    GesperrteVarianten: string[];
    /** ISO date string */
    ChangedDate: string;
    EmailAdresse: string;
    TelefonNummer: string;
    Art: string;
    IstSicSynchronized: boolean;
    LastSicMessage: string;
};

export type BerechnungParameterDTO = {
    MandantGuid: string;
    /** Default: true */
    SaveResultData: boolean;
    BelegPositionAVDTO: BelegPositionAVDTO;
    ProduktionsSettingsDTO: ProduktionsSettingsDTO;
    /** Default: -999 */
    VorgangsNummer: number;
    /** Default: -999 */
    BelegNummer: number;
    IgnoreSonderwuensche: boolean;
    ReturnRawDataFile: boolean;
    RawDataFileContent: string;
};

export type BerechnungResultDTO = {
    OriginalBelegPosition: BelegPositionDTO;
    BelegPositionGuid: string;
    RawDataFileContent: string;
    ProduktionsDaten: ProduktionsDatenDTO;
    Meldung: string;
};

export type BerechtigungDTO = {
    Code: string;
    ErklaerungsText: string;
};

export type BestellungListItemDTO = BaseListItemDTO;

export type CalculationInfoDTO = {
    MandantId: number;
    BelegPositionGuid: string;
    /** The timestamp when the calculation was requested. */
    CalculationRequestTimestamp: Date|null;
    /** The timestamp indicating for which request timestamp the calculation was performed. */
    CalculatedForTimestamp: Date|null;
};

export type ChangeDTO = {
    /** GUID des geänderten Objekts */
    ChangedGuid: string;
    /** ISO date string */
    ChangedWhen: string;
    /** Typ der Änderung */
    ChangeType: string;
    /** Art der Änderung (Insert, Update, Delete) */
    ChangeOperation: string;
    /** Mandanten-ID */
    MandantId: number | null;
    /** Mandanten-GUID */
    MandantGuid: string | null;
    /** JSON-Daten der Änderung */
    Data: string;
};

export type ChangeInfoDTO = {
    /** ISO date string */
    Kontakte: string;
    /** ISO date string */
    Vorgaenge: string;
    /** ISO date string */
    Serien: string;
    /** ISO date string */
    BelegPositionenAV: string;
    /** ISO date string */
    Settings: string;
    /** ISO date string */
    Lagerbestand: string;
    /** ISO date string */
    BelegPositionen: string;
    /** ISO date string */
    ProduktionsStati: string;
    /** ISO date string */
    TagInfos: string;
};

export type ContractDTO = {
    /** Eindeutige GUID des Vertrags */
    ContractGuid: string;
    /** GUID des Eigentümers */
    Owner: string;
    /** GUID des Partners */
    Partner: string;
    /** Kontext des Vertrags */
    Context: string;
    /** Wert des Vertrags */
    Value: string;
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    ChangedDate: string;
    /** Name des Eigentümers */
    OwnerName: string;
    /** Name des Partners */
    PartnerName: string;
    /** Gibt an, ob der Vertrag bearbeitbar ist */
    IsEditable: boolean;
    /** Gibt an, ob der Vertrag vererbt wird */
    Inherit: boolean;
};

export type CreateSammelrechnungDTO = {
    BelegGuids: string[];
    KontaktGuid: string;
    Ansprechpartner: string;
    Liefertermin: string;
    Schlusstext: string;
    ZahlungsBedingungen: string;
    RechnungsAdresse: BeleganschriftDTO;
};

export type CreateServiceTokenRequestDTO = {
    /** GUID des App-Tokens */
    AppTokenGuid: string;
};

/** Defines the combination of ArtikelArten + FarbArten which will be exported together in a CSV file. */
export type CsvExportCombinationDTO = {
    ExportArtikelArten: ExportArtikelArt[];
    ExportFarbArten: ExportFarbArt[];
};

/** Delivery information returned by `send`/`broadcast` — never the result of a handler. */
export type Delivery = {
    /** At least one recipient was reached. */
    delivered: boolean;
    /** Number of distinct modules delivered to. */
    recipients: number;
};

export type DevOpsStatusDTO = {
    /** Umgebung */
    Env: string;
    /** Datenbankinformation */
    DbInfo: string;
    /** Aktuelle Migration */
    CurrentMigration: string;
    /** Ausstehende Migrationen */
    PendingMigrations: string[];
};

/**
 * A registered endpoint, returned by `messages.register`. `register` is
 * idempotent; each handle's `dispose` only removes subscriptions made through it.
 */
export type Endpoint = {
    /** The module name of this endpoint. */
    name: string;
    /** Subscribe; returns an unsubscribe function. */
    on: (type: TypePattern, handler: MessageHandler) => (() => void);
    /** Directed message (`from` is stamped automatically). `to` is a module name, or `user:…`/`app:…`/`bot:…` for delivery via the server (`delivered` then means "handed to the server"; replies arrive as local broadcasts). */
    send: (to: string, type: string, payload?: any, options?: SendOptions) => Delivery;
    /** Broadcast to all other endpoints (`from` is stamped automatically; the sender does not receive its own broadcast). */
    broadcast: (type: string, payload?: any, options?: SendOptions) => Delivery;
    /** Remove all subscriptions created through this handle. */
    dispose: () => void;
};

export type EnvironmentConfig = {
    /** The environment name. */
    name: string;
    /** The version number. */
    version: string;
    /** The CMS URL. */
    cms: string;
    /** The IDAS API URL. */
    idas: string;
    /** The store API URL. */
    store: string;
    /** The documentation URL. */
    docs: string;
    /** The notification service URL. */
    notify: string;
    /** The feedback service URL. */
    feedback: string;
    /** The help center URL. */
    helpcenter: string;
    /** The reports service URL. */
    reports: string;
    /** The webhook service URL. */
    webhookService: string;
};

export type EtikettDatenDTO = {
    EtikettDatenGuid: string;
    Position: string;
    Typ: string;
    Inhalt: string;
};

export type EtikettDTO = {
    EtikettGuid: string;
    Kuerzel: string;
    Text: string;
    ZielKennzeichen: string;
    IstSonderEtikett: boolean;
    /** Zusatzetiketten sind manuell angelegte Etiketten, welche über die AppSpecificProperties gepflegt wurden und sich nun in den AdditionalProperties befinden. */
    IstZusatzEtikett: boolean;
    /** Default: "Produktionsetikett" */
    Typ: string;
    EtikettDaten: Array<EtikettDatenDTO>;
    EtikettenProfilVorbiegen: boolean;
    EtikettenSonderKuerzel: string;
};

/** ExportArtikelArt enum values */
export type ExportArtikelArt = ('Neher'|'Ueberschriebene'|'Eigene');

/** ExportFarbArt enum values */
export type ExportFarbArt = ('Standardfarbe'|'Trendfarbe'|'Sonderfarbe');

export type ExtendedStatusCodeDTO = {
    /** Exception-Information */
    Exception: Error | null;
    /** Statusinformation */
    Info: string;
};

export type FachzuordnungResultDTO = {
    ProduktfamilienOverCapacity: Array<string>;
    OverCapacity: boolean;
};

export type FakturaApi = {
    /** Get vorgang identifier */
    getVorgangKennzeichen: (vorgangGuid: string) => Promise<string>;
    /** Get beleg identifier */
    getBelegKennzeichen: (belegGuid: string) => Promise<string>;
    /** Get beleg position identifier */
    getBelegPositionKennzeichen: (belegPositionGuid: string) => Promise<string>;
    /** Get beleg position AV identifier */
    getBelegPositionAvKennzeichen: (belegPositionAvGuid: string) => Promise<string>;
    /** Set vorgang identifier */
    setVorgangKennzeichen: (dto: SetFakturaDTO) => Promise<string>;
    /** Set beleg identifier */
    setBelegKennzeichen: (dto: SetFakturaDTO) => Promise<string>;
    /** Set beleg position identifier */
    setBelegPositionKennzeichen: (dto: SetFakturaDTO) => Promise<string>;
    /** Set beleg position AV identifier */
    setBelegPositionAvKennzeichen: (dto: SetFakturaDTO) => Promise<string>;
    /** Set automatic invoicing in delivery notes */
    setFakturaInAbAuto: () => Promise<void>;
};

export type FarbArt = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7;

export type FarbeApi = {
    /** Get all colors */
    getAllFarben: () => Promise<FarbeDTO[]>;
    /** Save color */
    saveFarbe: (dto: FarbeDTO) => Promise<void>;
    /** Get all surfaces */
    getAllOberflaechen: () => Promise<OberflaecheDTO[]>;
    /** Save surface */
    saveOberflaeche: (dto: OberflaecheDTO) => Promise<void>;
    /** Get all color groups */
    getAllFarbGruppen: () => Promise<FarbGruppeDTO[]>;
    /** Save color group */
    saveFarbGruppe: (dto: FarbGruppeDTO) => Promise<void>;
    /** Get all color codes */
    getAllFarbKuerzel: () => Promise<FarbKuerzelDTO[]>;
    /** Save color code */
    saveFarbKuerzel: (dto: FarbKuerzelDTO) => Promise<void>;
    /** Get all color code groups */
    getAllFarbKuerzelGruppen: () => Promise<FarbKuerzelGruppeDTO[]>;
    /** Save color code group */
    saveFarbKuerzelGruppe: (dto: FarbKuerzelGruppeDTO) => Promise<void>;
    /** Get color group surcharges */
    getFarbgruppenaufpreise: () => Promise<FarbgruppenaufpreiseDTO[]>;
    /** Save color group surcharge */
    saveFarbgruppenaufpreise: (dto: FarbgruppenaufpreiseDTO) => Promise<void>;
    /** Get all producer color groups */
    getAllProduzentenFarbGruppen: () => Promise<ProduzentenFarbGruppeDTO[]>;
    /** Save producer color group */
    saveProduzentenFarbGruppe: (dto: ProduzentenFarbGruppeDTO) => Promise<void>;
    /** Delete producer color group */
    deleteProduzentenFarbGruppe: (produzentenFarbGruppeGuid: string) => Promise<void>;
};

export type FarbeDTO = {
    /** Eindeutige GUID der Farbe */
    FarbItemGuid: string;
    /** Bezeichnung der Farbe */
    Bezeichnung: string;
    /** Dateiname des Farbbildes */
    BildDateiname: string;
    /** Farbcode */
    FarbCode: string;
    /** Farbwert */
    Farbe: string;
    /** ISO date string */
    ChangedDate: string;
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    GueltigAb: string | null;
    /** ISO date string */
    GueltigBis: string | null;
};

export type FarbGruppeDTO = {
    /** Bezeichnung der Farbgruppe */
    Bezeichnung: string;
    /** Anzeigename der Farbgruppe */
    AnzeigeName: string;
    /** Eindeutige GUID der Farbgruppe */
    FarbItemGroupGuid: string;
    /** ISO date string */
    GueltigAb: string | null;
    /** ISO date string */
    GueltigBis: string | null;
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    ChangedDate: string;
    /** Reihenfolge der Anzeige */
    Reihenfolge: number;
    /** Gibt an, ob die Farbgruppe gesperrt ist */
    IstGesperrt: boolean;
    /** GUIDs der zugeordneten Farben */
    FarbItemGuids: string[];
    /** GUIDs der zugeordneten Oberflächen */
    OberflaecheGuids: string[];
};

export type FarbgruppenaufpreiseDTO = {
    /** Eindeutige GUID */
    FarbgruppenaufpreiseGuid: string;
    /** Neher Modell aktiv */
    NeherModellAktiv: boolean;
    /** Eigenes Modell aktiv */
    EigenesModellAktiv: boolean;
    /** Ist Admin DTO */
    IstAdminDTO: boolean;
    /** Liste der Farbgruppeneinstellungen */
    FarbgruppenSettings: FarbgruppeSettingsDTO[];
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type FarbgruppeSettingsDTO = {
    /** GUID der Farbgruppe */
    FarbgruppenGuid: string;
    /** Gibt an, ob die Gruppe aktiv ist */
    GruppeAktiv: boolean;
    /** Gibt an, ob der Preis auf Anfrage ist */
    PreisAufAnfrage: boolean;
    /** Aufpreis für Elemente */
    AufpreisElement: number;
    /** Aufpreis für Farbe */
    AufpreisFarbe: number;
    /** Prozentualer Aufpreis für Elemente */
    ProzentAufpreisElement: number;
    /** Maximaler Aufpreis */
    AufpreisMaximal: number;
    /** Gibt an, ob der maximale Aufpreis aktiv ist */
    AufpreisMaximalAktiv: boolean;
};

export type FarbKuerzelDTO = {
    /** Eindeutige GUID des Farbkürzels */
    FarbKuerzelGuid: string;
    /** Das Farbkürzel */
    Kuerzel: string;
    /** Beschreibung des Farbkürzels */
    Beschreibung: string;
    /** Bezeichnung der Farbe */
    FarbBezeichnung: string;
    /** Gibt an, ob es sich um eine Trendfarbe handelt */
    IstTrendfarbe: boolean;
    /** GUID der zugeordneten Farbe */
    FarbItemGuid: string;
    /** GUID der zugeordneten Oberfläche */
    OberflaecheGuid: string;
    /** ISO date string */
    GueltigAb: string | null;
    /** ISO date string */
    GueltigBis: string | null;
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type FarbKuerzelGruppeDTO = {
    /** Eindeutige GUID der Farbkürzelgruppe */
    FarbKuerzelGruppeGuid: string;
    /** Liste der Farbkürzel */
    Kuerzel: string[];
    /** Bezeichnung der Gruppe */
    Bezeichnung: string;
    /** ISO date string */
    GueltigAb: string | null;
    /** ISO date string */
    GueltigBis: string | null;
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type FileApi = {
    /** Get file by name */
    get: (name: string) => Promise<Uint8Array>;
    /** Get file list */
    getList: () => Promise<FileInfoDTO[]>;
    /** Get files as zip */
    getZipped: (fileNames: string[]) => Promise<Uint8Array>;
    data: { get: (filename: string) => Promise<Uint8Array>; getList: (directory?: string) => Promise<FileInfoDTO[]>; save: (fileName: string, data: Uint8Array) => Promise<void>; delete: (filename: string) => Promise<void> };
};

export type FileInfoDTO = {
    FileName: string;
    FileSize: number;
    /** ISO date string */
    Modified: string;
    /** ISO date string */
    Created: string;
    /** ISO date string */
    GueltigBis: string | null;
    MandantGuid: string | null;
};

export type FilterItemDTO = {
    FilterGuid: string;
    MandantGuid: string;
    BenutzerGuid: string;
    Title: string;
    Context: string;
    SerializedFilterSetting: string;
    Version: number;
    /** ISO date string */
    ChangedDate: string;
    IsDeleted: boolean;
    Reihenfolge: number;
};

export type FluentApi = {
    /** The base URL for API requests. */
    baseUrl: string;
    /** The authentication manager. */
    authManager: FluentAuthManager|null;
    /** The name of the service using this API. */
    serviceName: string;
    /** Legacy settings bag used by older API wrappers. */
    settings?: any;
    /** Sets the base URL for API requests and returns the FluentApi object. */
    useBaseUrl: (url?: string) => FluentApi;
    /** Sets the auth manager and returns the FluentApi object. */
    useAuthManager: (authManager: FluentAuthManager) => FluentApi;
    /** Sets the service name and returns the FluentApi object. */
    useServiceName: (name: string) => FluentApi;
    /** Legacy alias for useBaseUrl. */
    withBaseUrl: (url?: string) => FluentApi;
    /** Async function to perform GET requests. */
    get: (url?: string, auth?: boolean) => Promise<object|Array<any>>;
    /** Async function to perform PUT requests with a payload. */
    put: (url?: string, payload?: object, auth?: boolean) => Promise<object|Array<any>>;
    /** Async function to perform POST requests with a payload. */
    post: (url?: string, payload?: object, auth?: boolean) => Promise<object|Array<any>>;
    /** Async function to perform DELETE requests. */
    delete: (url?: string, payload?: object|FormData|Array<any>|string[]|string|null, auth?: boolean) => Promise<object|Array<any>>;
    /** Creates a configured REST client. */
    createRestClient: () => FluentRESTClient;
    /** Ensures a usable JWT before a request when required; throws an AuthError (request not sent) otherwise. */
    preCheck: (auth?: boolean) => Promise<void>;
    /** Runs a request with authentication and a one-time retry on 401. */
    _executeRequest: (auth: boolean, executeRequest: () => Promise<any>) => Promise<any>;
};

export type FluentAuthManager = {
    /** The application token. */
    appToken: string;
    /** The authentication URL. */
    authUrl: string;
    /** The JWT token for authorization (accessor, shared by every proxy/wrapper of this instance). */
    token: string;
    /** The refresh token (accessor, shared by every proxy/wrapper of this instance). */
    refreshToken: string;
    /** Decoded JWT claims for role/right checks (accessor, shared by every proxy/wrapper of this instance). */
    userInfo: JwtUserInfo;
    /** Sets the application token and returns the FluentApi object. */
    useAppToken: (appToken?: string) => FluentAuthManager|null;
    /** Sets the base URL for authentication and returns the FluentApi object. */
    useBaseUrl: (url?: string) => FluentAuthManager;
    /** Sets the JWT token and returns the FluentApi object. Only intended for usage with Service Tokens. */
    useToken: (jwtToken?: string|null) => FluentAuthManager;
    /** Sets the refresh token and returns the FluentApi object. */
    useRefreshToken: (storedRefreshToken?: string|null) => FluentAuthManager;
    /** Tries to provide a valid JWT (refresh if needed); never throws, a failed refresh is only logged. Requests use getAuthorizationToken instead. */
    ensureAuthenticated: () => Promise<void>;
    /** Returns the JWT to send with an authenticated request (refreshed if needed). Throws an AuthError instead of ever returning without a usable token. */
    getAuthorizationToken?: () => Promise<string>;
    /** Marks the JWT a request was sent with as rejected by the server (401) without discarding it; the next request refreshes first. */
    invalidateToken?: (token: string) => void;
    /** Authenticates the user with username and password, or refreshes the token. */
    authenticate: () => Promise<void>;
    /** Performs the actual token refresh (single-flight worker behind authenticate). */
    _doAuthenticate: (force?: boolean) => Promise<void>;
    /** In-flight authentication promise shared by concurrent callers (read-only). */
    _authenticatePromise: Promise<void>|null;
    /** Returns promise for authManager. */
    init: () => Promise<FluentAuthManager>;
    /** Logs in with the provided credentials. */
    login: (username?: string, password?: string) => Promise<void>;
    /** Attempts to refresh the authentication token using the refresh token. */
    tryRefreshToken: (refreshToken?: string) => Promise<string|null>;
    /** Updates the user session with the new token. */
    updateUserSession: (token: string|null) => void;
    /** Redirects to the login page. */
    redirectToLogin: () => void;
    /** Checks if the user has the specific right. */
    hasRight: (code: string) => boolean;
    /** Checks if the user has the specific role. */
    hasRole: (code: string) => boolean;
    /** Single-flight entry for (forced) refreshes; each caller decides about AUTH_EXPIRED_EVENT itself. */
    _runRefresh?: (force?: boolean, notifyExpired?: boolean) => Promise<void>;
    /** Refresh step executed while holding the cross-tab lock. */
    _refreshLocked?: (force: boolean) => Promise<void>;
    /** Picks the refresh token to send (own or newer one from localStorage). */
    _currentRefreshToken?: () => string|null;
    /** Calls LoginJwt/Refresh and reports the HTTP status. */
    _requestRefresh?: (refreshToken: string) => Promise<{token: string|null, status: number}>;
    /** Ends the session for good (clears tokens, stops the timer). */
    _expire?: (reason: string, rejectedRefreshToken?: string|null) => void;
    /** Dispatches AUTH_EXPIRED_EVENT once per expiry. */
    _notifyExpired?: (reason: string) => void;
    /** (Re)starts the proactive refresh timer for the current JWT. */
    _scheduleProactiveRefresh?: (delay?: number) => void;
    /** Stops the proactive refresh timer. */
    _stopProactiveRefresh?: () => void;
    /** Timer callback: refreshes ahead of expiry if the document is visible. */
    _proactiveRefresh?: () => void;
    /** Registers storage/visibilitychange listeners once. */
    _installBrowserListeners?: () => void;
};

export type FluentRESTClient = {
    /** The base URL for API requests. */
    baseUrl: string;
    /** The JWT token for authorization. */
    token: string;
    /** The user agent header value for API requests. */
    userAgent: string;
    /** Function to set the base URL and return the FluentApi object. */
    useBaseUrl: (url?: string) => FluentRESTClient;
    /** Function to set the JWT token and return the FluentApi object. */
    useToken: (jwtToken?: string) => FluentRESTClient;
    /** Function to set the user agent and return the FluentApi object. */
    useUserAgent: (userAgent?: string) => FluentRESTClient;
    /** Async function to perform GET requests. */
    get: (url?: string, auth?: boolean) => Promise<any>;
    /** Async function to perform PUT requests with a payload. */
    put: (url?: string, payload?: object) => Promise<any>;
    /** Async function to perform POST requests with a payload. */
    post: (url?: string, payload?: object|FormData) => Promise<any>;
    /** Async function to perform DELETE requests. */
    delete: (url?: string, payload?: object|FormData|Array<any>|string[]|string|null) => Promise<any>;
    /** Builds request headers for an outgoing request. */
    _createHeaders: (contentType?: string) => Headers;
    /** Parses a response based on its content type. */
    _parseReponse: (res: Response) => Promise<any>;
};

/** FreigabeArt enum values */
export type FreigabeArt = 0|1|2;

/** FreigabeLevel enum values */
export type FreigabeLevel = 0|1|2|3|4;

export type GesamtLieferzusageBuchungDTO = {
    GesamtLieferzusageBuchungGuid: string;
    MandantGuid: string;
    GesamtMaterialbedarfGuid: string;
    Stueckzahl: number;
    Laufmeter: number;
    Buchungsdatum: Date;
};

export type GesamtLieferzusageDTO = {
    GesamtLieferzusageGuid: string;
    MandantGuid: string;
    Liefertermin: Date;
    KatalogNummer: string;
    BestellNummer: string;
    Einheit: string;
    Stueckzahl: number;
    UngedeckteStueckzahl: number;
    Laufmeter: number;
    UngedeckteLaufmeter: number;
    FarbBezeichnung: string;
    FarbZusatzText: string;
    FarbKuerzel: string;
    FarbKuerzelGuid: string;
    FarbCode: string;
    PulverCode: string;
    FarbeItem: string;
    FarbItemGuid: string;
    OberFlaeche: string;
    OberFlaecheGuid: string;
    IstSonderfarbe: boolean;
    IstVE: boolean;
    VE_Menge?: number;
    Buchungen: Array<GesamtLieferzusageBuchungDTO>;
};

export type GesamtMaterialbedarfDTO = {
    GesamtMaterialbedarfGuid: string;
    MandantGuid: string;
    IsGruppe: boolean;
    Children: Array<GesamtMaterialbedarfDTO>;
    ProduktionsMaterialbedarfGuid: string;
    ProduktionsMaterialbedarf: MaterialbedarfDTO;
    SerieGuid: string;
    Serie: SerieDTO;
    SerienName: string;
    BelegPositionGuid: string;
    BelegPosition: BelegPositionDTO;
    BelegPositionAVGuid: string;
    BelegPositionAV: BelegPositionAVDTO;
    Liefertermin: Date;
    KatalogNummer: string;
    Vorgangsnummer: string;
    ArtikelBezeichnung: string;
    Einheit: string;
    Stueckzahl: number;
    GedeckteStueckzahl: number;
    UngedeckteStueckzahl: number;
    Laufmeter: number;
    GedeckteLaufmeter: number;
    UngedeckteLaufmeter: number;
    FarbBezeichnung: string;
    FarbZusatzText: string;
    FarbKuerzel: string;
    FarbKuerzelGuid: string;
    FarbCode: string;
    FarbeItem: string;
    FarbItemGuid: string;
    OberFlaeche: string;
    OberFlaecheGuid: string;
    PulverCode: string;
    IstZuschnitt: boolean;
    ZuschnittLaenge: number;
    IstStangenoptimiert: boolean;
    ZuschnittWinkel: string;
    IstSonderfarbe: boolean;
    KatalogArtikelArt: KatalogArtikelArt;
    DeckungInPercent: number;
    IstVE: boolean;
    VE_Menge?: number;
};

export type GesamtMaterialbedarfGetReturn = {
    Bedarfe: Array<GesamtMaterialbedarfDTO>;
    Fehlliste: Array<GesamtMaterialbedarfDTO>;
    Ueberliste: Array<GesamtLieferzusageDTO>;
    Zusagen: Array<GesamtLieferzusageDTO>;
};

export type GuidListDTO = {
    GuidList: Array<string>;
};

export type HistorieApi = {
    /** Get vorgang history */
    getVorgangHistorie: (vorgangGuid: string, includeBelege?: boolean, includePositionen?: boolean) => Promise<VorgangHistorienDTO>;
    /** Get beleg history */
    getBelegHistorie: (belegGuid: string, includePositionen?: boolean) => Promise<BelegHistorienDTO>;
    /** Get beleg position history */
    getBelegPositionHistorie: (positionGuid: string) => Promise<BelegPositionHistorienDTO>;
    /** Get serie history since date */
    getSerieHistorieSince: (sinceWhen: Date) => Promise<SerieHistorieDTO[]>;
    /** Get serie history by GUID */
    getSerieHistorie: (serieGuid: string) => Promise<SerieHistorieDTO[]>;
    /** Add vorgang history */
    addVorgangHistorie: (vorgangGuid: string, historyDto: VorgangHistorieDTO) => Promise<void>;
    /** Add beleg history */
    addBelegHistorie: (belegGuid: string, historyDto: BelegHistorieDTO) => Promise<void>;
    /** Add beleg position history */
    addBelegPositionHistorie: (positionGuid: string, historyDto: BelegPositionHistorieDTO) => Promise<void>;
    /** Add serie history */
    addSerieHistorie: (historyDto: SerieHistorieDTO) => Promise<void>;
    /** Add vorgang history from function */
    addVorgangHistorieFromFunction: (vorgangGuid: string, historyDto: VorgangHistorieDTO, mandantID: number) => Promise<void>;
    /** Add beleg position history from function */
    addBelegPositionHistorieFromFunction: (positionGuid: string, historyDto: BelegPositionHistorieDTO, mandantID: number) => Promise<void>;
    /** Add serie history from function */
    addSerieHistorieFromFunction: (historyDto: SerieHistorieDTO, mandantID: number) => Promise<void>;
    /** Get last editor for beleg */
    getLetzterBearbeiter: (belegGuid: string) => Promise<string>;
    /** Get last editors for belege */
    getLetzteBearbeiter: (belegGuids: string[]) => Promise<Record<string, string>>;
};

export type IDASFluentApi = FluentApi & {
  vorgang: VorgangApi;
  kontakt: KontaktApi;
  belegPositionen: BelegPositionenApi;
  material: MaterialApi;
  serien: SerienApi;
  benutzer: BenutzerApi;
  artikel: ArtikelApi;
  beleg: BelegApi;
  produktion: ProduktionApi;
  faktura: FakturaApi;
  rechnung: RechnungApi;
  settings: SettingsApi;
  ui: UiApi;
  utility: UtilityApi;
  ablage: AblageApi;
  av: AvApi;
  farbe: FarbeApi;
  lager: LagerApi;
  lieferung: LieferungApi;
  mandant: MandantApi;
  print: PrintApi;
  historie: HistorieApi;
  system: SystemApi;
  file: FileApi;
  mail: MailApi;
  anpassung: AnpassungApi;
  auth: AuthApi;
  userInfo: FluentAuthManager["userInfo"];
};

export type ILagerLogikDTO = {
    KatalogArtikelGuid: string;
    FarbKuerzelGuid: string;
    /** Deprecated: FarbKuerzelGuid verwenden */
    FarbGuid: string;
    LagerbestandGuid: string;
};

export type ILayoutBelegDruck = {
    ShowLogo: boolean;
    LogoPositionX: number;
    LogoPositionY: number;
    LogoSizeWidth: number;
    LogoSizeHeight: number;
    TabellePositionX: number;
    TabellePositionY_Seite1: number;
    TabellePositionY_AbSeite2: number;
    TabelleHoehe_Seite1: number;
    TabelleHoehe_AbSeite2: number;
    TabelleBreite: number;
    BriefkopfPositionX: number;
    BriefkopfPositionY: number;
    FusszeilePositionX: number;
    FusszeilePositionY: number;
    SeitenrandLinks: number;
    SeitenrandRechts: number;
    SeitenrandUnten: number;
    SeitenrandOben: number;
    KommissionPositionY: number;
    SeitenzaehlerPositionX: number;
    SeitenzaehlerPositionY_Seite1: number;
    SeitenzaehlerPositionY_AbSeite2: number;
    AnschriftPositionX: number;
    AnschriftPositionY: number;
    MicroAnschriftPositionX: number;
    MicroAnschriftPositionY: number;
    ShowMicroAnschrift: boolean;
    BelegKopfPositionX: number;
    BelegKopfPositionY: number;
    BelegKopfPositionY_AbSeite2: number;
    ShowHistorie: boolean;
    IsBlankoDruck: boolean;
    IsBestellfixBeleg: boolean;
    IsDiagnoseDruck: boolean;
};

export type IndiFarbDatenDTO = {
    /** UUID */
    IndiFarbDatenGuid: string;
    IsPassiv: boolean;
    FarbKuerzel: string;
    BestellMengeAufVERunden: boolean;
    SonderPreis: number;
    IsInventurpflichtig: boolean;
    Lagerfuehrung: boolean;
    Freigabe_IBOS: boolean;
    Freigabe_BestellFix: boolean;
    Freigabe_ARTOS: boolean;
};

export type InfoScreenConfigDTO = {
    InfoScreenGuid: string;
    ChangedDate: string;
    Caption: string;
    /** Default: "einspaltig" */
    Layout: string;
    Initiator: string;
    ParamType: any;
    Rows: Array<InfoScreenRowDTO>;
};

export type InfoScreenInitTypeDTO = {
    Name: string;
    Type: any;
    Data: any;
};

export type InfoScreenModulSettingsDTO = {
    ModuleGuid: string;
    InitType: InfoScreenInitTypeDTO;
    AllowedTypes: Array<InfoScreenInitTypeDTO>;
    NeedsInit: boolean;
    IsValid: boolean;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type InfoScreenRowDTO = {
    /** Array of 2 elements (for 2 columns) */
    InfoScreenModule: Array<InfoScreenModulSettingsDTO>;
    RowNum: number;
};

export type JobStatusEntryDTO = {
    /** UUID */
    JobGuid: string;
    /** ISO date string */
    Timestamp: string;
    StatusText: string;
    /** UUID (read-only) */
    RowKey: string;
};

export type JobStatusResponseDTO = {
    /** UUID */
    JobGuid: string;
};

export type JwtTokenExt = {
    id: string;
    refreshToken: string;
};

/** Decoded JWT claims used by this auth manager. */
export type JwtUserInfo = {
    rights?: string|string[];
    role?: string|string[];
};

/** KapaFarbArt enum values */
export type KapaFarbArt = 0|1|2|3;

export type Kapazitaetsvorgabe = {
    GroupName: string;
    Label: string;
    Produktgruppe: Array<string>;
    Artikelliste: Array<string>;
    Bearbeitungen: Array<string>;
    Etikettentext: Array<string>;
    FarbArt: KapaFarbArt;
    Zeitvorgabe: number;
    Gewicht: number;
    IstBasisregel: boolean;
    Order: number;
};

export type KapazitaetsvorgabenDTO = Array<Kapazitaetsvorgabe> & { Version: number };

export type KatalogArtikelArt = string;

export type KatalogArtikelDTO = {
    KatalogArtikelGuid: string;
    KatalogNummer: string;
    Bezeichnung: string;
    /** Einer der Werte aus der KatalogArtikelArt-Enum */
    Art: string;
    WarenGruppeGuid: string;
    ImageFileName: string;
    Einheit: string;
    MengeMussGanzZahligSein: boolean;
    NurAlsVEBestellbar: boolean;
    IstZuschnittArtikel: boolean;
    IstBestellfixSonderfarbBestellbar: boolean;
    IstIbosSonderfarbBestellbar: boolean;
    IstArtosSonderfarbBestellbar: boolean;
    IstBestellfixTrendfarbBestellbar: boolean;
    IstIbosTrendfarbBestellbar: boolean;
    IstArtosTrendfarbBestellbar: boolean;
    IstFarbeOptional: boolean;
    NichtRabattfaehig: boolean;
    IstEKPArtikel: boolean;
    IstGewebeArtikel: boolean;
    IstSaegbar: boolean;
    /** Gewicht pro Mengeneinheit */
    GewichtInKg: number;
    MaterialGuid: string;
    MoeglicheFarben: Array<KatalogArtikelFarbZuordnungDTO>;
    /** Für Art = ProfilArtikel */
    ProfilLaengeMM: number;
    Freigabe_IBOS: boolean;
    Freigabe_BestellFix: boolean;
    Freigabe_ARTOS: boolean;
    /** Preis des Artikels (pro VE?) */
    Preis: number;
    StaffelPreis: number;
    StaffelMenge: number;
    VEMenge: number;
    VEPreis: number;
    MengeGrossVE: number;
    MengeGrossVE2: number;
    MeldeSchwelleGrossVEs: number;
    MaxBestellMenge: number;
    Status: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
    /** Mögliche Ersatzartikel für diesen Artikel */
    ErsatzArtikel: Array<string>;
    /** Für Art = FertigElementArtikel */
    VarianteGuid: string;
    ChangedDate: string;
    Version: number;
    IstTechnischerArtikel: boolean;
    BasisBestellMenge: number;
    FrontendLogikGuid: string | null;
    IsIndiArtikel: boolean;
    IstEigenartikel: boolean;
    ErsetztNeherArtikel: boolean;
    OriginalArtikelGuid: string | null;
};

export type KatalogArtikelFarbZuordnungDTO = {
    FarbKuerzelGuid: string;
    FarbItemGuid: string;
    Preis: number;
    Freigabe_IBOS: boolean;
    Freigabe_BestellFix: boolean;
    Freigabe_ARTOS: boolean;
    FarbArt: FarbArt;
    WirdAlsStandardFarbeBestellt: boolean;
    VEMenge: number;
    MengeGrossVE: number;
    MengeGrossVE2: number;
    MeldeSchwelleGrossVEs: number;
    GueltigAb: string | null;
    GueltigBis: string | null;
    Version: number;
    ChangedDate: string;
    MaxBestellMenge: number;
};

export type KatalogArtikelIndiDatenDTO = {
    /** UUID */
    KatalogArtikelIndiDatenGuid: string;
    /** UUID */
    KatalogArtikelGuid: string;
    IsPassiv: boolean;
    IsInventurPflichtig: boolean;
    IsLagerartikel: boolean;
    BestellMengeAufVERunden: boolean;
    KundenArtikelNummer: string;
    FarbDaten: Array<IndiFarbDatenDTO>;
    Freigabe_IBOS: boolean;
    Freigabe_BestellFix: boolean;
    Freigabe_ARTOS: boolean;
    InventurBewertung: number;
    /** ISO date string */
    ChangedDate: string;
    SerializedOptions: string;
};

export type KomponenteDTO = {
    KomponenteGuid: string;
    BauteilGuid: string;
    GehoertZuKomponenteGuid: string;
    KomponenteArtGuid: string;
    KomponenteKategorieGuid: string;
    Name: string;
    AnzeigeName: string;
    Bild: string;
    Bestellbar: boolean;
    IstSichtbar: boolean;
    AenderungsInfoWeiterleitungen: string;
    gehoerenZuKomponente: Array<string>;
    ConstructScript: string;
    UpdateScript: string;
    ValidateScript: string;
    ReconstructScript: string;
    BearbeitungenScript: string;
    FeatureErkennungScript: string;
    ZugehoerigerKatalogArtikelGuid: string;
    Version: number;
    ChangedDate: Date;
    Variablen: Array<KomponenteVariableDTO>;
    Verknuepfungen: Array<KomponenteVerknuepfungDTO>;
};

export type KomponenteVariableDTO = {
    KomponenteVariableGuid: string;
    Anpassbar: boolean | null;
    AnzeigeText: string;
    Datentyp: number;
    EingabeFeldAnzeigen: boolean;
    EingabeFeldArt: string;
    EingabeFeldP1: string;
    EingabeFeldP2: string;
    EingabeFeldP3: string;
    Name: string;
    WerteListe: string;
    Version: number;
    ChangedDate: Date;
};

export type KomponenteVerknuepfungDTO = {
    KomponenteVerknuepfungGuid: string;
    QuellKomponenteGuid: string;
    ZielKomponenteGuid: string;
    Name: string;
    Version: number;
    ChangedDate: Date;
};

export type KonfigSatzDTO = {
    ChangedDate: string;
    Eintraege: Array<KonfigSatzEintragDTO>;
    KonfigSatzGuid: string;
    Version: number;
};

export type KonfigSatzEintragDTO = {
    DatenTyp: string;
    KonfigName: string;
    KonfigSatzEintragGuid: string;
    UnterkomponenteName: string;
    Wert: string;
    ChangedDate: string;
};

export type KonfigSatzInfoDTO = {
    KonfigSatzGuid: string;
    VarianteGuid: string;
    LM_Hoehe: string;
    LM_Breite: string;
    LM_Breite2: string;
};

export type KontaktApi = {
    /** Get list of all contacts */
    getList: (ohneEndkunden?: boolean, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<KontaktListItemDTO[]>;
    /** Get list of contacts changed since a specific date */
    getListChangedSince: (changedSince?: Date|null, ohneEndkunden?: boolean, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<KontaktListItemDTO[]>;
    /** Get contact by GUID */
    getByGuid: (kontaktGuid: string) => Promise<KontaktDTO>;
    /** Get contact by customer number */
    getByKundenNummer: (kundenNummer: string) => Promise<KontaktDTO>;
    /** Save a contact */
    save: (kontakt: KontaktDTO) => Promise<KontaktDTO>;
    /** Archive multiple contacts */
    archive: (kontakteIds: string[]) => Promise<void>;
    /** Unarchive multiple contacts */
    unarchive: (kontakteIds: string[]) => Promise<void>;
    /** Set Fremdfertigung GUID mapping */
    setFremdfertigungGuid: (guidMapping: Record<string, string>) => Promise<void>;
    /** Get contact for function */
    getForFunction: (kontaktGuid: string, mandantId: number) => Promise<KontaktDTO>;
    /** Get all contacts for function */
    getAllForFunction: (changedSince?: Date|null) => Promise<Record<number, string[]>>;
};

export type KontaktDTO = {
    /** Eindeutige GUID */
    KontaktGuid: string;
    /** Nachname (für Endkunden) */
    Nachname: string;
    /** Vorname(n) (für Endkunden) */
    Vorname: string;
    /** Firmierung (für jur. Personen) */
    Firmenname: string;
    /** Kundennummer (alphanummerisch) */
    KundenNummer: string;
    /** Datum des ersten Kontakts */
    Erstkontakt: Date|null;
    /** Datum des letzten Kontakts */
    LetzterKontakt: Date|null;
    /** Endkunde oder Firmenkunde */
    IstEndkunde: boolean;
    /** allg. Informationen */
    Kommentar: string;
    /** Status Kontakt oder Interessent */
    IstKunde: boolean;
    /** Gesperrt/Wird nicht beliefert */
    IstGesperrt: boolean;
    /** Archiviert, wird nicht mehr angezeigt, restliche Abhängigkeiten bleiben unberührt */
    IstArchiviert: boolean;
    /** Holt Ware normalerweise ab */
    IstSelbstabholer: boolean;
    /** Kunde muss in Vorkasse gehen. */
    IstVorkasse: boolean;
    IstUmsatzsteuerPflichtig: boolean;
    /** Wenn der Kontakt ein Innergemeinschaftlicher Kontakt ist, kann durch dieses Flag die MwSt. Berechnung abgeschaltet werden. */
    InnergemeinschaftOhneMwSt: boolean;
    /** Zugeordnete Personen */
    Personen: Array<PersonDTO>;
    /** Zugeordnete Standard-Adressen */
    Zusatzanschriften: Array<ZusatzanschriftDTO>;
    IstDummyKunde: boolean;
    ArtikelRabattVorgabe: number;
    ElementRabattVorgabe: number;
    UmsatzSteuerId: string;
    Branche: string;
    /** Kunden-Nummernkreis, z.B. 600, 0000, 000 */
    Nummernkreis: string;
    /** Liefertage, Montag bis Freitag */
    Liefertage: string[];
    ShowSonderetikett: boolean;
    Sonderetikett: string;
    Briefanrede: string;
    Titel: string;
    /** Namensanrede, z.B. "Herr"/"Frau"/"Firma" */
    Anrede: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz1: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz2: string;
    /** Postalische Straße */
    Strasse: string;
    /** Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)" */
    Hausnummer: string;
    /** Postfach (ersetzt Straße/Hausnummer in der Ausgabe) */
    Postfach: string;
    /** Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse */
    Postleitzahl: string;
    /** Postalische Ortsangabe */
    Ort: string;
    /** Nicht-postalische Angabe zum Ortsteil */
    Ortsteil: string;
    /** Land als Textkürzel */
    Land: string;
    IstInland: boolean;
    /** E-Mail-Adresse */
    Mailadresse: string;
    /** Telefon: Ländervorwahl (kanonisch [+49] oder landesspezifisch [0049]) */
    Landesvorwahl: string;
    /** Ortskennzahl mit führender "0" in Deutschland */
    Vorwahl: string;
    /** Anschlussrufnummer */
    Telefonnummer: string;
    /** Durchwahlzusatz */
    Durchwahl: string;
    /** Internet-/Web-URL mit Protokoll-Präfix (https://...) */
    Webadresse: string;
    /** Transportkosten für den Kunden */
    Transportkosten: number|null;
    /** Transportkosten für den Kunden */
    AbweichendeTransportkosten: boolean;
    /** Intern */
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    /** Intern */
    AdditionalProperties: Record<string, PropertyValueCollection>;
    KontaktMandantGuid: string;
    KontaktMandantIstAktiv: boolean;
    Version: number;
    ChangedDate: Date;
    /** Zahleneintrag für Tage */
    NettoTage: number;
    /** Zahleneintrag für Tage sowie Skonto in % */
    Skonto: number;
    /** Freitextfeld bei Vorkasse Kunden "Hinweis auf Zahlung" (Angebot + AB) */
    SchlussTextAngebotAB: string;
    /** Freitextfeld bei Vorkasse Kunden "Hinweis auf Zahlung" (Rechnung) */
    SchlussTextRechnung: string;
    /** Freitextfeld für die Zahlungsbedingung */
    Zahlungsbedingung: string;
    /** Kunde hat Winterrabatt ja/nein */
    HatWinterrabatt: boolean;
    KeineAutofreigabe: boolean;
    ErbtAuswahlOhneSprosse: boolean;
    DigitalerRechnungsversand: boolean;
    IstSammelrechnungsKunde: boolean;
    /** Inaktiv Kennzeichen */
    IstInaktiv: boolean;
    /** Erzeugt einen Text aus den Namensfeldern für die Anzeige in Überschriften, Anschriftenfeldern usw. */
    AnzeigeName: string;
    ProduktionZusatzInfo: string;
    ProduktionZusatzInfoPrintZusatzEtikett: boolean;
    ProduktionZusatzInfoPrintOnReport: boolean;
    FremdfertigungMandantGuid: string;
};

export type KontaktListItemDTO = {
    KontaktGuid: string;
    KontaktMandantGuid: string;
    FremdfertigungMandantGuid: string;
    /** Der KontaktMandant hat die App-Verwendung aktiv */
    KontaktMandantIstAktiv: boolean;
    /** Nachname (für Endkunden) */
    Nachname: string;
    /** Vorname(n) (für Endkunden) */
    Vorname: string;
    /** Firmierung (für jur. Personen) */
    Firmenname: string;
    /** Kundennummer (alphanummerisch) */
    KundenNummer: string;
    /** Strasse */
    Strasse: string;
    /** Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)" */
    Hausnummer: string;
    /** Land */
    Land: string;
    /** Postleitzahl */
    Plz: string;
    /** Stadt / Ort */
    Ort: string;
    /** Ortsteil */
    Ortsteil: string;
    /** Telefon (Zentrale) */
    Telefon: string;
    /** E-Mail (Zentrale) */
    Email: string;
    /** Endkunde oder Firmenkunde */
    IstEndkunde: boolean;
    IstKunde: boolean;
    /** Kunde gesperrt? */
    IstGesperrt: boolean;
    /** Archivierte Kontakte werden nicht angezeigt */
    IstArchiviert: boolean;
    URL: string;
    ChangedDate: Date;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type KonturDTO = {
    KonturGuid: string;
    KonturElemente: Array<KonturElementDTO>;
    Name: string;
    Schluessel_1: number;
    Schluessel_2: number;
    Schluessel_3: number;
    Schluessel_4: string;
    Schluessel_5: string;
    Version: number;
    ChangedDate: Date;
};

export type KonturElementDTO = {
    KonturElementGuid: string;
    AX: number;
    AY: number;
    AZ: number;
    EX: number;
    EY: number;
    EZ: number;
    MX: number;
    MY: number;
    MZ: number;
    KreisRichtung: number;
    MakroName: string;
    MakroParameter: string;
    OperationArt: string;
    OperationNr: number;
    Version: number;
    ChangedDate: Date;
};

export type LagerApi = {
    /** Get inventory by GUID */
    get: (guid: string) => Promise<LagerbestandDTO>;
    /** Get inventory from GUID list */
    getFromGuidList: (guids: string[]) => Promise<LagerbestandDTO[]>;
    /** Get all inventory */
    getAll: (changedSince?: Date) => Promise<LagerbestandDTO[]>;
    /** Get inventory below minimum stock */
    getUnterschreitungEisernerBestand: () => Promise<LagerbestandDTO[]>;
    /** Book inventory */
    buchung: (buchung: LagerbuchungDTO) => Promise<LagerbestandDTO>;
    /** Book multiple inventory items */
    buchungListe: (buchungen: LagerbuchungDTO[]) => Promise<LagerbestandDTO[]>;
    /** Save inventory */
    save: (dto: LagerbestandDTO) => Promise<void>;
    /** Save inventory list */
    saveListe: (dtos: LagerbestandDTO[]) => Promise<string[]>;
    /** Delete inventory */
    delete: (guid: string) => Promise<void>;
    /** Get inventory history */
    getHistorie: (vonDatum: Date, bisDatum: Date, mitLagerbuchungen?: boolean, mitReservierungen?: boolean, katalogArtikelGuid?: string) => Promise<LagerbuchungDTO[]>;
    reservierung: { get: (guid: string) => Promise<LagerReservierungDTO>; getAll: (artikelnummer?: string, farbkuerzel?: string, farbcode?: string, bezug?: string, oberflaeche?: string, changedSince?: Date) => Promise<LagerReservierungDTO[]>; save: (dtos: LagerReservierungDTO[]) => Promise<void>; delete: (guids: string[]) => Promise<void> };
    /** Get producer mandant IDs */
    getProduzentenMandantIds: () => Promise<number[]>;
    /** Initialize inventory for articles */
    initializeBestand: (mandantID: number) => Promise<number[]>;
};

export type LagerbestandDTO = {
    /** Eindeutige GUID des Lagerbestands */
    LagerbestandGuid: string;
    /** GUID des Katalogartikels */
    KatalogArtikelGuid: string;
    /** Katalognummer */
    KatalogNummer: string;
    /** GUID der Farbe (veraltet, verwende FarbKuerzelGuid) */
    FarbGuid: string;
    /** GUID des Farbkürzels */
    FarbKuerzelGuid: string;
    /** Farbkürzel */
    FarbKuerzel: string;
    /** Aktueller Lagerbestand */
    Lagerbestand: number;
    /** Bestellbestand */
    Bestellbestand: number;
    /** Mindestbestand */
    Mindestbestand: number;
    /** Reservierte Menge */
    Reserviert: number;
    /** Maximalbestand */
    Maximalbestand: number;
    /** Eiserner Bestand */
    EisernerBestand: number;
    /** Einheit (z.B. Stk, lfm) */
    Einheit: string;
    /** Lagerplatz */
    Lagerplatz: string;
    /** Chargennummer */
    Charge: string;
    /** Gibt an, ob der Lagerbestand aktiv ist */
    IstAktiv: boolean;
    /** Seriennummer */
    Seriennummer: string;
    /** ISO date string */
    ChangedDate: string;
    /** Windows-Benutzer */
    WindowsUser: string;
};

export type LagerbuchungDTO = {
    /** GUID des Katalogartikels */
    KatalogArtikelGuid: string;
    /** GUID der Farbe (veraltet, verwende FarbKuerzelGuid) */
    FarbGuid: string;
    /** GUID des Farbkürzels */
    FarbKuerzelGuid: string;
    /** GUID des Lagerbestands */
    LagerbestandGuid: string;
    /** Buchungsbetrag */
    Betrag: number;
    /** Gibt an, ob es sich um eine Reservierung handelt */
    IstReservierung: boolean;
    /** Einheit */
    Einheit: string;
    /** Hinweistext */
    Hinweis: string;
    /** Artos-Benutzer */
    ArtosUser: string;
    /** Windows-Benutzer */
    WindowsUser: string;
    /** ISO date string */
    ChangedDate: string;
    /** Alter Bestand */
    BestandAlt: number;
    /** Neuer Bestand */
    BestandNeu: number;
};

export type LagerReservierungDTO = {
    /** Eindeutige GUID der Lagerreservierung */
    LagerReservierungGuid: string;
    /** GUID des Materialbedarfs */
    MaterialbedarfGuid: string | null;
    /** GUID der Lieferzusage */
    LieferzusageGuid: string | null;
    /** GUID der Gesamtlieferzusage */
    GesamtLieferzusageGuid: string | null;
    /** Artikelnummer */
    Artikelnummer: string;
    /** Farbkürzel */
    FarbKuerzel: string;
    /** Farbcode */
    FarbCode: string;
    /** Oberfläche */
    Oberflaeche: string;
    /** Bezug (z.B. Vorgangsnummer) */
    Bezug: string;
    /** Reservierte Menge */
    Menge: number;
    /** Einheit */
    Einheit: string;
    /** ISO date string */
    ErstellDatum: string;
    /** Windows-Benutzer */
    WindowsUser: string;
    /** Artos-Benutzer */
    ArtosUser: string;
    /** ISO date string */
    ChangedDate: string;
    /** Versionsnummer */
    Version: number;
};

export type LayoutBelegDruckDTO = ILayoutBelegDruck;

export type LieferungApi = {
    /** Get all delivery promises for serie */
    getAllLieferzusagen: (serieGuid: string, lieferant?: string) => Promise<LieferzusageDTO[]>;
    /** Get delivery promises count */
    getLieferzusagenCount: (serieGuid: string, lieferant?: string) => Promise<number>;
    /** Submit material delivery promise */
    materialZusagen: (lieferzusage: LieferzusageDTO) => Promise<string>;
    /** Submit multiple material delivery promises */
    materialZusagenListe: (lieferzusagen: LieferzusageDTO[]) => Promise<string>;
    /** Reset delivery promise */
    resetLieferzusage: (lieferzusageGuid: string) => Promise<void>;
    /** Reset multiple delivery promises */
    resetLieferzusagen: (lieferzusagenGuids: string[]) => Promise<string>;
    /** Reset delivery promises by serie */
    resetLieferzusagenBySerie: (serieGuid: string, lieferant?: string) => Promise<void>;
    gesamt: { getAll: (stichTag?: Date) => Promise<GesamtLieferzusageDTO[]>; save: (dto: GesamtLieferzusageDTO) => Promise<void>; saveListe: (dtoSet: GesamtLieferzusageDTO[]) => Promise<string>; serieBuchen: (serieGuid: string) => Promise<void>; delete: (gesamtLieferzusageGuid: string) => Promise<void>; deleteListe: (gesamtLieferzusagenGuids: string[]) => Promise<string> };
};

/** Lieferungstyp enum values */
export type Lieferungstyp = 0|1|2;

export type LieferzusageDTO = {
    LieferzusageGuid: string;
    MaterialBedarfGuid: string;
    Stueckzahl: number;
    Laufmeter: number;
    Lieferant: string;
    Version: number;
    ChangedDate: Date;
};

/**
 * Dual-purpose translation entry point: pass a **key** to translate a string,
 * pass a **DOM node** to use it as a Svelte action (`use:localize`).
 *
 * ```js
 * localize("Speichern");                       // -> "Save"
 * localize("{n} Treffer", { n: 3 });           // placeholders
 * ```
 * ```svelte
 * <h2 use:localize>Persönliche Daten</h2>
 * <button title="Kopieren" use:localize data-i18n="title">…</button>
 * ```
 */
export type Localize = {
    (key: string, params?: LocalizeParams, namespace?: string): string;
    (node: Element, options?: LocalizeActionOptions): LocalizeActionHandle;
};

/** Return value of the `use:localize` action (a Svelte action handle). */
export type LocalizeActionHandle = {
    /** Re-translate with new options (called by Svelte when the parameter changes). */
    update: (options?: LocalizeActionOptions) => void;
    /** Detach from language/catalog changes. */
    destroy: () => void;
};

/**
 * Options for the `use:localize` action.
 *
 * Without options the action translates the element's own text nodes (child
 * elements are left untouched) and every attribute listed in the element's
 * `data-i18n` attribute, using each attribute's current value as the key.
 * These fields cover everything that cannot be written statically in markup.
 */
export type LocalizeActionOptions = {
    /** Key for the whole text content (replaces it). */
    text?: string;
    /** Like `text`, but the translation contains markup. */
    html?: string;
    /** Values for `{placeholder}` markers in text, html and attributes. */
    params?: LocalizeParams;
    /** Attribute name -> key, for dynamic attribute values. */
    attrs?: Record<string, string>;
    /** Namespace to look in first (defaults to the endpoint's namespace, otherwise `shell`). */
    ns?: string;
};

/** Values for `{placeholder}` markers inside a translated text. */
export type LocalizeParams = Record<string, string | number>;

export type LoginAttemptDTO = {
    UserGuid: string;
    FailCount: number;
    /** ISO date string */
    RequestTime: string | null;
};

export type LoginAttemptResultDTO = {
    FailCount: number;
    /** ISO date string */
    LastFailedLogin: string | null;
};

export type LoginDTO = {
    Email: string;
    Password: string;
    Mandant: string;
    AppToken: string;
};

export type MailApi = {
    /** Send mail */
    send: (job: MailJobInfo, attachments?: string[]) => Promise<JobStatusResponseDTO>;
    /** Get mail status */
    getStatus: (guid: string) => Promise<JobStatusEntryDTO[]>;
};

export type MailJobInfo = {
    /** UUID */
    JobGuid: string;
    ToAddresses: Array<string>;
    CCAddresses: Array<string>;
    ReplyToAddress: string;
    Subject: string;
    Content: string;
    /** UUID */
    BelegGuid: string;
};

export type MandantAndBelegPosGuidDTO = {
    MandantId: number;
    /** UUID */
    BelegPositionGuid: string;
};

export type MandantApi = {
    /** Sync mandanten list */
    abgleichen: (list: MandantDTO[]) => Promise<MandantDTO[]>;
    /** Create mandant */
    anlegen: (mandant: MandantDTO) => Promise<MandantDTO>;
    /** Load mandanten with filter */
    ladenMitFilter: (filter: string) => Promise<MandantDTO[]>;
    admin: { ladenMitFilter: (filter: string, onlyHaendler: boolean, onlyProduzenten: boolean) => Promise<MandantDTO[]>; laden: (guid: string) => Promise<MandantDTO>; umziehen: (mandantGuid: string, zielMandantGuid: string) => Promise<void>; addAdminRechte: (email: string) => Promise<void> };
    app: { getStatusByKunde: (kundeGuid: string) => Promise<AppActivationStatusDTO>; setStatusByKunde: (data: AppActivationStatusDTO) => Promise<AppActivationStatusDTO>; getAll: () => Promise<MandantDTO[]>; getBenutzerByKunde: (kundeGuid: string) => Promise<BenutzerDTO[]>; createOrUpdateBenutzer: (kundeGuid: string, data: BenutzerDTO, pwSenden?: boolean, passwort?: string) => Promise<BenutzerDTO>; deleteBenutzer: (kundeGuid: string, data: BenutzerDTO) => Promise<void>; aktiviere: (adminEmail: string) => Promise<void> };
};

export type MandantDTO = {
    /** Name des Mandanten */
    Name: string;
    /** Beschreibung des Mandanten */
    Beschreibung: string;
    /** ISO date string */
    ErstellDatum: string;
    /** ISO date string */
    AenderungsDatum: string;
    /** E-Mail des Administrators */
    AdminEmail: string;
    /** Eindeutige GUID des Mandanten */
    MandantGuid: string;
    /** SIC CMS Producer ID */
    SIC_CMS_Producer_Id: number;
    /** Dongle-Nummer */
    DongleNummer: string;
    /** GUID des Produzentenmandanten */
    ProduzentMandantGuid: string;
    /** Kundennummer beim Produzenten */
    KundenNummerBeimProduzenten: string;
    /** Gibt an, ob der Mandant aktiv ist */
    IstAktiv: boolean;
    /** Gibt an, ob es sich um einen Händler handelt */
    IstHaendler: boolean;
    /** Gibt an, ob es sich um einen Produzenten handelt */
    IstProduzent: boolean;
    /** Erbt Auswahl ohne Sprosse */
    ErbtAuswahlOhneSprosse: boolean;
    /** Stammdatenbearbeitung gesperrt */
    StammdatenbearbeitungGesperrt: boolean;
    /** Neher Kundennummer */
    NeherKundennummer: string;
};

export type MandantFreigabeDTO = {
    /** Freigabecode */
    Code: string;
    /** ISO date string */
    GueltigAb: string;
    /** Freigabelevel */
    Level: FreigabeLevel;
    /** Freigabeart */
    Art: FreigabeArt;
    /** Zusätzliche Daten */
    ZusatzDaten: string;
};

export type MaterialApi = {
    /** Get all materials */
    getAll: () => Promise<MaterialDTO[]>;
    /** Save a material */
    saveMaterial: (material: MaterialDTO) => Promise<void>;
};

export type MaterialBearbeitungsMethodeDTO = {
    /** UUID */
    MaterialBearbeitungsMethodeGuid: string;
    Bezeichnung: string;
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

/**
 * Represents optimization output for one material item.
 * Keys and values are backend-defined and may vary by optimization strategy.
 */
export type MaterialbedarfCutOptimization = Record<string, any>;

export type MaterialbedarfDTO = {
    MaterialBedarfGuid: string;
    /** Eindeutiges Kennzeichen des Items (aus GUID) */
    Kennzeichen: string;
    InternerName: string;
    /** InternerName wird derzeit an vielen Stellen verwendet weshalb wir jetzt die Backup Property hinzufügen welche den echten InternenNamen aus dem Modell beinhaltet */
    InternerName_Backup: string;
    /** Neher-Katalognummer des Artikels */
    KatalogNummer: string;
    /** Artikelbezeichnung */
    Bezeichnung: string;
    /** Einheit des Artikels (lfm=Laufmeter, Stk=Stück, qm=Quadratmeter) */
    Einheit: string;
    Beipacken: boolean;
    /** Vorgangsnummer die gesetzt ist, wenn es sich um Sonderfarbartikel handelt die nicht zusammengefasst wurden. */
    Vorgangsnummer: string;
    /** Anzahl des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Laufmeter!) */
    Stueckzahl: number;
    /** Laufmeter des Artikels (gleiche Artikel werden per Standard nicht zusammengefasst; schließt sich aus mit Stückzahl!) */
    Laufmeter: number;
    IstVE: boolean;
    VE_Menge?: number;
    /** FarbBezeichnung (Bezeichnung der Farbe) */
    FarbBezeichnung: string;
    /** FarbZusatzText, hauptsächlich für (Trend-)Farbkürzel (z.B. B7) */
    FarbZusatzText: string;
    /** FarbeKuerzel (Neher-Kürzel oder Sonderfarbton) */
    FarbKuerzel: string;
    FarbKuerzelGuid: string;
    /** FarbeCode der Farbe */
    FarbCode: string;
    FarbeItem: string;
    FarbItemGuid: string;
    OberflaecheBezeichnung: string;
    OberFlaecheGuid: string;
    PulverCode: string;
    /** Kennzeichen für Zuschnittartikel */
    IstZuschnitt: boolean;
    ZuschnittLaenge: number;
    ZuschnittWinkel: string;
    PositionsAngabe: string;
    MaterialBezeichnung: string;
    MaterialBearbeitungSaegen: boolean;
    MaterialBearbeitungFraesen: boolean;
    MaterialBearbeitungStanzen: boolean;
    MaterialBearbeitungBeschichten: boolean;
    MaterialBearbeitungBohren: boolean;
    MaterialBearbeitungEloxieren: boolean;
    AufPackListe: boolean;
    CADKennung: string;
    EtikettenSonderS: string;
    IndiSonderInfo1: string;
    IndiSonderInfo2: string;
    IndiSonderInfo3: string;
    PIText: string;
    SchraegElement: boolean;
    SonderFormInfo: string;
    ZusatzEtikettText: string;
    AufMaterialListe: boolean;
    NurLieferscheinAnzeige: boolean;
    FromSonderWunsch: boolean;
    IstBeschichtbar: boolean;
    KatalogArtikelArt: KatalogArtikelArt;
    AktuellerStatus: MaterialbedarfStatiDTO;
    /** Kennzeichen, ob das Profil gedreht gesägt wird (z.B. bei PT2/46) */
    ProfilGedrehtSaegen: boolean;
    IstSonderfarbe: boolean;
    MaterialPCode: string;
    Bemerkung: string;
    AVPositionGuid?: string;
    ZielKennzeichen: string;
    AblageGuid?: string;
    AblageFachGuid?: string;
    Lagerfach: string;
};

export type MaterialbedarfExportSettingsDTO = {
    NeherArtikelStandardFarbe: MaterialbedarfExportType;
    NeherArtikelTrendFarbe: MaterialbedarfExportType;
    NeherArtikelSonderFarbe: MaterialbedarfExportType;
    UeberschriebenerArtikelStandardFarbe: MaterialbedarfExportType;
    UeberschriebenerArtikelTrendFarbe: MaterialbedarfExportType;
    UeberschriebenerArtikelSonderFarbe: MaterialbedarfExportType;
    EigenArtikelStandardFarbe: MaterialbedarfExportType;
    EigenArtikelTrendFarbe: MaterialbedarfExportType;
    EigenArtikelSonderFarbe: MaterialbedarfExportType;
    CsvExportCombinations: CsvExportCombinationDTO[];
    WriteLieferzusageOnCsvExport: boolean;
};

/** MaterialbedarfExportType enum values */
export type MaterialbedarfExportType = ('CSV'|'Schnittstelle');

export type MaterialbedarfExportUserSettings = {
    CsvExportPath: string;
};

/** MaterialBedarfLogik enum values */
export type MaterialBedarfLogik = ('Serienbezogen'|'Stichtagbezogen');

export type MaterialbedarfStatiDTO = ('Unbekannt'|'Angefragt'|'Beschafft'|'NachSaege'|'NachSLK'|'Abgeschlossen');

export type MaterialBestellungListItemDTO = BaseListItemDTO;

export type MaterialDTO = {
    MaterialGuid: string;
    Bezeichnung: string;
    IstSaegbar: boolean;
    IstBeschichtbar: boolean;
    IstFaerbbar: boolean;
    ChangedDate: Date;
    Version: number;
    MoeglicheBearbeitungsMethoden: Array<string>;
};

/** Handler invoked with the full message envelope. */
export type MessageHandler = (message: NeherMessage) => void;

export type NachrichtenDTO = {
    /** UUID */
    NachrichtGuid: string;
    /** UUID */
    MandantGuid: string;
    /** UUID */
    BesitzerMandantGuid: string;
    Context: string;
    Nachricht: string;
    IstAktiv: boolean;
    /** ISO date string */
    GueltigAb: string | null;
    /** ISO date string */
    GueltigBis: string | null;
};

export type NeherApp3 = {
    /** Adds a menu item. If an item with the same `id` already exists it is replaced. */
    addMenuItem: (menuItem: NeherApp3MenuItem) => void;
    /** Updates properties of an existing menu item by `id`. Only keys present in `patch` are changed; the `id` is preserved. Returns `true` if the item existed. Relative icon URLs are resolved against the module's base URL. */
    updateMenuItem: (id: string, patch: Partial<NeherApp3MenuItem>) => boolean;
    /** Removes the menu item with the given `id`. Returns `true` if an item was removed. */
    removeMenuItem: (id: string) => boolean;
    addApp: (appModule: NeherApp3Module | string) => Promise<void>;
    /** Shows a notification. Type defaults to 0 (info). Callback is optional. */
    notify: (message: string, type?: NeherApp3NotifyType, cb?: Function) => void;
    api: NeherApp3ApiCollection;
    /** In-realm message bus for module-to-module communication. */
    messages: NeherApp3Messages;
    /** Localization: register a module's translation catalog, translate, switch language, sort language-aware. */
    i18n: NeherApp3I18n;
    /** Shorthand for `i18n.localize` (namespace `shell`): a function for strings, a `use:` action for elements. */
    localize: Localize;
    /** Per-user settings, stored in the database (not `localStorage`). */
    settings: NeherApp3Settings;
    /** The signed-in user: identity from the IDAS token plus the platform's own profile fields (avatar, job title, …). */
    profile: NeherApp3Profile;
    /** Light/dark mode: the active theme, the stored preference, and a subscription for theme changes. */
    theme: NeherApp3Theme;
    /** Indicates if the app is embedded inside i3 */
    isEmbedded: boolean;
};

export type NeherApp3ApiCollection = {
    idas?: IDASFluentApi;
    hostingEnvironment?: FluentApi;
};

/**
 * Localization, exposed at `neherapp3.i18n`.
 *
 * German is the source language and **the key is the German text**
 * (`localize("Speichern")`); a missing translation falls back to the key, so an
 * untranslated UI is never broken, just German. There is therefore no `de`
 * catalog. The shell carries only its own texts (namespace `shell`); every
 * module registers its own catalog under its module name.
 */
export type NeherApp3I18n = {
    /** Register a namespace's translation tables. */
    register: (namespace: string, translations?: TranslationCatalogs) => NeherApp3I18nEndpoint;
    /** Translate a key, or translate an element via `use:localize`. */
    localize: Localize;
    /** Is there a real translation for the key? */
    has: (key: string, namespace?: string) => boolean;
    /** Compare two **display texts** with the collator of the active language. */
    compare: (a: string, b: string) => number;
    /** Sorted copy, ordered by the **translated** text (translate first, then sort). */
    sort: <T>(items: readonly T[], selector?: (item: T) => string) => T[];
    /** Switch the language and persist the choice. */
    setLocale: (code: string) => void;
    /** Listen for language changes (for consumers without Svelte reactivity); returns an unsubscribe function. */
    onLocaleChange: (listener: (locale: string) => void) => (() => void);
    /** The source language — the keys themselves are texts in this language (`"de"`). */
    sourceLocale: string;
    /** Active language (reactive). */
    locale: string;
    /** Languages offered by the shell. */
    locales: NeherApp3LocaleInfo[];
};

/**
 * A registered translation namespace, returned by `i18n.register`. `register`
 * is idempotent; each handle's `dispose` only removes the tables added through
 * it. Lookups fall back to the shell catalog, so shared terms such as
 * "Speichern" need not be translated again per module.
 */
export type NeherApp3I18nEndpoint = {
    /** The namespace of this handle (usually the module name). */
    namespace: string;
    /** Translate in this namespace: as a function for script code, as a `use:` action for markup. */
    localize: Localize;
    /** Add further tables later (e.g. lazily loaded language files). */
    add: (translations: TranslationCatalogs) => void;
    /** Is there a real translation (not just the key)? */
    has: (key: string) => boolean;
    /** Remove exactly the tables registered through this handle. */
    dispose: () => void;
};

/** A language offered by the shell. */
export type NeherApp3LocaleInfo = {
    /** BCP-47 code, e.g. `de`, `de-x-du`, `en`. */
    code: string;
    /** Display name in its own language. */
    label: string;
};

export type NeherApp3MenuItem = {
    /** Unique identifier for the menu item (auto-generated if not provided) */
    id?: string;
    /** Indicates if the menu item is currently selected (managed by the menu system) */
    selected?: boolean;
    /** URL to an icon */
    icon?: string;
    /** Whether the icon adapts to the active theme (monochrome icons are inverted in dark mode via the host's `icon-adaptive` styling). Default `true`; set `false` for coloured/branded icons that must stay unchanged. */
    iconAdaptive?: boolean;
    /** Relative URL to use for routes */
    url?: string | null;
    /** Display text (ignored for separator items) */
    text?: string;
    /** Parent menu item (optional). If not set, the item will be added to the top level menu. */
    parent?: string | null;
    /** If true, the menu item will not be displayed */
    hidden?: boolean;
    /** If true, renders as a non-interactive divider between items (text/icon/url are ignored). Use `parent` to place the separator inside a sub-menu. */
    separator?: boolean;
    /** If true, renders `text` as a non-interactive group heading inside a sub-menu (ALL CAPS, bold, extra space above; icon/url are ignored). Requires `parent`; ignored on the top level. `text` is translated like any other entry. */
    heading?: boolean;
    /** Catalog in which `text` is translated. Set automatically to the registering module's name; only pass it explicitly for items added outside `setup`. See `NeherApp3I18n`. */
    i18nNamespace?: string;
};

/**
 * In-realm message bus for module-to-module communication, exposed at
 * `neherapp3.messages`. Messaging, not RPC: `send`/`broadcast` return delivery
 * information, never a handler's result.
 *
 * Topics the shell itself broadcasts: `i18n.localeChanged` with payload
 * `{ locale: string }` (sent with `retain: true`, so late subscribers receive
 * the current language as well).
 */
export type NeherApp3Messages = {
    /** Register a module as an endpoint; all sending goes through it. */
    register: (moduleName: string) => Endpoint;
    /** Does the module have at least one live handler? */
    isReachable: (moduleName: string) => boolean;
};

export type NeherApp3Module = {
    moduleName: string;
    setup?: (context: NeherApp3SetupContext) => void | Promise<void>;
    /** Must return an optional unmount function. `props` is the setup context plus the route's hash parameters (see `NeherApp3MountProps`). `node` sits inside the shell's content area, a size container named `content` whose width depends on the navigation layout (sidebars vs. menu flyout), not only on the viewport: lay out with container queries (`@container content (…)`, Tailwind `@3xl/content:`), not viewport breakpoints. */
    mount?: (node: HTMLElement, props: NeherApp3MountProps) => void | Function;
    embedUrl?: string;
    extraCSS?: string[];
    /** If true, the app will be embedded in a shadow DOM. This is required for CSS isolation. The module then ships all of its styles itself — including **both** themes (`neher`, `neher-dark`), because the shell mirrors `data-theme` onto the module's root inside the shadow root (see `NeherApp3Theme`). Shell-wide base rules do not reach the shadow root either — e.g. the `option` colours that keep native `<select>` popups readable in dark mode. */
    useShadowDom?: boolean;
};

/**
 * What `mount` receives: the setup context plus the route's hash parameters as
 * strings (`#my-module/key:value` → `props.key === "value"`). A parameter that
 * is not in the URL is `undefined`.
 */
export type NeherApp3MountProps = NeherApp3SetupContext & { [param: string]: string | undefined };

export type NeherApp3NotifyType = 0 | 1 | 2;

/**
 * The signed-in user, exposed at `neherapp3.profile`.
 *
 * Two sources in one place: identity comes from the IDAS token (user id, login
 * name, e-mail, roles, rights), the remaining fields from the platform's own
 * profile table — above all the avatar, which IDAS does not carry.
 *
 * Read-only and reactive: the local fields arrive shortly after start and are
 * edited in the framework's settings, not by a module. The same object carries
 * the lookup of *other* users' profiles (`byEmail`, `byEmails`, `byUserId`) —
 * the way to put a name and a face next to a user id in a list.
 */
export type NeherApp3Profile = {
    /** `benutzerGuid` from the token. */
    userId: string;
    /** Login name (`id` claim). */
    userName: string;
    /** E-mail address from the token. */
    email: string;
    /** Roles from the token. */
    roles: string[];
    /** Rights from the token. */
    rights: string[];
    /** Best available name: the self-chosen one, otherwise the token's. */
    displayName: string;
    /** Up to 3 characters: self-chosen, otherwise derived from the name. */
    initials: string;
    /** The avatar as a data URL, or `null` when none is stored. */
    avatar: string | null;
    /** Job title / function. */
    jobTitle: string | null;
    /** Department. */
    department: string | null;
    /** Site / plant. */
    location: string | null;
    /** Mobile number (IDAS carries only one phone number). */
    mobile: string | null;
    /** `true` once the local profile has been fetched. */
    loaded: boolean;
    /** Fetch the local profile again. */
    reload: () => Promise<void>;
    /** The profile of another user by e-mail address; `null` when this platform does not know them. Calls made close together are coalesced into one request and cached for the session. */
    byEmail: (email: string) => Promise<NeherApp3PublicProfile | null>;
    /** The profiles of several users; unknown addresses are absent from the result. */
    byEmails: (emails: string[]) => Promise<NeherApp3PublicProfile[]>;
    /** The profile of another user by their `benutzerGuid`. */
    byUserId: (userId: string) => Promise<NeherApp3PublicProfile | null>;
    /** Discard the cached profiles, so the next lookup asks again. */
    clearCache: () => void;
};

export type NeherApp3Props = {
    api: FluentApi;
    authManager?: FluentAuthManager;
    idas: IDASFluentApi;
    mainCssPath?: string;
};

/**
 * The profile of *another* user, as returned by `profile.byEmail` and friends.
 *
 * Identity comes from the platform's user table — whoever has signed in here at
 * least once; the remaining fields are filled in only where that user curated
 * them.
 */
export type NeherApp3PublicProfile = {
    /** The user's `benutzerGuid`. */
    userId: string;
    /** Login name. */
    userName: string;
    /** E-mail address. */
    email: string;
    /** Self-chosen name shown in the interface. */
    displayName: string | null;
    /** Self-chosen initials, up to 3 characters. */
    initials: string | null;
    /** Job title / function. */
    jobTitle: string | null;
    /** Department. */
    department: string | null;
    /** Site / plant. */
    location: string | null;
    /** Mobile number. */
    mobile: string | null;
    /** The avatar as a data URL, or `null` when none is stored. */
    avatar: string | null;
    /** When the avatar was last uploaded. */
    avatarUpdatedAt: string | null;
};

/**
 * User settings, exposed at `neherapp3.settings`.
 *
 * The store is the **database**, not `localStorage`: inside the i3 WebView
 * `localStorage` is ephemeral and would lose every setting on each start. A
 * setting is addressed by namespace and key, both lower case; `shell` belongs
 * to the framework, every module uses its own namespace — the same one it uses
 * for `i18n.register`. Values are arbitrary JSON.
 *
 * Reads are reactive. Writes are applied locally at once and sent to the
 * server after a short coalescing delay, so call `flush()` before a reload.
 */
export type NeherApp3Settings = {
    /** Namespace of the framework (`"shell"`). */
    scope: string;
    /** `true` once the values from the database have arrived. */
    loaded: boolean;
    /** Settings handle bound to a module's namespace. */
    register: (namespace: string) => NeherApp3SettingsHandle;
    /** Value of a setting, or `fallback`. Reactive. */
    get: (scope: string, key: string, fallback?: any) => any;
    /** Store a value. */
    set: (scope: string, key: string, value: unknown) => void;
    /** Drop a setting. */
    remove: (scope: string, key: string) => void;
    /** All settings of one namespace. */
    all: (scope: string) => Record<string, unknown>;
    /** Write pending changes now. Call before a reload. */
    flush: () => Promise<void>;
};

/**
 * Settings handle of a single namespace — what
 * `neherapp3.settings.register("my-module")` returns.
 */
export type NeherApp3SettingsHandle = {
    /** The bound namespace (lower case). */
    namespace: string;
    /** Value of a setting, or `fallback`. Reactive. */
    get: (key: string, fallback?: any) => any;
    /** Store a value: applied locally at once, sent to the server coalesced. */
    set: (key: string, value: unknown) => void;
    /** Drop a setting; the user is back to its default. */
    remove: (key: string) => void;
    /** All settings of this namespace. */
    all: () => Record<string, unknown>;
    /** Write pending changes now. Call before a reload. */
    flush: () => Promise<void>;
};

export type NeherApp3SetupContext = NeherApp3Props & { neherapp3: NeherApp3 };

/**
 * Theme handle, exposed at `neherapp3.theme`.
 *
 * The shell writes the resolved theme name to `data-theme` on `<html>`, so
 * anything in the light DOM follows it by inheritance. **Inside a Shadow DOM
 * module it does not**: an attribute selector never crosses the shadow
 * boundary, and the module's own `:host` rules override the inherited custom
 * properties — a module built with the shell's daisyUI setup would stay light
 * forever. The shell therefore mirrors `data-theme` onto the module's root
 * element inside the shadow root and keeps it in sync; a module only needs to
 * ship both themes (`neher`, `neher-dark`) in its stylesheet.
 *
 * `subscribe` is for consumers without Svelte reactivity (and for reacting to
 * a switch, e.g. to repaint a canvas or reload a themed asset).
 */
export type NeherApp3Theme = {
    /** Active, resolved theme name (reactive). */
    current: NeherApp3ThemeName;
    /** Stored choice, including `"system"` (reactive). */
    preference: NeherApp3ThemePreference;
    /** Shorthand for `current === "neher-dark"` (reactive). */
    isDark: boolean;
    /** Store a preference and apply it. */
    set: (preference: NeherApp3ThemePreference) => void;
    /** Switch light/dark as an explicit choice (replaces `"system"`). */
    toggle: () => void;
    /** Listen for theme changes; called immediately with the current theme, returns an unsubscribe function. */
    subscribe: (listener: (theme: NeherApp3ThemeName) => void) => (() => void);
    /** Theme name of the light mode. */
    LIGHT: "neher";
    /** Theme name of the dark mode. */
    DARK: "neher-dark";
    /** Preference "follow the operating system". */
    SYSTEM: "system";
};

/** Resolved theme name — the value of the `data-theme` attribute. */
export type NeherApp3ThemeName = "neher" | "neher-dark";

/**
 * Stored theme choice: a theme name, or `"system"` to follow
 * `prefers-color-scheme` live.
 */
export type NeherApp3ThemePreference = NeherApp3ThemeName | "system";

/** A single message envelope delivered to handlers. */
export type NeherMessage = {
    /** Unique message id (`crypto.randomUUID`). */
    id: string;
    /** Message kind, e.g. `"artikel.selected"`. */
    type: string;
    /** Target: module name, a server address (`user:…`, `app:…`, `bot:…`) or `null` (broadcast). */
    to: string | null;
    /** Sender, always stamped: the module name locally; from the server `user:<guid>/app:<module>`, `bot:<name>`, `service/app:<module>` (an app backend sending with an IDAS ServiceToken) or `system`. */
    from: string | null;
    /** JSON-serializable payload. */
    payload: any;
    /** Timestamp (`Date.now`). */
    ts: number;
};

export type OberflaecheDTO = {
    OberflaecheGuid: string;
    Bezeichnung: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
    Version: number;
    ChangedDate: string;
};

export type OperationsPunktDTO = {
    OperationsPunktGuid: string;
    Name: string;
    X: number;
    Y: number;
    Z: number;
    Kommentar: string;
    Version: number;
    ChangedDate: Date;
};

export type PasswortAendernDTO = {
    Benutzername: string;
    AltesPasswort: string;
    NeuesPasswort: string;
};

export type PCodeStatistikDTO = {
    MandantGuid: string;
    MandantName: string;
    UsedPCodes: number;
};

export type PersonDTO = {
    /** Eindeutige GUID */
    PersonGuid: string;
    /** Nachname der Person */
    Nachname: string;
    /** Vorname/Rufname der Person */
    Vorname: string;
    /** evtl. weitere Vornamen */
    WeitereVornamen: string;
    /** Geburtstag */
    Geburtstag: Date|null;
    Briefanrede: string;
    Anrede: string;
    Mailadresse: string;
    Telefonnummer: string;
    MobileTelefonnummer: string;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    /** Inaktiv Kennzeichen */
    IstInaktiv: boolean;
};

export type PositionsDatenDTO = object;

export type PositionSerieItemDTO = {
    BelegPositionGuid: string;
    Position: string;
    Menge: number;
    Vorlauf: number;
    SerieAuslastung: string;
    SerieGuid: string;
    /** ISO date string */
    ProduktionsDatum: string;
    /** ISO date string */
    LieferDatum: string;
    PositionInfo: string;
    KapBedarf: number;
    KapBedarfGes: number;
    HatNachfolgeBelegPosition: boolean;
    /** currently only used in client */
    VeschiedeneSerien: boolean;
    /** only set when VeschiedeneSerien is true */
    SerienGuids: string[] | null;
};

export type PreisermittlungsEinstellungenDTO = {
    WaehrungsSymbol: string;
    WaehrungsFaktor: number;
    SteuerSatz: number;
    EndpreisRundungsModus: string;
    SonderfarbZuschlaege: string;
    BruttoPreisErmitteln: boolean;
    /** Dictionary with UUID keys */
    AufpreisAnpassungen: Record<string, AufpreisAnpassungDTO[]>;
    /** Dictionary with UUID keys */
    PreisfaktorAnpassungen: Record<string, number>;
    /** Dictionary with UUID keys */
    ZuschnittpreisfaktorAnpassungen: Record<string, number>;
    /** Dictionary with UUID keys */
    AufpreisfaktorAnpassungen: Record<string, number>;
    /** Dictionary with UUID keys */
    GrenzfreigabeAnpassungen: Record<string, boolean>;
    MbAufpreis: number;
    Mb_v_Fix_Aufpreis: number|null;
    Mb_Klebeband_Aufpreis: number|null;
    /** ISO 8601 date string */
    ChangedDate: string;
};

export type PrintApi = {
    /** Generate PDF for beleg */
    pdfErzeugen: (belegGuid: string) => Promise<Uint8Array>;
    /** Generate XPS for beleg */
    xpsErzeugen: (belegGuid: string) => Promise<Uint8Array>;
    /** Generate PDF v2 */
    pdfV2: (belegGuid: string, email: string) => Promise<Uint8Array>;
    /** Load letterhead */
    briefbogenLaden: () => Promise<Uint8Array>;
};

export type ProduktFamilieDTO = {
    ProduktFamilieGuid: string;
    ProduktGruppeGuid: string;
    WarengruppenGuid: string;
    Bezeichnung: string;
    PreisErmittlung: string;
    StandardFarbe: string;
    KurzBezeichnung: string;
    HatRabatt2: boolean;
    HatRabatt3: boolean;
    Varianten: Array<VarianteDTO>;
    StandardFarbKuerzelGuids: Array<string>;
    ErsatzFarbZuordnungen: Array<ProduktFamilieErsatzFarbZuordnungDTO>;
    ChangedDate: string;
    Version: number;
};

export type ProduktFamilieErsatzFarbZuordnungDTO = {
    ProduktFamilieErsatzFarbZuordnungGuid: string;
    ChangedDate: string;
    Version: number;
    FarbItemGuid: string;
    ErsatzFarbItemGuid: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
};

export type ProduktFamilieFarbZuordnungDTO = {
    Kuerzel: string;
    ProduktFamilieFarbZuordnungGuid: string;
    ChangedDate: string;
    Version: number;
    FarbItemGuid: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
};

export type ProduktFamilienDTOListe = Array<ProduktFamilieDTO>;

export type ProduktGruppeDTO = {
    /** UUID */
    ProduktGruppeGuid: string;
    KurzBezeichnung: string;
    Bezeichnung: string;
    ProduktSerien: Array<ProduktFamilieDTO>;
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type ProduktionApi = {
    /** Calculate production for position */
    produktionBerechnen: (belegPositionsGuid: string) => Promise<string>;
    /** Get production for position */
    getProduktion: (belegPositionsGuid: string) => Promise<BearbeitungDTO[]>;
    /** Get material requirements for position */
    getMaterialBedarf: (belegPositionsGuid: string) => Promise<MaterialbedarfDTO[]>;
    /** Add production release */
    addProduktionsfreigabe: (dto: BelegartWechselDTO) => Promise<VorgangDTO>;
    /** Run production release web job */
    produktionsfreigabeWebJob: () => Promise<void>;
    /** Get all production release items */
    getAllProduktionsfreigabeItems: () => Promise<ProduktionsfreigabeItemDTO[]>;
    /** Get production release info for belege */
    getProduktionsfreigabeInfo: (belegGuids: string[]) => Promise<Record<string, Date>>;
    /** Get all production statuses */
    getAllProduktionsStatus: () => Promise<ProduktionsStatusDTO[]>;
    /** Get production status by GUID */
    getProduktionsStatus: (guid: string) => Promise<ProduktionsStatusDTO>;
    /** Save production status */
    saveProduktionsStatus: (status: ProduktionsStatusDTO) => Promise<void>;
    /** Save production status history */
    saveProduktionsStatusHistorie: (avGuid: string, historie: ProduktionsStatusHistorieDTO) => Promise<void>;
    /** Get production info for vorgang */
    getProduktionsInfo: (vorgangGuid: string) => Promise<ProduktionsInfoDTO>;
    /** Calculate IBOS1 production */
    ibos1ProduktionBerechnen: (belegPositionsGuid: string) => Promise<string>;
    /** Test IBOS1 position */
    ibos1PositionTesten: (belegPositionsGuid: string) => Promise<string>;
    /** Get IBOS1 production */
    getIbos1Produktion: (guid: string) => Promise<string>;
};

export type ProduktionProduktfamilieSettingsDTO = {
    GroupName: string;
    ProduktfamilienName: string;
    SprossenFrei: boolean;
    Vorbiegen: boolean;
    MoeglicheVariantenVorbiegen: string[];
    Buerste: string;
    FederkraftErhoeht: boolean;
    IndividuelleSeitenarretierung: boolean;
    HoeheFuerSeitenarretierung: number|null;
};

/** Produktionsdaten für ein Fertigelement */
export type ProduktionsDatenDTO = {
    /** Eindeutige ID */
    ProduktionsDatenGuid: string;
    /** Gesamtliste des benötigten Materials (immer für Stückzahl 1) */
    Material: Array<MaterialbedarfDTO>;
    /** Produktionsetiketten */
    Etiketten: Array<EtikettDTO>;
    /** CNC-Bearbeitungen */
    Bearbeitungen: Array<BearbeitungDTO>;
    /** Daten der Original-Belegposition */
    PositionsDaten: PositionsDatenDTO;
    Sonderwuensche: Array<SonderwuenscheDTO>;
    Log: Array<string>;
};

export type ProduktionsfreigabeItemDTO = {
    VorgangGuid: string;
    VorgangsNummer: number;
    BelegGuid: string;
    Belegdatum: Date;
    FreigabeDatum: Date;
    Kundenname: string;
    Kommission: string;
    Besitzer: string;
    Besteller: string;
    Bearbeiter: string;
    ProduktionsInfos: ProduktionsInfoDTO;
};

export type ProduktionsInfoBelegDTO = {
    BelegGuid: string;
    /** z.B. 'AB vom 17.07.2021' */
    BelegTitel: string;
    ErstellDatum: Date;
    PositionenInfos: Array<ProduktionsInfoBelegPositionDTO>;
};

export type ProduktionsInfoBelegPositionAVDTO = {
    AvBelegPositionGuid: string;
    PCode: string;
    ZugeodneteSerie?: string;
    ZugeodneteSerieName: string;
    AktuellerStatus: ProduktionsStatiWerteDTO;
    IstFuerAVBereitgestellt: boolean;
    IstAVBerechnet: boolean;
    IstAVAbgeschlossen: boolean;
    IstSerieZugeordnet: boolean;
    IstInProduktion: boolean;
    IstProduktionAbgeschlossen: boolean;
    IstVersandVorbereitung: boolean;
    IstVersandAbgeschlossen: boolean;
    IstProduktionUnterbrochen: boolean;
    IstFehler: boolean;
    AktuelleProzent: number;
    AktuellerText: string;
    GesamtMinuten: number;
    Historie: Array<ProduktionsStatusHistorieDTO>;
};

export type ProduktionsInfoBelegPositionDTO = {
    BelegPosGuid: string;
    NachfolgeBelegPosGuid: string;
    BelegPositionsNummer: number;
    VariantenName: string;
    Katalognummer: string;
    Menge: number;
    BelegPositionInfos: string;
    SerieGuid?: string;
    IstGeplanteSerie: boolean;
    SerieName: string;
    IsAktiv: boolean;
    IstAlternativPosition: boolean;
    LieferDatum?: Date;
    ProduktionsDatum?: Date;
    AvBelegPositionenInfos: Array<ProduktionsInfoBelegPositionAVDTO>;
};

export type ProduktionsInfoDTO = {
    VorgangsNummer: number;
    VorgangsGuid: string;
    BelegInfos: Array<ProduktionsInfoBelegDTO>;
};

export type ProduktionsSettingsDTO = {
    ProduktionProduktfamilieSettingList: ProduktionProduktfamilieSettingsDTO[];
    /** Aktiviert Sprossenfrei global. Die Produktionsberechnung prüft sowohl SprossenfreiEnabled als auch die Aktivierung in der jeweiligen Produktfamilie. Wenn gesetzt, ist außerdem die Bearbeitung der Familien-Settings erlaubt. */
    SprossenfreiEnabled: boolean;
    /** Aktiviert Vorbiegen global. Die Produktionsberechnung prüft sowohl VorbiegenEnabled als auch die Aktivierung in der jeweiligen Produktfamilie. Wenn gesetzt, ist außerdem die Bearbeitung der Familien-Settings erlaubt. */
    VorbiegenEnabled: boolean;
    VorbiegenSprossenfrei: string;
    IstAusserhalbGewaehrleistung: string;
    VorbiegenGrenzwert: string;
    SonderGewebe: string[];
    SaegedatenAufEtiketten: boolean;
    PacklistenEtikettenZusammengefasst: boolean;
    EtikettSerienkennzeichen: string;
    PackEtikettSerienkennzeichen: string;
    PrintPCode: boolean;
    PrintPCodeASQRCode: boolean;
    Schutzplattenmontage: boolean;
    WeisserKeder: boolean;
    SortierungMitPositionsbezug: boolean;
    HaendlerNameAufEtikett: boolean;
    HaendlerKommAufEtikett: boolean;
    VorgangKommAufEtikett: boolean;
    PositionKommAufEtikett: boolean;
    EinbauOrtAufEtikett: boolean;
    SettingsFuerHaendler: boolean;
    SaegemaßeOhneKorrektur: boolean;
    EtikettenZugehoerigkeit: boolean;
    Saegeliste4590Zusammenfassen: boolean;
    /** ISO 8601 date string */
    ChangedDate: string;
    EtikettNewStyleSonderkennzeichen: boolean;
    Buegelgriffe_10_22: boolean;
    RO4_Buerste: boolean;
    Montagelehre_ST_164802: boolean;
    Kunststoffbohrlehre_ST_164851: boolean;
    Inbussschluessel_lang_ST_170625_25: boolean;
    Schraubeckwinkel_1601: boolean;
    LI1_Sickenstanze_auf_Etikett: boolean;
    Griffmulde_ST3_134850: boolean;
    AnbauteileP2_G6: boolean;
    SP_Z_Mass_inkl_Buerstendichtung: boolean;
    SP5_Sprosse_ausklinken: boolean;
    ST3_BeidseitigeGriffleiste_GL_B: boolean;
    Gewebeeinzugsarm_122415: boolean;
    RO4_143908: boolean;
    PacklisteZusammengefasst: boolean;
    FarbersetzungsTabelleModel: string;
    Drehbandmontage: boolean;
    STmitLSo_LSu_Mbv_Mass: number;
    SP_WL_mit_Schraube_150329: boolean;
    LI_TE_Winkelprofil_mit_Schraube_150329_06: boolean;
    ProdukteMitc3Berechnen: string;
    DF4_DT4_133604: boolean;
    PT2_Griff_Innen_Knopf: boolean;
    ZR_Schraubeckwinkel: boolean;
    ZR_Verstanzen: boolean;
    ZR_Verstanzen_Mass: number|null;
    ZR_Eckwinkel: boolean;
    Magnetposition_DT3_DT6: boolean;
};

export type ProduktionsStatiWerteDTO = ('Unbekannt'|'FuerAVBereitgestellt'|'AVBerechnet'|'AVAbgeschlossen'|'SerieZugeordnet'|'InProduktion'|'ProduktionAbgeschlossen'|'VersandVorbereitung'|'VersandAbgeschlossen'|'ProduktionUnterbrochen'|'Fehler');

export type ProduktionsStatusDTO = {
    ProduktionsStatusGuid: string;
    BelegPositionAVGuid: string;
    Erstellt: Date;
    Ersteller: string;
    SerieGuid: string;
    SerieBezeichnung: string;
    AktuellerStatus: ProduktionsStatiWerteDTO;
    AktuelleProzent: number;
    AktuellerText: string;
    GesamtMinuten: number;
    Historie: Array<ProduktionsStatusHistorieDTO>;
    ChangedDate: Date;
};

export type ProduktionsStatusHistorieDTO = {
    ProduktionsStatusHistorieGuid: string;
    Status: ProduktionsStatiWerteDTO;
    Text: string;
    Produktionsminuten: number;
    ProduktionsStatusInfoText: string;
    ProduktionsStatusInProzent: number;
    Zeitstempel: Date;
    Benutzer: string;
};

export type ProduzentAktivierenDTO = {
    /** Freischaltcode */
    FreischaltCode: string;
    /** E-Mail des Administrators */
    AdminEmail: string;
    /** Dongle-Nummer */
    DongleNummer: number;
};

export type ProduzentenFarbGruppeDTO = {
    /** Eindeutige GUID */
    ProduzentenFarbGruppeGuid: string;
    /** Name der Produzentenfarbgruppe */
    Name: string;
    /** GUIDs der Oberflächen */
    Oberflaechen: string[];
    /** GUIDs der Farben */
    Farben: string[];
    /** Versionsnummer */
    Version: number;
    /** ISO date string */
    ChangedDate: string;
};

export type ProfilKuerzelDTO = {
    ProfilKuerzel: string;
    Beschreibung: string;
    VerfuegbarFuer: string[];
};

export type PropertyValueCollection = object;

export type RechnungApi = {
    /** Get all deliverable delivery notes */
    getAllAbFakturierbar: () => Promise<BelegeInfoDTO[]>;
    /** Get all printable invoices */
    getAllDruckbar: (printedSince?: Date) => Promise<BelegeInfoDTO[]>;
    /** Get all exportable invoices */
    getAllExportierbar: (exportedSince?: Date) => Promise<BelegeInfoDTO[]>;
    /** Set belege as printed */
    setBelegePrinted: (belegListe: string[]) => Promise<void>;
    /** Set belege as exported */
    setBelegeExported: (belegListe: string[]) => Promise<void>;
    /** Create invoices from delivery notes */
    erstelleRechnungen: (belegeWechsel: BelegartWechselDTO[]) => Promise<Record<string, string>>;
    sammel: { erstellen: (dto: CreateSammelrechnungDTO) => Promise<SammelrechnungListItemDTO>; getNotPrinted: (printedSince?: Date) => Promise<SammelrechnungListItemDTO[]>; getNotExported: (exportedSince?: Date) => Promise<SammelrechnungListItemDTO[]>; get: (guid: string, includeBelegDruckDTO: boolean) => Promise<SammelrechnungDTO>; getPossibleRechnungen: () => Promise<BelegeInfoDTO[]>; update: (dto: SammelrechnungDTO) => Promise<SammelrechnungDTO>; addRechnung: (belegGuid: string, sammelrechnungGuid: string) => Promise<SammelrechnungListItemDTO>; setAlsGedruckt: (guidListe: string[], setEinzel?: boolean) => Promise<void>; setAlsFibuUebergeben: (guidListe: string[], setEinzel?: boolean) => Promise<void>; search: (term: string) => Promise<SammelrechnungListItemDTO[]> };
};

/** RechnungsNummer enum values */
export type RechnungsNummer = 0|1;

export type RefreshTokenDTO = {
    Token: string;
    /** ISO date string */
    Expires: string;
    UserTokenGuid: string;
    UserToken: UserAuthTokenDTO | null;
    AppToken: string;
};

export type RolleDTO = {
    Berechtigungen: BerechtigungDTO[];
    Name: string;
    Beschreibung: string;
    RolleGuid: string;
};

export type SaegeDatenHistorieDTO = {
    SaegeDatenHistorieGuid: string;
    SerieGuid: string;
    SerienName: string;
    ErstelltAm: Date;
    DateiName: string;
    DateiPfad: string;
    SaegeModell: string;
    Benutzername: string;
    SaegeDatei: string;
    Meldungen: string;
};

export type SaegeDatenResultDTO = {
    Content: string;
    Meldungen: string;
    Modell: string;
    Dateipfad: string;
    Dateiname: string;
};

/** DTO für die Konfiguration von Sägen in IBOS3 */
export type SaegeKonfigurationDTO = {
    /** Bezeichnung der Säge */
    Bezeichnung: string;
    /** Modellbezeichnung des ISaegeDatenGenerator, der genutzt werden soll */
    Modell: string;
    /** DisplayName des ISaegeDatenGenerator, der genutzt werden soll */
    DisplayName: string;
    /** Bezeichnung des SaegemassKorrekturSatzDTO, das genutzt werden soll */
    KorrekturSatz: string;
    /** Angabe, ob die Säge Schnitte mit 90-90 Grad sägen kann */
    DoppelGeradSchnitt: boolean;
    /** Angabe, ob die Säge Schnitte mit 45-45 Grad sägen kann */
    DoppelGehrungsSchnitt: boolean;
    /** Angabe, ob die Säge Schnitte mit 45-90 Grad sägen kann */
    GeradGehrungsSchnitt: boolean;
    /** Angabe, ob die Säge Schnitte mit anderen Winkeln sägen kann */
    FreierSchnitt: boolean;
    /** Ausgabeverzeichnis für die Datei mit Geradschnitten (90-90) */
    Ausgabeverzeichnis_Geradschnitt: string;
    /** Ausgabeverzeichnis für die Datei mit GeradGehrungsschnitten (45-90; 90-45) */
    Ausgabeverzeichnis_GeradGehrung: string;
    /** Ausgabeverzeichnis für die Datei mit Doppelgehrungsschnitten (45-45) */
    Ausgabeverzeichnis_DoppelGehrung: string;
    /** Kennzeichen, ob alle Schnitte in einer Datei ausgegeben werden sollen */
    KombinierteSaegeDatei: boolean;
    /** Ausgabeverzeichnis für kombinierte Sägedatei */
    Ausgabverzeichnis_kombiniert: string;
    /** FarbKuerzel für Sonderfarbschnitte - Default: "SF" */
    FarbKuerzel_SF: string;
};

/** DTO für die Verwaltung der Sägemaßkorrekturen */
export type SaegemassKorrekturDTO = {
    /** Katalognummer des Profils, für das die Sägemaßkorrektur gilt */
    KatalogNummer: string;
    /** Korrekturmaß bei 90° Schnitt (in mm) */
    Korrektur90Grad: number;
    /** Korrekturmaß bei 45° Schnitt (in mm) */
    Korrektur45Grad: number;
    /** Winkelkorrektur bei 45° Schnitt (in °) */
    WinkelKorrektur45Grad: number;
    /** Winkelkorrektur bei 90° Schnitt (in °) */
    WinkelKorrektur90Grad: number;
};

/** DTO für die Verwaltung der Sägemaßkorrekturen */
export type SaegemassKorrekturSatzDTO = {
    /** Bezeichnung des Sägemaßkorrektursatzes */
    Bezeichnung: string;
    /** Liste mit profilbezogenen Sägemaßkorrekturen */
    SaegemassKorrekturen: Array<SaegemassKorrekturDTO>;
};

export type SammelrechnungDTO = {
    SammelrechnungGuid: string;
    SammelrechnungsNummer: number;
    /** ISO date string */
    ErstellDatum: string;
    /** ISO date string */
    LastPrintDate: string | null;
    /** ISO date string */
    LastExportDate: string | null;
    Ansprechpartner: string;
    Telefonnummer: string;
    Liefertermin: string;
    ZahlungsBedingungen: string;
    Kopfzeile: string;
    Fusszeile: string;
    Schlusstext: string;
    PageTitle: string;
    PageSubtitle1: string;
    PageSubtitle2: string;
    Kontakt: KontaktDTO;
    RechnungsAdresse: BeleganschriftDTO;
    Positionen: SammelrechnungPositionenDTO[];
    Salden: SammelrechnungSaldenDTO[];
    EinzelrechnungDTOs: BelegDruckDTO[];
};

export type SammelrechnungListItemDTO = {
    SammelrechnungGuid: string;
    SammelrechnungNummer: number;
    Kundenname: string;
    Kundennummer: string;
    /** ISO date string */
    ErstellDatum: string;
    /** ISO date string */
    LastPrintDate: string | null;
    /** ISO date string */
    LastExportDate: string | null;
    AnzahlPositionen: number;
    GesamtBetrag: number;
    KundenGuid: string;
    MwSt: number;
    Lieferungstyp: Lieferungstyp;
};

export type SammelrechnungPositionenDTO = {
    SammelrechnungPositionGuid: string;
    LaufendeNummer: number;
    RechnungNummer: number;
    /** ISO date string */
    RechnungDatum: string;
    RechnungKommision: string;
    RechnungBetrag: number;
    /** ISO date string */
    VorgangsDatum: string;
    Salden: SammelrechnungSaldenDTO[];
};

export type SammelrechnungSaldenDTO = {
    SammelrechnungSaldenGuid: string;
    Reihenfolge: number;
    Text: string;
    Betrag: number;
    Rabatt: number;
    Name: string;
};

export type SchnittDTO = {
    SchnittGuid: string;
    Name: string;
    OperationsPunkte: Array<OperationsPunktDTO>;
    SchnittKonturZuordnungen: Array<SchnittKonturDTO>;
    Version: number;
    ChangedDate: Date;
};

export type SchnittKonturDTO = {
    SchnittKonturGuid: string;
    Reihenfolge: number;
    Verschmelzen: boolean;
    Vorzeichen: number;
    KonturGuid: string;
    Operationen: Array<SchnittKonturOperationDTO>;
    Version: number;
    ChangedDate: Date;
};

export type SchnittKonturOperationDTO = {
    SchnittKonturOperationGuid: string;
    Operation: string;
    P1: number;
    P2: number;
    P3: number;
    P4: number;
    P5: number;
    Reihenfolge: number;
    Version: number;
    ChangedDate: Date;
};

export type SchnittoptimierungsOptionen = ('Keine'|'Lieferdatum'|'Serie'|'FarbeOberflaeche');

/** Options for `send`/`broadcast`. */
export type SendOptions = {
    /** Keep this `(to, type)` as a last value; subscribers that register later receive it immediately. Default `false`. */
    retain?: boolean;
};

export type SerieAuslastungDTO = {
    IstSumme: boolean;
    Produktfamilie: string;
    Anzahl: number;
    Reserviert: number;
    Arbeitsminuten: number;
    ArbeitsminutenReserviert: number;
    Elementgewicht: number;
    ElementgewichtReserviert: number;
    AnzahlMax: number;
    KapazitaetBelegt: number;
    KapazitaetMax: number;
};

export type SerieDruckInfoDTO = {
    SerieDruckInfoGuid: string;
    Benutzername: string;
    DokumentArt: string;
    /** ISO date string (UTC) */
    Zeitstempel: string;
};

export type SerieDTO = {
    /** Eindeutige ID der Serie */
    SerieGuid: string;
    /** Name der Serie (Langform) */
    Name: string;
    /** Serienkürzel für Ausdrucke, Kurzanzeige usw. */
    Kuerzel: string;
    /** Beginn der Produktion (erster Produktionstag) - ISO date string */
    Start: string;
    /** Ende der Produktion (letzter Produktionstag) - ISO date string */
    Ende: string;
    /** Ständige Serie */
    StaendigeSerie: boolean;
    /** AV-Positionen in dieser Serie */
    AVBelegPositionen: string[];
    /** Kapazität in neutralen Kapazitätseinheiten (alt) */
    Kapazitaet: number;
    /** Kapazität der Serie in Minuten */
    KapazitaetInMin: number;
    /** Belegung in neutralen Kapazitätseinheiten */
    KapazitaetReserviert: number;
    /** "NichtBerechnet", "BerechnungGestartet", "Berechnet" */
    MaterialBedarfStatus: string;
    /** Serie ist gesperrt */
    IstGesperrt: boolean;
    DruckInfos: SerieDruckInfoDTO[];
    /** ISO date string */
    ChangedDate: string;
};

export type SerieHistorieDTO = {
    SerieHistorieGuid: string;
    SerieGuid: string;
    SerienName: string;
    Text: string;
    /** ISO date string */
    Zeitstempel: string;
    Benutzer: string;
};

export type SerieInfoDTO = {
    SerieGuid: string;
    Name: string;
    Kuerzel: string;
    Start: Date;
    Ende: Date;
    StaendigeSerie: boolean;
    Kapazitaet: number;
    KapazitaetInMin: number;
    KapazitaetReserviert: number;
};

export type SerienApi = {
    /** // Serie Operations */
    fluentApi: FluentApi;
    releaseElemente: (fromSerie: string) => Promise<void>;
    moveElemente: (fromSerie: string, toSerie: string) => Promise<string>;
    redistributeElemente: (fromSerie: string) => Promise<string>;
    getAllSerien: () => Promise<SerieDTO[]>;
    getAllSerienChangedSince: (changedSince: Date) => Promise<SerieDTO[]>;
    getSerie: (guid: string) => Promise<SerieDTO>;
    saveSerie: (serie: SerieDTO) => Promise<void>;
    deleteSerie: (guid: string) => Promise<void>;
    getAuslastung: (serie: string) => Promise<SerieAuslastungDTO[]>;
    getGesamtAuslastung: (includeAbgelaufene?: boolean) => Promise<Record<string, SerieAuslastungDTO[]>>;
    getSerienKapazitaeten: (startDate?: Date, endDate?: Date, includeStaendige?: boolean) => Promise<Record<string, SerieAuslastungDTO[]>>;
    getAuslastungVirtualSerien: (startDate?: Date, endDate?: Date) => Promise<VirtualSerieWithAuslastungDTO[]>;
    getAuslastungVorgang: (startVorgangsnummer: number, endVorgangsnummer: number) => Promise<SerieAuslastungDTO[]>;
};

export type SerienMaterialEditDTO = {
    SerieGuid: string;
    MaterialListe: MaterialbedarfDTO[];
};

export type SetFakturaDTO = {
    /** Liste der GUIDs */
    GuidList: string[];
    /** Erlaubte Werte: "Freigegeben", "Abgerechnet" */
    Kennzeichen: string;
};

export type SettingsApi = {
    /** Get all settings */
    getAllSettings: () => Promise<Record<string, object>>;
    /** Save setting */
    saveSetting: (key: string, value: object) => Promise<void>;
    /** Get price conditions */
    getPreiskonditionen: () => Promise<PreisermittlungsEinstellungenDTO>;
    /** Save price conditions */
    savePreiskonditionen: (konditionen: string) => Promise<string>;
    /** Get all config set info */
    getAllKonfigSatzInfo: () => Promise<KonfigSatzInfoDTO[]>;
    /** Save config set info */
    saveKonfigSatzInfo: (konfigSatzInfo: KonfigSatzInfoDTO) => Promise<KonfigSatzInfoDTO>;
    /** Get all value lists */
    getAllWertelisten: (includeAutoWerteListen: boolean) => Promise<WerteListeDTO[]>;
    /** Get value list by GUID */
    getWerteliste: (wertelisteGuid: string, includeAutoWerteListen?: boolean) => Promise<WerteListeDTO>;
    /** Save value list */
    saveWerteliste: (dto: WerteListeDTO) => Promise<void>;
    /** Get all contracts */
    getAllContracts: () => Promise<ContractDTO[]>;
    /** Save contract */
    saveContract: (dto: ContractDTO) => Promise<ContractDTO>;
    /** Delete contract */
    deleteContract: (dto: ContractDTO) => Promise<void>;
    /** Get all templates */
    getAllTemplates: () => Promise<TemplateDTO[]>;
    /** Get template by ID */
    getTemplate: (id: string) => Promise<TemplateDTO>;
    /** Save template */
    saveTemplate: (dto: TemplateDTO) => Promise<void>;
    /** Delete template */
    deleteTemplate: (templateGuid: string) => Promise<void>;
    /** Get change info */
    getChangeInfo: () => Promise<ChangeInfoDTO>;
    /** Get update info */
    getUpdateInfo: () => Promise<UpdateInfoDTO>;
    /** Get data migration history version */
    getDataMigrationHistoryVersion: () => Promise<number>;
    /** Set data migration history version */
    setDataMigrationHistoryVersion: (newVersion: number) => Promise<void>;
};

export type SLKServerSettingsDTO = {
    SLKNichtAktiv: boolean;
};

export type SonderwuenscheDTO = {
    Bezeichnung: string;
    Wert: string;
};

export type SystemApi = {
    /** Get changes for type */
    getChanges: (typeName: string, changedSince: Date) => Promise<ChangeDTO[]>;
    /** Delete old changes */
    deleteOldChanges: () => Promise<void>;
    tagInfo: { getAll: (changedSince?: Date) => Promise<TagInfoDTO[]>; getSuggestions: (changedSince?: Date) => Promise<TagInfoDTO[]>; get: (objectGuid: string) => Promise<TagInfoDTO[]>; getForGuidList: (guidList: string[]) => Promise<Record<string, TagInfoDTO[]>>; getForFremdfertigungGuidList: (guidList: string[]) => Promise<Record<string, TagInfoDTO[]>>; addOrUpdate: (dto: TagInfoDTO) => Promise<void>; delete: (dto: TagInfoDTO) => Promise<void>; getVorlagen: () => Promise<TagVorlageDTO[]>; addOrUpdateVorlage: (dto: TagVorlageDTO) => Promise<void>; deleteVorlage: (tagVorlageGuid: string) => Promise<void>; getForFunction: (objectGuid: string, mandantID: number) => Promise<TagInfoDTO[]>; getListForFunction: (guidList: string[], mandantID: number) => Promise<Record<string, TagInfoDTO[]>>; addForFunction: (dto: TagInfoDTO, mandantID: number) => Promise<void>; deleteForFunction: (dto: TagInfoDTO, mandantID: number) => Promise<void>; cleanUp: () => Promise<void> };
    filter: { getAll: () => Promise<FilterItemDTO[]>; get: (id: string) => Promise<FilterItemDTO>; getByContext: (context: string) => Promise<FilterItemDTO[]>; save: (dto: FilterItemDTO) => Promise<void> };
    /** Get change info */
    getChangeInfo: () => Promise<ChangeInfoDTO>;
    /** Get update info */
    getUpdateInfo: () => Promise<UpdateInfoDTO>;
};

export type TagInfoDTO = {
    ObjectGuid: string;
    Text: string;
    CanRemove: boolean;
    IsDefaultTag: boolean;
    ToolTip: string;
    IconName: string;
    BackgroundColorCode: string;
    TextColorCode: string;
    IsDeleted: boolean;
    Version: number;
    ChangedDate: string;
};

export type TagVorlageDTO = {
    TagVorlageGuid: string;
    Text: string;
    ToolTip: string;
    BackgroundColorCode: string;
    TextColorCode: string;
    Version: number;
    ChangedDate: string;
};

export type TemplateDTO = {
    /** Eindeutige GUID des Templates */
    TemplateGuid: string;
    /** Titel des Templates */
    Titel: string;
    /** Beschreibung des Templates */
    Beschreibung: string;
    /** Typ des Templates */
    Typ: string;
    /** Serialisierte Daten als JSON */
    JsonDaten: string;
    /** ISO date string */
    ChangedDate: string;
    /** Benutzer, der das Template erstellt hat */
    Benutzer: string;
};

/** Translation tables by BCP-47 language code, e.g. `{ en: { "Bestand": "Stock" } }`. */
export type TranslationCatalogs = Record<string, TranslationTable>;

/** A translation table: key (the German source text) -> translation. */
export type TranslationTable = Record<string, string>;

/**
 * Subscription type pattern: exact (`"a.b"`), prefix glob (`"a.*"`), all (`"*"`)
 * or a list of patterns.
 */
export type TypePattern = string | string[];

export type UiApi = {
    /** Get all UI definitions */
    getAllUiDefinitions: () => Promise<UIDefinitionDTO[]>;
    /** Get UI definition by GUID */
    getUiDefinition: (guid: string) => Promise<UIDefinitionDTO>;
    /** Save UI definition */
    saveUiDefinition: (uiDefinition: UIDefinitionDTO) => Promise<UIDefinitionDTO>;
    /** Get all UI scripts */
    getAllUiScripts: () => Promise<UIScriptDTO[]>;
    /** Get UI script by name */
    getUiScript: (name: string) => Promise<UIScriptDTO>;
    /** Get UI script for function by name */
    getUiScriptForFunction: (name: string) => Promise<UIScriptDTO>;
    /** Save UI script */
    saveUiScript: (dto: UIScriptDTO) => Promise<void>;
    /** Delete UI script */
    deleteUiScript: (guid: string) => Promise<void>;
    /** Get all UI field info */
    getAllUiFeldInfo: () => Promise<UIEingabeFeldInfoDTO[]>;
    /** Save UI field info */
    saveUiEingabeFeldInfo: (uiEingabeFeldInfo: UIEingabeFeldInfoDTO) => Promise<UIEingabeFeldInfoDTO>;
    /** Get all tag info */
    getAllTagInfo: (changedSince?: Date) => Promise<TagInfoDTO[]>;
    /** Get tag info suggestions */
    getTagInfoSuggestions: (changedSince?: Date) => Promise<TagInfoDTO[]>;
    /** Get tag info by object GUID */
    getTagInfo: (objectGuid: string) => Promise<TagInfoDTO[]>;
    /** Get tag info for GUID list */
    getTagInfoForGuidList: (guidList: string[]) => Promise<Record<string, TagInfoDTO[]>>;
    /** Get tag info for external production GUID list */
    getTagInfoForFremdfertigungGuidList: (guidList: string[]) => Promise<Record<string, TagInfoDTO[]>>;
    /** Add or update tag info */
    addOrUpdateTagInfo: (dto: TagInfoDTO) => Promise<void>;
    /** Delete tag info */
    deleteTagInfo: (dto: TagInfoDTO) => Promise<void>;
    /** Get tag templates */
    getTagVorlagen: () => Promise<TagVorlageDTO[]>;
    /** Add or update tag template */
    addOrUpdateTagVorlage: (dto: TagVorlageDTO) => Promise<void>;
    /** Delete tag template */
    deleteTagVorlage: (tagVorlageGuid: string) => Promise<void>;
    /** Get tag info for function */
    getTagInfoForFunction: (objectGuid: string, mandantID: number) => Promise<TagInfoDTO[]>;
    /** Get tag info list for function */
    getTagInfoListForFunction: (guidList: string[], mandantID: number) => Promise<Record<string, TagInfoDTO[]>>;
    /** Add tag info for function */
    addTagInfoForFunction: (dto: TagInfoDTO, mandantID: number) => Promise<void>;
    /** Delete tag info for function */
    deleteTagInfoForFunction: (dto: TagInfoDTO, mandantID: number) => Promise<void>;
    /** Clean up tag infos */
    cleanUpTagInfos: () => Promise<void>;
    /** Get all filters */
    getAllFilters: () => Promise<FilterItemDTO[]>;
    /** Get filter by ID */
    getFilter: (id: string) => Promise<FilterItemDTO>;
    /** Get filters by context */
    getFiltersByContext: (context: string) => Promise<FilterItemDTO[]>;
    /** Save filter */
    saveFilter: (dto: FilterItemDTO) => Promise<void>;
    /** Translate text */
    translate: (language: string, text: string) => Promise<string | null>;
};

export type UIDefinitionDTO = {
    UIDefinitionGuid: string;
    Kategorie: string;
    BezeichnungKurz: string;
    BezeichnungLang: string;
    BildHorizontal: string;
    BildVertikal: string;
    Bild3D: string;
    EingabeFelder: Array<UIEingabeFeldDTO>;
    KonfiguratorFelder: Array<UIKonfiguratorFeldDTO>;
    Version: number;
    ChangedDate: string;
};

export type UIEingabeFeldDTO = {
    Reihenfolge: number;
    Caption: string;
    Tag: string;
    Regel: string;
    MinWert: number;
    MinWertWeichPruefen: boolean;
    MaxWert: number;
    MaxWertWeichPruefen: boolean;
    VorgabeWert: string;
    HilfeText: string;
    WarnText: string;
    FehlerText: string;
    WerteListeName: string;
    PreisFeldAnzeigen: boolean;
    MindestBreite: number;
    Version: number;
    ChangedDate: string;
    UIEingabeFeldGuid: string;
    BelegBlattText: string;
    AngebotsText: string;
    EingabeLevel: number;
    ZusatzFeldGruppeId: number | null;
    GehoertZuZusatzFeldGruppeId: number | null;
    GueltigAb: string | null;
    GueltigBis: string | null;
    IstKonfiguratorFeld: boolean;
};

export type UIEingabeFeldInfoDTO = {
    UIEingabeFeldGuid: string;
    VariantenGuids: Array<string>;
    Caption: string;
    MinWert: number;
    MinWertWeichPruefen: boolean;
    MaxWert: number;
    MaxWertWeichPruefen: boolean;
    HilfeText: string;
    WarnText: string;
    FehlerText: string;
    VorgabeWert: string;
};

export type UIEingabeFeldRegelNames = 0 | 1 | 2 | 4 | 8 | 16 | 32 | 64 | 128;

export type UIKonfiguratorFeldDTO = {
    EingabeLevel: number;
    Reihenfolge: number;
    Caption: string;
    Tag: string;
    Kuerzel: string;
    WerteListeName: string;
    VorgabeWert: string;
    BelegBlattText: string;
    AngebotsText: string;
    ProfilId: number | null;
    GehoertZuProfilId: number | null;
    GueltigAb: string | null;
    GueltigBis: string | null;
    Version: number;
    ChangedDate: string;
    UIKonfiguratorFeldGuid: string;
};

export type UIScriptDTO = {
    ScriptDefinitionGuid: string;
    Context: string;
    Code: string;
    Version: number;
    ChangedDate: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
    MandantGuid: string | null;
};

export type UpdateInfoDTO = {
    /** ISO date string */
    KatalogArtikel: string;
    /** ISO date string */
    ProduktFamilien: string;
    /** ISO date string */
    ProduktGruppen: string;
    /** ISO date string */
    Varianten: string;
    /** ISO date string */
    UI: string;
    /** ISO date string */
    WerteListen: string;
    /** ISO date string */
    Farben: string;
    /** ISO date string */
    Scripts: string;
    /** ISO date string */
    FarbKuerzel: string;
    /** ISO date string */
    Oberflaechen: string;
    /** ISO date string */
    FarbGruppen: string;
};

export type UserAuthTokenDTO = {
    AppToken: string;
    /** ISO date string */
    Expires: string;
    Token: string;
    Benutzer: BenutzerDTO | null;
    MandantGuid: string;
    Mandant: MandantDTO | null;
};

/** Utility API contract inferred from createUtilityApi implementation. */
export type UtilityApi = {
    /** Add web job history */
    addWebJobHistorie: (historyDto: WebJobHistorieDTO) => Promise<void>;
    /** Delete old web job history */
    deleteOldWebJobHistorie: () => Promise<void>;
    /** Get cut optimization */
    getCutOptimization: (materialbedarfDtos: MaterialbedarfDTO[]) => Promise<Record<string, MaterialbedarfCutOptimization>>;
    /** Get total material requirements */
    getGesamtMaterialbedarf: (optionen: ZusammenfassungsOptionen, stangenoptimierung: boolean, stichTag?: Date, bedarfAb?: Date, filterCsvExportedMaterial?: boolean) => Promise<GesamtMaterialbedarfGetReturn>;
    /** Update total material requirement delivery date */
    gesamtBedarfUpdateLiefertag: (mandantId: number, posGuid: string) => Promise<void>;
    /** Recalculate total material requirement */
    recalculateGesamtbedarf: (mandantId: number, avPosGuid: string) => Promise<void>;
    /** Create vorgang at coater */
    erzeugeVorgangBeiBeschichter: (vorgang: VorgangDTO, mGuid: string, produzentenKundenNummer: string) => Promise<VorgangDTO>;
    /** Create order vorgang */
    erzeugeBestellVorgang: (vorgang: VorgangDTO) => Promise<VorgangDTO>;
    /** Create complaint at coater */
    erzeugeReklamationBeiBeschichter: (vorgang: VorgangDTO, quellVorgang: string, mGuid: string, produzentenKundenNummer: string) => Promise<VorgangDTO>;
    /** Update status at producer */
    updateStatusBeimProduzenten: (vorgangGuid: string, status: string, externeReferenz?: string) => Promise<void>;
    /** Get all material orders by year */
    getMaterialBestellungenByJahr: (jahr: number) => Promise<BaseListItemDTO[]>;
    /** Get all material orders */
    getMaterialBestellungen: () => Promise<BaseListItemDTO[]>;
    /** Request newsletter subscription by GUID */
    requestNewsletterByGuid: (guid: string) => Promise<void>;
    /** Request newsletter subscription by email */
    requestNewsletterByMail: (mail: string) => Promise<void>;
    /** Unsubscribe newsletter by email */
    deleteNewsletterByMail: (mail: string) => Promise<void>;
    /** Unsubscribe newsletter by GUID */
    deleteNewsletterByGuid: (guid: string) => Promise<void>;
    /** Get vorgang GUIDs for backup */
    getBackupVorgangGuids: (email: string, year?: number, onlyBills?: boolean) => Promise<string[]>;
    /** Get vorgang for backup */
    getBackupVorgang: (email: string, guid: string, onlyBills?: boolean) => Promise<VorgangExtendedDTO>;
    /** Request backup */
    requestBackup: (email: string, onlyBills: boolean, year: number) => Promise<void>;
    /** Load orders */
    ladeBestellungen: (jahr?: number, includeAbgeholte?: boolean) => Promise<BestellungListItemDTO[]>;
    /** Reset orders */
    resetBestellungen: (resetAb: Date) => Promise<void>;
    /** Load material orders */
    ladeMaterialBestellungen: (jahr?: number, vorgangStatusText?: string, includeAbgeholte?: boolean, includeArchive?: boolean, includeAllTypes?: boolean, includeArtosGeloeschtFlag?: boolean) => Promise<MaterialBestellungListItemDTO[]>;
    /** Load material orders by date range */
    ladeMaterialBestellungenVonBis: (vonDatum: Date, bisDatum: Date, vorgangStatusText?: string, includeAbgeholte?: boolean, includeArchive?: boolean, includeAllTypes?: boolean, includeArtosGeloeschtFlag?: boolean) => Promise<MaterialBestellungListItemDTO[]>;
    /** Reset material orders */
    resetMaterialBestellungen: (resetAb: Date) => Promise<void>;
    /** Get gSQL beleg */
    getGsqlBeleg: (belegGuid: string) => Promise<string>;
    /** Get all notifications */
    getAllNotifications: () => Promise<NachrichtenDTO[]>;
    /** Get single user by customer and email */
    getOneBenutzerByKunde: (kundeGuid: string, email: string) => Promise<BenutzerDTO | undefined>;
};

export type VarianteDTO = {
    VarianteGuid: string;
    UIDefinitionGuid: string;
    ProduktFamilieGuid: string;
    WarengruppeGuid: string;
    KomponenteGuid: string;
    Kuerzel: string;
    Name: string;
    ElementArt: string;
    ElementTyp: string;
    Beschreibung: string;
    PreisErmittlung: string;
    Preisliste: string;
    PreisVorschrift: string;
    GrenzVorschrift: string;
    PreislistenFaktor: number;
    MasterKatalog: boolean;
    HauptKatalog: boolean;
    ExtraKatalog: boolean;
    ErfassungIBOS2Moeglich: boolean;
    ErfassungIBOS1Moeglich: boolean;
    GueltigAb: string | null;
    GueltigBis: string | null;
    ChangedDate: string;
    Version: number;
    UIDefinition: UIDefinitionDTO;
    /** Achtung, KonfigSatz-Klasse wird NICHT direkt gemappt! */
    KonfigSatzGuid: string;
    KonfigSatz: Array<KonfigSatzEintragDTO>;
    IstTechnischeVariante: boolean;
};

export type VarianteDTOListe = Array<VarianteDTO>;

export type VirtualSerieWithAuslastungDTO = {
    /** Eindeutige ID der Serie */
    SerieGuid: string;
    /** Name der Serie (Langform) */
    Name: string;
    /** Serienkürzel für Ausdrucke, Kurzanzeige usw. */
    Kuerzel: string;
    /** Beginn der Produktion (erster Produktionstag) - ISO date string */
    Start: string;
    /** Ende der Produktion (letzter Produktionstag) - ISO date string */
    Ende: string;
    Auslastungen: SerieAuslastungDTO[];
};

export type VorgangApi = {
    /** Get list of vorgangs by year */
    getList: (jahr: number) => Promise<VorgangListItemDTO[]>;
    /** Get list by status and year */
    getListByStatus: (status: string, jahr: number) => Promise<VorgangListItemDTO[]>;
    /** Get list by status, year, and changed since date */
    getListByStatusAndChangedSince: (status: string, jahr: number, changedSince: Date) => Promise<VorgangListItemDTO[]>;
    /** Get list with all filter options */
    getListWithFilters: (changedSince: Date, jahr: number, status: string, art: string, includeArchive: boolean, includeOthersData: boolean, search: string) => Promise<VorgangListItemDTO[]>;
    /** Get list by year with filters */
    getListByYearAndFilters: (jahr: number, status: string, changedSince: Date, art: string, includeArchive: boolean, includeOthersData: boolean, search: string) => Promise<VorgangListItemDTO[]>;
    /** Get list by customer GUID */
    getListByKunde: (kundeGuid: string) => Promise<VorgangListItemDTO[]>;
    /** Save multiple vorgangs */
    saveList: (list: VorgangDTO[]) => Promise<void>;
    /** Change vorgang number */
    changeNummer: (vorgangGuid: string, neueVorgangsNummer: number) => Promise<void>;
    /** Save a single vorgang */
    save: (vorgang: VorgangDTO) => Promise<VorgangDTO>;
    /** Get vorgang by GUID */
    getByGuid: (vorgangGuid: string, includeKunde: boolean, returnNullIfNotFound: boolean) => Promise<VorgangDTO>;
    /** Get vorgang by number and year */
    getByNummer: (vorgangsNummer: number, jahr: number, includeKunde: boolean) => Promise<VorgangDTO>;
    /** Get vorgang status */
    getStatus: (vorgangGuid: string) => Promise<VorgangStatusDTO>;
    /** Set vorgang status */
    setStatus: (vorgangGuid: string, statusCode: string) => Promise<VorgangStatusDTO>;
    /** Set text status for multiple vorgangs */
    setTextStatus: (vorgangGuids: string[], textStatus: string) => Promise<void>;
    /** Archive a vorgang */
    archive: (vorgangGuid: string) => Promise<void>;
    /** Archive multiple vorgangs */
    archiveList: (vorgangGuidList: string[]) => Promise<void>;
    /** Unarchive a vorgang */
    unarchive: (vorgangGuid: string) => Promise<void>;
    /** Change beleg art */
    changeBelegArt: (belegGuid: string, neueBelegArt: string) => Promise<void>;
    /** Get all vorgangs for function by changed since date */
    getAllForFunction: (changedSince: Date) => Promise<Record<number, VorgangListItemDTO[]>>;
    /** Get vorgang for function */
    getForFunction: (vorgangGuid: string, mandantId: number) => Promise<VorgangDTO>;
};

export type VorgangDTO = {
    /** Eindeutige GUID */
    VorgangGuid: string;
    /** Sichtbare Vorgangsnummer/zur Info für Kunden usw. */
    VorgangsNummer: number;
    /** Kundennummer (aus Kontakt-Objekt) */
    KundenNummer: string;
    /** End- oder Firmenkunde (aus Kontakt-Objekt) */
    IstEndkunde: boolean;
    /** Standard-Kommission des Vorgangs */
    Kommission: string;
    /** Kommission2 des Vorgangs */
    Kommission2: string;
    /** Erstelldatum des Vorgangs */
    ErstellDatum: Date;
    /** Letztes Änderungsdatum des Vorgangs */
    AenderungsDatum: Date;
    /** Liste und Daten der Belege zu diesem Vorgang */
    Belege: Array<BelegDTO>;
    /** Liste und Daten der Postionen in diesem Vorgang */
    Positionen: Array<BelegPositionDTO>;
    Nachrichten: Array<string>;
    Historie: Array<VorgangHistorieDTO>;
    /** Ersteller-/Besitzerbenutzer des Vorgangs */
    Besitzer: BenutzerDTO;
    /** Kontakt für diese Vorgang (Dummy-Kontakt, falls noch nicht erfasst) */
    Kunde: KontaktDTO;
    KundeGuid: string;
    AktuellerStatus: string;
    /** Gültige Werte: "NichtFreigegeben", "Freigegeben", "Abgerechnet" */
    FakturaKennzeichen: string;
    TextStatus: string;
    IstTestbeleg: boolean;
    WaehrungsSymbol: string;
    WaehrungsFaktor: number;
    IstBrutto: boolean;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    IstZustimmungErteilt: boolean;
    InterneNotiz: string;
    BemerkungFuerKunde: string;
    OriginalVorgangGuid: string;
    OriginalMandantGuid: string;
    OriginalVorgangsNummer: number|null;
    OriginalAppGuid: string;
    InnergemeinschaftlichOhneMwSt: boolean;
    ZielVorgangGuid: string;
};

export type VorgangExtendedDTO = {
    Vorgang: VorgangDTO;
    Mandant: MandantDTO;
    MandantId: number;
};

export type VorgangHistorieDTO = {
    VorgangHistorieGuid: string;
    Text: string;
    Zeitstempel: Date;
    Benutzer: string;
};

export type VorgangHistorienDTO = {
    VorgangHistorien: Array<VorgangHistorieDTO>;
    BelegHistorien: Record<string, Array<BelegHistorieDTO>>;
    BelegPositionHistorien: Record<string, Array<BelegPositionHistorieDTO>>;
};

export type VorgangListItemDTO = {
    /** Eindeutige GUID */
    VorgangGuid: string;
    /** Sichtbare Vorgangsnummer/zur Info für Kunden usw. */
    VorgangsNummer: number;
    /** Vorgangsnummer vom Originalbeleg */
    OriginalVorgangsNummer: number|null;
    /** Erstelldatum des Vorgangs */
    ErstellDatum: Date;
    /** Datum der letzten Änderung */
    AenderungsDatum: Date;
    /** Art des aktuellsten Belegs */
    AktuelleBelegArt: string;
    /** Eingegebene Kommission des Händlers */
    Kommission: string;
    /** Eingegebene Kommission2 des Händlers */
    Kommission2: string;
    /** Eingegebene Notitzen zum Vorgang vom Produzenten */
    VorgangsNotitz: string;
    /** Aktuelle Belegnummer */
    AktuelleBelegNummer: string;
    /** Aktuelle Rechnungsnummer */
    AktuelleRechnungsNummer: string;
    /** Alle Belegnummern, getrennt mit ", " */
    AlleBelegNummern: string;
    /** Die GUID des aktuellen Beleges. */
    AktuelleBelegGuid: string;
    /** Kundennummer des Kunden */
    KundenNummer: string;
    /** Name des Kunden für Anzeige */
    Kundenname: string;
    /** Guide des Kunden für Filter */
    KundeGuid: string;
    /** Adresse des detaillierten Vorgangs-Objektes */
    URL: string;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    Status: string;
    AnzahlNachrichten: number;
    IsArchiv: boolean;
    HatFehlerhaftenBeleg: boolean;
    PreisAufAnfrage: boolean;
    KundeFehlt: boolean;
    TextStatus: string;
    /** Email des Besitzer */
    Besitzer: string;
    /** Falls Benutzer null und 1. Beleg ist Bestellschein -> Bestellfix -> Besitzer aus OriginalVorgangGuid aus Vorgang */
    Besteller: string;
    /** Der Ansprechpartner vom letzten Beleg des Vorgangs */
    Bearbeiter: string;
    ExterneReferenznummer: string;
    ExterneMandantenGuid: string|null;
    ExternerFirmenname: string;
    /** Guids von "zugehörigen Objekten" (Belegen/BelegPositionen) als JSON-object. Zum Laden von Tags. */
    RelatedGuids: string;
    MandantGuid: string;
    IstBerechnet: boolean;
};

export type VorgangNachrichtAnhangDTO = {
    VorgangNachrichtAnhangGuid: string;
    FileName: string;
    FileSize: number;
    URL: string;
};

export type VorgangNachrichtDTO = {
    VorgangNachrichtGuid: string;
    VorgangGuid: string;
    Absender: string;
    Empfaenger: string;
    Betreff: string;
    Text: string;
    Anhaenge: Array<VorgangNachrichtAnhangDTO>;
    Gesendet: Date;
};

export type VorgangStatusDTO = {
    /** Eindeutige GUID */
    VorgangGuid: string;
    /** Sichtbare Vorgangsnummer/zur Info für Kunden usw. */
    VorgangsNummer: number;
    /** Statuscode */
    AktuellerStatus: string;
    /** Datum der letzten Änderung des Vorgangs */
    AenderungsDatum: Date;
    NeuerStatus: string;
};

export type VorgangStatusTableDTO = {
    /** Eindeutige GUID des Vorgangs */
    VorgangGuid: string;
    /** Eindeutige GUID des Kontaktes im Vorgang */
    KontaktGuid: string|null;
    /** Ob der Kunde geändert wurde, auch bei Neuanlöage = true */
    KundeGeaendert: boolean;
    /** Datum der letzten Änderung des Vorgangs */
    AenderungsDatum: Date;
    /** Die ID des Mandanten wird für die Functions benötigt */
    MandantId: number;
};

export type VorgangTextStatusDTO = {
    /** Liste von eindeutigen GUIDs */
    VorgangGuids: Array<string>;
    /** Status der in das Feld TextStatus für alle Vorgänge gesetzt werden soll. */
    NeuerTextStatus: string;
};

export type WarenGruppeDTO = {
    WarenGruppeGuid: string;
    Nummer: number;
    Bezeichnung: string;
    IstEKPWarengruppe: boolean;
    Artikel: Array<KatalogArtikelDTO>;
    Version: number;
    ChangedDate: string;
    FrontendLogik: string;
};

export type WarenGruppeDTOListe = Array<WarenGruppeDTO>;

export type WarenGruppeListDTO = {
    WarenGruppeGuid: string;
    Nummer: number;
    Bezeichnung: string;
    IstEKPWarengruppe: boolean;
    FrontendLogik: string;
    Version: number;
    ChangedDate: string;
    ArtikelAnzahl: number;
    ArtikelGuids: string[];
};

export type WebJobHistorieDTO = {
    /** Eindeutige GUID */
    WebJobHistorieGuid: string;
    /** Name des WebJobs */
    WebJobName: string;
    /** ISO date string */
    Timestamp: string;
    /** Status des WebJobs */
    Status: string;
    /** Zusätzlicher Text */
    Text: string;
};

export type WerteListeDTO = {
    Name: string;
    Version: number;
    ChangedDate: string;
    WerteListeGuid: string;
    Items: Array<WerteListeItemDTO>;
    GueltigAb: string;
};

export type WerteListeDTOListe = Array<WerteListeDTO>;

export type WerteListeItemDTO = {
    BelegBlattText: string;
    AngebotsText: string;
    Beschreibung: string;
    ChangedDate: string;
    Kuerzel: string;
    Reihenfolge: number;
    Version: number;
    WerteListeItemGuid: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
};

export type ZusammenfassungsOptionen = ('Unbekannt'|'Lieferdatum'|'Serienzuordnung'|'ArtikelnummerFrabeOberflaeche'|'Vorgang'|'FarbeOberflaeche'|'Keine');

export type ZusatzanschriftDTO = {
    ZusatzanschriftGuid: string;
    /** Akad. Titel/Adelstitel */
    Titel: string;
    /** Namensanrede, z.B. "Herr"/"Frau"/"Firma" */
    Anrede: string;
    /** Für natürliche Personen: Nachname */
    Nachname: string;
    /** Für natürliche Personen: Vorname(n) */
    Vorname: string;
    /** Für juristische Personen/Körperschaften: exakte Firmierung mit Zusatz der Gesellschaftsform, z.B. "Fensterbau Maier GmbH & Co. KG" */
    Firmenname: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz1: string;
    /** Adresszusatz, z.B. "c/o" (belegbezogen) */
    AdressZusatz2: string;
    /** Postalische Straße */
    Strasse: string;
    /** Postalische Hausnummer, ggf. mit Suffix/Prafix z.B. "16a" oder "77 (Hinterhaus)" */
    Hausnummer: string;
    /** Postfach (ersetzt Straße/Hausnummer in der Ausgabe) */
    Postfach: string;
    /** Postalische Postleitzahl bezogen auf die Straßen- oder Postfachadresse */
    Postleitzahl: string;
    /** Postalische Ortsangabe */
    Ort: string;
    /** Nicht-postalische Angabe zum Ortsteil */
    Ortsteil: string;
    /** Land als Textkürzel */
    Land: string;
    /** Bezogen auf den Versender die Angabe, ob die hier ausgefertigte Adresse eine Inlandsadresse ist */
    IstInland: boolean;
    /** E-Mail-Adresse */
    Mailadresse: string;
    /** Verwendungszweck für diesen Adressdatensatz, mögliche Werte: Allgemein = 0, Angebot = 1, Rechnung = 3, Versand = 4, Bestellschein = 5, Newsletter = 6, Postversand = 7, Speditionsversand = 8, DigitalerDownload = 9, EmailDownload = 10, Firmensitz = 11 */
    Verwendungszweck: string;
    /** Priorisierung der Adresse */
    Prioritaet: number;
    /** Intern */
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    /** Intern */
    AdditionalProperties: Record<string, PropertyValueCollection>;
    /** Inaktiv Kennzeichen */
    IstInaktiv: boolean;
};

export type ZusatztextDTO = {
    ObjectGuid: string;
    LfdNr: number;
    Context: string;
    Content: string;
};

export type ZustimmungsInfoDTO = {
    Dokument: string;
    Version: string;
    /** ISO date string */
    Zeitstempel: string;
    Plattform: string;
};

