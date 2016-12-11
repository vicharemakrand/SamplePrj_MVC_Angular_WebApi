var HomeModule;
(function (HomeModule) {
    var Services;
    (function (Services) {
        var AuthService = (function () {
            function AuthService($http, $q, _localStorageService) {
                var _this = this;
                this.useRefreshToken = false;
                this.isAuth = false;
                this.authVM = {
                    IsAuth: this.isAuth,
                    UseRefreshTokens: this.useRefreshToken,
                    UserName: ""
                };
                this.externalLoginVM = {
                    ExternalAccessToken: "",
                    UserName: "",
                    Provider: "",
                    Email: "",
                    AgeRange: 1,
                    AgeRangeList: Common.AppConstants.AgeRangeList
                };
                this.Login = function (loginData) {
                    var self = _this;
                    var data = "grant_type=password&username=" + loginData.UserName + "&password=" + loginData.Password;
                    if (loginData.UseRefreshTokens) {
                        data = data + "&client_id=" + Common.AppConstants.ClientId;
                    }
                    return self.httpService.post(Common.AppConstants.BaseWebApiUrl + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                        .then(function (response) {
                        if (loginData.UseRefreshTokens) {
                            self.localStorageService.set('authorizationData', {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: response.data.refresh_token,
                                UseRefreshTokens: !self.useRefreshToken
                            });
                        }
                        else {
                            self.localStorageService.set('authorizationData', {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: "",
                                UseRefreshTokens: self.useRefreshToken
                            });
                        }
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = loginData.UserName;
                        self.authVM.UseRefreshTokens = loginData.UseRefreshTokens;
                        return response;
                    }).catch(function (response) {
                        self.LogOut();
                        return response;
                    });
                };
                this.LogOut = function () {
                    var self = _this;
                    self.localStorageService.remove('authorizationData');
                    self.authVM.IsAuth = self.isAuth;
                    self.authVM.UserName = "";
                    self.authVM.UseRefreshTokens = !self.useRefreshToken;
                };
                this.GetAuthData = function () {
                    var self = _this;
                    var authData = self.localStorageService.get('authorizationData');
                    if (authData != null) {
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = authData.UserName;
                        self.authVM.UseRefreshTokens = authData.UseRefreshTokens;
                    }
                };
                this.GetFreshToken = function () {
                    var self = _this;
                    var authData = self.localStorageService.get('authorizationData');
                    if (authData) {
                        if (authData.UseRefreshTokens) {
                            var data = "grant_type=refresh_token&refresh_token=" + authData.RefreshToken + "&client_id=" + Common.AppConstants.ClientId;
                            self.localStorageService.remove('authorizationData');
                            return self.httpService.post(Common.AppConstants.BaseWebApiUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                                .then(function (response) {
                                self.localStorageService.set('authorizationData', {
                                    Token: response.data.access_token,
                                    UserName: response.data.userName,
                                    RefreshToken: response.data.refresh_token,
                                    UseRefreshTokens: self.useRefreshToken
                                });
                                return response;
                            })
                                .catch(function (response) {
                                self.LogOut();
                                return response;
                            });
                        }
                    }
                };
                this.GetAccessToken = function (externalData) {
                    var self = _this;
                    return self.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/Account/ObtainLocalAccessToken', {
                        params: {
                            provider: externalData.Provider,
                            externalAccessToken: externalData.ExternalAccessToken
                        }
                    })
                        .then(function (response) {
                        var authorizationVM = {
                            Token: response.data.access_token,
                            UserName: response.data.userName,
                            RefreshToken: "",
                            UseRefreshTokens: false
                        };
                        self.localStorageService.set('authorizationData', authorizationVM);
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = response.data.userName;
                        self.authVM.UseRefreshTokens = !self.useRefreshToken;
                        return response;
                    })
                        .catch(function (response) {
                        self.LogOut();
                        return response;
                    });
                };
                this.ExternalSignUp = function (registerExternalData) {
                    var self = _this;
                    return self.httpService.post(Common.AppConstants.BaseWebApiUrl + '/api/Account/registerexternal', registerExternalData)
                        .then(function (response) {
                        self.localStorageService.set('authorizationData', {
                            Token: response.data.access_token,
                            UserName: response.data.userName,
                            RefreshToken: "",
                            UseRefreshTokens: self.useRefreshToken
                        });
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = response.data.userName;
                        self.authVM.UseRefreshTokens = !self.useRefreshToken;
                        return response;
                    }).catch(function (response) {
                        self.LogOut();
                        return response;
                    });
                };
                this.GetAntiForgeryToken = function () {
                    var self = _this;
                    return self.httpService.get(Common.AppConstants.BaseWebApiUrl + '/api/RefreshTokens/antiforgerytoken')
                        .then(function (response) {
                        return response;
                    })
                        .catch(function (response) {
                        return response;
                    });
                };
                this.httpService = $http;
                this.qService = $q;
                this.localStorageService = _localStorageService;
            }
            AuthService.getInstance = function () {
                var instance = function ($http, $q, _localStorageService) { return new AuthService($http, $q, _localStorageService); };
                return instance;
            };
            AuthService.$inject = ["$http", "$q", "localStorageService"];
            return AuthService;
        }());
        Services.AuthService = AuthService;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").service("HomeModule.Services.AuthService", AuthService);
    })(Services = HomeModule.Services || (HomeModule.Services = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=AuthService.js.map