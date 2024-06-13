using System;
using System.Collections.Generic;
using Gandalan.Client.Contracts.Navigation;

namespace Gandalan.Client.Contracts.UIServices;

public interface IQuickCommandManager
{
    void AddQuickCommand(IQuickCommand command);
    List<IQuickCommand> GetAllCommands();
    event EventHandler QuickCommandsChanged;

    object Context { get; set; }
}