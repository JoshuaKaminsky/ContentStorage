using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class AwsS3StorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string AwsS3StorageConfigurationSectionName = "s3StorageConfiguration";

        public static AwsS3StorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<AwsS3StorageConfigurationSection>(AwsS3StorageConfigurationSectionName);
        }

        [ConfigurationProperty("accessKey", IsRequired = true)]
        public string AccessKey
        {
            get { return this["accessKey"] as string; }
        }

        [ConfigurationProperty("secretKey", IsRequired = true)]
        public string SecretKey
        {
            get { return this["secretKey"] as string; }
        }

        [ConfigurationProperty("bucketName", IsRequired = true)]
        public string BucketName
        {
            get { return this["bucketName"] as string; }
        }
    }
}
