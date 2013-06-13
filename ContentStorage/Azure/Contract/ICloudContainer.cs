namespace ContentStorage.Azure.Contract
{
    internal interface ICloudContainer
    {
        ICloudBlockBlob GetBlockBlobReference(string source);
    }
}