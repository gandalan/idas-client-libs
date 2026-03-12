using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Util;

/// <summary>
/// ISO 3166-1 Ländercodes mit case-insensitive Lookup
/// Datenstand: März 2026, basierend auf ISO-3166-1-Kodierliste
/// </summary>
public static class LaenderCodes
{
    // Internes Dictionary mit lowercase Keys
    private static readonly Dictionary<string, (string Alpha2, string Alpha3)> _nameZuCodeInternal = new()
    {
        ["afghanistan"] = ("AF", "AFG"),
        ["albanien"] = ("AL", "ALB"),
        ["algerien"] = ("DZ", "DZA"),
        ["amerikanisch-samoa"] = ("AS", "ASM"),
        ["amerikanische jungferninseln"] = ("VI", "VIR"),
        ["andorra"] = ("AD", "AND"),
        ["angola"] = ("AO", "AGO"),
        ["anguilla"] = ("AI", "AIA"),
        ["antarktis"] = ("AQ", "ATA"),
        ["antigua und barbuda"] = ("AG", "ATG"),
        ["argentinien"] = ("AR", "ARG"),
        ["armenien"] = ("AM", "ARM"),
        ["aruba"] = ("AW", "ABW"),
        ["aserbaidschan"] = ("AZ", "AZE"),
        ["australien"] = ("AU", "AUS"),
        ["bahamas"] = ("BS", "BHS"),
        ["bahrain"] = ("BH", "BHR"),
        ["bangladesch"] = ("BD", "BGD"),
        ["barbados"] = ("BB", "BRB"),
        ["belarus"] = ("BY", "BLR"),
        ["belgien"] = ("BE", "BEL"),
        ["belize"] = ("BZ", "BLZ"),
        ["benin"] = ("BJ", "BEN"),
        ["bermuda"] = ("BM", "BMU"),
        ["bhutan"] = ("BT", "BTN"),
        ["bolivien"] = ("BO", "BOL"),
        ["bonaire, saba, sint eustatius"] = ("BQ", "BES"),
        ["bosnien und herzegowina"] = ("BA", "BIH"),
        ["botsuana"] = ("BW", "BWA"),
        ["bouvetinsel"] = ("BV", "BVT"),
        ["brasilien"] = ("BR", "BRA"),
        ["britische jungferninseln"] = ("VG", "VGB"),
        ["britisches territorium im indischen ozean"] = ("IO", "IOT"),
        ["brunei"] = ("BN", "BRN"),
        ["bulgarien"] = ("BG", "BGR"),
        ["burkina faso"] = ("BF", "BFA"),
        ["burundi"] = ("BI", "BDI"),
        ["chile"] = ("CL", "CHL"),
        ["cookinseln"] = ("CK", "COK"),
        ["costa rica"] = ("CR", "CRI"),
        ["curaçao"] = ("CW", "CUW"),
        ["demokratische republik kongo"] = ("CD", "COD"),
        ["deutschland"] = ("DE", "DEU"),
        ["dominica"] = ("DM", "DMA"),
        ["dominikanische republik"] = ("DO", "DOM"),
        ["dschibuti"] = ("DJ", "DJI"),
        ["dänemark"] = ("DK", "DNK"),
        ["ecuador"] = ("EC", "ECU"),
        ["el salvador"] = ("SV", "SLV"),
        ["elfenbeinküste"] = ("CI", "CIV"),
        ["eritrea"] = ("ER", "ERI"),
        ["estland"] = ("EE", "EST"),
        ["eswatini"] = ("SZ", "SWZ"),
        ["falklandinseln"] = ("FK", "FLK"),
        ["fidschi"] = ("FJ", "FJI"),
        ["finnland"] = ("FI", "FIN"),
        ["frankreich"] = ("FR", "FRA"),
        ["französisch-guayana"] = ("GF", "GUF"),
        ["französisch-polynesien"] = ("PF", "PYF"),
        ["französische süd- und antarktisgebiete"] = ("TF", "ATF"),
        ["färöer"] = ("FO", "FRO"),
        ["föderierte staaten von mikronesien"] = ("FM", "FSM"),
        ["gabun"] = ("GA", "GAB"),
        ["gambia"] = ("GM", "GMB"),
        ["georgien"] = ("GE", "GEO"),
        ["ghana"] = ("GH", "GHA"),
        ["gibraltar"] = ("GI", "GIB"),
        ["grenada"] = ("GD", "GRD"),
        ["griechenland"] = ("GR", "GRC"),
        ["grönland"] = ("GL", "GRL"),
        ["guadeloupe"] = ("GP", "GLP"),
        ["guam"] = ("GU", "GUM"),
        ["guatemala"] = ("GT", "GTM"),
        ["guernsey"] = ("GG", "GGY"),
        ["guinea"] = ("GN", "GIN"),
        ["guinea-bissau"] = ("GW", "GNB"),
        ["guyana"] = ("GY", "GUY"),
        ["haiti"] = ("HT", "HTI"),
        ["heard und mcdonaldinseln"] = ("HM", "HMD"),
        ["honduras"] = ("HN", "HND"),
        ["hongkong"] = ("HK", "HKG"),
        ["indien"] = ("IN", "IND"),
        ["indonesien"] = ("ID", "IDN"),
        ["irak"] = ("IQ", "IRQ"),
        ["iran"] = ("IR", "IRN"),
        ["irland"] = ("IE", "IRL"),
        ["island"] = ("IS", "ISL"),
        ["isle of man"] = ("IM", "IMN"),
        ["israel"] = ("IL", "ISR"),
        ["italien"] = ("IT", "ITA"),
        ["jamaika"] = ("JM", "JAM"),
        ["japan"] = ("JP", "JPN"),
        ["jemen"] = ("YE", "YEM"),
        ["jersey"] = ("JE", "JEY"),
        ["jordanien"] = ("JO", "JOR"),
        ["kambodscha"] = ("KH", "KHM"),
        ["kamerun"] = ("CM", "CMR"),
        ["kanada"] = ("CA", "CAN"),
        ["kap verde"] = ("CV", "CPV"),
        ["kasachstan"] = ("KZ", "KAZ"),
        ["katar"] = ("QA", "QAT"),
        ["kenia"] = ("KE", "KEN"),
        ["kirgisistan"] = ("KG", "KGZ"),
        ["kiribati"] = ("KI", "KIR"),
        ["kokosinseln"] = ("CC", "CCK"),
        ["kolumbien"] = ("CO", "COL"),
        ["komoren"] = ("KM", "COM"),
        ["kroatien"] = ("HR", "HRV"),
        ["kuba"] = ("CU", "CUB"),
        ["kuwait"] = ("KW", "KWT"),
        ["laos"] = ("LA", "LAO"),
        ["lesotho"] = ("LS", "LSO"),
        ["lettland"] = ("LV", "LVA"),
        ["libanon"] = ("LB", "LBN"),
        ["liberia"] = ("LR", "LBR"),
        ["libyen"] = ("LY", "LBY"),
        ["liechtenstein"] = ("LI", "LIE"),
        ["litauen"] = ("LT", "LTU"),
        ["luxemburg"] = ("LU", "LUX"),
        ["macau"] = ("MO", "MAC"),
        ["madagaskar"] = ("MG", "MDG"),
        ["malawi"] = ("MW", "MWI"),
        ["malaysia"] = ("MY", "MYS"),
        ["malediven"] = ("MV", "MDV"),
        ["mali"] = ("ML", "MLI"),
        ["malta"] = ("MT", "MLT"),
        ["marokko"] = ("MA", "MAR"),
        ["marshallinseln"] = ("MH", "MHL"),
        ["martinique"] = ("MQ", "MTQ"),
        ["mauretanien"] = ("MR", "MRT"),
        ["mauritius"] = ("MU", "MUS"),
        ["mayotte"] = ("YT", "MYT"),
        ["mexiko"] = ("MX", "MEX"),
        ["moldau"] = ("MD", "MDA"),
        ["monaco"] = ("MC", "MCO"),
        ["mongolei"] = ("MN", "MNG"),
        ["montenegro"] = ("ME", "MNE"),
        ["montserrat"] = ("MS", "MSR"),
        ["mosambik"] = ("MZ", "MOZ"),
        ["myanmar"] = ("MM", "MMR"),
        ["namibia"] = ("NA", "NAM"),
        ["nauru"] = ("NR", "NRU"),
        ["nepal"] = ("NP", "NPL"),
        ["neukaledonien"] = ("NC", "NCL"),
        ["neuseeland"] = ("NZ", "NZL"),
        ["nicaragua"] = ("NI", "NIC"),
        ["niederlande"] = ("NL", "NLD"),
        ["niger"] = ("NE", "NER"),
        ["nigeria"] = ("NG", "NGA"),
        ["niue"] = ("NU", "NIU"),
        ["nordkorea"] = ("KP", "PRK"),
        ["nordmazedonien"] = ("MK", "MKD"),
        ["norfolkinsel"] = ("NF", "NFK"),
        ["norwegen"] = ("NO", "NOR"),
        ["nördliche marianen"] = ("MP", "MNP"),
        ["oman"] = ("OM", "OMN"),
        ["osttimor"] = ("TL", "TLS"),
        ["pakistan"] = ("PK", "PAK"),
        ["palau"] = ("PW", "PLW"),
        ["palästina"] = ("PS", "PSE"),
        ["panama"] = ("PA", "PAN"),
        ["papua-neuguinea"] = ("PG", "PNG"),
        ["paraguay"] = ("PY", "PRY"),
        ["peru"] = ("PE", "PER"),
        ["philippinen"] = ("PH", "PHL"),
        ["pitcairninseln"] = ("PN", "PCN"),
        ["polen"] = ("PL", "POL"),
        ["portugal"] = ("PT", "PRT"),
        ["puerto rico"] = ("PR", "PRI"),
        ["republik kongo"] = ("CG", "COG"),
        ["ruanda"] = ("RW", "RWA"),
        ["rumänien"] = ("RO", "ROU"),
        ["russland"] = ("RU", "RUS"),
        ["réunion"] = ("RE", "REU"),
        ["saint-pierre und miquelon"] = ("PM", "SPM"),
        ["salomonen"] = ("SB", "SLB"),
        ["sambia"] = ("ZM", "ZMB"),
        ["samoa"] = ("WS", "WSM"),
        ["san marino"] = ("SM", "SMR"),
        ["saudi-arabien"] = ("SA", "SAU"),
        ["schweden"] = ("SE", "SWE"),
        ["schweiz"] = ("CH", "CHE"),
        ["senegal"] = ("SN", "SEN"),
        ["serbien"] = ("RS", "SRB"),
        ["seychellen"] = ("SC", "SYC"),
        ["sierra leone"] = ("SL", "SLE"),
        ["simbabwe"] = ("ZW", "ZWE"),
        ["singapur"] = ("SG", "SGP"),
        ["sint maarten"] = ("SX", "SXM"),
        ["slowakei"] = ("SK", "SVK"),
        ["slowenien"] = ("SI", "SVN"),
        ["somalia"] = ("SO", "SOM"),
        ["spanien"] = ("ES", "ESP"),
        ["spitzbergen und jan mayen"] = ("SJ", "SJM"),
        ["sri lanka"] = ("LK", "LKA"),
        ["st. helena, ascension und tristan da cunha"] = ("SH", "SHN"),
        ["st. kitts und nevis"] = ("KN", "KNA"),
        ["st. lucia"] = ("LC", "LCA"),
        ["st. vincent und die grenadinen"] = ("VC", "VCT"),
        ["sudan"] = ("SD", "SDN"),
        ["suriname"] = ("SR", "SUR"),
        ["syrien"] = ("SY", "SYR"),
        ["são tomé und príncipe"] = ("ST", "STP"),
        ["südafrika"] = ("ZA", "ZAF"),
        ["südgeorgien und die südlichen sandwichinseln"] = ("GS", "SGS"),
        ["südkorea"] = ("KR", "KOR"),
        ["südsudan"] = ("SS", "SSD"),
        ["tadschikistan"] = ("TJ", "TJK"),
        ["taiwan"] = ("TW", "TWN"),
        ["tansania"] = ("TZ", "TZA"),
        ["thailand"] = ("TH", "THA"),
        ["togo"] = ("TG", "TGO"),
        ["tokelau"] = ("TK", "TKL"),
        ["tonga"] = ("TO", "TON"),
        ["trinidad und tobago"] = ("TT", "TTO"),
        ["tschad"] = ("TD", "TCD"),
        ["tschechien"] = ("CZ", "CZE"),
        ["tunesien"] = ("TN", "TUN"),
        ["turkmenistan"] = ("TM", "TKM"),
        ["turks- und caicosinseln"] = ("TC", "TCA"),
        ["tuvalu"] = ("TV", "TUV"),
        ["türkei"] = ("TR", "TUR"),
        ["uganda"] = ("UG", "UGA"),
        ["ukraine"] = ("UA", "UKR"),
        ["ungarn"] = ("HU", "HUN"),
        ["uruguay"] = ("UY", "URY"),
        ["usbekistan"] = ("UZ", "UZB"),
        ["vanuatu"] = ("VU", "VUT"),
        ["vatikanstadt"] = ("VA", "VAT"),
        ["venezuela"] = ("VE", "VEN"),
        ["vereinigte arabische emirate"] = ("AE", "ARE"),
        ["vereinigte staaten"] = ("US", "USA"),
        ["vereinigtes königreich"] = ("GB", "GBR"),
        ["vietnam"] = ("VN", "VNM"),
        ["volksrepublik china"] = ("CN", "CHN"),
        ["wallis und futuna"] = ("WF", "WLF"),
        ["weihnachtsinsel"] = ("CX", "CXR"),
        ["westsahara"] = ("EH", "ESH"),
        ["zentralafrikanische republik"] = ("CF", "CAF"),
        ["zypern"] = ("CY", "CYP"),
        ["ägypten"] = ("EG", "EGY"),
        ["äquatorialguinea"] = ("GQ", "GNQ"),
        ["äthiopien"] = ("ET", "ETH"),
        ["åland"] = ("AX", "ALA"),
        ["österreich"] = ("AT", "AUT"),
    };

    /// <summary>
    /// Gibt Alpha-2 und Alpha-3 Code für einen Ländernamen zurück (case-insensitive).
    /// </summary>
    /// <param name="laenderName">Name des Landes (z.B. "Deutschland", "deutschland", "DEUTSCHLAND")</param>
    /// <returns>Tuple mit Alpha2 und Alpha3 Code</returns>
    /// <exception cref="KeyNotFoundException">Wenn Land nicht gefunden</exception>
    public static (string Alpha2, string Alpha3) GetCode(string laenderName)
    {
        if (string.IsNullOrWhiteSpace(laenderName))
            throw new ArgumentException("Ländername darf nicht leer sein", nameof(laenderName));

        var key = laenderName.Trim().ToLowerInvariant();
        if (_nameZuCodeInternal.TryGetValue(key, out var result))
            return result;

        throw new KeyNotFoundException($"Land '{laenderName}' nicht gefunden");
    }

    /// <summary>
    /// Versucht Alpha-2 und Alpha-3 Code für einen Ländernamen zu ermitteln (case-insensitive).
    /// </summary>
    public static bool TryGetCode(string laenderName, out string alpha2, out string alpha3)
    {
        alpha2 = null;
        alpha3 = null;

        if (string.IsNullOrWhiteSpace(laenderName))
            return false;

        var key = laenderName.Trim().ToLowerInvariant();
        if (_nameZuCodeInternal.TryGetValue(key, out var result))
        {
            alpha2 = result.Alpha2;
            alpha3 = result.Alpha3;
            return true;
        }

        return false;
    }

    /// <summary>
    /// Versucht Alpha-2-Code für einen Ländernamen zu ermitteln (case-insensitive).
    /// </summary>
    public static bool TryGetAlpha2Code(string laenderName, out string alpha2)
    {
        alpha2 = null;
        if (TryGetCode(laenderName, out var a2, out _))
        {
            alpha2 = a2;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Versucht Alpha-3-Code für einen Ländernamen zu ermitteln (case-insensitive).
    /// </summary>
    public static bool TryGetAlpha3Code(string laenderName, out string alpha3)
    {
        alpha3 = null;
        if (TryGetCode(laenderName, out _, out var a3))
        {
            alpha3 = a3;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Gibt Anzahl der verfügbaren Länder zurück.
    /// </summary>
    public static int AnzahlLaender => _nameZuCodeInternal.Count;
}
