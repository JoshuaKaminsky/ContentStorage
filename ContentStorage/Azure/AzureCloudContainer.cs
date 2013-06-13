using ContentStorage.Azure.Contract;
using ContentStorage.Configuration.Contract;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ContentStorage.Azure
{
    internal class AzureCloudContainer : ICloudContainer
    {
        private readonly object _containerLock = new object();
        private readonly IBlobStorageConfiguration _configuration;

        private CloudBlobContainer _container;

        public AzureCloudContainer(IBlobStorageConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICloudBlockBlob GetBlockBlobReference(string source)
        {
            var blob = new AzureBlockBlob();

            var key = source.Replace(Container.Uri.AbsoluteUri, "");

            blob.SetBlockBlob(Container.GetBlockBlobReference(key));

            return blob ;
        }

        private CloudBlobContainer Container
        {
            get
            {
                if (_container == null)
                {
                    lock (_containerLock)
                    {
                        if (_container == null)
                        {
                            if (string.IsNullOrWhiteSpace(_configuration.ConnectionString))
                                return null;

                            var storageAccount = CloudStorageAccount.Parse(_configuration.ConnectionString);

                            var blobClient = storageAccount.CreateCloudBlobClient();
                            _container = blobClient.GetContainerReference(_configuration.ContainerName);

                            if (_container.CreateIfNotExists())
                            {
                                _container.SetPermissions(new BlobContainerPermissions
                                {
                                    PublicAccess = BlobContainerPublicAccessType.Blob
                                });
                            }
                        }
                    }
                }

                return _container;
            }
        }
    }
}
