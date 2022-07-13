using Swashbuckle.AspNetCore.Annotations;
using System;

namespace ARMSBackend.Models
{
    public class BaseEntity
    {
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? CreatedAt { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? LastUpdate { get; set;  }
    }
}