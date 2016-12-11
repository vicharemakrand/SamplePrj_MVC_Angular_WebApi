var UserProfileModule;
(function (UserProfileModule) {
    var Services;
    (function (Services) {
        var UserProfileService = (function () {
            function UserProfileService($http, $q) {
                this.httpService = $http;
                this.qService = $q;
            }
            UserProfileService.prototype.GetProfileList = function () {
                return this.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/values');
            };
            UserProfileService.prototype.SignUp = function (registration) {
                var self = this;
                return self.httpService.post(Common.AppConstants.BaseWebApiUrl + '/api/Account/Register', registration)
                    .then(function (response) {
                    return response;
                }).catch(function (response) {
                    return response;
                });
            };
            UserProfileService.$inject = ["$http", "$q"];
            UserProfileService.GetInstance = function () {
                var instance = function ($http, $q) { return new UserProfileService($http, $q); };
                return instance;
            };
            return UserProfileService;
        }());
        Services.UserProfileService = UserProfileService;
        MiniSpas.ModuleInitiator.GetModule("UserProfileModule").service("UserProfileModule.Services.UserProfileService", UserProfileService);
    })(Services = UserProfileModule.Services || (UserProfileModule.Services = {}));
})(UserProfileModule || (UserProfileModule = {}));
//# sourceMappingURL=UserProfileService.js.map