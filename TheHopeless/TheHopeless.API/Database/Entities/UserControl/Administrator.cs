using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Database.Entities.RentalControl;

namespace TheHopeless.API.Database.Entities.UserControl
{
    public class Administrator
    {
        //FKs
        public int UserId { get; set; }
        //Foregn Entities
        public RegisteredUser User { get; set; }

        public ICollection<AdministratorPrivilege> Privileges { get; set; }
        public ICollection<RentalAggrement> Aggrements { get; set; }
        public ICollection<RentalPaymentType> PaymentTypes { get; set; }
    }
}
