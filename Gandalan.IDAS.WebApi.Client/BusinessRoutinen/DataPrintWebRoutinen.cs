using System.Threading;
using System.Threading.Tasks;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.Jobs.Contracts;

namespace Gandalan.IDAS.WebApi.Client.BusinessRoutinen
{
    public class DataPrintWebRoutinen : WebRoutinenBase
    {
        public DataPrintWebRoutinen(IWebApiConfig settings) : base(settings)
        {
        }

        public async Task<bool> DruckErzeugenAsync(IDataPrintJobData data)
        {
            await PostAsync("DataPrint", data);

            DataPrintJobData daten = null;
            IgnoreOnErrorOccured = true;
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(2000);
                try
                {
                    daten = await GetAsync<DataPrintJobData>($"DataPrint/{data.PrintGuid}");
                }
                catch { }

                if (daten != null)
                {
                    data.ResultAsBase64String = daten.ResultAsBase64String;
                    break;
                }
            }
            IgnoreOnErrorOccured = false;

            return !string.IsNullOrEmpty(data.ResultAsBase64String);
        }
    }
}
