module MiniSpas
{
    export class ModuleInitiator
    {
        static modulesList = [
            { name: 'MiniSpas', dependencies: Array<string>() },
            { name: 'Common', dependencies: Array<string>() },
            { name: 'UserProfileModule', dependencies: Array<string>( "ngRoute","HomeModule", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies") },
            { name: 'HomeModule', dependencies: Array<string>( "ngRoute", "UserProfileModule", "Common", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies" ) },
            { name: 'SearchProfileModule', dependencies: Array<string>( "ngRoute", "HomeModule", "Common", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies" ) },
            { name: 'PaymentModule', dependencies: Array<string>( "ngRoute", "angular-loading-bar", "ngMessages", "ngCookies") }
        ];

        static GetModule( moduleName: string ): ng.IModule
        {
            try
            {
               return angular.module( moduleName );
            } catch (error)
            {
                var dependencies = this.modulesList.filter( o => o.name == moduleName ).shift().dependencies;
                return angular.module( moduleName, dependencies );
            }
        };
    }

    MiniSpas.ModuleInitiator.GetModule("MiniSpas").service( "MiniSpas.ModuleInitiator", ModuleInitiator );
}