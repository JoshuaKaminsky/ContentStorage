using Castle.Windsor;
using ContentStorage.IoC.Contract;

namespace ContentStorage.Bootstrap.CastleWindsor
{
    public class CastleIocContainer : IIocContainer
    {
        private WindsorContainer _container;

        public void Register()
        {
            _container = new WindsorContainer();

            _container.Install(new StorageInstaller());
        }

        public T Resolve<T>(string named = "")
        {
            return string.IsNullOrWhiteSpace(named) ? _container.Resolve<T>() : _container.Resolve<T>(named);
        }
    }
}
