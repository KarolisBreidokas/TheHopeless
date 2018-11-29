using System.Collections.Generic;

namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class Attribute:BaseEntity
    {
        //Values
        public string Name{get; set; }

        public ICollection<GroupAttribte> Groups { get; set; }
        public ICollection<ProductAttribute> Values { get; set; }
    }
}