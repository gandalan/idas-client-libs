using Gandalan.Client.Contracts.Navigation;
using System;
using System.Collections.Generic;

namespace Gandalan.Client.Contracts.UIServices
{
    public interface IQuickCommandManager
    {
        void AddQuickCommand(IQuickCommand command);
        List<IQuickCommand> GetAllCommands();
        event EventHandler QuickCommandsChanged;
    }
}
