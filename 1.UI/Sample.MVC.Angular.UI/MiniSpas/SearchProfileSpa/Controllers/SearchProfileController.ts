
module SearchProfileModule.Controllers
{
    export class SearchProfileController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector","SearchProfileModule.Services.SearchProfileService"];
        profiles: Array<SearchProfileModule.ViewModels.IUserProfileListVM>;
        constructor( _injectorService: ng.auto.IInjectorService, private searchProfileService: SearchProfileModule.Interfaces.ISearchProfileService)
        {
            super( _injectorService );
            this.Initialize();
        }

        profilesList: Array<SearchProfileModule.ViewModels.IUserProfileListVM>;
        profilePath: string;

        Initialize()
        {
            var self = this;
            self.profilePath = Common.AppConstants.BaseWebApiUrl;
            self.GetProfiles();
        }

        GetProfiles = () =>
        {
            var self = this;
            self.StartProcess();

            self.searchProfileService.GetProfiles()
                .then( function ( response: any )
                {
                    self.profilesList = response.data.result;
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
    MiniSpas.ModuleInitiator.GetModule( "SearchProfileModule" ).controller( "SearchProfileModule.Controllers.SearchProfileController", SearchProfileController );
} 