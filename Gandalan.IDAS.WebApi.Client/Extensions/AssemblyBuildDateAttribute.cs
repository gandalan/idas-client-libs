using System;

namespace Gandalan.IDAS.WebApi.Client.Extensions
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class AssemblyBuildDateAttribute : Attribute
    {
        private readonly string buildDate;
        public string BuildDate => buildDate;
        public AssemblyBuildDateAttribute(string buildDate)
        {
            this.buildDate = buildDate;
        }
    }
}
