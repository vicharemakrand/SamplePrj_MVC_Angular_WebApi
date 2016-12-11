module SearchProfileModule
{
    export class SearchProfileSpaRoutes
    {
        static $inject = ["$routeProvider"];
        static configureRoutes( $routeProvider: ng.route.IRouteProvider )
        {
            $routeProvider
                    .when( "/",
                            {
                                controller: "SearchProfileModule.Controllers.SearchProfileController",
                                templateUrl: "/MiniSpas/SearchProfileSpa/Views/search.html",
                                controllerAs: "searchProfileCtrl"
                            }
                   );
            $routeProvider.otherwise( { redirectTo: "/" });
        }
    }
}