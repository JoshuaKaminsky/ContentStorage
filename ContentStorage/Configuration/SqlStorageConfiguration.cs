using System.Diagnostics;
using ContentStorage.Configuration.Contract;

namespace ContentStorage.Configuration
{
    internal class SqlStorageConfiguration : ISqlConfiguration
    {
        private readonly string _connectionString;

        public SqlStorageConfiguration()
        {
            var configuration = SqlStorageConfigurationSection.GetConfig();

            if (configuration == null)
            {
                Trace.TraceError("Could not load sql image storage configuration.");
                return;
            }

            _connectionString = configuration.ConnectionString;
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
