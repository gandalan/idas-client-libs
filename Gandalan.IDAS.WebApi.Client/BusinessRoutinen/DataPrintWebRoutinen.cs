using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Jobs.Contracts;
using Gandalan.IDAS.WebApi.Client.Settings;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class DataPrintWebRoutinen : WebRoutinenBase
    {
        public DataPrintWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public bool DruckErzeugen(IDataPrintJobData data)
        {
            if (Login())
            {
                Post("DataPrint", data);

                DataPrintJobData daten = null;
                IgnoreOnErrorOccured = true;
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(2000);
                    try
                    {
                        daten = Get<DataPrintJobData>("DataPrint/" + data.PrintGuid.ToString());
                    }
                    catch { }

                    if (daten != null)
                    {
                        data.ResultAsBase64String = daten.ResultAsBase64String;
                        break;
                    }
                }
                IgnoreOnErrorOccured = false;

                if (!string.IsNullOrEmpty(data.ResultAsBase64String))
                    return true;
            }
            return false;
        }
        

        public async Task<bool> DruckErzeugenAsync(IDataPrintJobData data)
        {
            return await Task<string>.Run(() => { return DruckErzeugen(data); });
        }
    }
}
