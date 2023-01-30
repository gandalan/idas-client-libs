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
            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? $"No informational version found for {assembly.FullName}";
            var env = System.Environment.GetEnvironmentVariable("GDL_ENVIRONMENT") ?? "Development";
            var description = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

            // BuildDate format: "BuildDate=2023-01-30T09:00:00;"
            string buildDate;
            try
            {
                if (string.IsNullOrEmpty(description) || !description.Contains("BuildDate="))
                {
                    throw new Exception("BuildDate not found in assembly description");
                }
                var startIndex = description.IndexOf("BuildDate=");
                var endIndex = description.IndexOf(';', startIndex);
                var substring = description.Substring(startIndex, endIndex - startIndex);
                var split = substring.Split('=')[1].Split(';')[0];
                var date = DateTime.Parse(split);
                buildDate = date.ToString("dd.MM.yyyy hh:mm");
            }
            catch (Exception)
            {
                buildDate = "Build-Datum nicht verfügbar";
            }

            return new ApiVersionDTO() { Version = version, Environment = env, BuildDate = buildDate };
        }
    }
}
