using ContentStorage.Amazon;
using ContentStorage.Amazon.Contract;
using ContentStorage.Azure;
using ContentStorage.Azure.Contract;
using ContentStorage.Configuration;
using ContentStorage.Configuration.Contract;
using ContentStorage.Contract;
using ContentStorage.IO;
using ContentStorage.IO.Contract;
using ContentStorage.Storage;
using Microsoft.Practices.Unity;

namespace ContentStorage.BootStrap.Unity
{
    public class StorageContainer : UnityContainerExtension
    {
        private const string UnityConfigFileName = "unity.config.xml";

        protected override void Initialize()
        {
            Container.RegisterType<IDataStorage<IImageSource>, AwsS3ImageStorage>(DataStorageType.AmazonWebServiceS3.ToString());
            Container.RegisterType<IDataStorage<IImageSource>, AzureBlobImageStorage>(DataStorageType.WindowsAzureBlob.ToString());
            Container.RegisterType<IDataStorage<IImageSource>, FileSystemImageStorage>(DataStorageType.FileSystem.ToString());
            Container.RegisterType<IDataStorage<IImageSource>, MemoryImageStorage>(DataStorageType.InMemory.ToString());

            Container.RegisterType<IAwsS3StorageConfiguration, AwsS3StorageConfiguration>();
            Container.RegisterType<IBlobStorageConfiguration, AzureBlobStorageConfiguration>();
            Container.RegisterType<IFileStorageConfiguration, FileStorageConfiguration>();

            Container.RegisterType<IS3Client, AmazonS3Client>();

            Container.RegisterType<ICloudContainer, AzureCloudContainer>();
            Container.RegisterType<ICloudBlockBlob, AzureBlockBlob>();

            Container.RegisterType<IDirectoryFunctions, DirectoryFunctions>();
            Container.RegisterType<IFileFunctions, FileFunctions>();
        }
    }
}
