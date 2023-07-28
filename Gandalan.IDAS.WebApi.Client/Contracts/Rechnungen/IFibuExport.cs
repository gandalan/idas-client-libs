using Gandalan.IDAS.WebApi.DTO;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Rechnungen
{
    public interface IFibuExport
    {
        void ExportFibu(IList<IFibuRecord> data);
    }

    public interface IFibuRecord
    {
        IList<PropertyInfo> GetExportProperties();
    }
}
