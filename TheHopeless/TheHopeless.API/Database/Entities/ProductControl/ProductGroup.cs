using System.Collections.Generic;

namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class ProductGroup:BaseEntity
    {
        //attributes
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<GroupAttribute> Attributes { get; set; }
    }
}