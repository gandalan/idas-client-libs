using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Gandalan.Client.Contracts.Navigation;

public enum NotifyStatusEnum
{
    NoNotification,
    Info,
    Alert
}


public interface INavigationItem : INotifyPropertyChanged
{
    string Group { get; }
    string SubGroup { get; }
    string Caption { get; }
    object Icon { get; }
    int Order { get; }
    bool IsVisible { get; set; }
    
    NotifyStatusEnum NotifyStatus { get; set; }
    int NotifyCount { get; set; }

    Func<Task> Execute { get; }
}
