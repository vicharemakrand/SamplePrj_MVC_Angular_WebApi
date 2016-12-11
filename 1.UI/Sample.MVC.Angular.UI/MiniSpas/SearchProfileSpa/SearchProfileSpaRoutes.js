var SearchProfileModule;
(function (SearchProfileModule) {
    var SearchProfileSpaRoutes = (function () {
        function SearchProfileSpaRoutes() {
        }
        SearchProfileSpaRoutes.configureRoutes = function ($routeProvider) {
            $routeProvider
                .when("/", {
                controller: "SearchProfileModule.Controllers.SearchProfileController",
                templateUrl: "/MiniSpas/SearchProfileSpa/Views/search.html",
                controllerAs: "searchProfileCtrl"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        };
        SearchProfileSpaRoutes.$inject = ["$routeProvider"];
        return SearchProfileSpaRoutes;
    }());
    SearchProfileModule.SearchProfileSpaRoutes = SearchProfileSpaRoutes;
})(SearchProfileModule || (SearchProfileModule = {}));
//# sourceMappingURL=SearchProfileSpaRoutes.js.map