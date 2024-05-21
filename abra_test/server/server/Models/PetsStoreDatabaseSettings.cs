namespace server.Models
{
    public class PetsStoreDatabaseSettings : IPetsStoreDatabaseSettings
    {
        public string PetsCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
