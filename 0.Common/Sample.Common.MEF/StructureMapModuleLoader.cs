using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sample.Common.MEF
{
    public static class StructureMapModuleLoader
    {
        public static void LoadContainer(StructureMap.IContainer container, string path, string pattern)
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

                        var registrar = new StructureMapModuleRegistrar(container);
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

    internal class StructureMapModuleRegistrar : IModuleRegistrar
    {
        private readonly StructureMap.IContainer _container;

        public StructureMapModuleRegistrar(StructureMap.IContainer container)
        {
            this._container = container;
            //Register interception behaviour if any
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            { 
                //register with interception 
            }
            else
            {
                this._container.Configure(
                    registry =>
                    {
                        registry.For<TFrom>().Use<TTo>();
                    }
                );
            }
        }

        public void RegisterType<TFrom, TTo>(string arguments = "") where TTo : TFrom
        {
            if (!string.IsNullOrWhiteSpace(arguments))
            {
                this._container.Configure(
                    registry =>
                    {
                        registry.For<TFrom>().Use<TTo>().Ctor<string>(arguments);
                    }
                );
            }
        }

        public void RegisterTypeInstanceSingleton<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this._container.Configure(
                    registry =>
                    {
                        registry.For<TFrom>().Use<TTo>().Singleton();
                    }
                );
        }

        public void RegisterInstanceSingleton(Type tFrom, object instance)
        {
            this._container.Configure(
                    registry =>
                    {
                        registry.For(tFrom).Use(instance).Singleton();
                    }
                );
        }

        public void RegisterTypeInstancePerHttpRequest<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this._container.Configure(
                    registry =>
                    {
                        registry.For<TFrom>().Use<TTo>();
                    }
                );
        }

        public void RegisterType(Type tFrom, Type tTo)
        {
            this._container.Configure(
                    registry =>
                    {
                        registry.For(tFrom).Use(tTo);
                    }
                );
        }
    }
}
