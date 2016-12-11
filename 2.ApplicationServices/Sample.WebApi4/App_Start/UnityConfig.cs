using Sample.Common.MEF;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Sample.WebApi4
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            RegisterTypes(container);
            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<ISecureDataFormat<AuthenticationTicket>, SecureDataFormat<AuthenticationTicket>>();
            container.RegisterType<IDataSerializer<AuthenticationTicket>,TicketSerializer>();
            container.RegisterType<ITextEncoder,Base64UrlTextEncoder>();
            container.RegisterType<IDataProtector>(new InjectionFactory(c => new DpapiDataProtectionProvider().Create("ASP.NET Identity")));
            UnityModuleLoader.LoadContainer(container, ".\\bin", "Sample.*.dll");

        }
    }
}