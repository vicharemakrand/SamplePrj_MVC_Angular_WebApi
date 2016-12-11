using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.EntityModels.Core
{
    [Serializable]
    public abstract class AuditableEntityModel : BaseEntityModel
    {
        public DateTime UpdatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
