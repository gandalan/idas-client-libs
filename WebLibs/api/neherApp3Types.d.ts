// Auto-generated NeherApp3 root type definitions.
// Do not modify manually - changes will be overwritten by scripts/generate-root-dto-typedefs.mjs

export type NeherApp3NotifyType = 0 | 1 | 2;

export type ArtikelstammEintrag = {
    KatalogArtikelGuid?: string;
    KatalogNummer?: string;
    Katalognummer?: string;
    Nummer?: string;
};

export type Variante = {
    VarianteGuid?: string;
    Name?: string;
    Kuerzel?: string;
};

export type Werteliste = {
    WerteListeGuid?: string;
    Name?: string;
};

export type NeherApp3ArtikelstammCache = {
    getArtikelStamm: () => Promise<ArtikelstammEintrag[]>;
    getWarenGruppen: () => Promise<object[]>;
    getArtikelByGuid: (guid: string) => Promise<ArtikelstammEintrag | undefined>;
    getArtikelByKatalognummer: (nummer: string) => Promise<ArtikelstammEintrag | undefined>;
};

export type NeherApp3ErfassungCache = {
    getVarianten: () => Promise<Variante[]>;
    getVariante: (variantenNameOderKuerzel: string) => Promise<Variante | undefined>;
    getWertelisten: () => Promise<Werteliste[]>;
    getWerteliste: (name: string) => Promise<Werteliste | undefined>;
    getScripts: () => Promise<object[]>;
    createUIMachine: (v: Variante) => void;
};

export type NeherApp3Props = {
    api: import("./fluentApi.js").FluentApi;
    authManager?: import("./fluentAuthManager.js").FluentAuthManager;
    idas: import("./idasFluentApi.js").IDASFluentApi;
    mainCssPath?: string;
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

export type NeherApp3SetupContext = NeherApp3Props & { neherapp3: NeherApp3 };

export type NeherApp3Module = {
    moduleName: string;
    setup?: (context: NeherApp3SetupContext) => void | Promise<void>;
    mount?: (node: HTMLElement, props: NeherApp3SetupContext) => void | Function;
    embedUrl?: string;
    extraCSS?: string[];
    useShadowDom?: boolean;
};

export type NeherApp3ApiCollection = {
    idas?: import("./idasFluentApi.js").IDASFluentApi;
    hostingEnvironment?: import("./fluentApi.js").FluentApi;
};

export type NeherApp3CacheCollection = {
    artikelstamm: NeherApp3ArtikelstammCache;
    erfassung: NeherApp3ErfassungCache;
};

export type NeherApp3 = {
    addMenuItem: (menuItem: NeherApp3MenuItem) => void;
    addApp: (appModule: NeherApp3Module | string) => Promise<void>;
    notify: (message: string, type?: NeherApp3NotifyType, cb?: Function) => void;
    api: NeherApp3ApiCollection;
    cache: NeherApp3CacheCollection;
};

