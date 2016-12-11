module HomeModule.ViewModels
{
    export class IAuthenticationVM extends Common.ViewModels.IBaseVM
    {
        IsAuth: boolean;
        UserName: string;
        UseRefreshTokens: boolean;
    }
}