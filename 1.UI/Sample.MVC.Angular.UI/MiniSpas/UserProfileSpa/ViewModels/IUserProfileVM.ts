module UserProfileModule.ViewModels
{
    export class IUserProfileVM extends Common.ViewModels.IBaseVM
    {
        Id: any;
        UserName: string;
        Email: string;
        AgeRange: number;
        Gender: number;
        Location: string;
        UserStatus: number;
    }
}