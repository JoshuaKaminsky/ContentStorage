using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class FileStorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string FileImageStorageConfigurationSectionName = "fileStorageConfiguration";

        public static FileStorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<FileStorageConfigurationSection>(FileImageStorageConfigurationSectionName);
        }

        [ConfigurationProperty("fileStorageDirectory", IsRequired = true)]
        public string FileStorageDirectory
        {
            get { return this["fileStorageDirectory"] as string; }
        }
    }
}
