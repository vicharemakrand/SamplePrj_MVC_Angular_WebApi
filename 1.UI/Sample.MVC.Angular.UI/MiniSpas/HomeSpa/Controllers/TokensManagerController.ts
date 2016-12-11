
module HomeModule.Controllers
{
    export class TokensManagerController extends Common.Controllers.BaseController
    {
        tokenService: HomeModule.Interfaces.ITokensManagerService;
        static $inject = ["HomeModule.Services.TokensManagerService", "$injector"];

        constructor( _tokenService: HomeModule.Interfaces.ITokensManagerService, _injectorService: ng.auto.IInjectorService )
        {
            super( _injectorService );
            this.tokenService = _tokenService;
        }

        refreshTokens: Array<HomeModule.ViewModels.ITokenDetailsVM> = [];

        GetRefreshTokens()
        {
            var self = this;
            self.tokenService.GetRefreshTokens().then( function ( response: any )
            {
                self.refreshTokens = response.data;
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

        DeleteRefreshTokens( index: number, tokenid: string)
        {
            var self = this;
            tokenid = encodeURIComponent( tokenid );

            self.tokenService.DeleteRefreshTokens( tokenid).then( function ( response: any )
            {
                self.refreshTokens.splice( index, 1 );
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
    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.TokensManagerController", TokensManagerController );
} 