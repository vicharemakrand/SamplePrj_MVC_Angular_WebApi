using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample.WebApi4.BindingModels
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string Location { get; set; }
        public string PhotoFileName { get; set; }
    }
}