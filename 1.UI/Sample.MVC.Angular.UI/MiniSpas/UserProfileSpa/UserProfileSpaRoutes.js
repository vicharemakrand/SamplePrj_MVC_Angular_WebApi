var UserProfileModule;
(function (UserProfileModule) {
    var UserProfileSpaRoutes = (function () {
        function UserProfileSpaRoutes() {
        }
        UserProfileSpaRoutes.configureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "UserProfileModule.Controllers.UserProfileController",
                templateUrl: "/MiniSpas/UserProfileSpa/Views/userProfile.cshtml",
                controllerAs: "userprofileCtrl"
            })
                .when("/uploadphoto", {
                controller: "UserProfileModule.Controllers.UserProfileController",
                templateUrl: "/MiniSpas/UserProfileSpa/Views/uploadphoto.cshtml",
                controllerAs: "uploadphotoCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        UserProfileSpaRoutes.$inject = ["$routeProvider"];
        return UserProfileSpaRoutes;
    }());
    UserProfileModule.UserProfileSpaRoutes = UserProfileSpaRoutes;
})(UserProfileModule || (UserProfileModule = {}));
//# sourceMappingURL=UserProfileSpaRoutes.js.map