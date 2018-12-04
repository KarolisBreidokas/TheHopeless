using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Database.Entities.OrdersControl;

namespace TheHopeless.API.Database.Entities.DeliveryControl
{
    public class Curier:BaseEntity
    {
        //attribues
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        public ICollection<Order> AssignedOrders { get; set; }
    }

}
