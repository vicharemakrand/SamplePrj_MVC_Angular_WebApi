using Sample.Common.MEF;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.WebApi4
{
    public static class StructureMapConfig
    {
        public static IContainer RegisterComponents()
        {
            var container = BuildContainer();

            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IContainer BuildContainer()
        {
            var container = new Container();

            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IContainer container)
        {
            //container.RegisterType<IUserData, UserData>();
            //container.RegisterType<IUserDomain, UserDomain>();

            //Module initialization thru MEF
            StructureMapModuleLoader.LoadContainer(container, ".\\bin", "Sample.*.dll");
        }

        public static IContainer RegisterComponents(IContainer container)
        {
            RegisterTypes(container);

            return container;
        }

    }
}