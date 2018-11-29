using TheHopeless.API.Constants;

namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class Picture:BaseEntity
    {
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public bool Main { get; set; }
        public MimeType Type { get; set; }
        public int ProductId { get; set; }
        
        public Product BaseProduct { get; set; }
    }
}