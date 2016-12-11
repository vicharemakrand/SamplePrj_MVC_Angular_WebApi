var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var HomeModule;
(function (HomeModule) {
    var ViewModels;
    (function (ViewModels) {
        var ISignUpVM = (function (_super) {
            __extends(ISignUpVM, _super);
            function ISignUpVM() {
                _super.apply(this, arguments);
            }
            return ISignUpVM;
        }(UserProfileModule.ViewModels.IUserProfileVM));
        ViewModels.ISignUpVM = ISignUpVM;
    })(ViewModels = HomeModule.ViewModels || (HomeModule.ViewModels = {}));
})(HomeModule || (HomeModule = {}));
//# sourceMappingURL=ISignUpVM.js.map