namespace ContentStorage.Configuration.Contract
{
    internal interface ISqlConfiguration
    {
        /// <summary>
        /// The connection string to sql
        /// </summary>
        string ConnectionString { get; }
    }
}
