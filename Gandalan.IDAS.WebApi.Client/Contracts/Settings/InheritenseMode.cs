using System;
using System.Collections.Generic;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.Contracts.Settings
{
    public interface Inheritense
    {
        InheritenseMode Mode { get; set; }
    }

    public enum InheritenseMode
    {
        Default = 0,
        ReadOnly = 1,
        ReadWrite = 2,
        ReadOnlyInherited = 4,
    }
}
