using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace Sample.Common.MEF
{
    public static class UnityModuleLoader
    {
        public static void LoadContainer(IUnityContainer container, string path, string pattern)
        {
            var dirCat = new DirectoryCatalog(path, pattern);
            var importDef = BuildImportDefinition();
            try
            {
                using (var aggregateCatalog = new AggregateCatalog())
                {
                    aggregateCatalog.Catalogs.Add(dirCat);
                    
                    using (var componsitionContainer = new CompositionContainer(aggregateCatalog))
                    {
                        IEnumerable<Export> exports = componsitionContainer.GetExports(importDef);

                        IEnumerable<IModule> modules =
                            exports.Select(export => export.Value as IModule).Where(m => m != null);

                        var registrar = new UnityModuleRegistrar(container);
                        foreach (IModule module in modules)
                        {
                            module.Initialize(registrar);
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException typeLoadException)
            {
                var builder = new StringBuilder();
                foreach (Exception loaderException in typeLoadException.LoaderExceptions)
                {
                    builder.AppendFormat("{0}\n", loaderException.Message);
                }

                throw new TypeLoadException(builder.ToString(), typeLoadException);
            }
        }

        private static ImportDefinition BuildImportDefinition()
        {
            return new ImportDefinition(
                def => true, typeof(IModule).FullName, ImportCardinality.ZeroOrMore, false, false);
        }
    }

    internal class UnityModuleRegistrar : IModuleRegistrar
    {
        private readonly IUnityContainer _container;

        public UnityModuleRegistrar(IUnityContainer container)
        {
            this._container = container;
            //Register interception behaviour if any
        }

        public void RegisterType(Type tFrom, Type tTo)
        {
            this._container.RegisterType(tFrom, tTo);
        }

        public void RegisterType<TFrom, TTo>(string constructorPram = "") where TTo : TFrom
        {
            if (!string.IsNullOrWhiteSpace(constructorPram))
            {
                this._container.RegisterType<TFrom,TTo>(constructorPram);
            }
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            { 
                //register with interception 
            }
            else
            {
                this._container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeInstancePerHttpRequest<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            throw new NotImplementedException();
        }
        public void RegisterInstanceSingleton(Type tFrom, object instance)
        {
            this._container.RegisterInstance(tFrom, instance);
        }

        public void RegisterTypeInstanceSingleton<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            throw new NotImplementedException();
        }

    }
}
