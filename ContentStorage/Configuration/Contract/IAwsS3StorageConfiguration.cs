namespace ContentStorage.Configuration.Contract
{
    /// <summary>
    /// Interface for Amazon Web Services S3 storage configuration
    /// </summary>
    internal interface IAwsS3StorageConfiguration
    {
        string AccessKey { get; }

        string SecretKey { get; }

        string BucketName { get; }
    }
}