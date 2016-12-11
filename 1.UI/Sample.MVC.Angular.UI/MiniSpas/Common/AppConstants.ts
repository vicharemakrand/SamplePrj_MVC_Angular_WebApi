
module Common
{
    export class AppConstants
    {
        static get BaseWebApiUrl(): string { return "http://localhost:8888" };
        static get ClientId(): string { return 'sampleApp' };

        static get AgeRangeList(): Array<Object>
        {
            return [
                { id: Common.AgeRangeList.Age_18_30, name: "18-30" },
                { id: Common.AgeRangeList.Age_31_45, name: "31-45" },
                { id: Common.AgeRangeList.Age_46_55, name: "46-55" },
                { id: Common.AgeRangeList.Age_56_70, name: "56-70" }
            ];
        };
    }

    export enum Genders
    {
        Male = 1,
        Female = 2,
        Both = 3
    }

    export enum AgeRangeList
    {
        Age_18_30 = 1,
        Age_31_45 = 2,
        Age_46_55 = 3,
        Age_56_70 = 4
    }

    MiniSpas.ModuleInitiator.GetModule( "Common" ).constant( "Common.AppConstants", AppConstants);
}