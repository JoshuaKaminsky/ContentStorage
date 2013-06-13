using System;
using System.Linq;
using System.Reflection;
using ContentStorage.Bootstrap.Ninject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Extensions.Xml;
using Ninject.Infrastructure;
using Ninject.Planning.Bindings;

namespace ContentStorage.Test
{
    [TestClass]
    [DeploymentItem("ninject.config.xml")]
    [DeploymentItem("contentStorage.config")]
    public class NinjectContainerTest
    {
        private readonly StandardKernel _kernel;

        public NinjectContainerTest()
        {
            _kernel = new StandardKernel(new NinjectSettings {LoadExtensions = false}, new XmlExtensionModule(), new StorageModule());
        }

        [TestMethod]
        public void ContainerShouldResolveAllReferences()
        {
            var baseKernel = (KernelBase)_kernel;

            var field = typeof(KernelBase).GetField("bindings", BindingFlags.Instance | BindingFlags.NonPublic);

            var bindingsMap = (Multimap<Type, IBinding>)field.GetValue(baseKernel);

            var bindings = bindingsMap.SelectMany(map => map.Value).ToList();

            bindings.ForEach(binding =>
                {
                    object result;
                    if (string.IsNullOrWhiteSpace(binding.Metadata.Name))
                    {
                        result = _kernel.TryGet(binding.Service);
                    }
                    else
                    {
                        result = _kernel.TryGet(binding.Service, binding.Metadata.Name);
                    }

                    Assert.IsNotNull(result);
                });
        }
    }
}
