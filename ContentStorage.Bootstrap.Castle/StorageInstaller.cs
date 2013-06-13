using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
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

namespace ContentStorage.Bootstrap.CastleWindsor
{
    public class StorageInstaller : IWindsorInstaller
{
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDataStorage<IImageSource>>().ImplementedBy<AwsS3ImageStorage>().Named(DataStorageType.AmazonWebServiceS3.ToString()));
            container.Register(Component.For<IDataStorage<IImageSource>>().ImplementedBy<AzureBlobImageStorage>().Named(DataStorageType.WindowsAzureBlob.ToString()));
            container.Register(Component.For<IDataStorage<IImageSource>>().ImplementedBy<FileSystemImageStorage>().Named(DataStorageType.FileSystem.ToString()));
            container.Register(Component.For<IDataStorage<IImageSource>>().ImplementedBy<MemoryImageStorage>().Named(DataStorageType.InMemory.ToString()));

            container.Register(Component.For<IAwsS3StorageConfiguration>().ImplementedBy<AwsS3StorageConfiguration>());
            container.Register(Component.For<IBlobStorageConfiguration>().ImplementedBy<AzureBlobStorageConfiguration>());
            container.Register(Component.For<IFileStorageConfiguration>().ImplementedBy<FileStorageConfiguration>());

            container.Register(Component.For<IS3Client>().ImplementedBy<AmazonS3Client>());

            container.Register(Component.For<ICloudContainer>().ImplementedBy<AzureCloudContainer>());
            container.Register(Component.For<ICloudBlockBlob>().ImplementedBy<AzureBlockBlob>());
            
            container.Register(Component.For<IDirectoryFunctions>().ImplementedBy<DirectoryFunctions>());
            container.Register(Component.For<IFileFunctions>().ImplementedBy<FileFunctions>());
        }
    }
}
