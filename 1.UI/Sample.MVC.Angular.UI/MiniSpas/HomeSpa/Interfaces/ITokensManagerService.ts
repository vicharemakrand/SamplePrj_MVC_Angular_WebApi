module HomeModule.Interfaces
{
    export interface ITokensManagerService
    {
        GetRefreshTokens() : ng.IPromise<any>;
        DeleteRefreshTokens( tokenid: string ) : ng.IPromise<any>;
    }
} 