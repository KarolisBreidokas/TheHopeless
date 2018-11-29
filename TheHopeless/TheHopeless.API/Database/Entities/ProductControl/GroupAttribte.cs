namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class GroupAttribte
    {
        //FKs
        public int ProductGroupId;
        public int AttributeId;

        public ProductGroup Group { get; set; }
        public Attribute Attribute { get; set; }
    }
}