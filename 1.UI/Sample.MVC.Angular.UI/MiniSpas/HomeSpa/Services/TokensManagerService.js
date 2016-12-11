var HomeModule;
(function (HomeModule) {
    var Services;
    (function (Services) {
        var TokensManagerService = (function () {
            function TokensManagerService($http, $q) {
                var _this = this;
                this.GetRefreshTokens = function () {
                    return _this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/refreshtokens')
                        .then(function (response) {
                        return response;
                    })
                        .catch(function (response) {
                        return response;
                    });
                };
                this.DeleteRefreshTokens = function (tokenid) {
                    return _this.httpService.delete(Common.AppConstants.BaseWebApiUrl + '/api/refreshtokens/?tokenid=' + tokenid)
                        .then(function (response) {
                        return response;
                    })
                        .catch(function (response) {
                        return response;
                    });
                };
                this.httpService = $http;
                this.qService = $q;
            }
            TokensManagerService.getInstance = function () {
                var instance = function ($http, $q) { return new TokensManagerService($http, $q); };
                return instance;
            };
            TokensManagerService.$inject = ["$http", "$q"];
            return TokensManagerService;
        }());
        Services.TokensManagerService = TokensManagerService;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").service("HomeModule.Services.TokensManagerService", TokensManagerService);
    })(Services = HomeModule.Services || (HomeModule.Services = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=TokensManagerService.js.map