using ARMSBackend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using Model = ARMSBackend.Models.Model;

namespace ARMSBackend.DTOs
{
    public class AssetReadDto
    {
        public AssetReadDto(Asset asset)
        {
            Id = asset.Id;  
            Name = asset.Name; 
            Properties = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(asset.Properties));
            AssetType = asset.AssetType;
            Model = asset.Model;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "jsonb")]
        public object Properties { get; set; }

        public AssetType? AssetType { get; set; }

        public Model? Model { get; set; }
    }
}
