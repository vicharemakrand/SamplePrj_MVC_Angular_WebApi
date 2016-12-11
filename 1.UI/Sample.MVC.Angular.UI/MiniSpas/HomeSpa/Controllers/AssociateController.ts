
module HomeModule.Controllers
{
    export class AssociateController extends Common.Controllers.BaseController
    {
        authService: HomeModule.Interfaces.IAuthService;
        timeService: ng.ITimeoutService;
        static $inject = ["HomeModule.Services.AuthService", "$injector", "$timeout"];

        constructor( _authService: HomeModule.Interfaces.IAuthService, _injectorService: ng.auto.IInjectorService, _timeService: ng.ITimeoutService )
        {
            super( _injectorService );
            this.authService = _authService;
            this.timeService = _timeService;
            this.Initialize();
        }

        registerDataVM: HomeModule.ViewModels.IExternalLoginVM;

        Initialize()
        {
            var self = this;

            self.registerDataVM = {
                ExternalAccessToken: self.authService.externalLoginVM.ExternalAccessToken,
                UserName: self.authService.externalLoginVM.UserName,
                Provider: self.authService.externalLoginVM.Provider,
                Email: self.authService.externalLoginVM.Email,
                AgeRange: self.authService.externalLoginVM.AgeRange,
                AgeRangeList: Common.AppConstants.AgeRangeList,
            };
        }

        StartTimer()
        {
            var self = this;

            var timer = self.timeService(() =>
            {
                self.timeService.cancel( timer );
                self.locationService.path( '/orders' );
            }, 2000 );
        }

        RegisterExternal()
        {
            var self = this;
            self.registerDataVM.UserName = self.registerDataVM.Email;
            self.authService.ExternalSignUp( self.registerDataVM ).then( function ( response: any )
            {
                self.StartTimer();
            }).catch( function ( response )
                {
                    var errors:Array<string> = [];
                    for ( var key in response.modelState )
                    {
                        errors.push( response.modelState[key] );
                    }
                    self.ProcessInfo.Message = "Failed to register user due to:" + errors.join( ' ' );
             });
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.AssociateController", AssociateController );
} 