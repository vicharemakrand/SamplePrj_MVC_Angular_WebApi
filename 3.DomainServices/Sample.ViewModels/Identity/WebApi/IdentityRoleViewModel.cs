using Sample.ViewModels.Core;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.ViewModels.Identity.WebApi
{
    public class IdentityRoleViewModel : BaseViewModel, IRole<ObjectId>
    {

        public IdentityRoleViewModel(string name)
        {
            this.Name = name;
        }

        public IdentityRoleViewModel(string name, ObjectId id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; set; }
    }
}
