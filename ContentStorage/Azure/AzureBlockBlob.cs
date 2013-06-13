using System;
using System.IO;
using ContentStorage.Azure.Contract;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ContentStorage.Azure
{
    internal class AzureBlockBlob : ICloudBlockBlob
    {
        private CloudBlockBlob _blob;

        public Uri Uri
        {
            get { return _blob.Uri; }
        }

        public void SetBlockBlob(CloudBlockBlob blob)
        {
            _blob = blob;
        }

        public void SetContentType(string contentType)
        {
            _blob.Properties.ContentType = contentType;
        }

        public void UploadFromStream(Stream stream)
        {
            _blob.UploadFromStream(stream);
        }

        public void DownloadToStream(Stream stream)
        {
            _blob.DownloadToStream(stream);
        }

        public bool DeleteIfExists()
        {
            return _blob.DeleteIfExists();
        }
    }
}
