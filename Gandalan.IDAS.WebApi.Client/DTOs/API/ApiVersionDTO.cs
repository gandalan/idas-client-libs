using System.Reflection;

namespace Gandalan.IDAS.WebApi.Client.DTOs.API
{
    public class ApiVersionDTO
    {
        public string Version { get; set; }
        public string Environment { get; set; }
        
        public static ApiVersionDTO FromAssembly(Assembly assembly)
        {
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? $"No informational version found for {assembly.FullName}";
            var env = System.Environment.GetEnvironmentVariable("GDL_ENVIRONMENT") ?? "Development";
            return new ApiVersionDTO() { Version = version, Environment = env };
        }
    }
}
