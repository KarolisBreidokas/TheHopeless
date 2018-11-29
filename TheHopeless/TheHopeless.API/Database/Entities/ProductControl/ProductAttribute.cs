namespace TheHopeless.API.Database.Entities
{
    public class ProductAttribute
    {
        //Attributes
        public string Value { get;set; }
        //FKs
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        //Foreign Entities
        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
    }
}