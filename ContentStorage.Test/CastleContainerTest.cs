using System.Linq;
using Castle.Windsor;
using ContentStorage.Bootstrap.CastleWindsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentStorage.Test
{
    [TestClass]
    [DeploymentItem("castle.config.xml")]
    [DeploymentItem("contentStorage.config")]
    public class CastleContainerTest
    {
        private readonly WindsorContainer _container;

        public CastleContainerTest()
        {
            _container = new WindsorContainer();

            _container.Install(new StorageInstaller());
        }

        [TestMethod]
        public void ContainerShouldResolveAllReferences()
        {
            var registrations = _container.Kernel.GetAssignableHandlers(typeof (object));

            foreach (var registration in registrations)
            {
                var service = registration.ComponentModel.Services.First();

                object result;

                if (string.IsNullOrWhiteSpace(registration.ComponentModel.Name))
                {
                    result = _container.Resolve(service);
                }
                else
                {
                    result = _container.Resolve(registration.ComponentModel.Name, service);
                }

                Assert.IsNotNull(result);
                Assert.IsTrue(registration.ComponentModel.Implementation.IsInstanceOfType(result));
            }
        }
    }
}
