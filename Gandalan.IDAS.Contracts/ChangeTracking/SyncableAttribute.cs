using System;

namespace Gandalan.IDAS.Contracts.ChangeTracking
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class SyncableAttribute : Attribute
    {
        public SyncableAttribute(string guidColumnName)
        {
            GuidColumnName = guidColumnName;
        }

        public string GuidColumnName { get; private set; }
    }
}
