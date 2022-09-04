namespace ARMSBackend.Models
{
    public class AssetModelItem
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int DBID { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }

    }
}
