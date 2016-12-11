var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var UserProfileModule;
(function (UserProfileModule) {
    var Controllers;
    (function (Controllers) {
        var UserProfileController = (function (_super) {
            __extends(UserProfileController, _super);
            function UserProfileController(_injectorService) {
                _super.call(this, _injectorService);
                this.Initialize();
            }
            UserProfileController.prototype.Initialize = function () {
                var self = this;
            };
            UserProfileController.$inject = ["$injector"];
            return UserProfileController;
        }(Common.Controllers.BaseController));
        Controllers.UserProfileController = UserProfileController;
        MiniSpas.ModuleInitiator.GetModule("UserProfileModule").controller("UserProfileModule.Controllers.UserProfileController", UserProfileController);
    })(Controllers = UserProfileModule.Controllers || (UserProfileModule.Controllers = {}));
})(UserProfileModule || (UserProfileModule = {}));
//# sourceMappingURL=UserProfileController.js.map