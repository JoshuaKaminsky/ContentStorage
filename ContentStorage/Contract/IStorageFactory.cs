namespace ContentStorage.Contract
{
    /// <summary>
    /// Factory Interface for retrieving Image Storage Interfaces
    /// </summary>
    public interface IStorageFactory<out TSource> where TSource : IDataSource
    {
        /// <summary>
        /// Resolve an instance of an image storage interface
        /// </summary>
        /// <param name="dataStorageType">The type of image storage to resolve an instance for</param>
        /// <returns>An instance of the specifed image storage interface</returns>
        IDataStorage<TSource> Resolve(DataStorageType dataStorageType);
    }
}
