using System.Diagnostics;
using ContentStorage.Configuration.Contract;

namespace ContentStorage.Configuration
{
    internal class AwsS3StorageConfiguration : IAwsS3StorageConfiguration
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _bucketName;

        public AwsS3StorageConfiguration()
        {
            var configuration = AwsS3StorageConfigurationSection.GetConfig();

            if (configuration == null)
            {
                Trace.TraceError("Could not load Amazon Web Service image storage configuration.");
                return;
            }

            _accessKey = configuration.AccessKey;
            _secretKey = configuration.SecretKey;
            _bucketName = configuration.BucketName;
        }

        public string AccessKey
        {
            get { return _accessKey; }
        }

        public string SecretKey
        {
            get { return _secretKey; }
        }

        public string BucketName
        {
            get { return _bucketName; }
        }
    }
}
