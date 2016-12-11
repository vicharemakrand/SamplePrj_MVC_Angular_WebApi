
module UserProfileModule.Services
{
    export class UserProfileService implements UserProfileModule.Interfaces.IUserProfileService
    {
        httpService: ng.IHttpService;
        qService: ng.IQService;
        static $inject = ["$http","$q"];
        constructor( $http: ng.IHttpService, $q: ng.IQService)
        {
            this.httpService = $http;
            this.qService = $q;
        }

        GetProfileList(): ng.IPromise<any> 
        {
            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/values' );
        }

        SignUp( registration: HomeModule.ViewModels.ISignUpVM ): ng.IPromise<any> 
        {
            var self = this;
            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/api/Account/Register', registration )
                .then( function ( response: any )
                {
                    return response;

                }).catch( function ( response: any )
                {
                    return response;
                });
        }

        static GetInstance = () =>
        {
            var instance = ( $http: ng.IHttpService, $q: ng.IQService) => new UserProfileService( $http, $q );
            return instance;
        }
   }

    MiniSpas.ModuleInitiator.GetModule( "UserProfileModule" ).service( "UserProfileModule.Services.UserProfileService", UserProfileService);
} 