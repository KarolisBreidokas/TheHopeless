namespace TheHopeless.API.Database.Entities.UserControl
{
    public class AdministratorPrivilege
    {
        //FKs
        public int AdministratorId { get; set; }
        public int PrivilegeId { get; set; }
        //Foreign entities
        public Privilege Privilege { get; set; }
        public Administrator Administrator { get; set; }
    }
}