using System;
using System.IO;
using System.Linq;
using ContentStorage.Bootstrap.Autofac;
using ContentStorage.Contract;

namespace ContentStorage.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var storageType in Enum.GetValues(typeof(DataStorageType)).Cast<DataStorageType>())
            {
                var result = false;

                try
                {
                    result = TestClient(storageType);
                }
                catch (Exception)
                {
                }

                Console.WriteLine("Executed {0}: result: {1}", storageType, result);
            }

            Console.Read();
        }

        private static bool TestClient(DataStorageType storageType)
        {
            var storageFactory = new StorageFactory<IImageSource>(new AutoFacIocContainer());

            var storage = storageFactory.Resolve(storageType);

            var data = File.ReadAllBytes(@"C:\Users\Public\Pictures\Sample Pictures\Koala.jpg");

            var imageSource = storage.Save(data, ".png", "Joshs Photos");

            var sourceData = storage.Retrieve(imageSource.Source);
            var thumbnailData = storage.Retrieve(imageSource.Thumbnail);

            File.WriteAllBytes(@"C:\temp\source.jpg", sourceData);
            File.WriteAllBytes(@"C:\temp\thumbnail.jpg", thumbnailData);

            return storage.Delete(imageSource.Source);
        }
    }
}
