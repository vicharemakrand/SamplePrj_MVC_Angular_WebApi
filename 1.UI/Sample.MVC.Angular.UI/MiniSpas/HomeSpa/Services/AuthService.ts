
module HomeModule.Services
{
    export class AuthService implements HomeModule.Interfaces.IAuthService
    {
        httpService: ng.IHttpService;
        qService: ng.IQService;
        localStorageService: ng.local.storage.ILocalStorageService;
        static $inject = ["$http", "$q", "localStorageService"];

        constructor( $http: ng.IHttpService, $q: ng.IQService, _localStorageService: ng.local.storage.ILocalStorageService )
        {
            this.httpService = $http;
            this.qService = $q;
            this.localStorageService = _localStorageService;
        }

        useRefreshToken: boolean = false;
        isAuth: boolean = false;

        authVM: HomeModule.ViewModels.IAuthenticationVM = {
            IsAuth: this.isAuth,
            UseRefreshTokens: this.useRefreshToken,
            UserName: ""
        };

        externalLoginVM: HomeModule.ViewModels.IExternalLoginVM = {
            ExternalAccessToken: "",
            UserName: "",
            Provider: "",
            Email: "",
            AgeRange: 1,
            AgeRangeList: Common.AppConstants.AgeRangeList
        };

        Login = (loginData: HomeModule.ViewModels.ILoginVM): ng.IPromise<any> =>
        {
            var self = this;

            var data = "grant_type=password&username=" + loginData.UserName + "&password=" + loginData.Password;

            if ( loginData.UseRefreshTokens )
            {
                data = data + "&client_id=" + Common.AppConstants.ClientId;
            }

            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then( function( response:any )
                {
                    if (loginData.UseRefreshTokens)
                    {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: response.data.refresh_token,
                                UseRefreshTokens: !self.useRefreshToken
                            } as HomeModule.ViewModels.IAuthorizationVM );
                    }
                    else
                    {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                UserName: loginData.UserName,
                                RefreshToken: "",
                                UseRefreshTokens: self.useRefreshToken
                            } as HomeModule.ViewModels.IAuthorizationVM );
                    }
                    self.authVM.IsAuth = !self.isAuth;
                    self.authVM.UserName = loginData.UserName;
                    self.authVM.UseRefreshTokens = loginData.UseRefreshTokens;
                    return response;

                }).catch( function ( response: any )
                {
                    self.LogOut();
                    return response;
                });
        }

        LogOut = () =>
        {
            var self = this;
            self.localStorageService.remove( 'authorizationData' );
            self.authVM.IsAuth = self.isAuth;
            self.authVM.UserName = "";
            self.authVM.UseRefreshTokens = !self.useRefreshToken;
        }

        GetAuthData = () =>
        {
            var self = this;

            var authData = self.localStorageService.get( 'authorizationData' ) as HomeModule.ViewModels.IAuthorizationVM;
            if ( authData != null )
            {
                self.authVM.IsAuth = !self.isAuth;
                self.authVM.UserName = authData.UserName;
                self.authVM.UseRefreshTokens = authData.UseRefreshTokens;
            }
        }

        GetFreshToken = (): ng.IPromise<any> =>
        {
            var self = this;

            var authData = self.localStorageService.get( 'authorizationData' ) as HomeModule.ViewModels.IAuthorizationVM;
            if ( authData )
            {
                if ( authData.UseRefreshTokens )
                {
                    var data = "grant_type=refresh_token&refresh_token=" + authData.RefreshToken + "&client_id=" + Common.AppConstants.ClientId;
                    self.localStorageService.remove( 'authorizationData' );

                    return self.httpService.post( Common.AppConstants.BaseWebApiUrl + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                    .then( function ( response:any )
                    {
                        self.localStorageService.set( 'authorizationData',
                            {
                                Token: response.data.access_token,
                                UserName: response.data.userName,
                                RefreshToken: response.data.refresh_token,
                                UseRefreshTokens: self.useRefreshToken
                            } as HomeModule.ViewModels.IAuthorizationVM );
                        return response;
                    })
                    .catch( function ( response: any)
                    {
                        self.LogOut();
                        return response
                    });
                }
            }
       }

        GetAccessToken = ( externalData: HomeModule.ViewModels.IExternalLoginVM ): ng.IPromise<any> =>
        {
            var self = this;

            return self.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/Account/ObtainLocalAccessToken',
                {
                    params: {
                                provider: externalData.Provider,
                                externalAccessToken: externalData.ExternalAccessToken
                            }
                })
                .then( function ( response: any )
                    {
                        var authorizationVM: HomeModule.ViewModels.IAuthorizationVM = {
                            Token: response.data.access_token,
                            UserName: response.data.userName,
                            RefreshToken: "",
                            UseRefreshTokens: false 
                        };
                        self.localStorageService.set( 'authorizationData', authorizationVM);
                        self.authVM.IsAuth = !self.isAuth;
                        self.authVM.UserName = response.data.userName;
                        self.authVM.UseRefreshTokens = !self.useRefreshToken;
                        return response;
                    })
                    .catch( function ( response: any )
                    {
                        self.LogOut();
                        return response;
                    });
        }

        ExternalSignUp = ( registerExternalData: HomeModule.ViewModels.IExternalLoginVM ): ng.IPromise<any> =>
        {
            var self = this;
            return self.httpService.post( Common.AppConstants.BaseWebApiUrl + '/api/Account/registerexternal', registerExternalData )
                .then( function ( response: any )
                {
                    self.localStorageService.set( 'authorizationData',
                        {
                            Token: response.data.access_token,
                            UserName: response.data.userName,
                            RefreshToken: "",
                            UseRefreshTokens: self.useRefreshToken
                        } as HomeModule.ViewModels.IAuthorizationVM );

                    self.authVM.IsAuth = !self.isAuth;
                    self.authVM.UserName = response.data.userName;
                    self.authVM.UseRefreshTokens = !self.useRefreshToken;
                    return response;

                }).catch( function ( response: any )
                {
                    self.LogOut();
                    return response;
                });
        }

        GetAntiForgeryToken = (): ng.IPromise<any> =>
        {
            var self = this;

            return self.httpService.get( Common.AppConstants.BaseWebApiUrl + '/api/RefreshTokens/antiforgerytoken')
                .then( function ( response: any )
                {
                    return response;
                })
                .catch( function ( response: any )
                {
                    return response
                });
        }


        public static getInstance()
        {
            var instance = ( $http: ng.IHttpService, $q: ng.IQService, _localStorageService: ng.local.storage.ILocalStorageService ) => new AuthService( $http, $q, _localStorageService);
            return instance;
        }
    }

    MiniSpas.ModuleInitiator.GetModule( "HomeModule" ).service( "HomeModule.Services.AuthService", AuthService );
} 