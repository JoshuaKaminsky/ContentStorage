using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class FileStorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string FileImageStorageConfigurationSectionName = "fileStorageConfiguration";
        private const string FileStorageDirectoryKey = "fileStorageDirectory";

        public static FileStorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<FileStorageConfigurationSection>(FileImageStorageConfigurationSectionName);
        }

        [ConfigurationProperty(FileStorageDirectoryKey, IsRequired = true)]
        public string FileStorageDirectory
        {
            get { return this[FileStorageDirectoryKey] as string; }
        }
    }
}
