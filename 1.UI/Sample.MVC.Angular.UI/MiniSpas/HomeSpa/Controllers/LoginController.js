var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var LoginController = (function (_super) {
            __extends(LoginController, _super);
            function LoginController(_injectorService, _authService) {
                _super.call(this, _injectorService);
                this.loginVM = {
                    UserName: "",
                    UseRefreshTokens: true,
                    Password: ""
                };
                this.authService = _authService;
                this.Initialize();
            }
            LoginController.prototype.Login = function (loginData) {
                var self = this;
                self.authService.Login(loginData).then(function (response) {
                    if (response.data != null) {
                        self.windowService.location.href = '/SearchProfile';
                    }
                })
                    .catch(function (response) {
                    self.ProcessInfo.Message = response.data;
                })
                    .finally(function () {
                    self.ProcessInfo.Loading = false;
                });
            };
            LoginController.prototype.AuthExternalProvider = function (provider) {
                var self = this;
                var redirectUri = self.locationService.protocol() + '://' + self.locationService.host() + ':' + self.locationService.port() + '/home';
                var externalProviderUrl = Common.AppConstants.BaseWebApiUrl + "/api/Account/ExternalLogin?provider=" + provider
                    + "&response_type=token&client_id=" + Common.AppConstants.ClientId
                    + "&redirect_uri=" + redirectUri;
                var oauthWindow = self.windowService.open(externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750");
            };
            ;
            LoginController.prototype.RedirectToMainWindow = function () {
                var self = this;
                var queryStringData = self.GetQueryStringData();
                self.windowService.opener.location.href = self.locationService.protocol() + '://' + self.locationService.host() + ':' + self.locationService.port() + '/home/#/verifyexternallogin?' + queryStringData;
                self.windowService.close();
            };
            LoginController.prototype.VerifyExternalLogin = function () {
                var self = this;
                var fragment = self.GetFragment();
                if (fragment.haslocalaccount == 'False') {
                    self.authService.LogOut();
                    self.authService.externalLoginVM = {
                        Provider: fragment.provider,
                        UserName: fragment.external_user_name,
                        ExternalAccessToken: fragment.external_access_token,
                        Email: fragment.email,
                        AgeRange: fragment.ageRange,
                        AgeRangeList: Common.AppConstants.AgeRangeList,
                    };
                    self.locationService.path('/associate');
                    self.locationService.url(self.locationService.path());
                }
                else {
                    //Obtain access token and redirect to orders
                    var externalData = {
                        UserName: fragment.external_user_name,
                        Provider: fragment.provider,
                        ExternalAccessToken: fragment.external_access_token,
                        Email: fragment.email,
                        AgeRange: fragment.ageRange,
                        AgeRangeList: Common.AppConstants.AgeRangeList,
                    };
                    self.authService.GetAccessToken(externalData)
                        .then(function (response) {
                        self.locationService.path('/orders');
                        self.locationService.url(self.locationService.path());
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.error_description;
                    });
                }
            };
            LoginController.prototype.LogOut = function () {
                var self = this;
                self.authService.LogOut();
                self.locationService.path('/home');
            };
            LoginController.prototype.Initialize = function () {
                var self = this;
                self.authenticationVM = self.authService.authVM;
            };
            LoginController.$inject = ["$injector", "HomeModule.Services.AuthService"];
            return LoginController;
        }(Common.Controllers.BaseController));
        Controllers.LoginController = LoginController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.LoginController", LoginController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=LoginController.js.map