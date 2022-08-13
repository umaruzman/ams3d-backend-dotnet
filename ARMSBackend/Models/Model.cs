using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSBackend.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string ModelIdentifier { get; set; }
        public string ModelName { get; set; }

        [Column(TypeName = "jsonb")]
        public object ModelDetails { get; set; }
    }
}
