using System;
using System.IO;
using ContentStorage.Azure.Contract;
using ContentStorage.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContentStorage.Test
{
    [TestClass]
    public class AzureStorageUnitTest
    {
        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void SaveImageShouldReturnImageSource()
        {
            var uri = new Uri("http://test.com/testUri");

            var blob = new Mock<ICloudBlockBlob>();
            blob.Setup(b => b.UploadFromStream(It.IsAny<Stream>()));
            blob.Setup(b => b.Uri).Returns(uri);

            var container = new Mock<ICloudContainer>();
            container.Setup(c => c.GetBlockBlobReference(It.IsAny<string>())).Returns(blob.Object);

            var azureStorage = new AzureBlobImageStorage(container.Object);

            var data = File.ReadAllBytes("Koala.jpg");

            var result = azureStorage.Save(data);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Source, uri.AbsoluteUri);
            Assert.AreEqual(result.Thumbnail, uri.AbsoluteUri);
        }

        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        public void DeleteImagShouldReturnTrue()
        {
            var blob = new Mock<ICloudBlockBlob>();
            blob.Setup(b => b.DeleteIfExists()).Returns(true);

            var container = new Mock<ICloudContainer>();
            container.Setup(c => c.GetBlockBlobReference(It.IsAny<string>())).Returns(blob.Object);

            var azureStorage = new AzureBlobImageStorage(container.Object);

            var result = azureStorage.Delete("someKey");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void RetrieveImagShouldReturnImage()
        {
            var data = File.ReadAllBytes("Koala.jpg");

            var blob = new Mock<ICloudBlockBlob>();
            blob.Setup(b => b.DownloadToStream(It.IsAny<Stream>())).Callback<Stream>(stream => stream.Write(data, 0, data.Length));

            var container = new Mock<ICloudContainer>();
            container.Setup(c => c.GetBlockBlobReference(It.IsAny<string>())).Returns(blob.Object);

            var azureStorage = new AzureBlobImageStorage(container.Object);

            var result = azureStorage.Retrieve("");

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
