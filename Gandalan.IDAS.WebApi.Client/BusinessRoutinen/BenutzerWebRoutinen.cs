using System;
using System.Collections.Generic;
using Gandalan.IDAS.WebApi.DTO;
using System.Diagnostics;
using Gandalan.IDAS.WebApi.Client.Settings;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client
{
    public class BenutzerWebRoutinen : WebRoutinenBase
    {
        public BenutzerWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public BenutzerDTO[] GetBenutzerListe(Guid mandant, bool mitRollenUndRechten = true)
        {
            if (Login())
            {
                return Get<BenutzerDTO[]>($"BenutzerListe?id={mandant}&mitRollenUndRechten={mitRollenUndRechten}");
            }
            return null;
        }

        public BenutzerDTO GetBenutzer(Guid benutzer, bool mitRollenUndRechten = true)
        {
            if (Login())
            {
                return Get<BenutzerDTO>($"Benutzer?id={benutzer}&mitRollenUndRechten={mitRollenUndRechten}");
            }
            return null;
        }

        public void SaveBenutzer(List<BenutzerDTO> list)
        {
            if (Login())
            {
                list.ForEach(cb =>
                {
                    string responseStr = Put<string>("Benutzer", cb);
                    Debug.WriteLine(responseStr);
                });
            }
        }

        public void SaveBenutzer(BenutzerDTO benutzer)
        {
            if (Login())
            {
                string responseStr = Put<string>("Benutzer", benutzer);
                Debug.WriteLine(responseStr);
            }
        }

        public string PasswortReset(string benutzerName)
        {
            return Get("PasswortReset?email=" + System.Uri.EscapeDataString(benutzerName));
        }


        public async Task<BenutzerDTO[]> GetBenutzerListeAsync(Guid mandant, bool mitRollenUndRechten = true)
        {
            return await Task.Run(() => GetBenutzerListe(mandant, mitRollenUndRechten));
        }

        public async Task<BenutzerDTO> GetBenutzerAsync(Guid benutzer, bool mitRollenUndRechten = true)
        {
            return await Task.Run(() => GetBenutzer(benutzer, mitRollenUndRechten));
        }

        public async Task SaveBenutzerAsync(BenutzerDTO benutzer)
        {
            await Task.Run(() => { SaveBenutzer(benutzer); });
        }

        public async Task<string> PasswortResetAsync(string benutzerName)
        {
            return await Task.Run(() => PasswortReset(benutzerName));
        }
    }
}
