using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gandalan.IDAS.WebApi.Client.Backup;

public interface IBackupHelper
{
    Task GenerateBackup(List<Guid> vorgangGuids, string email, bool nurRechnungen);
    bool IsBackupPossible(string email);
}
