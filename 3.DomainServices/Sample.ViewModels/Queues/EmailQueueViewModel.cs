using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.ViewModels
{
    [Serializable]
    public class EmailQueueViewModel : AuditableViewModel
    {
        [Required]
        public string fromEmailId { get; set; }

        [Required]
        public string ToEmailId { get; set; }

        [Required]
        public string EmailSubject { get; set; }

        [Required]
        public string MessageBody { get; set; }

        [Required]
        public string AttachedFiles { get; set; }

        [Required]
        public bool IsSucceedEmailSent { get; set; }

        [Required]
        public string ErrorMessage { get; set; }

    }
}
