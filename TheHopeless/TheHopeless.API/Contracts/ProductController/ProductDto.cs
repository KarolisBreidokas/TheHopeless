using System.Collections.Generic;

namespace TheHopeless.API.Contracts.ProductController
{
    public class ProductDto
    {
        public int Id;
        public string Name;
        public string Description;
        public bool Sellable;
        public decimal Price;
        public ICollection<ProductAttributeDto> Attributes;
        public ICollection<PictureDto> Picture;
    }
}
