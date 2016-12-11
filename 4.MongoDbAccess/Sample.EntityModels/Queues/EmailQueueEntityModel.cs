using Sample.EntityModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.EntityModels.Queues
{
    [Serializable]
    public class EmailQueueEntityModel : AuditableEntityModel
    {

        [Required]
        public string FromEmailId { get; set; }

        [Required]
        public string ToEmailId { get; set; }

        [Required]
        public string EmailSubject { get; set; }

        [Required]
        public string MessageBody { get; set; }

        public string AttachedFiles { get; set; }

        [Required]
        public bool IsSucceedEmailSent { get; set; }

        public string ErrorMessage { get; set; }

    }
}
