using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Gandalan.IDAS.WebApi.DTO;

/// <summary>
/// <see href="https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-group-sort-and-filter-data-in-the-datagrid-control?view=netframeworkdesktop-4.8">https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-group-sort-and-filter-data-in-the-datagrid-control?view=netframeworkdesktop-4.8</see>
/// </summary>
public class KapazitaetsvorgabenDTO : ObservableCollection<Kapazitaetsvorgabe>
{
    public int Version { get; set; }

    public KapazitaetsvorgabenDTO()
    {
    }

    public KapazitaetsvorgabenDTO(IEnumerable<Kapazitaetsvorgabe> collection) : base(collection)
    {
    }

    // Creating the Kapazitaetsvorgabe collection in this way enables data binding from XAML.
    public void init()
    {
        if (Version < 1)
        {
            Version = 1;
            Add(new Kapazitaetsvorgabe { GroupName = "Spannrahmen", Label = "SP1", Produktgruppe = ["SP1"], IstBasisregel = true, Order = Count, Zeitvorgabe = 27 });
            Add(new Kapazitaetsvorgabe { GroupName = "Spannrahmen", Label = "SP2", Produktgruppe = ["SP2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 25 });
            Add(new Kapazitaetsvorgabe { GroupName = "Spannrahmen", Label = "SP4", Produktgruppe = ["SP4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 25 });
            Add(new Kapazitaetsvorgabe { GroupName = "Spannrahmen", Label = "SP5", Produktgruppe = ["SP5"], IstBasisregel = true, Order = Count, Zeitvorgabe = 25 });
            Add(new Kapazitaetsvorgabe { GroupName = "Spannrahmen", Label = "SP6", Produktgruppe = ["SP6"], IstBasisregel = true, Order = Count, Zeitvorgabe = 28 });
            Add(new Kapazitaetsvorgabe { GroupName = "Spannrahmen", Label = "SP7", Produktgruppe = ["SP7"], IstBasisregel = true, Order = Count, Zeitvorgabe = 28 });

            Add(new Kapazitaetsvorgabe { GroupName = "Drehfenster DF3, DF4", Label = "1 flg. ohne Rahmen", Produktgruppe = ["DF3/1", "DF3/3", "DF4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 33 });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehfenster DF3, DF4", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["DF3/7", "DF3/8", "DF3/9", "DF3/10"], IstBasisregel = true, Order = Count, Zeitvorgabe = 40 });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehfenster DF3, DF4", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["DF3/16"], IstBasisregel = true, Order = Count, Zeitvorgabe = 65 });

            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT3, DT4", Label = "1 flg. ohne Rahmen", Produktgruppe = ["DT3/1", "DT3/3", "DT3/31", "DT3/37", "DT3/38", "DT4/2", "DT4/4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 55 });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT3, DT4", Label = "2 flg. ohne Rahmen", Produktgruppe = ["DT3/11", "DT3/36", "DT4/12"], IstBasisregel = true, Order = Count, Zeitvorgabe = 102 });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT3, DT4", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["DT3", "DT4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 62 });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT3, DT4", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["DT3/13", "DT3/15", "DT3/16", "DT3/26", "DT3/27", "DT3/30", "DT3/40", "DT3/41", "DT4/9"], IstBasisregel = true, Order = Count, Zeitvorgabe = 109 });

            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT6", Label = "1 flg. ohne Rahmen", Produktgruppe = ["DT6/1", "DT6/11", "DT6/3", "DT6/38"], IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT6", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["DT6/8", "DT6/10", "DT6/13", "DT6/16", "DT6/42"], IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT6", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["DT6/40", "DT6/41"], IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe { GroupName = "Pendeltüren PT2", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["PT2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 63 });
            Add(new Kapazitaetsvorgabe { GroupName = "Pendeltüren PT2", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["PT2/71", "PT2/72", "PT2/73", "PT2/74", "PT2/75", "PT2/76", "PT2/77", "PT2/78", "PT2/79", "PT2/80"], IstBasisregel = true, Order = Count, Zeitvorgabe = 118 });

            Add(new Kapazitaetsvorgabe { GroupName = "Pendelfenster PF2", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["PF2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 53 });
            Add(new Kapazitaetsvorgabe { GroupName = "Pendelfenster PF2", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["PF2/71", "PF2/76", "PF2/78"], IstBasisregel = true, Order = Count, Zeitvorgabe = 98 });

            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "RO4", Produktgruppe = ["RO4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 44 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "RO4 quer", Produktgruppe = ["RO4/10"], IstBasisregel = true, Order = Count, Zeitvorgabe = 54 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "RO4 quer (2-fach)", Produktgruppe = ["RO4/12"], IstBasisregel = true, Order = Count, Zeitvorgabe = 105 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "RO5", Produktgruppe = ["RO5"], IstBasisregel = true, Order = Count, Zeitvorgabe = 38 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "RO6", Produktgruppe = ["RO6"], IstBasisregel = true, Order = Count, Zeitvorgabe = 44 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "SD1", Produktgruppe = ["SD1"], IstBasisregel = true, Order = Count, Zeitvorgabe = 92 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "ER1", Produktgruppe = ["ER1"], IstBasisregel = true, Order = Count, Zeitvorgabe = 120 });
            Add(new Kapazitaetsvorgabe { GroupName = "Rollo", Label = "ER2", Produktgruppe = ["ER2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 180 });

            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI1", Produktgruppe = ["LI1"], IstBasisregel = true, Order = Count, Zeitvorgabe = 26 });
            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI1 2tlg.", Produktgruppe = ["LI1/4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 49 });
            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI2", Produktgruppe = ["LI2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 32 });
            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI2 2tlg.", Produktgruppe = ["LI2/4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 49 });
            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI3", Produktgruppe = ["LI3"], IstBasisregel = true, Order = Count, Zeitvorgabe = 62 });
            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI3 2tlg.", Produktgruppe = ["LI3/4", "LI3/14", "LI3/54", "LI3/64"], IstBasisregel = true, Order = Count, Zeitvorgabe = 84 });
            Add(new Kapazitaetsvorgabe { GroupName = "Lichtschachtabdeckung", Label = "LI4", Produktgruppe = ["LI4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 49 });

            Add(new Kapazitaetsvorgabe { GroupName = "Terresa", Label = "TE1", Produktgruppe = ["TE1"], IstBasisregel = true, Order = Count, Zeitvorgabe = 62 });
            Add(new Kapazitaetsvorgabe { GroupName = "Terresa", Label = "TE1 2tlg.", Produktgruppe = ["TE1/14"], IstBasisregel = true, Order = Count, Zeitvorgabe = 84 });

            Add(new Kapazitaetsvorgabe { GroupName = "Schiebeanlage ST3, ST4", Label = "1 flg. mit Lso/Lsu", Produktgruppe = ["ST3/1", "ST3/2", "ST3/3", "ST3/4", "ST3/5", "ST3/6", "ST3/7", "ST3/8", "ST3/9", "ST4/1", "ST4/2", "ST4/4", "ST4/6"], IstBasisregel = true, Order = Count, Zeitvorgabe = 42 });
            Add(new Kapazitaetsvorgabe { GroupName = "Schiebeanlage ST3, ST4", Label = "2 flg. mit Lso/Lsu", Produktgruppe = ["ST3/21", "ST3/22", "ST3/23", "ST3/24", "ST3/25", "ST3/26", "ST3/29", "ST3/52", "ST4/21", "ST4/22", "ST4/24", "ST4/26", "ST4/52"], IstBasisregel = true, Order = Count, Zeitvorgabe = 76 });
            Add(new Kapazitaetsvorgabe { GroupName = "Schiebeanlage ST3, ST4", Label = "1 flg. mit Rahmen", Produktgruppe = ["ST3", "ST4"], IstBasisregel = true, Order = Count, Zeitvorgabe = 52 });
            Add(new Kapazitaetsvorgabe { GroupName = "Schiebeanlage ST3, ST4", Label = "2 flg. mit Rahmen", Produktgruppe = ["ST3/50.AMB", "ST3/50.LMM", "ST3/51.AMB", "ST3/51.LMM", "ST3/55", "ST3/56", "ST4/50.AMB", "ST4/50.LMM", "ST4/51.AMB", "ST4/51.LMM", "ST4/55", "ST4/56"], IstBasisregel = true, Order = Count, Zeitvorgabe = 86 });
            Add(new Kapazitaetsvorgabe { GroupName = "Schiebeanlage ST3, ST4", Label = "3 flg. mit Rahmen", Produktgruppe = ["ST3/80", "ST3/81", "ST4/80", "ST4/81"], IstBasisregel = true, Order = Count, Zeitvorgabe = 109 });
            Add(new Kapazitaetsvorgabe { GroupName = "Schiebeanlage ST3, ST4", Label = "4 flg. mit Rahmen", Produktgruppe = ["ST3/57", "ST3/58"], IstBasisregel = true, Order = Count, Zeitvorgabe = 158 });

            Add(new Kapazitaetsvorgabe { GroupName = "Plissee PL1", Label = "1 flg. ohne Rahmen", Produktgruppe = ["PL1/1"], IstBasisregel = true, Order = Count, Zeitvorgabe = 38 });
            Add(new Kapazitaetsvorgabe { GroupName = "Plissee PL1", Label = "2 flg. ohne Rahmen", Produktgruppe = ["PL1/2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 68 });
            Add(new Kapazitaetsvorgabe { GroupName = "Plissee PL1", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["PL1/5", "PL1/9"], IstBasisregel = true, Order = Count, Zeitvorgabe = 45 });
            Add(new Kapazitaetsvorgabe { GroupName = "Plissee PL1", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["PL1/6", "PL1/10"], IstBasisregel = true, Order = Count, Zeitvorgabe = 82 });

            Add(new Kapazitaetsvorgabe { GroupName = "Plissee PL2", Label = "1 flg. mit Montagerahmen", Produktgruppe = ["PL2"], IstBasisregel = true, Order = Count, Zeitvorgabe = 45 });
            Add(new Kapazitaetsvorgabe { GroupName = "Plissee PL2", Label = "2 flg. mit Montagerahmen", Produktgruppe = ["PL2/25", "PL2/29.AMB", "PL2/25.LMM"], IstBasisregel = true, Order = Count, Zeitvorgabe = 82 });

            Add(new Kapazitaetsvorgabe { GroupName = "Zusatzrahmen", Label = "ZR", Produktgruppe = ["ZR"], IstBasisregel = true, Order = Count, Zeitvorgabe = 14 });
        }

        if (Version < 2)
        {
            Version = 2;
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Metallgewebe (nicht bei Lichtschächten)",
                Produktgruppe = ["SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "ST3", "ST4"],
                Artikelliste = ["142627", "142632"],
                Etikettentext = ["V4", "V2AA"],
                Zeitvorgabe = 5,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Sondergewebe (nicht bei Lichtschächten)",
                Produktgruppe = ["SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "ST3", "ST4"],
                Artikelliste = ["142628", "142638", "142680"],
                Etikettentext = ["PA", "PAE", "PIA"],
                Zeitvorgabe = 4,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Transpatecgewebe (nicht bei Lichtschächten)",
                Produktgruppe = ["SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "ST3", "ST4"],
                Artikelliste = ["142519", "142520", "142521", "142523"],
                Etikettentext = ["TTA", "TFM", "TFP"],
                Zeitvorgabe = 2,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Polyestergewebe unterhalb der Sprosse",
                Produktgruppe = ["PT2", "DT3", "DT4", "ST3", "ST4"],
                Artikelliste = ["142628", "142638"],
                Etikettentext = ["/ PA", "/ PAE"],
                Zeitvorgabe = 3,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Vorbiegen",
                Produktgruppe = ["SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "ST3", "ST4"],
                Etikettentext = ["v_Kw_"],
                Zeitvorgabe = 4,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Seitenarretierung SP1",
                Produktgruppe = ["SP1"],
                Artikelliste = ["132466"],
                Etikettentext = ["SA_"],
                Zeitvorgabe = 1,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Seitenarretierung SP5",
                Produktgruppe = ["SP5"],
                Artikelliste = ["132466", "132272"],
                Etikettentext = ["SA_", "mW_"],
                Zeitvorgabe = 1,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Seitenarretierung SP2, SP4, SP6, SP7",
                Produktgruppe = ["SP2", "SP4", "SP6", "SP7"],
                Artikelliste = ["132472"],
                Etikettentext = ["mW_"],
                Zeitvorgabe = 1,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Sprosse (im Spannrahmen)",
                Produktgruppe = ["SP1", "SP2", "SP4", "SP5", "SP6", "SP7"],
                Etikettentext = ["SpB_"],
                Zeitvorgabe = 2,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Sprosse (im Lichtschacht)",
                Produktgruppe = ["LI1", "LI2"],
                Artikelliste = ["103313"],
                Etikettentext = ["SpB_"],
                Zeitvorgabe = 6,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Sprossenpaneel",
                Produktgruppe = ["PT2", "DT3", "DT4", "ST3", "ST4"],
                Etikettentext = ["Pan_"],
                Zeitvorgabe = 5,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Montagebohrung",
                Produktgruppe = ["SP1", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "RO4", "RO5", "RO6", "ER1", "ER2", "PL1", "PL2", "ST3", "ST4", "LI4"],
                Etikettentext = ["MB_s", "MB_v"],
                Zeitvorgabe = 4,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Katzen-/Hundeklappe",
                Produktgruppe = ["PT2", "DT3", "DT4", "ST3", "ST4"],
                Artikelliste = ["222501", "223510", "223520"],
                Etikettentext = ["KP", "NeKP", "NeHP"],
                Zeitvorgabe = 20,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Standflügelarretierung",
                Produktgruppe = ["PF2", "PT2"],
                Artikelliste = ["133470"],
                Etikettentext = ["ExV_"],
                Zeitvorgabe = 12,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Schiebeverschluss",
                Produktgruppe = ["DT3", "PT2"],
                Artikelliste = ["166460.02", "133460.05"],
                Etikettentext = ["SchiebVs_"],
                Zeitvorgabe = 14,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "gedämpfte Tür",
                Produktgruppe = ["DT3"],
                Artikelliste = ["133510"],
                Etikettentext = ["Mag"],
                Zeitvorgabe = 2,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Türschliesser",
                Produktgruppe = ["DT3", "DT4"],
                Artikelliste = ["133540"],
                Etikettentext = ["TD"],
                Zeitvorgabe = 19,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Einhandbedienung RO5",
                Produktgruppe = ["RO5"],
                Artikelliste = ["153925"],
                Etikettentext = ["Stab"],
                Zeitvorgabe = 5,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Aussenbedienung",
                Produktgruppe = ["RO4", "RO5", "RO6"],
                Artikelliste = ["143920"],
                Etikettentext = ["ABf_"],
                Zeitvorgabe = 4,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Zusatzbedienung",
                Produktgruppe = ["RO4", "RO5", "RO6"],
                Artikelliste = ["144080", "143981"],
                Etikettentext = ["ZiehSch", "EinhSch"],
                Zeitvorgabe = 1,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Flügelspaltdichtung",
                Produktgruppe = ["ST3", "ST4"],
                Artikelliste = ["124860"],
                Etikettentext = ["FSp__D"],
                Zeitvorgabe = 2,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Griffleiste",
                Produktgruppe = ["ST3"],
                Artikelliste = ["104850"],
                Etikettentext = ["GL"],
                Zeitvorgabe = 13,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Fußbedienmulde",
                Produktgruppe = ["ST3", "ST4"],
                Artikelliste = ["103518", "134852"],
                Etikettentext = ["SpSoB", "Fb_"],
                Zeitvorgabe = 10,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Sockelblech",
                Produktgruppe = ["ST3", "ST4"],
                Artikelliste = ["103518"],
                Etikettentext = ["SpSoB"],
                Zeitvorgabe = 5,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Trittschutzdistanzstück",
                Produktgruppe = ["LI2/2"],
                Artikelliste = ["143311"],
                Etikettentext = ["TsDs"],
                Zeitvorgabe = 2,
                Order = Count
            });
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "symmetrischer Gitterrost",
                Produktgruppe = ["LI3", "TE1"],
                Etikettentext = ["GR_sym"],
                Zeitvorgabe = 2,
                Order = Count
            });
        }

        if (Version < 3)
        {
            Version = 3;
            Add(new Kapazitaetsvorgabe { GroupName = "Drehtüren DT6", Label = "2 flg. ohne Montagerahmen", Produktgruppe = ["DT6/11"], IstBasisregel = true, Order = Count });
        }

        if (Version < 4)
        {
            Version = 4;
            Add(new Kapazitaetsvorgabe
            {
                GroupName = "Sonstiges",
                Label = "Mehraufwand durch Sonderfarbe",
                FarbArt = KapaFarbArt.Sonderfarbe,
                Zeitvorgabe = 5,
                Order = Count
            });
        }
    }
}

public class Kapazitaetsvorgabe : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string GroupName { get; set; }
    public string Label { get; set; }
    public List<string> Produktgruppe { get; set; } = [];
    public List<string> Artikelliste { get; set; } = [];
    public List<string> Bearbeitungen { get; set; } = [];
    public List<string> Etikettentext { get; set; } = [];
    [JsonConverter(typeof(StringEnumConverter))]
    public KapaFarbArt FarbArt { get; set; } = KapaFarbArt.Alle;
    public decimal Zeitvorgabe { get; set; }
    public decimal Gewicht { get; set; }
    public bool IstBasisregel { get; set; }
    public int Order { get; set; }
}

/// <summary>
/// Definiert die Art der Farbe für die eine Kapazitätsvorgabe gilt.
/// Standardmäßig wird die Kapazitätsvorgabe für alle Farben verwendet.
/// </summary>
public enum KapaFarbArt
{
    Alle,
    Standardfarbe,
    Sonderfarbe,
    Trendfarbe,
}