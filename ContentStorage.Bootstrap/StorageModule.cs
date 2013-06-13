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
using Ninject.Modules;

namespace ContentStorage.Bootstrap.Ninject
{
    public sealed class StorageModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataStorage<IImageSource>>().To<AwsS3ImageStorage>().Named(DataStorageType.AmazonWebServiceS3.ToString());
            Bind<IDataStorage<IImageSource>>().To<AzureBlobImageStorage>().Named(DataStorageType.WindowsAzureBlob.ToString());
            Bind<IDataStorage<IImageSource>>().To<FileSystemImageStorage>().Named(DataStorageType.FileSystem.ToString());
            Bind<IDataStorage<IImageSource>>().To<MemoryImageStorage>().Named(DataStorageType.InMemory.ToString());

            Bind<IAwsS3StorageConfiguration>().To<AwsS3StorageConfiguration>();
            Bind<IBlobStorageConfiguration>().To<AzureBlobStorageConfiguration>();
            Bind<IFileStorageConfiguration>().To<FileStorageConfiguration>();

            Bind<IS3Client>().To<AmazonS3Client>();

            Bind<ICloudContainer>().To<AzureCloudContainer>();
            Bind<ICloudBlockBlob>().To<AzureBlockBlob>();

            Bind<IDirectoryFunctions>().To<DirectoryFunctions>();
            Bind<IFileFunctions>().To<FileFunctions>();
        }
    }
}
