using Microsoft.Extensions.Configuration;

namespace RewardingSystem.Helpers
{
    public class AppSettings
    {
        public static AppSettings Instance { get; private set; } = new AppSettings();
        public string Version { get; private set; }

        public string Environment { get; private set; }

        public string ConnectionString { get; set; }

        private AppSettings()
        {

        }

        public static void Initialize(IConfiguration configurations)
        {
            AppSettings.Instance.Version = configurations.GetValue<string>("AppSettings:Version");
            AppSettings.Instance.Environment = configurations.GetValue<string>("AppSettings:Environment");
        }
    }
}