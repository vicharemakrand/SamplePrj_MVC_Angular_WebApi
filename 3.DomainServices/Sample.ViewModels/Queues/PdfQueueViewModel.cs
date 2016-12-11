using Sample.ViewModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.ViewModels
{
    [Serializable]
    public class PdfQueueViewModel : AuditableViewModel
    {
        [Required]
        public long CriminalId { get; set; }

        [Required]
        public string GeneratedHtml { get; set; }

        [Required]
        public bool ReGenerationRequired { get; set; }

        [Required]
        public bool IsPdfGenerationSucceed { get; set; }

        [Required]
        public string ErrorMessage { get; set; }

    }
}
