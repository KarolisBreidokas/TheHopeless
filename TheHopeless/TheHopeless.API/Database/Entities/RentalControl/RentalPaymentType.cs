using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Database.Entities.UserControl;

namespace TheHopeless.API.Database.Entities.RentalControl
{
    public class RentalPaymentType:BaseEntity
    {
        //properties
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public bool State { get; set; }
        //FKs
        public int AdministratorId { get; set; }
        //Forein entities
        public Administrator Administers { get; set; }

        public ICollection<RentalAggrement> Agreements { get; set; }
    }
}
