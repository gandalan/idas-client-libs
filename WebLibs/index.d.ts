export * from "./index.js";

export type AblageApi = ReturnType<typeof createAblageApi>;

export type AblageDTO = {
    AblageGuid: string;
    ChangedDate: Date;
    AblageFaecher: Array<AblageFachDTO>;
    Standort: string;
    Bezeichnung: string;
    Kuerzel: string;
};

export type AblageFachDTO = {
    AblageFachGuid: string;
    Belegt: boolean;
    FachNr: number;
    ProduktGruppenGuids: Array<string>;
    MaterialBedarfGuids: Array<string>;
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
    Titel: string;
    Anrede: string;
    Nachname: string;
    Vorname: string;
    Firmenname: string;
    AdressZusatz1: string;
    AdressZusatz2: string;
    Strasse: string;
    Hausnummer: string;
    Postfach: string;
    Postleitzahl: string;
    Ort: string;
    Ortsteil: string;
    Land: string;
    IstInland: boolean;
    Mailadresse: string;
    Landesvorwahl: string;
    Vorwahl: string;
    Telefonnummer: string;
    Durchwahl: string;
    Webadresse: string;
    Verwendungszweck: string;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type AnpassungApi = ReturnType<typeof createAnpassungApi>;

export type ApiVersionDTO = {
    Version: string;
    Environment: string;
    BuildTime: string;
    ReleaseTime: string;
};

export type AppActivationStatusDTO = {
    KundeGuid: string;
    KundenMandantGuid: string;
    KundenMandantIstAktiv: boolean;
};

export type ArtikelApi = ReturnType<typeof createArtikelApi>;

export type ArtikelstammEintrag = {
    KatalogArtikelGuid?: string;
    KatalogNummer?: string;
    Katalognummer?: string;
    Nummer?: string;
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

export type AuthApi = ReturnType<typeof createAuthApi>;

export type AvApi = ReturnType<typeof createAvApi>;

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
    VorgangGuid: string;
    BelegGuid: string;
    VorgangsNummer: number;
    BelegNummer: number;
    BelegJahr: number;
    ErstellDatum: Date;
    AenderungsDatum: Date;
    Kundenname: string;
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
    Kennzeichen: string;
    ZielKennzeichen: string;
    BearbeitungsName: string;
    X: number;
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
    Art: string;
    Titel: string;
    Anrede: string;
    Nachname: string;
    Vorname: string;
    Firmenname: string;
    Zusatz: string;
    AdressZusatz1: string;
    AdressZusatz2: string;
    Strasse: string;
    Hausnummer: string;
    Postfach: string;
    Postleitzahl: string;
    Ort: string;
    Ortsteil: string;
    Land: string;
    IstInland: boolean;
    Mailadresse: string;
    Landesvorwahl: string;
    Vorwahl: string;
    Telefonnummer: string;
    Durchwahl: string;
    Webadresse: string;
    Verwendungszweck: string;
    Prioritaet: number;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    AnzeigeName: string;
};

export type BelegApi = ReturnType<typeof createBelegApi>;

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
    BelegDatum: string;
    PosAnzahl: number;
    GesamtBetrag: number;
    Kundennummer: string;
    Kundenname: string;
    Lieferadresse: string;
    IstSammelrechnungsKunde: boolean;
    InnergemeinschaftlichOhneMwSt: boolean;
    SammelrechnungsNummer: number | null;
    LastPrintDate: string | null;
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
    Bereitgestellt: string;
    Berechnet: string | null;
    IstBerechnet: boolean;
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
    FakturaKennzeichen: string;
    IstAusserhalbGewaehrleistung: boolean;
    KapazitaetsBedarf: number;
    Position: BelegPositionDTO | null;
    ProduktionsDaten: ProduktionsDatenDTO | null;
    IstGedruckt: boolean;
    ErfassungsDatum: string;
    ChangedDate: string;
    CalculatedForTimestamp: string | null;
};

export type BelegPositionAVListItemDTO = {
    BelegPositionAVGuid: string;
    BelegPositionGuid: string | null;
    PCode: string;
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
    LaufendeNummer: number;
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
    setBelegPositionGesperrtStatus: (gesperrtStatus: boolean, positionen: string[]) => Promise<string[]>;
    getVorgangForFunction: (belegPositionGuid: string, mandantId: number) => Promise<VorgangDTO>;
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
    Text: string;
    Betrag: number;
    Wert: number;
    Typ: string;
    Art: string;
    Name: string;
    SaldenStatus: string;
    IstInaktiv: boolean;
    Tag: string;
    Rabatt: number;
    TemplateText: string;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
};

export type BelegSerienInfoDTO = {
    BelegGuid: string;
    SerienInfos: Array<SerieInfoDTO>;
};

export type BelegStatus = 0|10|20|30|40|50|60|70|80|90|100|110|120|130|140|150|160;

export type BelegStatusDTO = {
    VorgangGuid: string;
    BelegGuid: string;
    VorgangsNummer: number;
    BelegNummer: number;
    AktuellerStatus: string;
    AenderungsDatum: Date;
    NeuerStatus: string;
    NeuerStatusText: string;
    AktuellerStatusText: string;
};

export type BelegWorkflow = {
    Steps: Array<BelegArt>;
};

export type BenutzerApi = ReturnType<typeof createBenutzerApi>;

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
    ChangedDate: string;
    EmailAdresse: string;
    TelefonNummer: string;
    Art: string;
    IstSicSynchronized: boolean;
    LastSicMessage: string;
};

export type BerechnungParameterDTO = {
    MandantGuid: string;
    SaveResultData: boolean;
    BelegPositionAVDTO: BelegPositionAVDTO;
    ProduktionsSettingsDTO: ProduktionsSettingsDTO;
    VorgangsNummer: number;
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
};

export type BerechtigungDTO = {
    Code: string;
    ErklaerungsText: string;
    Level: string;
};

export type BestellungListItemDTO = BaseListItemDTO;

export type CalculationInfoDTO = {
    MandantId: number;
    BelegPositionGuid: string;
    CalculationRequestTimestamp: Date|null;
    CalculatedForTimestamp: Date|null;
};

export type ChangeDTO = {
    ChangedGuid: string;
    ChangedWhen: string;
    ChangeType: string;
    ChangeOperation: string;
    MandantId: number | null;
    MandantGuid: string | null;
    Data: string;
};

export type ChangeInfoDTO = {
    Kontakte: string;
    Vorgaenge: string;
    Serien: string;
    BelegPositionenAV: string;
    Settings: string;
    Lagerbestand: string;
    BelegPositionen: string;
    ProduktionsStati: string;
    TagInfos: string;
};

export type ContractDTO = {
    ContractGuid: string;
    Owner: string;
    Partner: string;
    Context: string;
    Value: string;
    Version: number;
    ChangedDate: string;
    OwnerName: string;
    PartnerName: string;
    IsEditable: boolean;
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
    AppTokenGuid: string;
};

export type CsvExportCombinationDTO = {
    ExportArtikelArten: ExportArtikelArt[];
    ExportFarbArten: ExportFarbArt[];
};

export type DecodedToken = import("jwt-decode").JwtPayload & JwtUserInfo & { id?: string };

export type DevOpsStatusDTO = {
    Env: string;
    DbInfo: string;
    CurrentMigration: string;
    PendingMigrations: string[];
};

export type EnvironmentConfig = {
    name: string;
    version: string;
    cms: string;
    idas: string;
    store: string;
    docs: string;
    notify: string;
    feedback: string;
    helpcenter: string;
    reports: string;
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
    IstZusatzEtikett: boolean;
    Typ: string;
    EtikettDaten: Array<EtikettDatenDTO>;
    EtikettenProfilVorbiegen: boolean;
    EtikettenSonderKuerzel: string;
};

export type ExportArtikelArt = ('Neher'|'Ueberschriebene'|'Eigene');

export type ExportFarbArt = ('Standardfarbe'|'Trendfarbe'|'Sonderfarbe');

export type ExtendedStatusCodeDTO = {
    Exception: Error | null;
    Info: string;
};

export type FachzuordnungResultDTO = {
    ProduktfamilienOverCapacity: Array<string>;
    OverCapacity: boolean;
};

export type FakturaApi = ReturnType<typeof createFakturaApi>;

export type FarbArt = 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7;

export type FarbeApi = ReturnType<typeof createFarbeApi>;

export type FarbeDTO = {
    FarbItemGuid: string;
    Bezeichnung: string;
    BildDateiname: string;
    FarbCode: string;
    Farbe: string;
    ChangedDate: string;
    Version: number;
    GueltigAb: string | null;
    GueltigBis: string | null;
};

export type FarbGruppeDTO = {
    Bezeichnung: string;
    AnzeigeName: string;
    FarbItemGroupGuid: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
    Version: number;
    ChangedDate: string;
    Reihenfolge: number;
    IstGesperrt: boolean;
    FarbItemGuids: string[];
    OberflaecheGuids: string[];
};

export type FarbgruppenaufpreiseDTO = {
    FarbgruppenaufpreiseGuid: string;
    NeherModellAktiv: boolean;
    EigenesModellAktiv: boolean;
    IstAdminDTO: boolean;
    FarbgruppenSettings: FarbgruppeSettingsDTO[];
    Version: number;
    ChangedDate: string;
};

export type FarbgruppeSettingsDTO = {
    FarbgruppenGuid: string;
    GruppeAktiv: boolean;
    PreisAufAnfrage: boolean;
    AufpreisElement: number;
    AufpreisFarbe: number;
    ProzentAufpreisElement: number;
    AufpreisMaximal: number;
    AufpreisMaximalAktiv: boolean;
};

export type FarbKuerzelDTO = {
    FarbKuerzelGuid: string;
    Kuerzel: string;
    Beschreibung: string;
    FarbBezeichnung: string;
    IstTrendfarbe: boolean;
    FarbItemGuid: string;
    OberflaecheGuid: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
    Version: number;
    ChangedDate: string;
};

export type FarbKuerzelGruppeDTO = {
    FarbKuerzelGruppeGuid: string;
    Kuerzel: string[];
    Bezeichnung: string;
    GueltigAb: string | null;
    GueltigBis: string | null;
    Version: number;
    ChangedDate: string;
};

export type FileApi = ReturnType<typeof createFileApi>;

export type FluentApi = {
    baseUrl: string;
    authManager: FluentAuthManager|null;
    serviceName: string;
    settings?: any;
    useBaseUrl: (url?: string) => FluentApi;
    useAuthManager: (authManager: FluentAuthManager) => FluentApi;
    useServiceName: (name: string) => FluentApi;
    withBaseUrl: (url?: string) => FluentApi;
    get: (url?: string, auth?: boolean) => Promise<object|Array<any>>;
    put: (url?: string, payload?: object, auth?: boolean) => Promise<object|Array<any>>;
    post: (url?: string, payload?: object, auth?: boolean) => Promise<object|Array<any>>;
    delete: (url?: string, payload?: object|FormData|Array<any>|string[]|string|null, auth?: boolean) => Promise<object|Array<any>>;
    createRestClient: () => FluentRESTClient;
    preCheck: (auth?: boolean) => Promise<void>;
};

export type FluentAuthManager = {
    appToken: string;
    authUrl: string;
    token: string;
    refreshToken: string;
    userInfo: JwtUserInfo;
    useAppToken: (appToken?: string) => FluentAuthManager|null;
    useBaseUrl: (url?: string) => FluentAuthManager;
    useToken: (jwtToken?: string|null) => FluentAuthManager;
    useRefreshToken: (storedRefreshToken?: string|null) => FluentAuthManager;
    ensureAuthenticated: () => Promise<void>;
    authenticate: () => Promise<void>;
    init: () => Promise<FluentAuthManager>;
    login: (username?: string, password?: string) => Promise<void>;
    tryRefreshToken: (refreshToken?: string) => Promise<string|null>;
    updateUserSession: (token: string|null) => void;
    redirectToLogin: () => void;
    hasRight: (code: string) => boolean;
    hasRole: (code: string) => boolean;
};

export type FluentRESTClient = {
    baseUrl: string;
    token: string;
    userAgent: string;
    useBaseUrl: (url?: string) => FluentRESTClient;
    useToken: (jwtToken?: string) => FluentRESTClient;
    useUserAgent: (userAgent?: string) => FluentRESTClient;
    get: (url?: string, auth?: boolean) => Promise<any>;
    put: (url?: string, payload?: object) => Promise<any>;
    post: (url?: string, payload?: object|FormData) => Promise<any>;
    delete: (url?: string, payload?: object|FormData|Array<any>|string[]|string|null) => Promise<any>;
    _createHeaders: (contentType?: string) => Headers;
    _parseReponse: (res: Response) => Promise<any>;
};

export type FreigabeArt = 0|1|2;

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

export type HistorieApi = ReturnType<typeof createHistorieApi>;

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
    InfoScreenModule: Array<InfoScreenModulSettingsDTO>;
    RowNum: number;
};

export type JobStatusEntryDTO = {
    JobGuid: string;
    Timestamp: string;
    StatusText: string;
    RowKey: string;
};

export type JobStatusResponseDTO = {
    JobGuid: string;
};

export type JwtTokenExt = {
    id: string;
    refreshToken: string;
};

export type JwtUserInfo = {
    rights?: string|string[];
    role?: string|string[];
};

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
    GewichtInKg: number;
    MaterialGuid: string;
    MoeglicheFarben: Array<KatalogArtikelFarbZuordnungDTO>;
    ProfilLaengeMM: number;
    Freigabe_IBOS: boolean;
    Freigabe_BestellFix: boolean;
    Freigabe_ARTOS: boolean;
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
    ErsatzArtikel: Array<string>;
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
    KatalogArtikelIndiDatenGuid: string;
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
    getList: (ohneEndkunden?: boolean, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<KontaktListItemDTO[]>;
    getListChangedSince: (changedSince?: Date|null, ohneEndkunden?: boolean, includeASP?: boolean, includeAdditionalProperties?: boolean) => Promise<KontaktListItemDTO[]>;
    getByGuid: (kontaktGuid: string) => Promise<KontaktDTO>;
    getByKundenNummer: (kundenNummer: string) => Promise<KontaktDTO>;
    save: (kontakt: KontaktDTO) => Promise<KontaktDTO>;
    archive: (kontakteIds: string[]) => Promise<void>;
    unarchive: (kontakteIds: string[]) => Promise<void>;
    setFremdfertigungGuid: (guidMapping: Record<string, string>) => Promise<void>;
    getForFunction: (kontaktGuid: string, mandantId: number) => Promise<KontaktDTO>;
    getAllForFunction: (changedSince?: Date|null) => Promise<Record<number, string[]>>;
};

export type KontaktDTO = {
    KontaktGuid: string;
    Nachname: string;
    Vorname: string;
    Firmenname: string;
    KundenNummer: string;
    Erstkontakt: Date|null;
    LetzterKontakt: Date|null;
    IstEndkunde: boolean;
    Kommentar: string;
    IstKunde: boolean;
    IstGesperrt: boolean;
    IstArchiviert: boolean;
    IstSelbstabholer: boolean;
    IstVorkasse: boolean;
    IstUmsatzsteuerPflichtig: boolean;
    InnergemeinschaftOhneMwSt: boolean;
    Personen: Array<PersonDTO>;
    Zusatzanschriften: Array<ZusatzanschriftDTO>;
    IstDummyKunde: boolean;
    ArtikelRabattVorgabe: number;
    ElementRabattVorgabe: number;
    UmsatzSteuerId: string;
    Branche: string;
    Nummernkreis: string;
    Liefertage: string[];
    ShowSonderetikett: boolean;
    Sonderetikett: string;
    Briefanrede: string;
    Titel: string;
    Anrede: string;
    AdressZusatz1: string;
    AdressZusatz2: string;
    Strasse: string;
    Hausnummer: string;
    Postfach: string;
    Postleitzahl: string;
    Ort: string;
    Ortsteil: string;
    Land: string;
    IstInland: boolean;
    Mailadresse: string;
    Landesvorwahl: string;
    Vorwahl: string;
    Telefonnummer: string;
    Durchwahl: string;
    Webadresse: string;
    Transportkosten: number|null;
    AbweichendeTransportkosten: boolean;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
    KontaktMandantGuid: string;
    KontaktMandantIstAktiv: boolean;
    Version: number;
    ChangedDate: Date;
    NettoTage: number;
    Skonto: number;
    SchlussTextAngebotAB: string;
    SchlussTextRechnung: string;
    Zahlungsbedingung: string;
    HatWinterrabatt: boolean;
    KeineAutofreigabe: boolean;
    ErbtAuswahlOhneSprosse: boolean;
    DigitalerRechnungsversand: boolean;
    IstSammelrechnungsKunde: boolean;
    IstInaktiv: boolean;
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
    KontaktMandantIstAktiv: boolean;
    Nachname: string;
    Vorname: string;
    Firmenname: string;
    KundenNummer: string;
    Strasse: string;
    Hausnummer: string;
    Land: string;
    Plz: string;
    Ort: string;
    Ortsteil: string;
    Telefon: string;
    Email: string;
    IstEndkunde: boolean;
    IstKunde: boolean;
    IstGesperrt: boolean;
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

export type LagerApi = ReturnType<typeof createLagerApi>;

export type LagerbestandDTO = {
    LagerbestandGuid: string;
    KatalogArtikelGuid: string;
    KatalogNummer: string;
    FarbGuid: string;
    FarbKuerzelGuid: string;
    FarbKuerzel: string;
    Lagerbestand: number;
    Bestellbestand: number;
    Mindestbestand: number;
    Reserviert: number;
    Maximalbestand: number;
    EisernerBestand: number;
    Einheit: string;
    Lagerplatz: string;
    Charge: string;
    IstAktiv: boolean;
    Seriennummer: string;
    ChangedDate: string;
    WindowsUser: string;
};

export type LagerbuchungDTO = {
    KatalogArtikelGuid: string;
    FarbGuid: string;
    FarbKuerzelGuid: string;
    LagerbestandGuid: string;
    Betrag: number;
    IstReservierung: boolean;
    Einheit: string;
    Hinweis: string;
    ArtosUser: string;
    WindowsUser: string;
    ChangedDate: string;
    BestandAlt: number;
    BestandNeu: number;
};

export type LagerReservierungDTO = {
    LagerReservierungGuid: string;
    MaterialbedarfGuid: string | null;
    LieferzusageGuid: string | null;
    GesamtLieferzusageGuid: string | null;
    Artikelnummer: string;
    FarbKuerzel: string;
    FarbCode: string;
    Oberflaeche: string;
    Bezug: string;
    Menge: number;
    Einheit: string;
    ErstellDatum: string;
    WindowsUser: string;
    ArtosUser: string;
    ChangedDate: string;
    Version: number;
};

export type LayoutBelegDruckDTO = ILayoutBelegDruck;

export type LieferungApi = ReturnType<typeof createLieferungApi>;

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

export type LoginAttemptDTO = {
    UserGuid: string;
    FailCount: number;
    RequestTime: string | null;
};

export type LoginAttemptResultDTO = {
    FailCount: number;
    LastFailedLogin: string | null;
};

export type LoginDTO = {
    Email: string;
    Password: string;
    Mandant: string;
    AppToken: string;
};

export type MailApi = ReturnType<typeof createMailApi>;

export type MailJobInfo = {
    JobGuid: string;
    ToAddresses: Array<string>;
    CCAddresses: Array<string>;
    ReplyToAddress: string;
    Subject: string;
    Content: string;
    BelegGuid: string;
};

export type MandantAndBelegPosGuidDTO = {
    MandantId: number;
    BelegPositionGuid: string;
};

export type MandantApi = ReturnType<typeof createMandantApi>;

export type MandantDTO = {
    Name: string;
    Beschreibung: string;
    ErstellDatum: string;
    AenderungsDatum: string;
    AdminEmail: string;
    MandantGuid: string;
    SIC_CMS_Producer_Id: number;
    DongleNummer: string;
    ProduzentMandantGuid: string;
    KundenNummerBeimProduzenten: string;
    IstAktiv: boolean;
    IstHaendler: boolean;
    IstProduzent: boolean;
    ErbtAuswahlOhneSprosse: boolean;
    StammdatenbearbeitungGesperrt: boolean;
    NeherKundennummer: string;
};

export type MandantFreigabeDTO = {
    Code: string;
    GueltigAb: string;
    Level: FreigabeLevel;
    Art: FreigabeArt;
    ZusatzDaten: string;
};

export type MaterialApi = {
    getAll: () => Promise<MaterialDTO[]>;
    saveMaterial: (material: MaterialDTO) => Promise<void>;
};

export type MaterialBearbeitungsMethodeDTO = {
    MaterialBearbeitungsMethodeGuid: string;
    Bezeichnung: string;
    Version: number;
    ChangedDate: string;
};

export type MaterialbedarfCutOptimization = object.<string, any>;

export type MaterialbedarfDTO = {
    MaterialBedarfGuid: string;
    Kennzeichen: string;
    InternerName: string;
    InternerName_Backup: string;
    KatalogNummer: string;
    Bezeichnung: string;
    Einheit: string;
    Beipacken: boolean;
    Vorgangsnummer: string;
    Stueckzahl: number;
    Laufmeter: number;
    IstVE: boolean;
    VE_Menge?: number;
    FarbBezeichnung: string;
    FarbZusatzText: string;
    FarbKuerzel: string;
    FarbKuerzelGuid: string;
    FarbCode: string;
    FarbeItem: string;
    FarbItemGuid: string;
    OberflaecheBezeichnung: string;
    OberFlaecheGuid: string;
    PulverCode: string;
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

export type MaterialbedarfExportType = ('CSV'|'Schnittstelle');

export type MaterialbedarfExportUserSettings = {
    CsvExportPath: string;
};

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

export type NachrichtenDTO = {
    NachrichtGuid: string;
    MandantGuid: string;
    BesitzerMandantGuid: string;
    Context: string;
    Nachricht: string;
    IstAktiv: boolean;
    GueltigAb: string | null;
    GueltigBis: string | null;
};

export type NeherApp3 = {
    addMenuItem: (menuItem: NeherApp3MenuItem) => void;
    addApp: (appModule: NeherApp3Module | string) => Promise<void>;
    notify: (message: string, type?: NeherApp3NotifyType, cb?: Function) => void;
    api: NeherApp3ApiCollection;
    cache: NeherApp3CacheCollection;
};

export type NeherApp3ApiCollection = {
    idas?: IDASFluentApi;
    hostingEnvironment?: FluentApi;
};

export type NeherApp3ArtikelstammCache = {
    getArtikelStamm: () => Promise<ArtikelstammEintrag[]>;
    getWarenGruppen: () => Promise<object[]>;
    getArtikelByGuid: (guid: string) => Promise<ArtikelstammEintrag | undefined>;
    getArtikelByKatalognummer: (nummer: string) => Promise<ArtikelstammEintrag | undefined>;
};

export type NeherApp3CacheCollection = {
    artikelstamm: NeherApp3ArtikelstammCache;
    erfassung: NeherApp3ErfassungCache;
};

export type NeherApp3ErfassungCache = {
    getVarianten: () => Promise<Variante[]>;
    getVariante: (variantenNameOderKuerzel: string) => Promise<Variante | undefined>;
    getWertelisten: () => Promise<Werteliste[]>;
    getWerteliste: (name: string) => Promise<Werteliste | undefined>;
    getScripts: () => Promise<object[]>;
    createUIMachine: (v: Variante) => void;
};

export type NeherApp3MenuItem = {
    id?: string;
    selected?: boolean;
    icon?: string;
    url?: string | null;
    text: string;
    parent?: string | null;
    hidden?: boolean;
};

export type NeherApp3Module = {
    moduleName: string;
    setup?: (context: NeherApp3SetupContext) => void | Promise<void>;
    mount?: (node: HTMLElement, props: NeherApp3SetupContext) => void | Function;
    embedUrl?: string;
    extraCSS?: string[];
    useShadowDom?: boolean;
};

export type NeherApp3NotifyType = 0 | 1 | 2;

export type NeherApp3Props = {
    api: FluentApi;
    authManager?: FluentAuthManager;
    idas: IDASFluentApi;
    mainCssPath?: string;
};

export type NeherApp3SetupContext = NeherApp3Props & { neherapp3: NeherApp3 };

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
    PersonGuid: string;
    Nachname: string;
    Vorname: string;
    WeitereVornamen: string;
    Geburtstag: Date|null;
    Briefanrede: string;
    Anrede: string;
    Mailadresse: string;
    Telefonnummer: string;
    MobileTelefonnummer: string;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
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
    ProduktionsDatum: string;
    LieferDatum: string;
    PositionInfo: string;
    KapBedarf: number;
    KapBedarfGes: number;
    HatNachfolgeBelegPosition: boolean;
    VeschiedeneSerien: boolean;
    SerienGuids: string[] | null;
};

export type PreisermittlungsEinstellungenDTO = {
    WaehrungsSymbol: string;
    WaehrungsFaktor: number;
    SteuerSatz: number;
    EndpreisRundungsModus: string;
    SonderfarbZuschlaege: string;
    BruttoPreisErmitteln: boolean;
    AufpreisAnpassungen: object.<string, AufpreisAnpassungDTO[]>;
    PreisfaktorAnpassungen: object.<string, number>;
    ZuschnittpreisfaktorAnpassungen: object.<string, number>;
    AufpreisfaktorAnpassungen: object.<string, number>;
    GrenzfreigabeAnpassungen: object.<string, boolean>;
    MbAufpreis: number;
    Mb_v_Fix_Aufpreis: number|null;
    Mb_Klebeband_Aufpreis: number|null;
    ChangedDate: string;
};

export type PrintApi = ReturnType<typeof createPrintApi>;

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
    ProduktGruppeGuid: string;
    KurzBezeichnung: string;
    Bezeichnung: string;
    ProduktSerien: Array<ProduktFamilieDTO>;
    Version: number;
    ChangedDate: string;
};

export type ProduktionApi = ReturnType<typeof createProduktionApi>;

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

export type ProduktionsDatenDTO = {
    ProduktionsDatenGuid: string;
    Material: Array<MaterialbedarfDTO>;
    Etiketten: Array<EtikettDTO>;
    Bearbeitungen: Array<BearbeitungDTO>;
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
    SprossenfreiEnabled: boolean;
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
    FreischaltCode: string;
    AdminEmail: string;
    DongleNummer: number;
};

export type ProduzentenFarbGruppeDTO = {
    ProduzentenFarbGruppeGuid: string;
    Name: string;
    Oberflaechen: string[];
    Farben: string[];
    Version: number;
    ChangedDate: string;
};

export type ProfilKuerzelDTO = {
    ProfilKuerzel: string;
    Beschreibung: string;
    VerfuegbarFuer: string[];
};

export type PropertyValueCollection = object;

export type RechnungApi = ReturnType<typeof createRechnungApi>;

export type RechnungsNummer = 0|1;

export type RefreshTokenDTO = {
    Token: string;
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

export type SaegeKonfigurationDTO = {
    Bezeichnung: string;
    Modell: string;
    DisplayName: string;
    KorrekturSatz: string;
    DoppelGeradSchnitt: boolean;
    DoppelGehrungsSchnitt: boolean;
    GeradGehrungsSchnitt: boolean;
    FreierSchnitt: boolean;
    Ausgabeverzeichnis_Geradschnitt: string;
    Ausgabeverzeichnis_GeradGehrung: string;
    Ausgabeverzeichnis_DoppelGehrung: string;
    KombinierteSaegeDatei: boolean;
    Ausgabverzeichnis_kombiniert: string;
    FarbKuerzel_SF: string;
};

export type SaegemassKorrekturDTO = {
    KatalogNummer: string;
    Korrektur90Grad: number;
    Korrektur45Grad: number;
    WinkelKorrektur45Grad: number;
    WinkelKorrektur90Grad: number;
};

export type SaegemassKorrekturSatzDTO = {
    Bezeichnung: string;
    SaegemassKorrekturen: Array<SaegemassKorrekturDTO>;
};

export type SammelrechnungDTO = {
    SammelrechnungGuid: string;
    SammelrechnungsNummer: number;
    ErstellDatum: string;
    LastPrintDate: string | null;
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
    ErstellDatum: string;
    LastPrintDate: string | null;
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
    RechnungDatum: string;
    RechnungKommision: string;
    RechnungBetrag: number;
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
    Zeitstempel: string;
};

export type SerieDTO = {
    SerieGuid: string;
    Name: string;
    Kuerzel: string;
    Start: string;
    Ende: string;
    StaendigeSerie: boolean;
    AVBelegPositionen: string[];
    Kapazitaet: number;
    KapazitaetInMin: number;
    KapazitaetReserviert: number;
    MaterialBedarfStatus: string;
    IstGesperrt: boolean;
    DruckInfos: SerieDruckInfoDTO[];
    ChangedDate: string;
};

export type SerieHistorieDTO = {
    SerieHistorieGuid: string;
    SerieGuid: string;
    SerienName: string;
    Text: string;
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
    getAllBelegPositionenAV: () => Promise<BelegPositionAVDTO[]>;
    getAllBelegPositionenAVChangedSince: (changedSince: Date) => Promise<BelegPositionAVDTO[]>;
    getAllBelegPositionenAVWithOptions: (includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    getAllBelegPositionenAVChangedSinceWithOptions: (changedSince: Date, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    getSerieBelegPositionenAV: (serieGuid: string, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    getVorgangBelegPositionenAV: (vorgangGuid: string, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    getVorgaengeBelegPositionenAV: (vorgangGuids: string[], includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    getBelegPositionenAV: (belegpositionGuid: string) => Promise<BelegPositionAVDTO[]>;
    getBelegPositionAVById: (avGuid: string) => Promise<BelegPositionAVDTO>;
    getBelegPositionAVByPCode: (pcode: string, includeOriginalBeleg?: boolean, includeProdDaten?: boolean) => Promise<BelegPositionAVDTO[]>;
    searchBelegPositionAVByPCode: (search: string) => Promise<BelegPositionAVDTO[]>;
    saveBelegPositionenAV: (position: BelegPositionAVDTO) => Promise<void>;
    saveBelegPositionenAVBulk: (positionen: BelegPositionAVDTO[]) => Promise<BelegPositionAVDTO[]>;
    saveBelegPositionenAVToSerie: (serieGuid: string, positionen: string[]) => Promise<BelegPositionAVDTO[]>;
    belegPositionenAVBerechnen: (guids: string[]) => Promise<void>;
    deleteBelegPositionenAV: (guid: string) => Promise<void>;
    deleteBelegPositionenAVBulk: (guids: string[]) => Promise<void>;
    belegPositionenSerienZuordnen: (belegGuid: string, positionSerieItems: PositionSerieItemDTO[]) => Promise<void>;
};

export type SerienMaterialEditDTO = {
    SerieGuid: string;
    MaterialListe: MaterialbedarfDTO[];
};

export type SetFakturaDTO = {
    GuidList: string[];
    Kennzeichen: string;
};

export type Settings = {
    appToken: string;
    mandantGuid: string;
    apiBaseurl: string;
    authUrl: string;
};

export type SettingsApi = ReturnType<typeof createSettingsApi>;

export type SLKServerSettingsDTO = {
    SLKNichtAktiv: boolean;
};

export type SonderwuenscheDTO = {
    Bezeichnung: string;
    Wert: string;
};

export type SystemApi = ReturnType<typeof createSystemApi>;

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
    TemplateGuid: string;
    Titel: string;
    Beschreibung: string;
    Typ: string;
    JsonDaten: string;
    ChangedDate: string;
    Benutzer: string;
};

export type UiApi = ReturnType<typeof createUiApi>;

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
    KatalogArtikel: string;
    ProduktFamilien: string;
    ProduktGruppen: string;
    Varianten: string;
    UI: string;
    WerteListen: string;
    Farben: string;
    Scripts: string;
    FarbKuerzel: string;
    Oberflaechen: string;
    FarbGruppen: string;
};

export type UserAuthTokenDTO = {
    AppToken: string;
    Expires: string;
    Token: string;
    Benutzer: BenutzerDTO | null;
    MandantGuid: string;
    Mandant: MandantDTO | null;
};

export type UtilityApi = ReturnType<typeof createUtilityApi>;

export type Variante = {
    VarianteGuid?: string;
    Name?: string;
    Kuerzel?: string;
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
    KonfigSatzGuid: string;
    KonfigSatz: Array<KonfigSatzEintragDTO>;
    IstTechnischeVariante: boolean;
};

export type VarianteDTOListe = Array<VarianteDTO>;

export type VirtualSerieWithAuslastungDTO = {
    SerieGuid: string;
    Name: string;
    Kuerzel: string;
    Start: string;
    Ende: string;
    Auslastungen: SerieAuslastungDTO[];
};

export type VorgangApi = {
    getList: (jahr: number) => Promise<VorgangListItemDTO[]>;
    getListByStatus: (status: string, jahr: number) => Promise<VorgangListItemDTO[]>;
    getListByStatusAndChangedSince: (status: string, jahr: number, changedSince: Date) => Promise<VorgangListItemDTO[]>;
    getListWithFilters: (changedSince: Date, jahr: number, status: string, art: string, includeArchive: boolean, includeOthersData: boolean, search: string) => Promise<VorgangListItemDTO[]>;
    getListByYearAndFilters: (jahr: number, status: string, changedSince: Date, art: string, includeArchive: boolean, includeOthersData: boolean, search: string) => Promise<VorgangListItemDTO[]>;
    getListByKunde: (kundeGuid: string) => Promise<VorgangListItemDTO[]>;
    saveList: (list: VorgangDTO[]) => Promise<void>;
    changeNummer: (vorgangGuid: string, neueVorgangsNummer: number) => Promise<void>;
    save: (vorgang: VorgangDTO) => Promise<VorgangDTO>;
    getByGuid: (vorgangGuid: string, includeKunde: boolean, returnNullIfNotFound: boolean) => Promise<VorgangDTO>;
    getByNummer: (vorgangsNummer: number, jahr: number, includeKunde: boolean) => Promise<VorgangDTO>;
    getStatus: (vorgangGuid: string) => Promise<VorgangStatusDTO>;
    setStatus: (vorgangGuid: string, statusCode: string) => Promise<VorgangStatusDTO>;
    setTextStatus: (vorgangGuids: string[], textStatus: string) => Promise<void>;
    archive: (vorgangGuid: string) => Promise<void>;
    archiveList: (vorgangGuidList: string[]) => Promise<void>;
    unarchive: (vorgangGuid: string) => Promise<void>;
    changeBelegArt: (belegGuid: string, neueBelegArt: string) => Promise<void>;
    getAllForFunction: (changedSince: Date) => Promise<Record<number, VorgangListItemDTO[]>>;
    getForFunction: (vorgangGuid: string, mandantId: number) => Promise<VorgangDTO>;
};

export type VorgangDTO = {
    VorgangGuid: string;
    VorgangsNummer: number;
    KundenNummer: string;
    IstEndkunde: boolean;
    Kommission: string;
    Kommission2: string;
    ErstellDatum: Date;
    AenderungsDatum: Date;
    Belege: Array<BelegDTO>;
    Positionen: Array<BelegPositionDTO>;
    Nachrichten: Array<string>;
    Historie: Array<VorgangHistorieDTO>;
    Besitzer: BenutzerDTO;
    Kunde: KontaktDTO;
    KundeGuid: string;
    AktuellerStatus: string;
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
    VorgangGuid: string;
    VorgangsNummer: number;
    OriginalVorgangsNummer: number|null;
    ErstellDatum: Date;
    AenderungsDatum: Date;
    AktuelleBelegArt: string;
    Kommission: string;
    Kommission2: string;
    VorgangsNotitz: string;
    AktuelleBelegNummer: string;
    AktuelleRechnungsNummer: string;
    AlleBelegNummern: string;
    AktuelleBelegGuid: string;
    KundenNummer: string;
    Kundenname: string;
    KundeGuid: string;
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
    Besitzer: string;
    Besteller: string;
    Bearbeiter: string;
    ExterneReferenznummer: string;
    ExterneMandantenGuid: string|null;
    ExternerFirmenname: string;
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
    VorgangGuid: string;
    VorgangsNummer: number;
    AktuellerStatus: string;
    AenderungsDatum: Date;
    NeuerStatus: string;
};

export type VorgangStatusTableDTO = {
    VorgangGuid: string;
    KontaktGuid: string|null;
    KundeGeaendert: boolean;
    AenderungsDatum: Date;
    MandantId: number;
};

export type VorgangTextStatusDTO = {
    VorgangGuids: Array<string>;
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

export type WebJobHistorieDTO = {
    WebJobHistorieGuid: string;
    WebJobName: string;
    Timestamp: string;
    Status: string;
    Text: string;
};

export type Werteliste = {
    WerteListeGuid?: string;
    Name?: string;
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
    Titel: string;
    Anrede: string;
    Nachname: string;
    Vorname: string;
    Firmenname: string;
    AdressZusatz1: string;
    AdressZusatz2: string;
    Strasse: string;
    Hausnummer: string;
    Postfach: string;
    Postleitzahl: string;
    Ort: string;
    Ortsteil: string;
    Land: string;
    IstInland: boolean;
    Mailadresse: string;
    Verwendungszweck: string;
    Prioritaet: number;
    ApplicationSpecificProperties: Record<string, PropertyValueCollection>;
    AdditionalProperties: Record<string, PropertyValueCollection>;
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
    Zeitstempel: string;
    Plattform: string;
};

