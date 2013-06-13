using System.Diagnostics;
using ContentStorage.Configuration.Contract;

namespace ContentStorage.Configuration
{
    internal class FileStorageConfiguration : IFileStorageConfiguration
    {
        private readonly string _storageDirectory;

        public FileStorageConfiguration()
        {
            var configuration = FileStorageConfigurationSection.GetConfig();

            if (configuration == null)
            {
                Trace.TraceError("Could not load image storage configuration.");
                return;
            }

            _storageDirectory = configuration.FileStorageDirectory;
        }

        public string StorageDirectory
        {
            get { return _storageDirectory; }
        }
    }
}
