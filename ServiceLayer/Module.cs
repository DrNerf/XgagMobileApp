using System;
using Common;
using Microsoft.Practices.Unity;

namespace ServiceLayer
{
    public class Module : IModule
    {
        public void RegisterDependencies(IUnityContainer container)
        {
            container.RegisterInstance<IUserSessionModel>(new UserSessionModel());

            container.RegisterType<PostsProxy>();
            container.RegisterType<IPostsProxy, PostsProxy>();

            container.RegisterType<AuthenticationProxy>();
            container.RegisterType<IAuthenticationProxy, AuthenticationProxy>();
        }
    }
}
