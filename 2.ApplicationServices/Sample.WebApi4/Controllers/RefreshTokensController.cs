using Sample.IDomainServices.IdentityStores;
using Sample.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace Sample.WebApi4.Controllers
{
    [RoutePrefix("api/RefreshTokens")]
    public class RefreshTokensController : ApiController
    {

        private readonly IRefreshTokenService refreshTokenService;

        public RefreshTokensController(IRefreshTokenService refreshTokenService)
        {
            this.refreshTokenService = refreshTokenService;
        }

        [Authorize(Users = "Admin")]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(refreshTokenService.GetAllRefreshTokens());
        }

        [Authorize(Users = "Admin")]
        [AllowAnonymous]
        [Route("")]
        public async Task<IHttpActionResult> Delete(string tokenId)
        {
            var result = await refreshTokenService.RemoveRefreshToken(tokenId);
            if (result)
            {
                return Ok();
            }
            return BadRequest("Token Id does not exist");

        }

        [HttpGet]
        [Route("antiforgerytoken")]
        public HttpResponseMessage GetAntiForgeryToken()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            HttpCookie cookie = HttpContext.Current.Request.Cookies[AppConstants.XsrfCookie];
            string oldCookieToken = cookie == null ? "" : cookie.Value;
            string cookieToken;
            string formToken;
            AntiForgery.GetTokens(oldCookieToken, out cookieToken, out formToken);

            var content = new { FormToken = formToken , CookieToken = cookieToken };

            response.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            if (!string.IsNullOrEmpty(cookieToken))
            {
                CookieHeaderValue cookieData = new CookieHeaderValue(AppConstants.XsrfCookie, cookieToken);
                cookieData.Expires = DateTimeOffset.Now.AddMinutes(10);
                cookieData.Domain = Request.RequestUri.Host;
                cookieData.Path = "/";
                response.Headers.AddCookies(new CookieHeaderValue[] { cookieData });
            }

            return response;
        }
    }
}
