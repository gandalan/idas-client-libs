using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Gandalan.IDAS.WebApi.Client.DTOs.API
{
    public class ApiVersionDTO
    {
        public string Version { get; set; }
        public string Environment { get; set; }
        
        /// <returns>The ApiVersionDTO of the object/method that invoked this method.</returns>
        public static ApiVersionDTO FromThis()
        {
            var assembly = Assembly.GetCallingAssembly();
            var env = System.Environment.GetEnvironmentVariable("GDL_ENVIRONMENT") ?? "GDL_ENVIRONMENT not found";
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? $"No informational version found for {assembly.FullName}";
            return new ApiVersionDTO() { Version = version, Environment = env };
        }
    }
}
