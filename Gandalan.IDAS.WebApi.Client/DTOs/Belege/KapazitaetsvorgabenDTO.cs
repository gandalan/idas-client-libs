using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-group-sort-and-filter-data-in-the-datagrid-control?view=netframeworkdesktop-4.8
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
                Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP1", Produktgruppe = new List<string>() { "SP1" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP2", Produktgruppe = new List<string>() { "SP2" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP4", Produktgruppe = new List<string>() { "SP4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP5", Produktgruppe = new List<string>() { "SP5" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP6", Produktgruppe = new List<string>() { "SP6" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP7", Produktgruppe = new List<string>() { "SP7" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "1 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DF3/1", "DF3/3", "DF4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DF3/7", "DF3/8", "DF3/9", "DF3/10" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DF3/16" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "1 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DT3/1", "DT3/3", "DT3/31", "DT3/37", "DT3/38", "DT4/2", "DT4/4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "2 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DT3/11", "DT3/36", "DT4/12" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DT3", "DT4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DT3/13", "DT3/15", "DT3/16", "DT3/26", "DT3/27", "DT3/30", "DT3/40", "DT3/41", "DT4/9" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT6", Label = "1 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DT6/1", "DT6/11", "DT6/3", "DT6/38" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT6", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DT6/8", "DT6/10", "DT6/13", "DT6/16", "DT6/42" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT6", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DT6/40", "DT6/41" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Pendeltüren PT2", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PT2" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Pendeltüren PT2", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PT2/71", "PT2/72", "PT2/73", "PT2/74", "PT2/75", "PT2/76", "PT2/77", "PT2/78", "PT2/79", "PT2/80" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Pendelfenster PF2", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PF2" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Pendelfenster PF2", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PF2/71", "PF2/76", "PF2/78" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RO4", Produktgruppe = new List<string>() { "RO4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RO4 quer", Produktgruppe = new List<string>() { "RO4/10" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RO4 quer (2-fach)", Produktgruppe = new List<string>() { "RO4/12" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RO5", Produktgruppe = new List<string>() { "RO5" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RO6", Produktgruppe = new List<string>() { "RO6" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "SD1", Produktgruppe = new List<string>() { "SD1" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "ER1", Produktgruppe = new List<string>() { "ER1" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "ER2", Produktgruppe = new List<string>() { "ER2" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI1", Produktgruppe = new List<string>() { "LI1" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI1 2tlg.", Produktgruppe = new List<string>() { "LI1/4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI2", Produktgruppe = new List<string>() { "LI2" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI2 2tlg.", Produktgruppe = new List<string>() { "LI2/4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI3", Produktgruppe = new List<string>() { "LI3" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI3 2tlg.", Produktgruppe = new List<string>() { "LI3/4", "LI3/14", "LI3/54", "LI3/64" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI4", Produktgruppe = new List<string>() { "LI4" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Terresa", Label = "TE1", Produktgruppe = new List<string>() { "TE1" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Terresa", Label = "TE1 2tlg.", Produktgruppe = new List<string>() { "TE1/14" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Schiebeanlage ST3, ST4", Label = "1 flg. mit Lso/Lsu", Produktgruppe = new List<string>() { "ST3/1", "ST3/2", "ST3/3", "ST3/4", "ST3/5", "ST3/6", "ST3/7", "ST3/8", "ST3/9", "ST4/1", "ST4/2", "ST4/4", "ST4/6" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Schiebeanlage ST3, ST4", Label = "2 flg. mit Lso/Lsu", Produktgruppe = new List<string>() { "ST3/21", "ST3/22", "ST3/23", "ST3/24", "ST3/25", "ST3/26", "ST3/29", "ST3/52", "ST4/21", "ST4/22", "ST4/24", "ST4/26", "ST4/52" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Schiebeanlage ST3, ST4", Label = "1 flg. mit Rahmen", Produktgruppe = new List<string>() { "ST3", "ST4" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Schiebeanlage ST3, ST4", Label = "2 flg. mit Rahmen", Produktgruppe = new List<string>() { "ST3/50.AMB", "ST3/50.LMM", "ST3/51.AMB", "ST3/51.LMM", "ST3/55", "ST3/56", "ST4/50.AMB", "ST4/50.LMM", "ST4/51.AMB", "ST4/51.LMM", "ST4/55", "ST4/56" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Schiebeanlage ST3, ST4", Label = "3 flg. mit Rahmen", Produktgruppe = new List<string>() { "ST3/80", "ST3/81", "ST4/80", "ST4/81" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Schiebeanlage ST3, ST4", Label = "4 flg. mit Rahmen", Produktgruppe = new List<string>() { "ST3/57", "ST3/58" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1", Label = "1 flg. ohne Rahmen", Produktgruppe = new List<string>() { "PL1/1" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1", Label = "2 flg. ohne Rahmen", Produktgruppe = new List<string>() { "PL1/2" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PL1/5", "PL1/9" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PL1/6", "PL1/10" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL2", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PL2" }, IstBasisregel = true, Order = Count });
                Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL2", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "PL2/25", "PL2/29.AMB", "PL2/25.LMM" }, IstBasisregel = true, Order = Count });

                Add(new Kapazitaetsvorgabe() { GroupName = "Zusatzrahmen", Label = "ZR", Produktgruppe = new List<string>() { "ZR" }, IstBasisregel = true, Order = Count });
            }

            if (Version < 2)
            {
                Version = 2;
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Metallgewebe (nicht bei Lichtschächten)",
                    Produktgruppe = new List<string>() { "SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "ST3", "ST4" },
                    Artikelliste = new List<string>() { "142627", "142632" },
                    Etikettentext = new List<string>() { "V4", "V2AA" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Sondergewebe (nicht bei Lichtschächten)",
                    Produktgruppe = new List<string>() { "SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "ST3", "ST4" },
                    Artikelliste = new List<string>() { "142628", "142638", "142680" },
                    Etikettentext = new List<string>() { "PA", "PAE", "PIA" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Transpatecgewebe (nicht bei Lichtschächten)",
                    Produktgruppe = new List<string>() { "SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "ST3", "ST4" },
                    Artikelliste = new List<string>() { "142519", "142520", "142521", "142523" },
                    Etikettentext = new List<string>() { "TTA", "TFM", "TFP" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Polyestergewebe unterhalb der Sprosse",
                    Produktgruppe = new List<string>() { "PT2", "DT3", "DT4", "ST3", "ST4" },
                    Artikelliste = new List<string>() { "142628", "142638" },
                    Etikettentext = new List<string>() { "/ PA", "/ PAE" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Vorbiegen",
                    Produktgruppe = new List<string>() { "SP1", "SP2", "SP4", "SP5", "SP6", "SP7", "ST3", "ST4" },
                    Etikettentext = new List<string>() { "v_Kw_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Seitenarretierung SP1",
                    Produktgruppe = new List<string>() { "SP1" },
                    Artikelliste = new List<string>() { "132466" },
                    Etikettentext = new List<string>() { "SA_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Seitenarretierung SP5",
                    Produktgruppe = new List<string>() { "SP5" },
                    Artikelliste = new List<string>() { "132466", "132272" },
                    Etikettentext = new List<string>() { "SA_", "mW_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Seitenarretierung SP2, SP4, SP6, SP7",
                    Produktgruppe = new List<string>() { "SP2", "SP4", "SP6", "SP7" },
                    Artikelliste = new List<string>() { "132472" },
                    Etikettentext = new List<string>() { "mW_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Sprosse (im Spannrahmen)",
                    Produktgruppe = new List<string>() { "SP1", "SP2", "SP4", "SP5", "SP6", "SP7" },
                    Etikettentext = new List<string>() { "SpB_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Sprosse (im Lichtschacht)",
                    Produktgruppe = new List<string>() { "LI1", "LI2" },
                    Artikelliste = new List<string>() { "103313" },
                    Etikettentext = new List<string>() { "SpB_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Sprossenpaneel",
                    Produktgruppe = new List<string>() { "PT2", "DT3", "DT4", "ST3", "ST4" },
                    Etikettentext = new List<string>() { "Pan_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Montagebohrung",
                    Produktgruppe = new List<string>() { "SP1", "PF2", "DF3", "DF4", "PT2", "DT3", "DT4", "RO4", "RO5", "RO6", "ER1", "ER2", "PL1", "PL2", "ST3", "ST4", "LI4" },
                    Etikettentext = new List<string>() { "MB_s", "MB_v" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Katzen-/Hundeklappe",
                    Produktgruppe = new List<string>() { "PT2", "DT3", "DT4", "ST3", "ST4" },
                    Artikelliste = new List<string>() { "222501", "223510", "223520" },
                    Etikettentext = new List<string>() { "KP", "NeKP", "NeHP" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Standflügelarretierung",
                    Produktgruppe = new List<string>() { "PF2", "PT2" },
                    Artikelliste = new List<string>() { "133470" },
                    Etikettentext = new List<string>() { "ExV_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Schiebeverschluss",
                    Produktgruppe = new List<string>() { "DT3", "PT2" },
                    Artikelliste = new List<string>() { "166460.02", "133460.05" },
                    Etikettentext = new List<string>() { "SchiebVs_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "gedämpfte Tür",
                    Produktgruppe = new List<string>() { "DT3" },
                    Artikelliste = new List<string>() { "133510" },
                    Etikettentext = new List<string>() { "Mag" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Türschliesser",
                    Produktgruppe = new List<string>() { "DT3", "DT4" },
                    Artikelliste = new List<string>() { "133540" },
                    Etikettentext = new List<string>() { "TD" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Einhandbedienung RO5",
                    Produktgruppe = new List<string>() { "RO5" },
                    Artikelliste = new List<string>() { "153925" },
                    Etikettentext = new List<string>() { "Stab" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Aussenbedienung",
                    Produktgruppe = new List<string>() { "RO4", "RO5", "RO6" },
                    Artikelliste = new List<string>() { "143920" },
                    Etikettentext = new List<string>() { "ABf_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Zusatzbedienung",
                    Produktgruppe = new List<string>() { "RO4", "RO5", "RO6" },
                    Artikelliste = new List<string>() { "144080", "143981" },
                    Etikettentext = new List<string>() { "ZiehSch", "EinhSch" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Flügelspaltdichtung",
                    Produktgruppe = new List<string>() { "ST3", "ST4" },
                    Artikelliste = new List<string>() { "124860" },
                    Etikettentext = new List<string>() { "FSp__D" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Griffleiste",
                    Produktgruppe = new List<string>() { "ST3" },
                    Artikelliste = new List<string>() { "104850" },
                    Etikettentext = new List<string>() { "GL" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Fußbedienmulde",
                    Produktgruppe = new List<string>() { "ST3", "ST4" },
                    Artikelliste = new List<string>() { "103518", "134852" },
                    Etikettentext = new List<string>() { "SpSoB", "Fb_" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Sockelblech",
                    Produktgruppe = new List<string>() { "ST3", "ST4" },
                    Artikelliste = new List<string>() { "103518" },
                    Etikettentext = new List<string>() { "SpSoB" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Trittschutzdistanzstück",
                    Produktgruppe = new List<string>() { "LI2/2" },
                    Artikelliste = new List<string>() { "143311" },
                    Etikettentext = new List<string>() { "TsDs" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "symmetrischer Gitterrost",
                    Produktgruppe = new List<string>() { "LI3", "TE1" },
                    Etikettentext = new List<string>() { "GR_sym" },
                    Order = Count
                });
                Add(new Kapazitaetsvorgabe()
                {
                    GroupName = "Sonstiges",
                    Label = "Mehraufwand durch Sonderfarbe",
                    Etikettentext = new List<string>() { "Kunst.Farbe:" },
                    Order = Count
                });
            }

            if (Version < 3)
            {
                Version = 3;
                Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT6", Label = "2 flg. ohne Montagerahmen", Produktgruppe = new List<string>() { "DT6/11" }, IstBasisregel = true, Order = Count });
            }
        }
    }

    public class Kapazitaetsvorgabe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string GroupName { get; set; }
        public string Label { get; set; }
        public List<string> Produktgruppe { get; set; } = new List<string>();
        public List<string> Artikelliste { get; set; } = new List<string>();
        public List<string> Bearbeitungen { get; set; } = new List<string>();
        public List<string> Etikettentext { get; set; } = new List<string>();
        public decimal Zeitvorgabe { get; set; }
        public decimal Gewicht { get; set; }
        public bool IstBasisregel { get; set; }
        public int Order { get; set; }
    }
}

