using Funq;
using ServiceStack.Mvc;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using ServiceStack.WebHost.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSWMVC.App_Start
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("MVC 4", typeof(MyServices).Assembly) { }

        public override void Configure(Container container)
        {
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
            SetConfig(new EndpointHostConfig
            {
                //This is needed since you will be hosting your services from /api
                ServiceStackHandlerFactoryPath = "api"
            });
        }
    }

    [Route("/hello/{Name}")]
    public class Hello
    {
        public string Name { get; set; }
    }

    public class MyServices : Service
    {
        public object Any(Hello request)
        {
            return request;
        }
    }
}