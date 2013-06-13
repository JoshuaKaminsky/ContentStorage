using System;
using System.Linq;
using ContentStorage.BootStrap.Unity;
using ContentStorage.Bootstrap.Autofac;
using ContentStorage.Bootstrap.CastleWindsor;
using ContentStorage.Bootstrap.Ninject;
using ContentStorage.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentStorage.Test
{
    [TestClass]
    public class IocContainerUnitTest
    {
        [TestMethod]
        public void AutoFacShouldRetrieveAllImageStorageInterfaces()
        {
            var container = new AutoFacIocContainer();

            container.Register();

            foreach (var imageStorage in Enum.GetNames(typeof(DataStorageType)).Select(container.Resolve<IDataStorage<IImageSource>>))
            {
                Assert.IsNotNull(imageStorage);
            }
        }

        [TestMethod]
        public void CastleShouldRetrieveAllImageStorageInterfaces()
        {
            var container = new CastleIocContainer();

            container.Register();

            foreach (var imageStorage in Enum.GetNames(typeof(DataStorageType)).Select(container.Resolve<IDataStorage<IImageSource>>))
            {
                Assert.IsNotNull(imageStorage);
            }
        }

        [TestMethod]
        public void NinjectShouldRetrieveAllImageStorageInterfaces()
        {
            var container = new NinjectIocContainer();

            container.Register();

            foreach (var imageStorage in Enum.GetNames(typeof(DataStorageType)).Select(container.Resolve<IDataStorage<IImageSource>>))
            {
                Assert.IsNotNull(imageStorage);
            }
        }

        [TestMethod]
        public void UnityShouldRetrieveAllImageStorageInterfaces()
        {
            var container = new UnityIocContainer();

            container.Register();

            foreach (var imageStorage in Enum.GetNames(typeof(DataStorageType)).Select(container.Resolve<IDataStorage<IImageSource>>))
            {
                Assert.IsNotNull(imageStorage);
            }
        }
    }
}
