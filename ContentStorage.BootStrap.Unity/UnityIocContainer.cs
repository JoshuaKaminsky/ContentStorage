using ContentStorage.IoC.Contract;
using Microsoft.Practices.Unity;

namespace ContentStorage.BootStrap.Unity
{
    public class UnityIocContainer : IIocContainer
    {
        private UnityContainer _container;

        public void Register()
        {
            _container = new UnityContainer();
            
            _container.AddExtension(new StorageContainer());
        }

        public T Resolve<T>(string named = "")
        {
            return (string.IsNullOrWhiteSpace(named)) ? _container.Resolve<T>() : _container.Resolve<T>(named);
        }
    }
}
