namespace ContentStorage.Contract
{
    /// <summary>
    /// Interface for accessing image sources
    /// </summary>
    public interface IImageSource : IDataSource
    {
        /// <summary>
        /// The path to the thumbnail image
        /// </summary>
        string Thumbnail { get; }
    }
}