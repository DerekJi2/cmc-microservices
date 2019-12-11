using CmcApi.Data.AbstractEntities;
using System.ComponentModel.DataAnnotations;

namespace CmcApi.Data.Entities
{
    public class Vendor: AuditedEntity
    {
        [MaxLength(25)]
        public string  Code { get; set; }

        [MaxLength(25)]
        public string AbnNum { get; set; }

        [MaxLength(255)]
        public string LegalName { get; set; }

        [MaxLength(255)]
        public string BusinessName { get; set; }
    }
}
