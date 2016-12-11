var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function (_super) {
            __extends(HomeController, _super);
            function HomeController(_userProfileService, _injectorService) {
                var _this = this;
                _super.call(this, _injectorService);
                this.GetProfiles = function () {
                    var self = _this;
                    self.StartProcess();
                    self.userProfileService.GetProfileList()
                        .then(function (response) {
                        self.profiles = response.data.result;
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                this.userProfileService = _userProfileService;
            }
            HomeController.$inject = ["UserProfileModule.Services.UserProfileService", "$injector"];
            return HomeController;
        }(Common.Controllers.BaseController));
        Controllers.HomeController = HomeController;
        MiniSpas.ModuleInitiator.GetModule("HomeModule").controller("HomeModule.Controllers.HomeController", HomeController);
    })(Controllers = HomeModule.Controllers || (HomeModule.Controllers = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=HomeController.js.map