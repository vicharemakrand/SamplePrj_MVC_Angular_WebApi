using Sample.EntityModels.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sample.EntityModels.Queues
{
    [Serializable]
    public class RequestQueueEntityModel : AuditableEntityModel
    {

        [Required]
        public string SearchParameters { get; set; }

        [Required]
        public bool IsRequestSucceed { get; set; }

        public string ErrorMessage { get; set; }

    }
}
