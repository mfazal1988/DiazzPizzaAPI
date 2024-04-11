using System;

namespace DPizza.Domain.Common
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
