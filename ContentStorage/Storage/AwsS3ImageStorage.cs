using System;
using System.IO;
using ContentStorage.Amazon.Contract;
using ContentStorage.Contract;
using ContentStorage.Extension;
using ContentStorage.IO;

namespace ContentStorage.Storage
{
    internal class AwsS3ImageStorage : BaseImageStorage
    {
        private readonly IS3Client _client;

        public AwsS3ImageStorage(IS3Client client)
        {
            _client = client;
        }

        public override IImageSource Save(byte[] image, string extension = "", string path = "")
        {
            var imageSource = new ImageSource();

            var key = string.Format("{0}.data", Path.Combine(path, Guid.NewGuid().ToString()));
            var thumbnailKey = GetThumbnailName(key);

            var contentType = new FileExtension(extension).GetContentType();

            using (var memoryStream = new MemoryStream(image))
            {
                memoryStream.Position = 0;

                imageSource.Source = _client.PutRequest(key, memoryStream, contentType);
            }

            using (var memoryStream = new MemoryStream(GetThumbnail(image)))
            {
                memoryStream.Position = 0;

                imageSource.Thumbnail = _client.PutRequest(thumbnailKey, memoryStream, contentType);
            }

            return imageSource;
        }

        public override bool Delete(string source)
        {
            var imageSource = GetImageSourceFromSource(source);
            if (imageSource == null)
                return true;

            return _client.DeleteRequest(imageSource.Source) & _client.DeleteRequest(imageSource.Thumbnail);
        }

        public override byte[] Retrieve(string source)
        {
            return _client.RetrieveRequest(source);
        }
    }
}
