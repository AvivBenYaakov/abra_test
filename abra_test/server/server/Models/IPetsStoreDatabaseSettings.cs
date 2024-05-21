namespace server.Models
{
    public interface IPetsStoreDatabaseSettings
    {
        string PetsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
