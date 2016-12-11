module HomeModule.ViewModels
{
    export class IExternalLoginVM extends Common.ViewModels.IBaseVM
    {
        Provider: string;
        UserName: string;
        ExternalAccessToken: string;
        Email: string;
        AgeRange: number;
        AgeRangeList: Array<Object>;
    }
}