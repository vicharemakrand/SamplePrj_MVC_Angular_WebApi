module HomeModule.Controllers
{
    export class RefreshController extends Common.Controllers.BaseController
    {
        authService: HomeModule.Interfaces.IAuthService;
        static $inject = ["HomeModule.Services.AuthService", "$injector"];

        constructor( _authService: HomeModule.Interfaces.IAuthService, _injectorService: ng.auto.IInjectorService)
        {
            super( _injectorService );
            this.authService = _authService;
            this.Initialize();
        }

        refreshTokenVM: HomeModule.ViewModels.IRefreshTokensVM;

        RefreshToken()
        {
            var self = this;
            self.authService.GetFreshToken().then( function ( response : any)
            {
                self.refreshTokenVM.TokenRefreshed = true;
                self.refreshTokenVM.TokenResponse = response.data;
            }).catch( function (response : any)
            {
                self.locationService.path( '/login' );
            });
        };

        Initialize()
        {
            var self = this;

            self.refreshTokenVM = {
                TokenRefreshed: false,
                TokenResponse: undefined,
                Authentication: self.authService.authVM
            };
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.RefreshController", RefreshController );
} 