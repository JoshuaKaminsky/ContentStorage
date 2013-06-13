using Autofac;
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

namespace ContentStorage.Bootstrap.Autofac
{
    public class StorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AwsS3ImageStorage>().As<IDataStorage<IImageSource>>().Named<IDataStorage<IImageSource>>(DataStorageType.AmazonWebServiceS3.ToString());
            builder.RegisterType<AzureBlobImageStorage>().As<IDataStorage<IImageSource>>().Named<IDataStorage<IImageSource>>(DataStorageType.WindowsAzureBlob.ToString());
            builder.RegisterType<FileSystemImageStorage>().As<IDataStorage<IImageSource>>().Named<IDataStorage<IImageSource>>(DataStorageType.FileSystem.ToString());
            builder.RegisterType<MemoryImageStorage>().As<IDataStorage<IImageSource>>().Named<IDataStorage<IImageSource>>(DataStorageType.InMemory.ToString());

            builder.RegisterType<AwsS3StorageConfiguration>().As<IAwsS3StorageConfiguration>();
            builder.RegisterType<AzureBlobStorageConfiguration>().As<IBlobStorageConfiguration>();
            builder.RegisterType<FileStorageConfiguration>().As<IFileStorageConfiguration>();

            builder.RegisterType<AmazonS3Client>().As<IS3Client>();

            builder.RegisterType<AzureCloudContainer>().As<ICloudContainer>();
            builder.RegisterType<AzureBlockBlob>().As<ICloudBlockBlob>();

            builder.RegisterType<DirectoryFunctions>().As<IDirectoryFunctions>();
            builder.RegisterType<FileFunctions>().As<IFileFunctions>();
        }
    }
}
