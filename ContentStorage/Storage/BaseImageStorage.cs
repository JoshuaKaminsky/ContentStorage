using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using ContentStorage.Contract;

namespace ContentStorage.Storage
{
    internal abstract class BaseImageStorage : IDataStorage<IImageSource>
    {
        private const int MaxThumbnailDimension = 128;

        protected const string ThumbnailExtension = ".thumbnail";

        public abstract IImageSource Save(byte[] image, string extension = "", string path = "");

        public abstract bool Delete(string source);

        public abstract byte[] Retrieve(string source);

        protected static byte[] GetThumbnail(byte[] image, int maxDimension = MaxThumbnailDimension)
        {
            if (image == null || image.Length <= 0)
            {
                Trace.TraceWarning("Cannot create thumbnail image from empty byte array.");
                return new byte[0];
            }

            var inputMemoryStream = new MemoryStream(image);
            var fullsizeImage = Image.FromStream(inputMemoryStream);

            double thumbnailWidth;
            double thumbnailHeight;

            if (fullsizeImage.Width > fullsizeImage.Height)
            {
                thumbnailWidth = maxDimension;
                thumbnailHeight = maxDimension * (fullsizeImage.Height / (double)fullsizeImage.Width);
            }
            else
            {
                thumbnailWidth = maxDimension * (fullsizeImage.Width / (double)fullsizeImage.Height);
                thumbnailHeight = maxDimension;
            }

            var thumbnail = fullsizeImage.GetThumbnailImage((int)thumbnailWidth, (int)thumbnailHeight, () => false, IntPtr.Zero);

            using (var resultStream = new MemoryStream())
            {
                thumbnail.Save(resultStream, fullsizeImage.RawFormat);

                return resultStream.ToArray();
            }
        }

        protected static string GetThumbnailName(string source)
        {
            return string.Format("{0}{1}", source, ThumbnailExtension);
        }

        protected static ImageSource GetImageSourceFromSource(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;

            var sourceFile = "";
            var thumbnailFile = "";

            if (key.Contains(ThumbnailExtension))
            {
                thumbnailFile = key;
                sourceFile = thumbnailFile.Replace(ThumbnailExtension, string.Empty);
            }
            else
            {
                sourceFile = key;
                thumbnailFile = string.Concat(sourceFile, ThumbnailExtension);
            }

            return new ImageSource {Source = sourceFile, Thumbnail = thumbnailFile};
        }
    }
}
