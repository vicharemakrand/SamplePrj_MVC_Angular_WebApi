module HomeModule.ViewModels
{
    export class IRefreshTokensVM extends Common.ViewModels.IBaseVM
    {
        TokenResponse: string;
        TokenRefreshed: boolean;
        Authentication: IAuthenticationVM;
    }
}