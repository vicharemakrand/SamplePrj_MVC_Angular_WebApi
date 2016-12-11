/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

( (): void =>
{
    var searchProfileModule = MiniSpas.ModuleInitiator.GetModule( "SearchProfileModule" );
    searchProfileModule.config( SearchProfileModule.SearchProfileSpaRoutes.configureRoutes );

    searchProfileModule.config(( $httpProvider: ng.IHttpProvider ) =>
    {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push( Common.Interceptors.AuthenticationInterceptor.Factory );
    });

    searchProfileModule.run( ['HomeModule.Services.AuthService', function ( authService: HomeModule.Services.AuthService )
    {
        authService.GetAuthData();
    }]);
})() 