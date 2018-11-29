namespace TheHopeless.API.Database.Entities.ProductControl
{
    public class ProductAttribute
    {
        //Values
        public string Value { get;set; }
        //FKs
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        //Foreign Entities
        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
    }
}