namespace ContentStorage.IO.Contract
{
    internal interface IDirectoryFunctions
    {
        bool Exists(string path);

        void CreateDirectory(string path);
    }
}