using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Database.Entities.ProductControl;

namespace TheHopeless.API.Database.Entities.OrdersControl
{
    public class ProductOrder
    {
        //FKs
        public int ProductId { get;set; }
        public int OrderId { get; set; }
        //Foreign Entities
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
