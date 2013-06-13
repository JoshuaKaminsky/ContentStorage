using System;
using System.IO;
using System.Diagnostics;
using ContentStorage.Configuration.Contract;
using ContentStorage.Contract;
using ContentStorage.IO.Contract;

namespace ContentStorage.Storage
{
    internal class FileSystemImageStorage : BaseImageStorage
    {
        private const string DefaultImageDirectory = @"Storage\Images\";

        private readonly IFileFunctions _fileFunctions;
        private readonly string _imageDirectory = DefaultImageDirectory;

        public FileSystemImageStorage(IFileStorageConfiguration configuration, IDirectoryFunctions directoryFunctions, IFileFunctions fileFunctions)
        {
            _fileFunctions = fileFunctions;

            var directory = (configuration != null && !string.IsNullOrWhiteSpace(configuration.StorageDirectory))
                                ? configuration.StorageDirectory
                                : DefaultImageDirectory;

            _imageDirectory = Path.Combine(Environment.CurrentDirectory, directory);

            if (!directoryFunctions.Exists(_imageDirectory))
            {
                try
                {
                    directoryFunctions.CreateDirectory(_imageDirectory);
                }
                catch (Exception exception)
                {
                    Trace.TraceError("Could not create image storage directory {0}. {1}", _imageDirectory, exception.Message);
                    Trace.TraceError(exception.ToString());
                }
            }
        }

        public override IImageSource Save(byte[] image, string extension = "", string path = "")
        {
            var directory = Path.Combine(_imageDirectory, path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var fileName = Path.Combine(directory, Path.GetRandomFileName());
            var thumbnailFileName = GetThumbnailName(fileName);
           
            _fileFunctions.Write(fileName, image);

            _fileFunctions.Write(thumbnailFileName, GetThumbnail(image));

            return new ImageSource { Source = fileName, Thumbnail = thumbnailFileName };
        }

        public override bool Delete(string source)
        {
            var imageSource = GetImageSourceFromSource(source);
            if (imageSource == null)
                return true;

            return _fileFunctions.DeleteIfExists(imageSource.Source) &&
                   _fileFunctions.DeleteIfExists(imageSource.Thumbnail);
        }

        public override byte[] Retrieve(string source)
        {
            return _fileFunctions.Read(source);
        }
    }
}
