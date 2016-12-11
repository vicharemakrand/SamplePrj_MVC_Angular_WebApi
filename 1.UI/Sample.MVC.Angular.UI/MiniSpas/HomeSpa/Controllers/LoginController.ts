
module HomeModule.Controllers
{
    export class LoginController extends Common.Controllers.BaseController
    {
        authService: HomeModule.Interfaces.IAuthService;
        static $inject = ["$injector", "HomeModule.Services.AuthService"];

        constructor( _injectorService: ng.auto.IInjectorService , _authService: HomeModule.Interfaces.IAuthService)
        {
            super( _injectorService);
            this.authService = _authService;
            this.Initialize();
        }

        loginVM: HomeModule.ViewModels.ILoginVM = {
            UserName: "",
            UseRefreshTokens: true,
            Password: ""
        };

        authenticationVM: HomeModule.ViewModels.IAuthenticationVM ;

        Login(loginData:HomeModule.ViewModels.ILoginVM)
        {
            var self = this;
            self.authService.Login(loginData).then( function ( response: any )
            {
                if ( response.data != null )
                {
                    self.windowService.location.href = '/SearchProfile';
                }

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

        AuthExternalProvider( provider : string )
        {
            var self = this;
            var redirectUri = self.locationService.protocol() + '://' + self.locationService.host() + ':' + self.locationService.port() + '/home';

            var externalProviderUrl = Common.AppConstants.BaseWebApiUrl + "/api/Account/ExternalLogin?provider=" + provider
                + "&response_type=token&client_id=" + Common.AppConstants.ClientId
                + "&redirect_uri=" + redirectUri;

            var oauthWindow = self.windowService.open( externalProviderUrl, "Authenticate Account", "location=0,status=0,width=600,height=750" );
        };

        RedirectToMainWindow()
        {
            var self = this;
            var queryStringData = self.GetQueryStringData();
            self.windowService.opener.location.href = self.locationService.protocol() + '://' + self.locationService.host() + ':' + self.locationService.port() + '/home/#/verifyexternallogin?' + queryStringData;
            self.windowService.close();
        }

        VerifyExternalLogin()
        {
            var self = this;

            var fragment = self.GetFragment();

            if ( fragment.haslocalaccount == 'False' )
            {
                self.authService.LogOut();
                self.authService.externalLoginVM = {
                    Provider: fragment.provider,
                    UserName: fragment.external_user_name,
                    ExternalAccessToken: fragment.external_access_token,
                    Email: fragment.email,
                    AgeRange: fragment.ageRange,
                    AgeRangeList: Common.AppConstants.AgeRangeList,
                };
                self.locationService.path( '/associate' )
                self.locationService.url( self.locationService.path() );
            }
            else
            {
                //Obtain access token and redirect to orders
                var externalData: HomeModule.ViewModels.IExternalLoginVM = {
                    UserName: fragment.external_user_name,
                    Provider: fragment.provider,
                    ExternalAccessToken: fragment.external_access_token,
                    Email: fragment.email,
                    AgeRange: fragment.ageRange,
                    AgeRangeList: Common.AppConstants.AgeRangeList,
                };
                self.authService.GetAccessToken( externalData )
                    .then( function ( response: any )
                    {
                        self.locationService.path( '/orders' );
                        self.locationService.url( self.locationService.path() );

                    })
                    .catch( function ( response: any )
                    {
                        self.ProcessInfo.Message = response.error_description;
                    });
            }
        }

        LogOut()
        {
            var self = this;
            self.authService.LogOut();
            self.locationService.path( '/home' );
        }

        Initialize()
        {
            var self = this;
            self.authenticationVM = self.authService.authVM;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.LoginController", LoginController );
} 