using System;
using System.Collections.Generic;
using System.IO;
using Gandalan.IDAS.Client.Contracts.Contracts;
using Gandalan.IDAS.WebApi.DTO;
using Newtonsoft.Json;

namespace Gandalan.IDAS.WebApi.Client.Settings
{
    internal static class WebApiFileConfig
    {
        private static readonly string[] _environments = new[] {"dev", "staging", "produktiv" };
        private static string _settingsPath;
        private static Dictionary<string, IWebApiConfig> _settings;
        private static string _appTokenString;

        public static void Initialize(Guid appToken)
        {
            _settings = new Dictionary<string, IWebApiConfig>(StringComparer.OrdinalIgnoreCase);
            _settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Gandalan");
            _appTokenString = appToken.ToString().Trim('{', '}');

            setupEnvironments(appToken);
            setupLocalEnvironment(appToken);
        }
        
        public static IWebApiConfig ByName(string name)
        {
            if (_settings.ContainsKey(name))
            {
                return _settings[name];
            }
            return null;
        }

        private static void setupLocalEnvironment(Guid appToken)
        {
            try
            {
                IWebApiConfig localEnvironment = null;
                var localSettingsFile = Path.Combine(_settingsPath, "Local", "local.json");

                if (File.Exists(localSettingsFile))
                {
                    localEnvironment = JsonConvert.DeserializeObject<WebApiSettings>(File.ReadAllText(localSettingsFile));
                    localEnvironment.AppToken = appToken;
                }

                if (localEnvironment != null)
                {
                    _settings.Add("local", localEnvironment);
                    internalLoadSavedAuthToken("local", localEnvironment);
                }
            }
            catch (Exception e)
            {
                // Local env not available, that's actually the "normal" case
            }
        }

        private static void setupEnvironments(Guid appToken)
        {
            var hub = new ConnectHub(apiVersion: "2.1", clientOS: "win");
            var liste = _environments;
            foreach (var env in liste)
            {
                try
                {
                    var response = hub.GetEndpoints(env: env);
                    IWebApiConfig environment = null;
                    if (response != null)
                    {
                        environment = new WebApiSettings
                        {
                            Url = response.IDAS,
                            CMSUrl = response.CMS,
                            DocUrl = response.DocUrl,
                            I1Url = response.Prod_I1,
                            I2Url = response.Prod_I2, 
                            LatexReportUrl = response.Print_Latex,
                            FriendlyName = env,
                            AppToken = appToken
                        };
                        internalLoadSavedAuthToken(env, environment);
                    }

                    if (environment != null)
                        _settings.Add(env, environment);
                }
                catch (Exception e)
                {
                    // No Hub response, discard
                }
            }
        }

        private static void internalLoadSavedAuthToken(string env, IWebApiConfig environment)
        {
            var savedAuthToken = internalLoadSavedAuthToken(env);
            if (savedAuthToken != null)
            {
                environment.AuthToken = new UserAuthTokenDTO()
                {
                    Token = savedAuthToken.AuthTokenGuid,
                    AppToken = environment.AppToken
                };
                environment.UserName = savedAuthToken.UserName;
            }
        }
        
        private static SavedAuthToken internalLoadSavedAuthToken(string env)
        {
            string configFile = Path.Combine(_settingsPath, env, "AuthToken_" + _appTokenString + ".json");
            if (File.Exists(configFile))
            {
                try
                {
                    return JsonConvert.DeserializeObject<SavedAuthToken>(File.ReadAllText(configFile));
                }
                catch (Exception e)
                {
                    // damaged file, ignore saved token
                }
            }
            return null;
        }

        internal static List<IWebApiConfig> GetAll()
        {
            return new List<IWebApiConfig>(_settings.Values);
        }

        internal static void Save(IWebApiConfig settings)
        {
            if (settings == null) 
                return;

            string configPath = Path.Combine(_settingsPath, settings.FriendlyName);
            string configFile = Path.Combine(configPath, "AuthToken_" + _appTokenString + ".json");
            if (!Directory.Exists(configPath))
                Directory.CreateDirectory(configPath);

            try
            {
                File.WriteAllText(configFile, JsonConvert.SerializeObject(new SavedAuthToken()
                {
                    UserName = settings.UserName,
                    AuthTokenGuid = settings.AuthToken?.Token ?? Guid.Empty
                }));
                _settings[settings.FriendlyName] = settings;
            }
            catch (Exception ex)
            {
                // Save went wrong, maybe rights missing. Ignore, no user info for now
            }
        }
    }
}