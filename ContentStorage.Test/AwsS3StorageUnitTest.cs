using System.IO;
using ContentStorage.Amazon.Contract;
using ContentStorage.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContentStorage.Test
{
    [TestClass]
    public class AwsS3StorageUnitTest
    {
        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void SaveImageShouldReturnImageSource()
        {
            var client = new Mock<IS3Client>();
            client.Setup(b => b.PutRequest(It.IsAny<string>(), It.IsAny<Stream>(), It.IsAny<string>()));

            var s3Storage = new AwsS3ImageStorage(client.Object);

            var data = File.ReadAllBytes("Koala.jpg");

            var result = s3Storage.Save(data);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        public void DeleteImagShouldReturnTrue()
        {
            var client = new Mock<IS3Client>();
            client.Setup(b => b.DeleteRequest(It.IsAny<string>())).Returns(true);

            var s3Storage = new AwsS3ImageStorage(client.Object);

            var result = s3Storage.Delete("someKey");

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DeploymentItem("contentStorage.config")]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void RetrieveImagShouldReturnImage()
        {
            var data = File.ReadAllBytes("Koala.jpg");

            var client = new Mock<IS3Client>();
            client.Setup(b => b.RetrieveRequest(It.IsAny<string>())).Returns(data);

            var s3Storage = new AwsS3ImageStorage(client.Object);

            var result = s3Storage.Retrieve("");

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
