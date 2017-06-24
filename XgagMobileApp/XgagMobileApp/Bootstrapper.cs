using System;
using Microsoft.Practices.Unity;
using Common;

namespace XgagMobileApp
{
    internal class Bootstrapper
    {
        public IUnityContainer Container { get; set; }

        public Bootstrapper()
        {
            Container = new UnityContainer();
        }

        public void Init()
        {
            RegisterDependencies();
            RegisterModules();
        }

        private void RegisterModules()
        {
            RegisterModule<ServiceLayer.Module>();
        }

        private void RegisterDependencies()
        {
            //Register stuff.
        }

        private void RegisterModule<T>()
            where T : IModule
        {
            var module = Container.Resolve<T>();
            module.RegisterDependencies(Container);
        }
    }
}
