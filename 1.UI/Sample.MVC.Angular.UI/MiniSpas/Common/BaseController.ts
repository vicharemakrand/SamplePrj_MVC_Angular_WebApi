module Common.Controllers
{
    export class BaseController
    {
        protected locationService: ng.ILocationService;
        protected windowService: ng.IWindowService;
        static $inject = ["$injector"];

        constructor(private injectorService: ng.auto.IInjectorService )
        {
            this.windowService = injectorService.get<ng.IWindowService>("$window");
            this.locationService = injectorService.get<ng.ILocationService>( "$location" );
        }

        ProcessInfo = { Message: "" } as Common.ViewModels.IMessageVM;

        StartProcess()
        {
            var self = this;
            self.ProcessInfo = {
                Message: "loading..",
                Loading: true,
                IsSucceed:false
            }
        }

        GetQueryStringData()
        {
            var self = this;

            var indexQuestionMark = self.windowService.location.hash.indexOf( "?" );
            if ( indexQuestionMark >= 0 )
            {
                return self.windowService.location.hash.substr( indexQuestionMark + 1 ) ;
            } else
            {
                return "";
            }
        }

        GetFragment = (): any =>
        {
            var self = this;
            var queryStringData = self.GetQueryStringData();
            if ( queryStringData.length >= 0 )
            {
                return self.ParseQueryString( queryStringData );
            } else
            {
                return {};
            }
        }

        ParseQueryString = ( queryString: string ): any =>
        {
            var data: IDictionary<string> = {};
            var pairs: Array<string>;
            var pair: string;
            var separatorIndex: number;
            var escapedKey: string;
            var escapedValue: string;
            var key: string;
            var value: string;

            if ( queryString === null )
            {
                return data;
            }

            pairs = queryString.split( "&" );

            for ( var i = 0; i < pairs.length; i++ )
            {
                pair = pairs[i];
                separatorIndex = pair.indexOf( "=" );

                if ( separatorIndex === -1 )
                {
                    escapedKey = pair;
                    escapedValue = null;
                } else
                {
                    escapedKey = pair.substr( 0, separatorIndex );
                    escapedValue = pair.substr( separatorIndex + 1 );
                }

                key = decodeURIComponent( escapedKey );
                value = decodeURIComponent( escapedValue );

                data[key] = value;
            }

            return data;
        }

        EndProcess(message: string, isSucceed: boolean)
        {
            var self = this;
            self.ProcessInfo = {
                Message: message,
                Loading: false,
                IsSucceed: isSucceed
            }
        }
    }
}