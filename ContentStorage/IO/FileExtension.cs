namespace ContentStorage.IO
{
    internal class FileExtension
    {
        private readonly string _extension = string.Empty;

        public FileExtension(string extension)
        {
            _extension = extension;
        }

        public string Value { get { return _extension; } }
    }
}
