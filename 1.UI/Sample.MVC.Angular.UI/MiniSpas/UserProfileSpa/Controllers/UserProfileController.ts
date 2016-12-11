
module UserProfileModule.Controllers
{
    export class UserProfileController extends Common.Controllers.BaseController
    {
        static $inject = [ "$injector"];

        constructor(_injectorService: ng.auto.IInjectorService )
        {
            super( _injectorService );
            this.Initialize();
        }

        Initialize()
        {
            var self = this;
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "UserProfileModule" ).controller( "UserProfileModule.Controllers.UserProfileController", UserProfileController );
} 