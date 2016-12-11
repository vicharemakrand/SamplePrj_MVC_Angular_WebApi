/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var searchProfileModule = MiniSpas.ModuleInitiator.GetModule("SearchProfileModule");
    searchProfileModule.config(SearchProfileModule.SearchProfileSpaRoutes.configureRoutes);
    searchProfileModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    searchProfileModule.run(['HomeModule.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=SearchProfileSpaApp.js.map