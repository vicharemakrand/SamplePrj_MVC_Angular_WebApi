module UserProfileModule
{
    export class UserProfileSpaRoutes
    {
        static $inject = ["$routeProvider"];
        static configureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                .when( "/",
                            {
                                controller: "UserProfileModule.Controllers.UserProfileController",
                                templateUrl: "/MiniSpas/UserProfileSpa/Views/userProfile.cshtml",
                                controllerAs: "userprofileCtrl"
                            }
                   )
                .when( "/uploadphoto",
                {
                    controller: "UserProfileModule.Controllers.UserProfileController",
                    templateUrl: "/MiniSpas/UserProfileSpa/Views/uploadphoto.cshtml",
                    controllerAs: "uploadphotoCtrl"
                }
                );
            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}