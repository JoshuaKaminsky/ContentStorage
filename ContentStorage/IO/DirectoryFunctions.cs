using System.IO;
using ContentStorage.IO.Contract;

namespace ContentStorage.IO
{
    internal class DirectoryFunctions : IDirectoryFunctions
    {
        public bool Exists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
