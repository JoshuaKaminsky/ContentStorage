using System.IO;
using ContentStorage.IO.Contract;

namespace ContentStorage.IO
{
    internal class FileFunctions : IFileFunctions
    {
        public byte[] Read(string path)
        {
            if (!File.Exists(path))
                return null;

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                return ReadAllBytes(fileStream);
            }
        }

        public void Write(string path, byte[] data)
        {
            using (var writer = new BinaryWriter(new FileStream(path, FileMode.CreateNew)))
            {
                writer.Write(data);
            }
        }

        public bool DeleteIfExists(string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            return true;
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        protected static byte[] ReadAllBytes(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
