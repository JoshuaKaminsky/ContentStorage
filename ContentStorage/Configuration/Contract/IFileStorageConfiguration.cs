namespace ContentStorage.Configuration.Contract
{
    /// <summary>
    /// Configuration for file system storage
    /// </summary>
    internal interface IFileStorageConfiguration
    {
        /// <summary>
        /// The directory to store data
        /// </summary>
        string StorageDirectory { get; } 
    }
}