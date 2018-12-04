using System;
using TheHopeless.API.Database.Entities.DeliveryControl;

namespace TheHopeless.API.Database.Entities.OrdersControl
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        //FKs
        public int? CurrierId { get; set; }
        //Foreign entities
        public Curier AssignedCurier { get; set; }
    }
}
