using System.Configuration;

namespace Lotus.Libraries
{
    public class AppConfig
    {
        public static string GetValue(string key)
        {
            return ConfigurationManager.AppSettings.Get(key);
        }

        public static void SetValue(string key, string value)
        {
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
        public static void SetConnectionString(string conn, string name)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings[name].ConnectionString = conn;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }


    public sealed class Settings
    {
        private static Settings defaultInstance = new Settings();
        public static Settings Default
        {
            get { return defaultInstance; }
        }

        public string ConnectionString
        {
            get
            {
                return Lotus.Base.Properties.Settings.Default.BaseConnString;

            }
            set
            {
                Lotus.Base.Properties.Settings.Default["BaseConnString"] = value; ;
            }
        }
    }
}