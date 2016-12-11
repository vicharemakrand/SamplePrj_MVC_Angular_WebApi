/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
(function () {
    var useProfileModule = MiniSpas.ModuleInitiator.GetModule("UserProfileModule");
    useProfileModule.config(UserProfileModule.UserProfileSpaRoutes.configureRoutes);
    useProfileModule.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
        $httpProvider.interceptors.push(Common.Interceptors.AuthenticationInterceptor.Factory);
    });
    useProfileModule.run(['HomeModule.Services.AuthService', function (authService) {
            authService.GetAuthData();
        }]);
})();
//# sourceMappingURL=UserProfileSpaApp.js.map