using Sample.WebApi4.BindingModels;
using FizzWare.NBuilder;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sample.WebApi4.Controllers
{
    [Authorize]
    public class ProfileController : ApiController
    {
        public HttpResponseMessage GetProfiles()
        {
            var result = Builder<UserProfileViewModel>.CreateListOfSize(20)
                        .All()
                            .With(c => c.UserName = Faker.Name.FullName())
                            .With(c => c.Location = Faker.Address.UsState())
                        .Build();

            if (result.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result, message = "found records" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Record Found");
            }
        }
    }
}
