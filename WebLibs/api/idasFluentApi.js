import { createApi } from "./fluentApi";
import { createVorgangApi } from "./business/vorgangApi";
import { createKontaktApi } from "./business/kontaktApi";
import { createBelegPositionenApi } from "./business/belegPositionenApi";
import { createMaterialApi } from "./business/materialApi";
import { createSerienApi } from "./business/serienApi";
import { createBenutzerApi } from "./business/benutzerApi";
import { createArtikelApi } from "./business/artikelApi";
import { createBelegApi } from "./business/belegApi";
import { createProduktionApi } from "./business/produktionApi";
import { createFakturaApi } from "./business/fakturaApi";
import { createRechnungApi } from "./business/rechnungApi";
import { createSettingsApi } from "./business/settingsApi";
import { createUiApi } from "./business/uiApi";
import { createUtilityApi } from "./business/utilityApi";
import { createAblageApi } from "./business/ablageApi";
import { createAvApi } from "./business/avApi";
import { createFarbeApi } from "./business/farbeApi";
import { createLagerApi } from "./business/lagerApi";
import { createLieferungApi } from "./business/lieferungApi";
import { createMandantApi } from "./business/mandantApi";
import { createPrintApi } from "./business/printApi";
import { createHistorieApi } from "./business/historieApi";
import { createSystemApi } from "./business/systemApi";
import { createFileApi } from "./business/fileApi";
import { createMailApi } from "./business/mailApi";
import { createAnpassungApi } from "./business/anpassungApi";
import { createAuthApi } from "./business/authApi";

/**
 * @typedef {import("./business/vorgangApi.js").VorgangApi} VorgangApi
 * @typedef {import("./business/kontaktApi.js").KontaktApi} KontaktApi
 * @typedef {import("./business/belegPositionenApi.js").BelegPositionenApi} BelegPositionenApi
 * @typedef {import("./business/materialApi.js").MaterialApi} MaterialApi
 * @typedef {import("./business/serienApi.js").SerienApi} SerienApi
 * @typedef {import("./business/benutzerApi.js").BenutzerApi} BenutzerApi
 * @typedef {import("./business/artikelApi.js").ArtikelApi} ArtikelApi
 * @typedef {import("./business/belegApi.js").BelegApi} BelegApi
 * @typedef {import("./business/produktionApi.js").ProduktionApi} ProduktionApi
 * @typedef {import("./business/fakturaApi.js").FakturaApi} FakturaApi
 * @typedef {import("./business/rechnungApi.js").RechnungApi} RechnungApi
 * @typedef {import("./business/settingsApi.js").SettingsApi} SettingsApi
 * @typedef {import("./business/uiApi.js").UiApi} UiApi
 * @typedef {import("./business/utilityApi.js").UtilityApi} UtilityApi
 * @typedef {import("./business/ablageApi.js").AblageApi} AblageApi
 * @typedef {import("./business/avApi.js").AvApi} AvApi
 * @typedef {import("./business/farbeApi.js").FarbeApi} FarbeApi
 * @typedef {import("./business/lagerApi.js").LagerApi} LagerApi
 * @typedef {import("./business/lieferungApi.js").LieferungApi} LieferungApi
 * @typedef {import("./business/mandantApi.js").MandantApi} MandantApi
 * @typedef {import("./business/printApi.js").PrintApi} PrintApi
 * @typedef {import("./business/historieApi.js").HistorieApi} HistorieApi
 * @typedef {import("./business/systemApi.js").SystemApi} SystemApi
 * @typedef {import("./business/fileApi.js").FileApi} FileApi
 * @typedef {import("./business/mailApi.js").MailApi} MailApi
 * @typedef {import("./business/anpassungApi.js").AnpassungApi} AnpassungApi
 * @typedef {import("./business/authApi.js").AuthApi} AuthApi
 */

/**
 * @typedef {import("./fluentApi.js").FluentApi & {
 *   vorgang: VorgangApi;
 *   kontakt: KontaktApi;
 *   belegPositionen: BelegPositionenApi;
 *   material: MaterialApi;
 *   serien: SerienApi;
 *   benutzer: BenutzerApi;
 *   artikel: ArtikelApi;
 *   beleg: BelegApi;
 *   produktion: ProduktionApi;
 *   faktura: FakturaApi;
 *   rechnung: RechnungApi;
 *   settings: SettingsApi;
 *   ui: UiApi;
 *   utility: UtilityApi;
 *   ablage: AblageApi;
 *   av: AvApi;
 *   farbe: FarbeApi;
 *   lager: LagerApi;
 *   lieferung: LieferungApi;
 *   mandant: MandantApi;
 *   print: PrintApi;
 *   historie: HistorieApi;
 *   system: SystemApi;
 *   file: FileApi;
 *   mail: MailApi;
 *   anpassung: AnpassungApi;
 *   auth: AuthApi;
 *   userInfo: import("./fluentAuthManager.js").FluentAuthManager["userInfo"];
 * }} IDASFluentApi
 * @description IDAS API client with all business routine getters. Extends FluentApi with IDAS-specific business routines:
 * - vorgang: Vorgang (Auftrag) business routines
 * - kontakt: Kontakt (Kunden/Lieferanten) business routines
 * - belegPositionen: BelegPositionen business routines
 * - material: Material business routines
 * - serien: Serien/AV business routines
 * - benutzer: Benutzer/Rollen business routines
 * - artikel: Artikel/Stammdaten business routines
 * - beleg: Beleg/Status/Historie business routines
 * - produktion: Produktion business routines
 * - faktura: Faktura kennzeichen (status flags) business routines
 * - rechnung: Rechnungen/Sammelrechnungen (invoicing) business routines
 * - settings: Settings/Contracts business routines
 * - ui: UI/Scripts/Filter business routines
 * - utility: Utility/File/Mail/Print business routines
 * - ablage: Storage/bin management business routines
 * - av: Arbeitsvorbereitung (work preparation) business routines
 * - farbe: Color management business routines
 * - lager: Warehouse/inventory management business routines
 * - lieferung: Delivery/shipping management business routines
 * - mandant: Tenant/client management business routines
 * - print: Printing management business routines
 * - historie: History tracking business routines
 * - system: System information business routines
 * - file: File operations business routines
 * - mail: Email operations business routines
 * - anpassung: Customization/adaptation business routines
 * - auth: Authentication management business routines
 * - userInfo: Decoded auth user info from authManager
 */

/**
 * Creates an IDAS API client with all business routine getters.
 *
 * @return {IDASFluentApi} A configured IDAS API client instance with business routines.
 */
export function createIDASApi() {
    const api = createApi();

    // Define all business routine getters - lazy loaded on first access
    Object.defineProperty(api, "vorgang", {
        get() {
            if (!this._vorgangApi) {
                this._vorgangApi = createVorgangApi(this);
            }
            return this._vorgangApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "kontakt", {
        get() {
            if (!this._kontaktApi) {
                this._kontaktApi = createKontaktApi(this);
            }
            return this._kontaktApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "belegPositionen", {
        get() {
            if (!this._belegPositionenApi) {
                this._belegPositionenApi = createBelegPositionenApi(this);
            }
            return this._belegPositionenApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "material", {
        get() {
            if (!this._materialApi) {
                this._materialApi = createMaterialApi(this);
            }
            return this._materialApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "serien", {
        get() {
            if (!this._serienApi) {
                this._serienApi = createSerienApi(this);
            }
            return this._serienApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "benutzer", {
        get() {
            if (!this._benutzerApi) {
                this._benutzerApi = createBenutzerApi(this);
            }
            return this._benutzerApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "artikel", {
        get() {
            if (!this._artikelApi) {
                this._artikelApi = createArtikelApi(this);
            }
            return this._artikelApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "beleg", {
        get() {
            if (!this._belegApi) {
                this._belegApi = createBelegApi(this);
            }
            return this._belegApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "produktion", {
        get() {
            if (!this._produktionApi) {
                this._produktionApi = createProduktionApi(this);
            }
            return this._produktionApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "faktura", {
        get() {
            if (!this._fakturaApi) {
                this._fakturaApi = createFakturaApi(this);
            }
            return this._fakturaApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "rechnung", {
        get() {
            if (!this._rechnungApi) {
                this._rechnungApi = createRechnungApi(this);
            }
            return this._rechnungApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "settings", {
        get() {
            if (!this._settingsApi) {
                this._settingsApi = createSettingsApi(this);
            }
            return this._settingsApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "ui", {
        get() {
            if (!this._uiApi) {
                this._uiApi = createUiApi(this);
            }
            return this._uiApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "utility", {
        get() {
            if (!this._utilityApi) {
                this._utilityApi = createUtilityApi(this);
            }
            return this._utilityApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "ablage", {
        get() {
            if (!this._ablageApi) {
                this._ablageApi = createAblageApi(this);
            }
            return this._ablageApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "av", {
        get() {
            if (!this._avApi) {
                this._avApi = createAvApi(this);
            }
            return this._avApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "farbe", {
        get() {
            if (!this._farbeApi) {
                this._farbeApi = createFarbeApi(this);
            }
            return this._farbeApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "lager", {
        get() {
            if (!this._lagerApi) {
                this._lagerApi = createLagerApi(this);
            }
            return this._lagerApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "lieferung", {
        get() {
            if (!this._lieferungApi) {
                this._lieferungApi = createLieferungApi(this);
            }
            return this._lieferungApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "mandant", {
        get() {
            if (!this._mandantApi) {
                this._mandantApi = createMandantApi(this);
            }
            return this._mandantApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "print", {
        get() {
            if (!this._printApi) {
                this._printApi = createPrintApi(this);
            }
            return this._printApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "historie", {
        get() {
            if (!this._historieApi) {
                this._historieApi = createHistorieApi(this);
            }
            return this._historieApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "system", {
        get() {
            if (!this._systemApi) {
                this._systemApi = createSystemApi(this);
            }
            return this._systemApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "file", {
        get() {
            if (!this._fileApi) {
                this._fileApi = createFileApi(this);
            }
            return this._fileApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "mail", {
        get() {
            if (!this._mailApi) {
                this._mailApi = createMailApi(this);
            }
            return this._mailApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "anpassung", {
        get() {
            if (!this._anpassungApi) {
                this._anpassungApi = createAnpassungApi(this);
            }
            return this._anpassungApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "auth", {
        get() {
            if (!this._authApi) {
                this._authApi = createAuthApi(this);
            }
            return this._authApi;
        },
        configurable: true,
        enumerable: true
    });

    Object.defineProperty(api, "userInfo", {
        get() {
            return this.authManager?.userInfo;
        },
        configurable: true,
        enumerable: true
    });

    return api;
}

/**
 * Sets up an IDAS API client with business routines.
 *
 * - Requests will be sent to the url provided.
 * - Example usage:
 *   const api = idasFluentApi("https://api.idas.de", authManager, "myService");
 *   api.vorgang.getByGuid(guid); // Access Vorgang business routines
 *
 * @export
 * @param {string} url - The base URL for API requests.
 * @param {import("./fluentAuthManager.js").FluentAuthManager} authManager - The authentication manager instance.
 * @param {string} serviceName - The name of the service using this API.
 * @return {IDASFluentApi} Configured IDAS API instance with business routines.
 */
export function idasFluentApi(url, authManager, serviceName) {
    return createIDASApi()
        .useAuthManager(authManager)
        .useBaseUrl(url)
        .useServiceName(serviceName);
}
