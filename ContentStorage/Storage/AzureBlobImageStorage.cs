using System;
using System.IO;
using ContentStorage.Azure.Contract;
using ContentStorage.Contract;
using ContentStorage.Extension;
using ContentStorage.IO;

namespace ContentStorage.Storage
{
    internal class AzureBlobImageStorage : BaseImageStorage
    {
        private readonly ICloudContainer _container;

        public AzureBlobImageStorage(ICloudContainer container)
        {
            _container = container;
        }

        public override IImageSource Save(byte[] image, string extension = "", string path = "")
        {
            var imageSource = new ImageSource();

            var key = string.Format("{0}.data", Guid.NewGuid());
            var thumbnailKey = GetThumbnailName(key);
            
            var contentType = new FileExtension(extension).GetContentType();

            var blob = _container.GetBlockBlobReference(key);
            blob.SetContentType(contentType);

            using (var memoryStream = new MemoryStream(image))
            {
                memoryStream.Position = 0;
                blob.UploadFromStream(memoryStream);
            }

            imageSource.Source = blob.Uri.AbsoluteUri;

            blob = _container.GetBlockBlobReference(thumbnailKey);
            blob.SetContentType(contentType);

            using (var memoryStream = new MemoryStream(GetThumbnail(image)))
            {
                memoryStream.Position = 0;
                blob.UploadFromStream(memoryStream);
            }

            imageSource.Thumbnail = blob.Uri.AbsoluteUri;

            return imageSource;
        }

        public override bool Delete(string source)
        {
            var imageSource = GetImageSourceFromSource(source);
            if (imageSource == null)
                return true;

            return _container.GetBlockBlobReference(imageSource.Source).DeleteIfExists() &&
                   _container.GetBlockBlobReference(imageSource.Thumbnail).DeleteIfExists();
        }

        public override byte[] Retrieve(string source)
        {
            var block = _container.GetBlockBlobReference(source);

            using (var memoryStream = new MemoryStream())
            {
                block.DownloadToStream(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}
