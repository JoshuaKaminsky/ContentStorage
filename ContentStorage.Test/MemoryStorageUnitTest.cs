using System.IO;
using ContentStorage.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentStorage.Test
{
    [TestClass]
    public class MemoryStorageUnitTest
    {
        [TestMethod]
        public void SaveImageShouldReturnImageSource()
        {
            var storage = new MemoryImageStorage();

            var result = storage.Save(new byte[] { });

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DeleteImagShouldReturnTrue()
        {
            var storage = new MemoryImageStorage();

            var result = storage.Delete("someKey");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void RetrieveImagShouldReturnImage()
        {
            var data = File.ReadAllBytes("Koala.jpg");

            var storage = new MemoryImageStorage();

            var sources = storage.Save(data);

            var result = storage.Retrieve(sources.Source);

            Assert.IsNotNull(result);
            Assert.IsTrue(data.Length == result.Length);

            var index = 0;
            foreach (var @byte in data)
            {
                Assert.IsTrue(@byte == result[index]);
                index++;
            }
        }

        [TestMethod]
        [DeploymentItem(@"Data\Koala.jpg")]
        public void ThumbnailIsLessThan10K()
        {
            var data = File.ReadAllBytes("Koala.jpg");

            var storage = new MemoryImageStorage();

            var sources = storage.Save(data);

            var result = storage.Retrieve(sources.Thumbnail);

            File.WriteAllBytes(@"C:\temp\" + sources.Thumbnail, result);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length < 10000);
        }
    }
}
