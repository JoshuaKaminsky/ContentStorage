namespace ContentStorage.IO.Contract
{
    internal interface IFileFunctions
    {
        byte[] Read(string path);

        void Write(string path, byte[] data);

        bool Exists(string path);
     
        bool DeleteIfExists(string path);
    }
}