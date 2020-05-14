using Gandalan.IDAS.WebApi.Client.Settings;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client
{
    public class ArtosBestellungenRoutinen : WebRoutinenBase
    {
        public ArtosBestellungenRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public void SaveBenutzer(List<ArtosBestellungDTO> list)
        {
            if (!Login())
                return;


            foreach(var artosBestellung in list)
            {
                string responseStr = Put<string>("ArtosBestellung", artosBestellung);
                Debug.WriteLine(responseStr);
            }
        }
    }
}