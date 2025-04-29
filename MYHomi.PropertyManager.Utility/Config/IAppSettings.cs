namespace MyHomi.PropertyManager.Utility.Config
{
    public interface IAppSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
