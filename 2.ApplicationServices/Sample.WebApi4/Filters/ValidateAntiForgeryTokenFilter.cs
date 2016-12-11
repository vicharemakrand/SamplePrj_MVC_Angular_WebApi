using Sample.InfraStructure.Logging;
using Sample.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace Sample.WebApi4
{
    public sealed class ValidateAntiForgeryTokenFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpRequestHeaders headers = actionContext.Request.Headers;
            IEnumerable<string> xsrfTokenList;

            if (actionContext.Request.Method == HttpMethod.Get || SkipFilterCheck(actionContext))
            {
                return;
            }

            if (!headers.TryGetValues(AppConstants.XsrfHeader, out xsrfTokenList))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return;
            }

            string tokenHeaderValue = xsrfTokenList.First();
            CookieState tokenCookie = actionContext.Request.Headers.GetCookies().Select(c => c[AppConstants.XsrfCookie]).FirstOrDefault();

            if (tokenCookie == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return;
            }

            try
            {
                AntiForgery.Validate(tokenCookie.Value, tokenHeaderValue);
            }
            catch (HttpAntiForgeryException ex)
            {
                NLogLogger.Instance.Log(ex);
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        private static bool SkipFilterCheck(HttpActionContext filterContext)
        {
            return filterContext.ActionDescriptor.GetCustomAttributes<SkipFilter>().Any();
        }
    }
}