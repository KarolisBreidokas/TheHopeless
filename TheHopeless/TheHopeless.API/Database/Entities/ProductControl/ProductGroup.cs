using System.Collections.Generic;
using TheHopeless.API.Database.Entities.ProductControl;

namespace TheHopeless.API.Database.Entities
{
    public class ProductGroup:BaseEntity
    {
        //attributes
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<GroupAttribte> Attribtes { get; set; }
    }
}