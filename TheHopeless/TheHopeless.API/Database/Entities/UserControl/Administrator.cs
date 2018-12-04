using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHopeless.API.Database.Entities.UserControl
{
    public class Administrator
    {
        public int UserId { get; set; }

        public RegisteredUser User { get; set; }

        public ICollection<AdministratorPrivilege> Privileges { get; set; }
    }
}
