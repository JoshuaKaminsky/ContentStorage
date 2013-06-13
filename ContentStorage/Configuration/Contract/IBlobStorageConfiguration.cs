namespace ContentStorage.Configuration.Contract
{
    /// <summary>
    /// Interface for Windows Azure blob storage configuration
    /// </summary>
    internal interface IBlobStorageConfiguration
    {
        /// <summary>
        /// The connection string to azure blob storage
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// The name of the blob storage container
        /// </summary>
        string ContainerName { get; }
    }
}