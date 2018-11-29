using System.Collections.Generic;
using TheHopeless.API.Database.Entities.ProductControl;

namespace TheHopeless.API.Database.Entities
{
    public class Attribute:BaseEntity
    {
        //Attributes
        public string Name{get; set; }

        public ICollection<GroupAttribte> Groups { get; set; }
        public ICollection<ProductAttribute> Attributes { get; set; }
    }
}