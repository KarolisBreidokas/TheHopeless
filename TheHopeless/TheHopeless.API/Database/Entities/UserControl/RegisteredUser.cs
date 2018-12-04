using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Database.Entities.DeliveryControl;
using TheHopeless.API.Database.Entities.OrdersControl;

namespace TheHopeless.API.Database.Entities.UserControl
{
    public class RegisteredUser:BaseEntity
    {
        //properties
        public string Name { get; set; }
        public string Password { get;set; }
        public string EMail { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
