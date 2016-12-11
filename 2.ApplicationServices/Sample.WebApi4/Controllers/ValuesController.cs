using Sample.ViewModels.Identity.WebApi;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sample.WebApi4.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            var result = new List<IdentityUserViewModel>() {
                new IdentityUserViewModel { Id = new ObjectId() , Email ="email1@mail.com", AgeRange = 1, Gender = 1 , Location = "location1", UserStatus = 1 },
                 new IdentityUserViewModel { Id = new ObjectId() , Email ="email2@mail.com", AgeRange = 1, Gender = 1 , Location = "location1", UserStatus = 1 },
                new IdentityUserViewModel { Id = new ObjectId() , Email ="email3@mail.com", AgeRange = 1, Gender = 1 , Location = "location1", UserStatus = 1 },
                new IdentityUserViewModel { Id = new ObjectId() , Email ="email4@mail.com", AgeRange = 1, Gender = 1 , Location = "location1", UserStatus = 1 }
           };
            if (result.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result, message = "found records" });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Record Found");
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
