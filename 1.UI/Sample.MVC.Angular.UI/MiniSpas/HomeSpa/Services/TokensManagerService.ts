
module HomeModule.Services
{
    export class TokensManagerService implements HomeModule.Interfaces.ITokensManagerService
    {
        httpService: ng.IHttpService;
        qService: ng.IQService;
        static $inject = ["$http", "$q"];
        constructor( $http: ng.IHttpService, $q: ng.IQService )
        {
            this.httpService = $http;
            this.qService = $q;
        }

        GetRefreshTokens = (): ng.IPromise<any> =>
        {
            return this.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/refreshtokens' )
                .then( function ( response: any )
                {
                    return response;
                })
                .catch( function ( response: any )
                {
                    return response;
                });
        }

        DeleteRefreshTokens = ( tokenid: string ): ng.IPromise<any> =>
        {
            return this.httpService.delete( Common.AppConstants.BaseWebApiUrl + '/api/refreshtokens/?tokenid=' + tokenid )
                .then( function ( response: any )
                {
                    return response;
                })
                .catch( function ( response: any )
                {
                    return response;
                });
        }

        static getInstance()
        {
            var instance = ( $http: ng.IHttpService, $q: ng.IQService ) => new TokensManagerService( $http, $q);
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).service( "HomeModule.Services.TokensManagerService", TokensManagerService );
} 