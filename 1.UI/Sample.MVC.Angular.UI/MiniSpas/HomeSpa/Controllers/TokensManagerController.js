var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var TokensManagerController = (function (_super) {
            __extends(TokensManagerController, _super);
            function TokensManagerController(_tokenService, _injectorService) {
                _super.call(this, _injectorService);
                this.refreshTokens = [];
                this.tokenService = _tokenService;
            }
            TokensManagerController.prototype.GetRefreshTokens = function () {
                var self = this;
                self.tokenService.GetRefreshTokens().then(function (response) {
                    self.refreshTokens = response.data;
                    self.ProcessInfo.Message = response.data.message;
                })
                    .catch(function (response) {
                    self.ProcessInfo.Message = response.data;
                })
                    .finally(function () {
                    self.ProcessInfo.Loading = false;
                });
            };
            TokensManagerController.prototype.DeleteRefreshTokens = function (index, tokenid) {
                var self = this;
                tokenid = encodeURIComponent(tokenid);
                self.tokenService.DeleteRefreshTokens(tokenid).then(function (response) {
                    self.refreshTokens.splice(index, 1);
                    self.ProcessInfo.Message = response.data.message;
                })
                    .catch(function (response) {
                    self.ProcessInfo.Message = response.data;
                })
                    .finally(function () {
                    self.ProcessInfo.Loading = false;
                });
            };
            TokensManagerController.$inject = ["HomeModule.Services.TokensManagerService", "$injector"];
            return TokensManagerController;
        }(Common.Controllers.BaseController));
        Controllers.TokensManagerController = TokensManagerController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.TokensManagerController", TokensManagerController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=TokensManagerController.js.map