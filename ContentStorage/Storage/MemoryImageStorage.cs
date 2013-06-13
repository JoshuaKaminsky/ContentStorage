using System;
using System.Collections.Generic;
using System.IO;
using ContentStorage.Contract;
using ContentStorage.Extension;

namespace ContentStorage.Storage
{
    internal class MemoryImageStorage : BaseImageStorage
    {
        private readonly Dictionary<string, byte[]> _imageCache = new Dictionary<string, byte[]>();

        public override IImageSource Save(byte[] image, string extension = "", string path = "")
        {
            var key = string.Format("{0}.data", Path.Combine(path, Guid.NewGuid().ToString()));
            var thumbnailKey = GetThumbnailName(key);

            _imageCache.Add(key, image);
            _imageCache.Add(thumbnailKey, GetThumbnail(image));

            return new ImageSource() {Source = key, Thumbnail = thumbnailKey};
        }

        public override bool Delete(string source)
        {
            var imageSource = GetImageSourceFromSource(source);
            if (imageSource == null)
                return true;

            return _imageCache.SafeRemove(imageSource.Source) &&
                   _imageCache.SafeRemove(imageSource.Thumbnail);
        }

        public override byte[] Retrieve(string source)
        {
            return _imageCache.ContainsKey(source) ? _imageCache[source] : null;
        }
    }
}
