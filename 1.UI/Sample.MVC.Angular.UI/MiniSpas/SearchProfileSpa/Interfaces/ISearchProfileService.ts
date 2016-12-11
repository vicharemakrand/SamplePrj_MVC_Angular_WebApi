module SearchProfileModule.Interfaces
{
    export interface ISearchProfileService
    {
        GetProfiles(): ng.IPromise<any>;
    }
}