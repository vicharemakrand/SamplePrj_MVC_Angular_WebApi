using Sample.ViewModels.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.ViewModels.Identity.WebMvc
{
    public class ExternalLoginConfirmationViewModel 
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

    }

}
