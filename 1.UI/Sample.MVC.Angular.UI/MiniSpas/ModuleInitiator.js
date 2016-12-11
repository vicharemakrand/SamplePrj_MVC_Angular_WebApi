var MiniSpas;
(function (MiniSpas) {
    var ModuleInitiator = (function () {
        function ModuleInitiator() {
        }
        ModuleInitiator.GetModule = function (moduleName) {
            try {
                return angular.module(moduleName);
            }
            catch (error) {
                var dependencies = this.modulesList.filter(function (o) { return o.name == moduleName; }).shift().dependencies;
                return angular.module(moduleName, dependencies);
            }
        };
        ;
        ModuleInitiator.modulesList = [
            { name: 'MiniSpas', dependencies: Array() },
            { name: 'Common', dependencies: Array() },
            { name: 'UserProfileModule', dependencies: Array("ngRoute", "HomeModule", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies") },
            { name: 'HomeModule', dependencies: Array("ngRoute", "UserProfileModule", "Common", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies") },
            { name: 'SearchProfileModule', dependencies: Array("ngRoute", "HomeModule", "Common", "LocalStorageModule", "angular-loading-bar", "ngMessages", "ngCookies") },
            { name: 'PaymentModule', dependencies: Array("ngRoute", "angular-loading-bar", "ngMessages", "ngCookies") }
        ];
        return ModuleInitiator;
    }());
    MiniSpas.ModuleInitiator = ModuleInitiator;
    MiniSpas.ModuleInitiator.GetModule("MiniSpas").service("MiniSpas.ModuleInitiator", ModuleInitiator);
})(MiniSpas || (MiniSpas = {}));
//# sourceMappingURL=ModuleInitiator.js.map