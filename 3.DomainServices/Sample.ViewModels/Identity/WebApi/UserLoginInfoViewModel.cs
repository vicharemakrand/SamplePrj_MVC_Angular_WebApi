using Sample.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.ViewModels.Identity.WebApi
{
    public class UserLoginInfoViewModel : BaseViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }


    }

}
