module UserProfileModule.Interfaces
{
    export interface IUserProfileService
    {
        GetProfileList() : ng.IPromise<any>;
        SignUp( registration: HomeModule.ViewModels.ISignUpVM ): ng.IPromise<any>;
    }
}