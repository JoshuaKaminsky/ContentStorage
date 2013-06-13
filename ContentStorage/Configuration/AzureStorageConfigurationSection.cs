using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class AzureStorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string AzureImageStorageConfigurationSectionName = "azureStorageConfiguration";

        public static AzureStorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<AzureStorageConfigurationSection>(AzureImageStorageConfigurationSectionName);
        }

        [ConfigurationProperty("connectionStringKey", IsRequired = true)]
        public string ConnectionStringKey
        {
            get { return this["connectionStringKey"] as string; }
        }

        [ConfigurationProperty("containerName", IsRequired = true)]
        public string ContainerName
        {
            get { return this["containerName"] as string; }
        }
    }
}
