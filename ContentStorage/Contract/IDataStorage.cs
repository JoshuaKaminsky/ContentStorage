namespace ContentStorage.Contract
{
    public interface IDataStorage<out TResponse>
    {
        /// <summary>
        /// Method for saving data
        /// </summary>
        /// <param name="data">The data as a byte array</param>
        /// <param name="extension">Optional file extension for the data</param>
        /// <param name="path">Optional string for creating path hierachy</param>
        /// <returns>Interface for accessing data</returns>
        TResponse Save(byte[] data, string extension = "", string path = "");

        /// <summary>
        /// Method for removing data
        /// </summary>
        /// <param name="source">The path of the data to remove</param>
        /// <returns>True if successful, otherwise false</returns>
        bool Delete(string source);

        /// <summary>
        /// Method for retrieving saved data
        /// </summary>
        /// <param name="source">The path of the data to retrieve</param>
        /// <returns>The data as a byte array</returns>
        byte[] Retrieve(string source);
    }
}