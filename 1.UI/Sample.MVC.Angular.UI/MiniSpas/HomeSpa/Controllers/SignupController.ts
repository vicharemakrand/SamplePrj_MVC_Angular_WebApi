
module HomeModule.Controllers
{
    export class SignupController extends Common.Controllers.BaseController
    {
        static $inject = ["$injector", "UserProfileModule.Services.UserProfileService", "$timeout"];
        signUpVM: HomeModule.ViewModels.ISignUpVM;

        constructor( _injectorService: ng.auto.IInjectorService,
                     private userProfileService: UserProfileModule.Interfaces.IUserProfileService,
                     private timeOutService: ng.ITimeoutService)
        { 
            super( _injectorService );
            this.Initialize();
        }

        SignUp = () =>
        {
            var self = this;
            self.StartProcess();

            self.userProfileService.SignUp( this.signUpVM )
                .then( function ( response: any ) {
                    self.ProcessInfo.Message = response.data.message;
                    self.ProcessInfo.IsSucceed = true;
                    self.StartTimer();
                })
                .catch( function ( response: any )
                {
                    var errors: Array<string>;
                    for ( var key in response.data.modelState )
                    {
                        for ( var i = 0; i < response.data.modelState[key].length; i++ )
                        {
                            errors.push( response.data.modelState[key][i] );
                        }
                    }
                    self.ProcessInfo.Message = "Failed to register user due to:" + errors.join( ' ' );
                })
                .finally( function ()
                {
                    self.ProcessInfo.Loading = false;
                });;
        }

        StartTimer = () =>
        {
            var self = this;
            var timer = self.timeOutService( function ()
                                            {
                self.timeOutService.cancel( timer );
                self.locationService.path( '/login' );
            }, 2000 ) as ng.IPromise<void>;
        }

        Initialize()
        {
            var self = this;
            self.signUpVM = {
                Password: "",
                Email: "",
                Gender: Common.Genders.Female,
                Genders: [{ id: Common.Genders.Male, name: Common.Genders[Common.Genders.Male] },
                    { id: Common.Genders.Female, name: Common.Genders[Common.Genders.Female] }
                ],
                AgeRange: Common.AgeRangeList.Age_18_30,
                AgeRangeList: Common.AppConstants.AgeRangeList,
                Id: null,
                Location: "",
                UserName: "",
                UserStatus: 1 // active,
            } as HomeModule.ViewModels.ISignUpVM;
        }
    }
    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).controller( "HomeModule.Controllers.SignupController", SignupController );
} 