using System.Reflection;
using Autofac;
using ContentStorage.IoC.Contract;

namespace ContentStorage.Bootstrap.Autofac
{
    public class AutoFacIocContainer : IIocContainer
    {
        private IContainer _container;

        public void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(Assembly.GetAssembly(typeof(AutoFacIocContainer)));

            _container = builder.Build();
        }

        public T Resolve<T>(string named = "")
        {
            return string.IsNullOrWhiteSpace(named) ? _container.Resolve<T>() : _container.ResolveNamed<T>(named);
        }
    }
}
