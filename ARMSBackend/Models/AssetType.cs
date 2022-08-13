using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSBackend.Models
{
    public class AssetType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        [Column(TypeName = "jsonb")]
        public object? DefaultProperties { get; set; }

    }
}
