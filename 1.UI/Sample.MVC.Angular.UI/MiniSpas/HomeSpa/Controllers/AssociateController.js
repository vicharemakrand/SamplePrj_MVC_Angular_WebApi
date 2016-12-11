var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var AssociateController = (function (_super) {
            __extends(AssociateController, _super);
            function AssociateController(_authService, _injectorService, _timeService) {
                _super.call(this, _injectorService);
                this.authService = _authService;
                this.timeService = _timeService;
                this.Initialize();
            }
            AssociateController.prototype.Initialize = function () {
                var self = this;
                self.registerDataVM = {
                    ExternalAccessToken: self.authService.externalLoginVM.ExternalAccessToken,
                    UserName: self.authService.externalLoginVM.UserName,
                    Provider: self.authService.externalLoginVM.Provider,
                    Email: self.authService.externalLoginVM.Email,
                    AgeRange: self.authService.externalLoginVM.AgeRange,
                    AgeRangeList: Common.AppConstants.AgeRangeList,
                };
            };
            AssociateController.prototype.StartTimer = function () {
                var self = this;
                var timer = self.timeService(function () {
                    self.timeService.cancel(timer);
                    self.locationService.path('/orders');
                }, 2000);
            };
            AssociateController.prototype.RegisterExternal = function () {
                var self = this;
                self.registerDataVM.UserName = self.registerDataVM.Email;
                self.authService.ExternalSignUp(self.registerDataVM).then(function (response) {
                    self.StartTimer();
                }).catch(function (response) {
                    var errors = [];
                    for (var key in response.modelState) {
                        errors.push(response.modelState[key]);
                    }
                    self.ProcessInfo.Message = "Failed to register user due to:" + errors.join(' ');
                });
            };
            AssociateController.$inject = ["HomeModule.Services.AuthService", "$injector", "$timeout"];
            return AssociateController;
        }(Common.Controllers.BaseController));
        Controllers.AssociateController = AssociateController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.AssociateController", AssociateController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=AssociateController.js.map