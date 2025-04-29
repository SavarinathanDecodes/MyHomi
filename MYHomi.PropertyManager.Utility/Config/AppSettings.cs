namespace MyHomi.PropertyManager.Utility.Config
{
    public class AppSettings : IAppSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
