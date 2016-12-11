var SearchProfileModule;
(function (SearchProfileModule) {
    var Services;
    (function (Services) {
        var SearchProfileService = (function () {
            function SearchProfileService(httpService) {
                this.httpService = httpService;
            }
            SearchProfileService.prototype.GetProfiles = function () {
                return this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/Profile/GetProfiles');
            };
            SearchProfileService.$inject = ["$http"];
            SearchProfileService.GetInstance = function () {
                var instance = function ($http) { return new SearchProfileService($http); };
                return instance;
            };
            return SearchProfileService;
        }());
        Services.SearchProfileService = SearchProfileService;
        MiniSpas.ModuleInitiator.GetModule("SearchProfileModule").service("SearchProfileModule.Services.SearchProfileService", SearchProfileService);
    })(Services = SearchProfileModule.Services || (SearchProfileModule.Services = {}));
})(SearchProfileModule || (SearchProfileModule = {}));
//# sourceMappingURL=SearchProfileService.js.map