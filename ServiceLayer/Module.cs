using System;
using Common;
using Microsoft.Practices.Unity;

namespace ServiceLayer
{
    public class Module : IModule
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterType<PostsProxy>(
                new InjectionConstructor(
                    new InjectionParameter<string>("posts")));
            container.RegisterType<IPostsProxy, PostsProxy>();
        }
    }
}
