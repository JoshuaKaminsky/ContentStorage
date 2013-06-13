namespace ContentStorage.Contract
{
    /// <summary>
    /// Interface containing data source information
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// The source location of the data
        /// </summary>
        string Source { get; }
    }
}
