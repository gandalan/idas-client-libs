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

            Add(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "einfacher Rahmen", Produktgruppe = new List<string>() { "DF" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "doppelfl. Rahmen", Produktgruppe = new List<string>() { "DF" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "einf. Rah. + Montagerahmen", Produktgruppe = new List<string>() { "DF" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "doppelfl. Rahmen + Montagerahmen", Produktgruppe = new List<string>() { "DF3" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "einfacher Rahmen", Produktgruppe = new List<string>() { "DT" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "doppelfl. Rahmen", Produktgruppe = new List<string>() { "DT" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "einf. Rah. + Montagerahmen", Produktgruppe = new List<string>() { "DT" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "doppelfl. Rahmen + Montagerahmen", Produktgruppe = new List<string>() { "DT" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT5", Label = "einfacher Rahmen", Produktgruppe = new List<string>() { "DT5" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT5", Label = "doppelfl. Rahmen", Produktgruppe = new List<string>() { "DT5" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RF3", Produktgruppe = new List<string>() { "RF3" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RF4", Produktgruppe = new List<string>() { "RF4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RF5", Produktgruppe = new List<string>() { "RF5" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT4", Produktgruppe = new List<string>() { "RT4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT4 quer", Produktgruppe = new List<string>() { "RT4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT4 quer (2-fach)", Produktgruppe = new List<string>() { "RT4" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT5", Produktgruppe = new List<string>() { "RT5" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "ER1", Produktgruppe = new List<string>() { "ER1" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "ER2", Produktgruppe = new List<string>() { "ER2" }, IstBasisregel = true, Order = Count });
            //Add(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "Schieberahmen für Dachfenster", Produktgruppe = "Schieberahmen Dachfenster", IstBasisregel = true });

            Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI1", Produktgruppe = new List<string>() { "LI1" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI1 2tlg.", Produktgruppe = new List<string>() { "LI1" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI2", Produktgruppe = new List<string>() { "LI2" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI2 2tlg.", Produktgruppe = new List<string>() { "LI2" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI3", Produktgruppe = new List<string>() { "LI3" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI3 2tlg.", Produktgruppe = new List<string>() { "LI3" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Terresa", Label = "TE1", Produktgruppe = new List<string>() { "TE1" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "1 flg. Anlage", Produktgruppe = new List<string>() { "ST" }, IstBasisregel = true });
            Add(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "2 flg. Anlage mit 1-fach. LS", Produktgruppe = new List<string>() { "ST" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "2 flg. Anlage mit geschl. LS", Produktgruppe = new List<string>() { "ST" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "3 flg. Anlage mit geschl. LS", Produktgruppe = new List<string>() { "ST" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "4 flg. Anlage mit geschl. LS", Produktgruppe = new List<string>() { "ST" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "einfach", Produktgruppe = new List<string>() { "PL" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "doppelflügelig", Produktgruppe = new List<string>() { "PL" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "mit Montagerahmen", Produktgruppe = new List<string>() { "PL" }, IstBasisregel = true, Order = Count });
            Add(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "doppelfl. mit Montagerahmen", Produktgruppe = new List<string>() { "PL" }, IstBasisregel = true, Order = Count });

            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Metallgewebe" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Einhandbedienung beim Rollo" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Mehraufwand für Sonderfarbe" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Mehraufwand Sonderfarbe bei Plissee" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Katzenklappe" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Hundeklappe" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Schiebeverschluss" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Türschließer bei Drehrahmen" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Drehstabfeder bei Drehrahmen" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Griffleiste für Schiebeanlagen" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Fussbedienung mit Sockelblech" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Sockelblech für Schiebeanlage" });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Sprossenpaneel", Artikelliste = new List<string>() { "123456" } });
            Add(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Montagebohrungen", Bearbeitungen = new List<string>() { "MB" } });

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

