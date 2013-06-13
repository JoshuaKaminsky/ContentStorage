using System.IO;
using ContentStorage.Configuration.Contract;
using ContentStorage.IO.Contract;
using ContentStorage.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContentStorage.Test
{
    [TestClass]
    public class FileStorageUnitTest
    {
        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        public void SaveImageShouldReturnImageSource()
        {
            const string storageDirectory = @"Storage\Images";

            var directoryFunctions = new Mock<IDirectoryFunctions>();
            directoryFunctions.Setup(d => d.Exists(It.IsAny<string>())).Returns(true);

            var fileFunctions = new Mock<IFileFunctions>();
            fileFunctions.Setup(f => f.Write(It.IsAny<string>(), It.IsAny<byte[]>()));

            var configuration = new Mock<IFileStorageConfiguration>();
            configuration.Setup(c => c.StorageDirectory).Returns(storageDirectory);

            var storage = new FileSystemImageStorage(configuration.Object, directoryFunctions.Object, fileFunctions.Object);

            var result = storage.Save(new byte[] {});

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Source.Contains(storageDirectory));
            Assert.IsTrue(result.Thumbnail.Contains(storageDirectory));
        }

        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        public void DeleteImagShouldReturnTrue()
        {
            const string storageDirectory = @"Storage\Images";

            var directoryFunctions = new Mock<IDirectoryFunctions>();
            directoryFunctions.Setup(d => d.Exists(It.IsAny<string>())).Returns(true);

            var fileFunctions = new Mock<IFileFunctions>();
            fileFunctions.Setup(f => f.DeleteIfExists(It.IsAny<string>())).Returns(true);

            var configuration = new Mock<IFileStorageConfiguration>();
            configuration.Setup(c => c.StorageDirectory).Returns(storageDirectory);

            var storage = new FileSystemImageStorage(configuration.Object, directoryFunctions.Object, fileFunctions.Object);

            var result = storage.Delete("someKey");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void RetrieveImagShouldReturnImage()
        {
            const string storageDirectory = @"Storage\Images";

            var data = File.ReadAllBytes("Koala.jpg");
            
            var directoryFunctions = new Mock<IDirectoryFunctions>();
            directoryFunctions.Setup(d => d.Exists(It.IsAny<string>())).Returns(true);

            var fileFunctions = new Mock<IFileFunctions>();
            fileFunctions.Setup(f => f.Read(It.IsAny<string>())).Returns(data);

            var configuration = new Mock<IFileStorageConfiguration>();
            configuration.Setup(c => c.StorageDirectory).Returns(storageDirectory);

            var storage = new FileSystemImageStorage(configuration.Object, directoryFunctions.Object, fileFunctions.Object);

            var result = storage.Retrieve("");

            Assert.IsNotNull(result);
            Assert.IsTrue(data.Length == result.Length);

            var index = 0;
            foreach (var @byte in data)
            {
                Assert.IsTrue(@byte == result[index]);
                index++;
            }
        }
    }
}
