namespace ContentStorage.Configuration.Contract
{
    /// <summary>
    /// Interface for Amazon Web Services S3 storage configuration
    /// </summary>
    internal interface IAwsS3StorageConfiguration
    {
        /// <summary>
        /// The Amazon Web Service Access Key
        /// </summary>
        string AccessKey { get; }

        /// <summary>
        /// The Amazon Web Service Secret Key
        /// </summary>
        string SecretKey { get; }

        /// <summary>
        /// The Amazon Web Service BucketName
        /// </summary>
        string BucketName { get; }
    }
}