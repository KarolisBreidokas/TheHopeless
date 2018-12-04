using System;
using System.Collections.Generic;
using TheHopeless.API.Constants;
using TheHopeless.API.Database.Entities.DeliveryControl;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Database.Entities.OrdersControl
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        //FKs
        public int? CurrierId { get; set; }
        public int UserId{get; set; }
        //Foreign entities
        public Curier AssignedCurier { get; set; }
        public RegisteredUser User { get; set; }

        public ICollection<ProductOrder> Products { get; set; }

    }
}
