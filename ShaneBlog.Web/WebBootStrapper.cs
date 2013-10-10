using System.Web.Mvc;
using Castle.Windsor;
using ShaneBlog.Web.Injection;

namespace ShaneBlog.Web
{
    public class WebBootStrapper
    {
        public void Run()
        {


            var windsor = new WindsorContainer()
                   .Install(new ControllerInstaller());

            var controllerFactory = new ControllerFactory(windsor.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }
    }
}