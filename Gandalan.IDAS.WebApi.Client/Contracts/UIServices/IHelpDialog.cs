using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gandalan.IDAS.Client.Contracts.Contracts.UIServices
{
    public interface IHelpDialog
    {
        Task Show(string selectedTopic = null);
        Task<bool> HelpDialogExists();
    }
}
