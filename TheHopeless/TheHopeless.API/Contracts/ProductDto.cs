using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHopeless.API.Contracts
{
    public class ProductDto
    {
        public int Id;
        public string Name;
        public string Description;
        public bool Sellable;
        public ICollection<ProductAttributeDto> Attributes;
        public ICollection<PictureDto> Picture;
    }
}
