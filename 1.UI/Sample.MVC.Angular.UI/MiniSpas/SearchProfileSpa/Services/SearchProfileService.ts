
module SearchProfileModule.Services
{
    export class SearchProfileService implements SearchProfileModule.Interfaces.ISearchProfileService
    {
        static $inject = ["$http"];
        constructor( private httpService: ng.IHttpService)
        {
        }

        GetProfiles(): ng.IPromise<any> 
        {
            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/Profile/GetProfiles' );
        }


        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService ) => new SearchProfileService( $http );
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "SearchProfileModule" ).service( "SearchProfileModule.Services.SearchProfileService", SearchProfileService );
} 