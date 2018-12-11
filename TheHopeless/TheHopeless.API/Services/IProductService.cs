using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Contracts;
using TheHopeless.API.Contracts.ProductController;

namespace TheHopeless.API.Services
{
    public interface IProductService
    {
        Task<ICollection<ProductDto>> Get();
        Task<ProductDto> GetSpecific(int id);
        Task<ProductDto> Add(NewProductDto newProduct);
        Task<ProductDto> Edit(int id,NewProductDto product);
        Task<bool> RemoveFromSale(int id);
    }
}
