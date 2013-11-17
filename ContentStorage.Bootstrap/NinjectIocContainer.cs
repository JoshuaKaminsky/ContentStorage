using ContentStorage.IoC.Contract;
using Ninject;

namespace ContentStorage.Bootstrap.Ninject
{
    public class NinjectIocContainer : IIocContainer
    {
        private StandardKernel _kernel;

        public void Register()
        {
            _kernel = new StandardKernel(new StorageModule());
        }

        public T Resolve<T>(string named = "")
        {
            return string.IsNullOrWhiteSpace(named) ? _kernel.TryGet<T>() : _kernel.TryGet<T>(named);
        }
    }
}
