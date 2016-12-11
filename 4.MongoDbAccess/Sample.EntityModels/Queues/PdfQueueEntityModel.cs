using Sample.EntityModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.EntityModels.Queues
{
    [Serializable]
    public class PdfQueueEntityModel : AuditableEntityModel
    {

        [Required]
        public long CriminalId { get; set; }

        [Required]
        public string GeneratedHtml { get; set; }

        [Required]
        public bool ReGenerationRequired { get; set; }

        [Required]
        public bool IsPdfGenerationSucceed { get; set; }

        public string ErrorMessage { get; set; }

    }
}
