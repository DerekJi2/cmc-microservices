using System;

namespace CmcApi.Data.AbstractEntities
{
    public abstract class AuditedEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}
