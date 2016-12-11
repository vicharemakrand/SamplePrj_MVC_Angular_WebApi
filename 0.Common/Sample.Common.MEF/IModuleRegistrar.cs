using System;

namespace Sample.Common.MEF
{
    /// <summary>
    /// Allows objects implementing IModule to register types in unity.
    /// </summary>
    public interface IModuleRegistrar
    {
        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        void RegisterType<TFrom, TTo>(string constructorPram) where TTo : TFrom;
        void RegisterTypeInstanceSingleton<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        void RegisterInstanceSingleton(Type tFrom, object instance);
        void RegisterTypeInstancePerHttpRequest<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        void RegisterType(Type type1, Type type2);
    }
}
