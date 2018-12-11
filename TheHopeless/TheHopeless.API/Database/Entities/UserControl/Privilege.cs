using System.Collections.Generic;

namespace TheHopeless.API.Database.Entities.UserControl
{
    public class Privilege : BaseEntity
    {
        //properties
        public string Name { get; set; }

        public ICollection<AdministratorPrivilege> Administrators { get; set; }
    }
}
