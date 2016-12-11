var HomeModule;
(function (HomeModule) {
    var HomeSpaRoutes = (function () {
        function HomeSpaRoutes() {
        }
        HomeSpaRoutes.ConfigureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "HomeModule.Controllers.HomeController",
                templateUrl: "/MiniSpas/HomeSpa/Views/home.html",
                controllerAs: "homeCtrl"
            })
                .when("/home", {
                controller: "HomeModule.Controllers.HomeController",
                templateUrl: "/MiniSpas/HomeSpa/Views/home.html",
                controllerAs: "homeCtrl"
            })
                .when("/login", {
                controller: "HomeModule.Controllers.LoginController",
                templateUrl: "/MiniSpas/HomeSpa/Views/login.html",
                controllerAs: "loginCtrl"
            })
                .when("/signup", {
                controller: "HomeModule.Controllers.SignupController",
                templateUrl: "/MiniSpas/HomeSpa/Views/signup.html",
                controllerAs: "signupCtrl"
            })
                .when("/verifyexternallogin", {
                controller: "HomeModule.Controllers.LoginController",
                templateUrl: "/MiniSpas/HomeSpa/Views/verifyexternallogin.html",
                controllerAs: "loginCtrl"
            })
                .when("/redirector", {
                controller: "HomeModule.Controllers.LoginController",
                templateUrl: "/MiniSpas/HomeSpa/Views/redirector.html",
                controllerAs: "loginCtrl"
            })
                .when("/associate", {
                controller: "HomeModule.Controllers.AssociateController",
                templateUrl: "/MiniSpas/HomeSpa/Views/associate.html",
                controllerAs: "associateCtrl"
            })
                .when("/refresh", {
                controller: "HomeModule.Controllers.RefreshController",
                templateUrl: "/MiniSpas/HomeSpa/Views/refresh.html",
                controllerAs: "refreshCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        HomeSpaRoutes.$inject = ["$routeProvider"];
        return HomeSpaRoutes;
    }());
    HomeModule.HomeSpaRoutes = HomeSpaRoutes;
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=HomeSpaRoutes.js.map