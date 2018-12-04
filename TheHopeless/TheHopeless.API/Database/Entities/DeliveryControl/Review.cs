using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Database.Entities.DeliveryControl
{
    public class Review:BaseEntity
    {
        //properties
        public double Score { get; set; }
        public string Comment { get; set; }
        //FKs
        public int CommenterId { get; set; }
        //Foreign entities
        public RegisteredUser Comenter { get; set; }
    }
}
