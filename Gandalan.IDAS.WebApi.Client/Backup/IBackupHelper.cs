using System;
using System.Collections.Generic;

namespace Gandalan.IDAS.WebApi.Client.Backup
{
    public interface IBackupHelper
    {
        void GenerateBackup(List<Guid> vorgangGuids, string email, bool nurRechnungen);
        bool IsBackupPossible(string email);
    }
}
