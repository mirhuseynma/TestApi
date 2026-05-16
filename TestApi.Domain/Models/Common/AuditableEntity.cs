using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.Domain.Models.Common
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? CreatedBy { get; set; } = string.Empty;
        public string? UpdatedBy { get; set;} = string.Empty;
        public string? DeletedBy { get; set; } = string.Empty;
    }
}
