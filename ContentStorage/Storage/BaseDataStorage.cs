using ContentStorage.Contract;

namespace ContentStorage.Storage
{
    internal abstract class BaseDataStorage<TDataSource> : IDataStorage<TDataSource> where TDataSource : IDataSource
    {
        public abstract TDataSource Save(byte[] data, string extension = "", string key = "");
        
        public abstract bool Delete(string source);
        
        public abstract byte[] Retrieve(string source);
    }
}
