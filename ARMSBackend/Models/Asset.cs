using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARMSBackend.Models
{
    public class Asset
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "jsonb")]
        public object Properties { get; set; }

        public int? AssetTypeId { get; set; }
        public AssetType? AssetType { get; set; }

        public int? ModelId { get; set; }
        public Model? Model { get; set; }
    }
}