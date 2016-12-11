var __extends = (this && this.__extends) || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
};
var SearchProfileModule;
(function (SearchProfileModule) {
    var Controllers;
    (function (Controllers) {
        var SearchProfileController = (function (_super) {
            __extends(SearchProfileController, _super);
            function SearchProfileController(_injectorService, searchProfileService) {
                var _this = this;
                _super.call(this, _injectorService);
                this.searchProfileService = searchProfileService;
                this.GetProfiles = function () {
                    var self = _this;
                    self.StartProcess();
                    self.searchProfileService.GetProfiles()
                        .then(function (response) {
                        self.profilesList = response.data.result;
                        self.ProcessInfo.Message = response.data.message;
                    })
                        .catch(function (response) {
                        self.ProcessInfo.Message = response.data;
                    })
                        .finally(function () {
                        self.ProcessInfo.Loading = false;
                    });
                };
                this.Initialize();
            }
            SearchProfileController.prototype.Initialize = function () {
                var self = this;
                self.profilePath = Common.AppConstants.BaseWebApiUrl;
                self.GetProfiles();
            };
            SearchProfileController.$inject = ["$injector", "SearchProfileModule.Services.SearchProfileService"];
            return SearchProfileController;
        }(Common.Controllers.BaseController));
        Controllers.SearchProfileController = SearchProfileController;
        MiniSpas.ModuleInitiator.GetModule("SearchProfileModule").controller("SearchProfileModule.Controllers.SearchProfileController", SearchProfileController);
    })(Controllers = SearchProfileModule.Controllers || (SearchProfileModule.Controllers = {}));
})(SearchProfileModule || (SearchProfileModule = {}));
//# sourceMappingURL=SearchProfileController.js.map