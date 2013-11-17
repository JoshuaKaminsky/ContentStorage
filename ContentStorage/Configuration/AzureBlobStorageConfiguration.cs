using System.Diagnostics;
using ContentStorage.Configuration.Contract;

namespace ContentStorage.Configuration
{
    internal class AzureBlobStorageConfiguration : IBlobStorageConfiguration
    {
        private readonly string _connectionString;
        private readonly string _containerName;

        public AzureBlobStorageConfiguration()
        {
            var configuration = AzureStorageConfigurationSection.GetConfig();

            if (configuration == null)
            {
                Trace.TraceError("Could not load Azure Blob image storage configuration.");
                return;
            }

            _connectionString = configuration.ConnectionString;
            _containerName = configuration.ContainerName;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public string ContainerName
        {
            get { return _containerName; }
        }
    }
}
