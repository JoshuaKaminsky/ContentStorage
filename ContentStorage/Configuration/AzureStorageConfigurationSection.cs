using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class AzureStorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string AzureImageStorageConfigurationSectionName = "azureStorageConfiguration";
        private const string ConnectionStringKey = "connectionString";
        private const string ContainerNameKey = "containerName";

        public static AzureStorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<AzureStorageConfigurationSection>(AzureImageStorageConfigurationSectionName);
        }

        [ConfigurationProperty(ConnectionStringKey, IsRequired = true)]
        public string ConnectionString
        {
            get { return this[ConnectionStringKey] as string; }
        }

        [ConfigurationProperty(ContainerNameKey, IsRequired = true)]
        public string ContainerName
        {
            get { return this[ContainerNameKey] as string; }
        }
    }
}
