/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

( (): void =>
{
    var useProfileModule = MiniSpas.ModuleInitiator.GetModule( "UserProfileModule" );
    useProfileModule.config( UserProfileModule.UserProfileSpaRoutes.configureRoutes );

    useProfileModule.config( function ( $httpProvider: ng.IHttpProvider )
    {
         $httpProvider.defaults.withCredentials = true;
         $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    useProfileModule.run(['HomeModule.Services.AuthService', function ( authService: HomeModule.Services.AuthService )
    {
        authService.GetAuthData();
    }] );
})();