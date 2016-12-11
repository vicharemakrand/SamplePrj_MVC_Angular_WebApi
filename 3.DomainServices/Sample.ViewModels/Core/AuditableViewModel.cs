using Sample.ViewModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.ViewModels
{
    [Serializable]
    public abstract class AuditableViewModel : BaseViewModel
    {

        [Display(Name = "Updated On")]
        public DateTime UpdatedOn { get; set; }

        [Display(Name = "Updated By")]
        public long UpdatedBy { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}
