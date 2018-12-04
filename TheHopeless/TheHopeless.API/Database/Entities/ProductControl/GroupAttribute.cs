namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class GroupAttribute
    {
        //FKs
        public int ProductGroupId { get; set; }
        public int AttributeId { get; set; }
        //Foreign entities
        public ProductGroup Group { get; set; }
        public Attribute Attribute { get; set; }
    }
}