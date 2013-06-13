using ContentStorage.Contract;
using ContentStorage.IoC.Contract;

namespace ContentStorage
{
    public class StorageFactory<TDataSource> : IStorageFactory<TDataSource> where TDataSource : IDataSource
    {
        private readonly IIocContainer _container;

        public StorageFactory(IIocContainer container)
        {
            _container = container;

            _container.Register();
        }

        public IDataStorage<TDataSource> Resolve(DataStorageType dataStorageType)
        {
            return _container.Resolve<IDataStorage<TDataSource>>(named: dataStorageType.ToString());
        }
    }
}
