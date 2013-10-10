using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel;

namespace ShaneBlog.Web.Injection
{
    public class ControllerResolver : IHandlersFilter
    {
        public bool HasOpinionAbout(Type service)
        {
            return service == typeof(IController);
        }

        public IHandler[] SelectHandlers(Type service, IHandler[] handlers)
        {
            return handlers;
        }
    }
}
