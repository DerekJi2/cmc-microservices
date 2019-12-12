using System;

namespace CmcApi.Database.Entity
{
    public abstract class AuditedEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
