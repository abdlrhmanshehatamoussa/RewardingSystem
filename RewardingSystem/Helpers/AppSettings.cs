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

        public void Initialize(IConfiguration configurations)
        {
            this.Version = configurations.GetValue<string>("AppSettings:Version");
            this.Environment = configurations.GetValue<string>("AppSettings:Environment");
        }
    }
}