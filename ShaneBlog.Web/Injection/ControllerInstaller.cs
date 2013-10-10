using System.Web.Mvc;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ShaneBlog.Web
{
    internal class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.AddHandlersFilter(new ControllerResolver());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<Controller>()
                .Configure(x => x.LifestylePerWebRequest()));
        }
    }
}
