/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

((): void =>
{
    var homeModule = MiniSpas.ModuleInitiator.GetModule( "HomeModule" );

    homeModule.config( HomeModule.HomeSpaRoutes.ConfigureRoutes );
    homeModule.config( ( $httpProvider: ng.IHttpProvider ) =>
    {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    homeModule.run( ['HomeModule.Services.AuthService', function ( authService: HomeModule.Services.AuthService )
    {
        authService.GetAuthData();
    }] );
})() 