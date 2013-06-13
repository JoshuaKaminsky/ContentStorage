using System;
using System.Configuration;
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
                Trace.TraceError("Could not load image storage configuration.");
                return;
            }

            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings[configuration.ConnectionStringKey].ConnectionString;
            }
            catch (Exception)
            {
                Trace.TraceError("Could not find azure storage connection string with name {0}", configuration.ConnectionStringKey);
            }
            
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
