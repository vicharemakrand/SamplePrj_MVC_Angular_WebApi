using Sample.ViewModels.Core;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sample.ViewModels.Identity.WebApi
{

    public class IdentityUserViewModel : BaseViewModel, IUser<ObjectId>
    {
        public IdentityUserViewModel()
        {

        }
        public IdentityUserViewModel(string userName)
        {
            this.UserName = userName;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public int AgeRange { get; set; }
        public int Gender { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int UserStatus { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
        public string InputPassword { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

    }
}
