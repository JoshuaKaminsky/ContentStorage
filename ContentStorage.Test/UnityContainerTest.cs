using ContentStorage.BootStrap.Unity;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentStorage.Test
{
    [TestClass]
    [DeploymentItem("unity.config.xml")]
    [DeploymentItem("contentStorage.config")]
    public class UnityContainerTest
    {
        private readonly UnityContainer _container;

        public UnityContainerTest()
        {
            _container = new UnityContainer();
            _container.AddExtension(new StorageContainer());
        }

        [TestMethod]
        public void ContainerShouldResolveAllReferences()
        {
            _container.Registrations.ForEach(registration =>
                {
                    object result;

                    if (string.IsNullOrWhiteSpace(registration.Name))
                    {
                        result = _container.Resolve(registration.RegisteredType);
                    }
                    else
                    {
                        result = _container.Resolve(registration.RegisteredType, registration.Name);
                    }

                    Assert.IsNotNull(result);
                    Assert.IsTrue(registration.MappedToType.IsInstanceOfType(result));
                });
        }
    }
}
