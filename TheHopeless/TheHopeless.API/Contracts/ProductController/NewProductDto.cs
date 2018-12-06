using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheHopeless.API.Contracts.ProductController
{
    public class NewProductDto
    {
        public string Name;
        public string Description;
        public ICollection<NewProductAttributeDto> Attributes;
    }
}
