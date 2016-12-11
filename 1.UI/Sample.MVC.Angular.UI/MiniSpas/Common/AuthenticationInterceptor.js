var Common;
(function (Common) {
    var Interceptors;
    (function (Interceptors) {
        var AuthenticationInterceptor = (function () {
            function AuthenticationInterceptor(injectorService, qService, localStorageService, locationService, logService) {
                var _this = this;
                this.injectorService = injectorService;
                this.qService = qService;
                this.localStorageService = localStorageService;
                this.locationService = locationService;
                this.logService = logService;
                this.request = function (config) {
                    config.headers = config.headers || {};
                    var authData = _this.localStorageService.get('authorizationData');
                    if (authData) {
                        config.headers.Authorization = 'Bearer ' + authData.Token;
                    }
                    return config;
                };
                this.requestError = function (requestFailure) {
                    _this.logService.log("requestError reported");
                    if (requestFailure.status === 401) {
                        var authService = _this.injectorService.get('authService');
                        var authData = _this.localStorageService.get('authorizationData');
                        if (authData) {
                            if (authData.UseRefreshTokens) {
                                _this.locationService.path('/refresh');
                                return _this.qService.reject(requestFailure);
                            }
                        }
                        authService.LogOut();
                        _this.locationService.path('/login');
                    }
                    return _this.qService.reject(requestFailure);
                };
                this.response = function (responseSuccess) {
                    _this.logService.log("success response reported with status: " + responseSuccess.status);
                    console.log("response: ", responseSuccess);
                    return responseSuccess;
                };
                this.responseError = function (responseFailure) {
                    _this.logService.log("response Error reported");
                    if (responseFailure.status === 401) {
                        console.log("401 error");
                    }
                    return _this.qService.reject(responseFailure);
                };
                logService.log("initializing AuthenticationInterceptor");
            }
            AuthenticationInterceptor.Factory = function ($injector, $q, localStorageService, $location, $log) {
                return new AuthenticationInterceptor($injector, $q, localStorageService, $location, $log);
            };
            AuthenticationInterceptor.$inject = ["$injector", "$q", "localStorageService", "$location", "$log"];
            return AuthenticationInterceptor;
        }());
        Interceptors.AuthenticationInterceptor = AuthenticationInterceptor;
    })(Interceptors = Common.Interceptors || (Common.Interceptors = {}));
})(Common || (Common = {}));
//# sourceMappingURL=AuthenticationInterceptor.js.map