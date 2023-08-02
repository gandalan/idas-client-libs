using Gandalan.IDAS.WebApi.Client.DTOs.Rechnung;
using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Rechnungen
{
    public interface IFibuExport
    {
        Task ExportFibu(IList<IFibuRecord> data);
        IFibuRecord CreateRecord();
    }

    public interface IFibuRecord
    {
        IList<PropertyInfo> GetExportProperties();
        void FromSammelrechnung(SammelrechnungListItemDTO sammelrechnung);
        void FromRechnung(BelegeInfoDTO rechnung);
    }
}
