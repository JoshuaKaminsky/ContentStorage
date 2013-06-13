using Autofac;
using ContentStorage.Bootstrap.Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentStorage.Test
{
    [TestClass]
    [DeploymentItem("autofac.config.xml")]
    [DeploymentItem("contentStorage.config")]
    public class AutofacContainerTest
    {
        private readonly IContainer _container;

        public AutofacContainerTest()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterModule(new StorageModule());
            _container = builder.Build();
        }

        [TestMethod]
        public void ContainerShouldResolveAllReferences()
        {
            //_container.ComponentRegistry.Registrations.ForEach(registration =>
            //    {
            //        if(string.IsNullOrWhiteSpace(registration))

            //    });

            //foreach (var service in services)
            //{
            //    var serviceName = service.ToString();
            //    if(!serviceName.Contains("Hmb"))
            //        continue;
                
            //    var serviceType = Type.GetType(service.ToString());
            //    var result = _container.Resolve(serviceType);

            //    Assert.IsNotNull(result);
            //}
        }
    }
}
