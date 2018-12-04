using System;

namespace TheHopeless.API.Database.Entities.OrdersControl
{
    public class Order : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        //FKs
        public int? CurrierId { get; set; }
    }
}
