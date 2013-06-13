using ContentStorage.Contract;

namespace ContentStorage.Storage
{
    internal class ImageSource : DataSource, IImageSource
    {
        public string Thumbnail { get; set; }
    }
}
