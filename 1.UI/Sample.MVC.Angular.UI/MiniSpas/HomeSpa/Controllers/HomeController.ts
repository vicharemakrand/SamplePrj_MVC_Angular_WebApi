
module HomeModule.Controllers
{
    export class HomeController extends Common.Controllers.BaseController
    {
        userProfileService: UserProfileModule.Interfaces.IUserProfileService;
        static $inject = ["UserProfileModule.Services.UserProfileService", "$injector"];
        profiles: Array<UserProfileModule.ViewModels.IUserProfileVM>;
        constructor( _userProfileService: UserProfileModule.Interfaces.IUserProfileService, _injectorService: ng.auto.IInjectorService )
        {
            super( _injectorService);
            this.userProfileService = _userProfileService;
        }

        GetProfiles = () =>
        {
            var self = this;
            self.StartProcess();

            self.userProfileService.GetProfileList()
                .then(function ( response: any )
                {
                    self.profiles = response.data.result;
                    self.ProcessInfo.Message = response.data.message;
                })
                .catch( function ( response: any )
                {
                    self.ProcessInfo.Message = response.data;
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });
        }
    }
    MiniSpas.ModuleInitiator.GetModule("HomeModule").controller( "HomeModule.Controllers.HomeController", HomeController );
} 