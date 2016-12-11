module HomeModule.ViewModels
{
    export class ISignUpVM extends UserProfileModule.ViewModels.IUserProfileVM
    {
        Password: string;
        Genders: Array<Object>;
        AgeRangeList: Array<Object>;
    }
}