var Common;
(function (Common) {
    var AppConstants = (function () {
        function AppConstants() {
        }
        Object.defineProperty(AppConstants, "BaseWebApiUrl", {
            get: function () { return "http://localhost:8888"; },
            enumerable: true,
            configurable: true
        });
        ;
        Object.defineProperty(AppConstants, "ClientId", {
            get: function () { return 'sampleApp'; },
            enumerable: true,
            configurable: true
        });
        ;
        Object.defineProperty(AppConstants, "AgeRangeList", {
            get: function () {
                return [
                    { id: Common.AgeRangeList.Age_18_30, name: "18-30" },
                    { id: Common.AgeRangeList.Age_31_45, name: "31-45" },
                    { id: Common.AgeRangeList.Age_46_55, name: "46-55" },
                    { id: Common.AgeRangeList.Age_56_70, name: "56-70" }
                ];
            },
            enumerable: true,
            configurable: true
        });
        ;
        return AppConstants;
    }());
    Common.AppConstants = AppConstants;
    (function (Genders) {
        Genders[Genders["Male"] = 1] = "Male";
        Genders[Genders["Female"] = 2] = "Female";
        Genders[Genders["Both"] = 3] = "Both";
    })(Common.Genders || (Common.Genders = {}));
    var Genders = Common.Genders;
    (function (AgeRangeList) {
        AgeRangeList[AgeRangeList["Age_18_30"] = 1] = "Age_18_30";
        AgeRangeList[AgeRangeList["Age_31_45"] = 2] = "Age_31_45";
        AgeRangeList[AgeRangeList["Age_46_55"] = 3] = "Age_46_55";
        AgeRangeList[AgeRangeList["Age_56_70"] = 4] = "Age_56_70";
    })(Common.AgeRangeList || (Common.AgeRangeList = {}));
    var AgeRangeList = Common.AgeRangeList;
    MiniSpas.ModuleInitiator.GetModule("Common").constant("Common.AppConstants", AppConstants);
})(Common || (Common = {}));
//# sourceMappingURL=AppConstants.js.map