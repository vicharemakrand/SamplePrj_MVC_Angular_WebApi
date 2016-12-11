module HomeModule.ViewModels
{
    export class IAuthorizationVM extends Common.ViewModels.IBaseVM
    {
        Token: string;
        UserName: string;
        RefreshToken: string;
        UseRefreshTokens: boolean;
    }
}