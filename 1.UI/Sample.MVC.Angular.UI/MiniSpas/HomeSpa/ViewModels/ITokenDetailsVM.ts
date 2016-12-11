module HomeModule.ViewModels
{
    export class ITokenDetailsVM extends Common.ViewModels.IBaseVM
    {
        TokenId: string;
        Subject: string;
        ClientId: string;
        IssuedUtc: Date;
        ExpiresUtc: Date;
        ProtectedTicket: string;
    }
}