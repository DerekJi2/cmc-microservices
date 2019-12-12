using System.ComponentModel.DataAnnotations;

namespace CmcApi.Database.Entity
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
