using System.Collections.Generic;

namespace TheHopeless.API.Database.Entities
{

    public class Product:BaseEntity
    {
        
        //attributes
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description{get; set; }
        public bool Sellable { get; set; }
        
        //FKs
        public int GroupId { get; set; }
        //Foreign entities
        public ProductGroup Group { get;set; }

        public ICollection<Picture> Pictures { get; set; }
        public ICollection<ProductAttribute> Values { get; set; }
    }
}
