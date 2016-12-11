module HomeModule.Interfaces
{
    export interface IAuthService
    {
        Login( loginData: HomeModule.ViewModels.ILoginVM ) : ng.IPromise<any>;
        LogOut(): void;
        GetAuthData(): void;
        GetFreshToken() : ng.IPromise<any>;
        GetAccessToken( externalData: HomeModule.ViewModels.IExternalLoginVM ) : ng.IPromise<any>;
        ExternalSignUp( registerExternalData: HomeModule.ViewModels.IExternalLoginVM ): ng.IPromise<any>;
        GetAntiForgeryToken(): ng.IPromise<any>;
        externalLoginVM: HomeModule.ViewModels.IExternalLoginVM;
        authVM: HomeModule.ViewModels.IAuthenticationVM;
    }
}