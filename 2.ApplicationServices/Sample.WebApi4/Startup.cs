using Sample.IDomainServices.AutoMapper;
using Sample.WebApi4.DependencyResolution;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(Sample.WebApi4.Startup))]

namespace Sample.WebApi4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);

            var config = new HttpConfiguration();
            config.DependencyResolver = new StructureMapWebApiDependencyResolver(StructuremapMvc.StructureMapDependencyScope.Container);
            WebApiConfig.Register(config);

            app.UseWebApi(config);
         }
    }
}
