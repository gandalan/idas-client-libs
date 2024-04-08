using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Gandalan.IDAS.WebApi.DTO
{
    public class BenutzerDTO : INotifyPropertyChanged
    {
        public IList<RolleDTO> Rollen { get; set; }
        public Guid BenutzerGuid { get; set; }
        public string Benutzername { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public Guid? MandantGuid { get; set; }
        public string Passwort { get; set; }
        public string PasswortBCrypt { get; set; }
        public bool? MasterKatalog { get; set; }
        public bool? HauptKatalog { get; set; }
        public long? NewsletterId { get; set; }
        public bool IstAktiv { get; set; }
        public IList<Guid> GesperrteVarianten { get; set; }
        public DateTime ChangedDate { get; set; }
        public string EmailAdresse { get; set; }
        public string TelefonNummer { get; set; }
        public string Art { get; set; }
        public bool IstSicSynchronized { get; set; }
        public string LastSicMessage { get; set; }

        public BenutzerDTO()
        {
            Rollen = [];
            GesperrteVarianten = [];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool HatBerechtigung(string code)
        {
            return Rollen.Any(r => r.Berechtigungen.Any(b => b.Code == code));
        }

        public void RemoveRolle(string rollenName)
        {
            RemoveRolle(new RolleDTO { Name = rollenName });
        }

        public void RemoveRolle(RolleDTO rolle)
        {
            for (var i = Rollen.Count - 1; i >= 0; i--)
            {
                if (Rollen[i].Name.Equals(rolle.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    Rollen.RemoveAt(i);
                }
            }
        }

        public void AddRolle(RolleDTO rolle)
        {
            RemoveRolle(rolle.Name);
            Rollen.Add(rolle);
        }
    }
}
