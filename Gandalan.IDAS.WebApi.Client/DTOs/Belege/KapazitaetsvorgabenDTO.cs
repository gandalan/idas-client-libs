using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/how-to-group-sort-and-filter-data-in-the-datagrid-control?view=netframeworkdesktop-4.8
    /// </summary>
    public class KapazitaetsvorgabenDTO : ObservableCollection<Kapazitaetsvorgabe>
    {
        public KapazitaetsvorgabenDTO()
        {
        }

        public KapazitaetsvorgabenDTO(IEnumerable<Kapazitaetsvorgabe> collection) : base(collection)
        {
        }

        // Creating the Kapazitaetsvorgabe collection in this way enables data binding from XAML.
        public void init()
        {
            if (Count > 0) return;

            Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP1", Produktgruppe = new List<string>() { "SP1" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP2", Produktgruppe = new List<string>() { "SP2" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP4", Produktgruppe = new List<string>() { "SP4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP5", Produktgruppe = new List<string>() { "SP5" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP6", Produktgruppe = new List<string>() { "SP6" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP7", Produktgruppe = new List<string>() { "SP7" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "1 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DF3/1", "DF3/3", "DF4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "2 flg. ohne Rahmen", Produktgruppe = new List<string>() { "" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DF3/7", "DF3/8", "DF3/9", "DF3/10" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehfenster DF3, DF4", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DF3/16" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "1 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DT3/1", "DT3/3", "DT3/31", "DT3/37", "DT3/38", "DT4/2", "DT4/4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "2 flg. ohne Rahmen", Produktgruppe = new List<string>() { "DT3/11", "DT3/36", "DT4/12" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "1 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DT3", "DT4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "2 flg. mit Montagerahmen", Produktgruppe = new List<string>() { "DT3/13", "DT3/15", "DT3/16", "DT3/26", "DT3/27", "DT3/30", "DT3/40", "DT4/9" }, IstBasisregel = true, Order = Count });

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

            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Metallgewebe", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Einhandbedienung beim Rollo", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Mehraufwand für Sonderfarbe", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Mehraufwand Sonderfarbe bei Plissee", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Katzenklappe", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Hundeklappe", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Schiebeverschluss", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Türschließer bei Drehrahmen", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Drehstabfeder bei Drehrahmen", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Griffleiste für Schiebeanlagen", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Fussbedienung mit Sockelblech", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Sockelblech für Schiebeanlage", Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Sprossenpaneel", Artikelliste = new List<string>() { "123456" }, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Montagebohrungen", Bearbeitungen = new List<string>() { "MB" }, Order = Count });

        }
    }

    public class Kapazitaetsvorgabe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string GroupName { get; set; }
        public string Label { get;set; }
        public List<string> Produktgruppe { get; set; }
        public List<string> Artikelliste { get; set; } = new List<string>();
        public List<string> Bearbeitungen { get; set; } = new List<string>();
        public decimal Zeitvorgabe { get;set; }
        public decimal Gewicht { get; set; }
        public bool IstBasisregel { get; set; }
        public int Order { get; set; }
    }
}

