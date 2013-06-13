using System.IO;

namespace ContentStorage.Amazon.Contract
{
    internal interface IS3Client
    {
        string PutRequest(string key, Stream data, string contentType);

        bool DeleteRequest(string source);

        byte[] RetrieveRequest(string source);
    }
}