module Common.Interceptors
{
    export class AuthenticationInterceptor implements Common.Interfaces.IInterceptor
    {
        static $inject = ["$injector", "$q", "localStorageService", "$location", "$log"];

        public static Factory( $injector: ng.auto.IInjectorService, $q: ng.IQService,
            localStorageService: ng.local.storage.ILocalStorageService, $location: ng.ILocationService,
            $log: ng.ILogService)
        {
            return new AuthenticationInterceptor( $injector, $q, localStorageService, $location, $log );
        }

        constructor( private injectorService: ng.auto.IInjectorService, private qService: ng.IQService,
            private localStorageService: ng.local.storage.ILocalStorageService, private locationService: ng.ILocationService,
            private logService: ng.ILogService)
        {
             logService.log( "initializing AuthenticationInterceptor" );
        }

        public request = ( config: any ): ng.IRequestConfig =>
        {
            config.headers = config.headers || {};
            var authData = this.localStorageService.get('authorizationData') as HomeModule.ViewModels.IAuthorizationVM;
            if ( authData )
            {
                config.headers.Authorization = 'Bearer ' + authData.Token;
            }

            return config;
        }
        public requestError = ( requestFailure: any ): ng.IPromise<any> =>
        {
             this.logService.log( "requestError reported" );
            if ( requestFailure.status === 401 )
            {
                var authService = this.injectorService.get( 'authService' ) as HomeModule.Interfaces.IAuthService;
                var authData = this.localStorageService.get( 'authorizationData' ) as HomeModule.ViewModels.IAuthorizationVM;

                if ( authData )
                {
                    if ( authData.UseRefreshTokens )
                    {
                        this.locationService.path( '/refresh' );
                        return this.qService.reject( requestFailure );
                    }
                }
                authService.LogOut();
                this.locationService.path( '/login' );
            }
            return this.qService.reject( requestFailure );
        }
        public response = ( responseSuccess: any ): ng.IPromise<any> =>
        {
             this.logService.log( "success response reported with status: " + responseSuccess.status );
            console.log( "response: ", responseSuccess );
            return responseSuccess;
        }
        public responseError = ( responseFailure: any ): ng.IPromise<any> =>
        {
            this.logService.log( "response Error reported" );
            if ( responseFailure.status === 401 )
            {
                console.log( "401 error" );
            }
            return this.qService.reject( responseFailure );
        }
    }
}