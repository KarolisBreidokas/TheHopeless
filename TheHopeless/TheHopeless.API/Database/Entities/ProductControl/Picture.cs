using TheHopeless.API.Constants;

namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class Picture:BaseEntity
    {
        //attributes
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public bool Main { get; set; }
        public MimeType Type { get; set; }
        //FKs
        public int ProductId { get; set; }
        //Foreign entities
        public Product BaseProduct { get; set; }
    }
}