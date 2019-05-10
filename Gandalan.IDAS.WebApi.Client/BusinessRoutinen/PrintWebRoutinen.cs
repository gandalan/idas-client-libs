using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class PrintWebRoutinen : WebRoutinenBase
    {
        public PrintWebRoutinen(WebApiSettings settings) : base(settings)
        {
        }

        public byte[] PDFErzeugen(Guid belegGuid)
        {
            if (Login())
            {
                Post("Print/?bguid=" + belegGuid.ToString(), null);

                byte[] daten = null;
                IgnoreOnErrorOccured = true;
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(2000);
                    try
                    {
                        daten = GetData("Print/?bguid=" + belegGuid.ToString());
                    }
                    catch {}
                    if (daten != null) break;
                }
                IgnoreOnErrorOccured = true;
                return daten;
            }
            return null;
        }

        public byte[] XPSErzeugen(Guid belegGuid)
        {
            if (Login())
            {
                Post("Print/?bguid=" + belegGuid.ToString() + "&fileFormat=XPS", null);
                byte[] daten = null;
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        Thread.Sleep(2000);
                        daten = GetData("Print/?bguid=" + belegGuid.ToString());
                    }
                    catch {}
                }

                return daten;
            }
            return null;
        }


        public async Task<byte[]> PDFErzeugenAsync(Guid belegGuid)
        {
            return await Task<string>.Run(() => { return PDFErzeugen(belegGuid); });
        }

        public async Task<byte[]> XPSErzeugenAsync(Guid belegGuid)
        {
            return await Task<string>.Run(() => { return XPSErzeugen(belegGuid); });
        }
    }
}
