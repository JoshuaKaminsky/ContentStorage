using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class SqlStorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string SqlStorageConfigurationSectionName = "sqlStorageConfiguration";
        private const string ConnectionStringKey = "connectionStringKey";

        public static SqlStorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<SqlStorageConfigurationSection>(SqlStorageConfigurationSectionName);
        }

        [ConfigurationProperty(ConnectionStringKey, IsRequired = true)]
        public string ConnectionString
        {
            get { return this[ConnectionStringKey] as string; }
        }
    }
}
