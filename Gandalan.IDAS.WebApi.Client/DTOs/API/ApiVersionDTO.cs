using System;
using System.Reflection;

namespace Gandalan.IDAS.WebApi.Client.DTOs.API
{
    public class ApiVersionDTO
    {
        public string Version { get; set; }
        public string Environment { get; set; }
        public string BuildDate { get; set; }

        public static ApiVersionDTO FromAssembly(Assembly assembly)
        {
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? $"Keine Version gefunden für: {assembly.FullName}";
            var env = System.Environment.GetEnvironmentVariable("GDL_ENVIRONMENT") ?? "Development";
            var buildDate = ExtractBuildDateFromAssembly(assembly) ?? "Build-Datum nicht verfügbar";

            return new ApiVersionDTO() { Version = version, Environment = env, BuildDate = buildDate };
        }

        #region private methods
        /// <summary>
        /// Assembly description should contain the build date in following format: <code>"BuildDate=2023-01-30T09:00:00;"</code>
        /// </summary>
        private static string ExtractBuildDateFromAssembly(Assembly assembly)
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
            if (!DateTime.TryParse(split, out var date))
                return null;

            return date.ToString("dd.MM.yyyy hh:mm"); ;
        }
        #endregion
    }
}
