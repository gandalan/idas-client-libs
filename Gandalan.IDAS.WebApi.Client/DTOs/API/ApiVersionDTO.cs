using System;
using System.Globalization;
using System.Reflection;

namespace Gandalan.IDAS.WebApi.Client.DTOs.API
{
    public class ApiVersionDTO
    {
        public string Version { get; set; }
        public string Environment { get; set; }
        public string BuildTime { get; set; }
        public string ReleaseTime { get; set; }

        public static ApiVersionDTO FromAssembly(Assembly assembly)
        {
            var deploymentTime = System.Environment.GetEnvironmentVariable("RELEASE_DEPLOYMENT_STARTTIME");
            var informationalVersion = System.Environment.GetEnvironmentVariable("GDL_InformationalVersion") ?? System.Environment.GetEnvironmentVariable("GDL.InformationalVersion");

            return new ApiVersionDTO
            {
                Version = informationalVersion ?? assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? $"Keine Version gefunden für: {assembly.FullName}",
                Environment = System.Environment.GetEnvironmentVariable("GDL_ENVIRONMENT") ?? System.Environment.GetEnvironmentVariable("GDL.ENVIRONMENT") ?? System.Environment.GetEnvironmentVariable("GDL.Environment") ?? "Development",
                BuildTime = ExtractBuildTimeFromAssembly(assembly) ?? deploymentTime ?? "-",
                ReleaseTime = deploymentTime ?? "-",
            };
        }

        /// <summary>
        /// Assembly description should contain the build date in following format: <code>"BuildDate=2023-01-11 16:09:51Z;"</code>
        /// </summary>
        private static string ExtractBuildTimeFromAssembly(Assembly assembly)
        {
            var description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

            if (string.IsNullOrEmpty(description) || !description.Contains("BuildDate="))
                return null;

            var startIndex = description.IndexOf("BuildDate=");
            var endIndex = description.IndexOf(';', startIndex);
            if (startIndex < 0 || endIndex < 0)
                return null;

            var substring = description.Substring(startIndex, endIndex - startIndex);
            var split = substring.Split('=')[1].Split(';')[0];
            if (!DateTime.TryParse(split, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var date))
                return null;

            return date.ToString("yyyy-MM-dd HH:mm:ssK");
        }
    }
}
