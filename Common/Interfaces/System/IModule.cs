using Microsoft.Practices.Unity;

namespace Common
{
    public interface IModule
    {
        void RegisterDependencies(IUnityContainer container);
    }
}
