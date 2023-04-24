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
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP1", Produktgruppe = "SP1" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP2", Produktgruppe = "SP2" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP4", Produktgruppe = "SP4" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP5", Produktgruppe = "SP5" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP6", Produktgruppe = "SP6" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Spannrahmen", Label = "SP7", Produktgruppe = "SP7" });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "einfacher Rahmen", Produktgruppe = "DF", Tag = new Tag("Rahmenanzahl", "1")});
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "doppelfl. Rahmen", Produktgruppe = "DF", Tag = new Tag("Rahmenanzahl", "2") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "einf. Rah. + Montagerahmen", Produktgruppe = "DF", Tag = new Tag("Rahmenanzahl", "1+1") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehflügel DF3, DF4", Label = "doppelfl. Rahmen + Montagerahmen", Produktgruppe = "DF", Tag = new Tag("Rahmenanzahl", "2+1") });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "einfacher Rahmen", Produktgruppe = "DT", Tag = new Tag("Rahmenanzahl", "1") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "doppelfl. Rahmen", Produktgruppe = "DT", Tag = new Tag("Rahmenanzahl", "2") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "einf. Rah. + Montagerahmen", Produktgruppe = "DT", Tag = new Tag("Rahmenanzahl", "1+1") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT3, DT4", Label = "doppelfl. Rahmen + Montagerahmen", Produktgruppe = "DT", Tag = new Tag("Rahmenanzahl", "2+1") });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT5", Label = "einfacher Rahmen", Produktgruppe = "DT5", Tag = new Tag("Rahmenanzahl", "1") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Drehtüren DT5", Label = "doppelfl. Rahmen", Produktgruppe = "DT5", Tag = new Tag("Rahmenanzahl", "2") });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RF3", Produktgruppe = "RF3" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RF4", Produktgruppe = "RF4" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RF5", Produktgruppe = "RF5" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT4", Produktgruppe = "RT4" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT4 quer", Produktgruppe = "RT4", Tag = new Tag("Ausrichtung", "quer") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT4 quer (2-fach)", Produktgruppe = "RT4", Tag = new Tag("Ausrichtung", "quer2") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "RT5", Produktgruppe = "RT5" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "ER1", Produktgruppe = "ER1" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "ER2", Produktgruppe = "ER2" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Rollo", Label = "Schieberahmen für Dachfenster", Produktgruppe = "Schieberahmen Dachfenster" });
            
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI1", Produktgruppe = "LI1" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI1 2tlg.", Produktgruppe = "LI1", Tag = new Tag("2tlg", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI2", Produktgruppe = "LI2" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI2 2tlg.", Produktgruppe = "LI2", Tag = new Tag("2tlg", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI3", Produktgruppe = "LI3" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Lichtschachtabdeckung", Label = "LI3 2tlg.", Produktgruppe = "LI3", Tag = new Tag("2tlg", "") });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Terresa", Label = "TE1", Produktgruppe = "TE1" });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "1 flg. Anlage", Produktgruppe = "ST" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "2 flg. Anlage mit 1-fach. LS", Produktgruppe = "ST" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "2 flg. Anlage mit geschl. LS", Produktgruppe = "ST" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "3 flg. Anlage mit geschl. LS", Produktgruppe = "ST" });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Schiebetüren", Label = "4 flg. Anlage mit geschl. LS", Produktgruppe = "ST" });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "einfach", Produktgruppe = "PL", Tag = new Tag("Rahmenanzahl", "1") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "doppelflügelig", Produktgruppe = "PL", Tag = new Tag("Rahmenanzahl", "2") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "mit Montagerahmen", Produktgruppe = "PL", Tag = new Tag("Rahmenanzahl", "1+1") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Plissee PL1, PL2", Label = "doppelfl. mit Montagerahmen", Produktgruppe = "PL", Tag = new Tag("Rahmenanzahl", "2+1") });

            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Metallgewebe", Tag = new Tag("Metallgewebe", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Einhandbedienung beim Rollo", Tag = new Tag("Einhandbedienung Rollo", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Mehraufwand für Sonderfarbe", Tag = new Tag("Sonderfarbe", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Mehraufwand Sonderfarbe bei Plissee", Tag = new Tag("Sonderfarbe Plisse", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Katzenklappe", Tag = new Tag("Katzenklappe", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Hundeklappe", Tag = new Tag("Hundeklappe", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Schiebeverschluss", Tag = new Tag("Schiebeverschluss", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Türschließer bei Drehrahmen", Tag = new Tag("Türschließer Drehrahmen", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Drehstabfeder bei Drehrahmen", Tag = new Tag("Drehstabfeder Drehrahmen", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Griffleiste für Schiebeanlagen", Tag = new Tag("Griffleiste Schiebeanlage", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Fussbedienung mit Sockelblech", Tag = new Tag("Fussbedienung Sockelblech", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Sockelblech für Schiebeanlage", Tag = new Tag("Sockelblech Schiebeanlage", "") });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Sprossenpaneel", Artikelliste = new List<string>() { "123456" } });
            AddValueIfNotExist(new Kapazitaetsvorgabe() { GroupName = "Sonstiges", Label = "Montagebohrungen", Bearbeitungen = new List<string>() { "MB" } });

        }

        private void AddValueIfNotExist(Kapazitaetsvorgabe value)
        {
            var entry = this.FirstOrDefault(t => t.GroupName == value.GroupName 
                && t.Label == value.Label 
                && t.Produktgruppe == value.Produktgruppe 
                && t.Tag == value.Tag 
                && t.Artikelliste.SequenceEqual(value.Artikelliste) 
                && t.Bearbeitungen.SequenceEqual(value.Bearbeitungen));
            if (entry == null)
            {
                // Bei Sonstiges könnte sich nur die Artikel-Bearbeitungsliste geändert haben und muss dann neu gesetzt werden. Label muss hier eindeutig sein!
                entry = this.FirstOrDefault(t => t.GroupName == "Sonstiges"
                && t.Label == value.Label
                && t.Produktgruppe == value.Produktgruppe
                && t.Tag == value.Tag);
                if (entry != null)
                {
                    entry.Artikelliste = value.Artikelliste;
                    entry.Bearbeitungen = value.Bearbeitungen;
                }
            }
            if (entry == null)
                Add(value);
        }
    }

    public class Kapazitaetsvorgabe : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string GroupName { get; set; }
        public string Label { get;set; }
        public string Produktgruppe { get; set; }
        public Tag Tag { get; set; }
        public List<string> Artikelliste { get; set; } = new List<string>();
        public List<string> Bearbeitungen { get; set; } = new List<string>();
        public decimal Zeitvorgabe { get;set; }
        public decimal Gewicht { get; set; }
    }

    public struct Tag
    {
        public Tag(string name, string value)
        {
            Name = name; 
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Tag tag &&
                   Name == tag.Name &&
                   Value == tag.Value;
        }

        public override int GetHashCode()
        {
            int hashCode = -244751520;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            return hashCode;
        }

        public static bool operator ==(Tag obj1, Tag obj2)
        {
            return (obj1.Name == obj2.Name
                        && obj1.Value == obj2.Value);
        }
        public static bool operator !=(Tag obj1, Tag obj2)
        {
            return !(obj1.Name == obj2.Name
                        && obj1.Value == obj2.Value);
        }
    }
}

