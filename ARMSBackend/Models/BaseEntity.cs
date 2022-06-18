using System;

namespace ARMSBackend.Models
{
    public class BaseEntity
    {
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set;  }
    }
}