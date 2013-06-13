using System.Globalization;
using System.IO;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using ContentStorage.Amazon.Contract;
using ContentStorage.Configuration.Contract;

namespace ContentStorage.Amazon
{
    internal class AmazonS3Client : IS3Client
    {
        private readonly string _baseStorageEndpoint;

        private readonly AmazonS3 _client;
        private readonly IAwsS3StorageConfiguration _configuration;

        public AmazonS3Client(IAwsS3StorageConfiguration configuration)
        {
            _baseStorageEndpoint = string.Format("http://s3.amazonaws.com/{0}/", configuration.BucketName);
            _client = AWSClientFactory.CreateAmazonS3Client(configuration.AccessKey, configuration.SecretKey);
            _configuration = configuration;
        }

        public string PutRequest(string key, Stream data, string contentType)
        {
            key = key.Replace('\\', '/');

            var putRequest = new PutObjectRequest()
                .WithBucketName(_configuration.BucketName)
                .WithCannedACL(S3CannedACL.PublicRead)
                .WithContentType(contentType)
                .WithKey(key)
                .WithMetaData("Content-Length", data.Length.ToString(CultureInfo.InvariantCulture))
                .WithStorageClass(S3StorageClass.Standard);

            putRequest.WithInputStream(data);

            _client.PutObject(putRequest);

            return string.Concat(_baseStorageEndpoint, key);
        }

        public bool DeleteRequest(string source)
        {
            var key = source.Replace(_baseStorageEndpoint, "");

            var deleteRequest = new DeleteObjectRequest()
                .WithBucketName(_configuration.BucketName)
                .WithKey(key);

            var response = _client.DeleteObject(deleteRequest);

            return true;
        }

        public byte[] RetrieveRequest(string source)
        {
            var key = source.Replace(_baseStorageEndpoint, "");

            var getRequest = new GetObjectRequest()
                .WithBucketName(_configuration.BucketName)
                .WithKey(key);

            var response = _client.GetObject(getRequest);

            using (var memoryStream = new MemoryStream())
            {
                response.ResponseStream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
