module Common.Interfaces
{
    export interface IInterceptor
    {
        request: ( requestSuccess: any ) => ng.IRequestConfig;
        requestError: ( requestFailure: any )=> ng.IPromise<any>;
        response: ( responseSuccess: any )=> ng.IPromise<any>;
        responseError: ( responseFailure: any ) => ng.IPromise<any>;
    }
}