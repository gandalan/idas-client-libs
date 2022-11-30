using System;

namespace Gandalan.IDAS.Contracts.ChangeTracking
{
    public interface IVersionable
	{
        long Version { get; set; }
        DateTime ChangedDate { get; set; }
	}
}
