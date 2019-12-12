using CmcApi.Core.Classes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CmcApi.Core.Entities
{
    public abstract class BaseEntity : AuditedEntity, IBaseEntity
    {
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            IsDeleted = false;
        }
    }

}
