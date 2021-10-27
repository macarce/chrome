using ChromeShape.Extensions;
using ChromeShape.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace ChromeShape.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            //HttpContext
            container.RegisterType<HttpContextBase>(new InjectionFactory(_ => new HttpContextWrapper(HttpContext.Current)));
            container.RegisterType<IShapeServices, ShapeServices>(new HierarchicalLifetimeManager());


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

            var providers = GlobalConfiguration.Configuration.Services.GetFilterProviders().ToList();
            var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            GlobalConfiguration.Configuration.Services.Remove(typeof(IFilterProvider), defaultprovider);
            GlobalConfiguration.Configuration.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(container));

        }
    }
}