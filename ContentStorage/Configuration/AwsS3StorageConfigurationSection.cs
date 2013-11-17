using System.Configuration;

namespace ContentStorage.Configuration
{
    internal class AwsS3StorageConfigurationSection : BaseStorageConfigurationSection
    {
        private const string AwsS3StorageConfigurationSectionName = "s3StorageConfiguration";
        private const string AccessKeyConfigurationKey = "accessKey";
        private const string SecretKeyConfigurationKey = "secretKey";
        private const string BucketNameConfigurationKey = "bucketName";

        public static AwsS3StorageConfigurationSection GetConfig()
        {
            return GetStorageConfig<AwsS3StorageConfigurationSection>(AwsS3StorageConfigurationSectionName);
        }

        [ConfigurationProperty(AccessKeyConfigurationKey, IsRequired = true)]
        public string AccessKey
        {
            get { return this[AccessKeyConfigurationKey] as string; }
        }

        [ConfigurationProperty(SecretKeyConfigurationKey, IsRequired = true)]
        public string SecretKey
        {
            get { return this[SecretKeyConfigurationKey] as string; }
        }

        [ConfigurationProperty(BucketNameConfigurationKey, IsRequired = true)]
        public string BucketName
        {
            get { return this[BucketNameConfigurationKey] as string; }
        }
    }
}
