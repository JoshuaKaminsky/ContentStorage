using System;
using System.IO;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ContentStorage.Azure.Contract
{
    internal interface ICloudBlockBlob
    {
        Uri Uri { get; }

        void SetBlockBlob(CloudBlockBlob blob);

        void SetContentType(string contentType);

        void UploadFromStream(Stream stream);

        void DownloadToStream(Stream stream);

        bool DeleteIfExists();
    }
}