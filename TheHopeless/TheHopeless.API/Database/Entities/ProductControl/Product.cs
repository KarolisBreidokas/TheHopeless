using System.Collections.Generic;
using TheHopeless.API.Database.Entities.OrdersControl;
using TheHopeless.API.Database.Entities.RentalControl;

namespace TheHopeless.API.Database.Entities.ProductControl
{

    public class Product : BaseEntity
    {

        //attributes
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Sellable { get; set; }

        public ICollection<Picture> Pictures { get; set; }
        public ICollection<ProductAttribute> Values { get; set; }
        public ICollection<ProductOrder> Orders { get; set; }
        public ICollection<RentalAgreement> Rentals { get; set; }
    }
}
