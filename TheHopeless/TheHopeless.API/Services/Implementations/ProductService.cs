using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Database;
using TheHopeless.API.Database.Entities.ProductControl;

namespace TheHopeless.API.Services.Implementations
{
    public class ProductService:IProductService
    {
        private readonly EshopDbContext _context;
        private readonly DbSet<Product> _products;
        private readonly IMapper _mapper;
        public ProductService(EshopDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _products = context.Products;
        }

        public async Task<ICollection<ProductDto>> Get()
        {
            var ans=await _products.Include(x=>x.Values).ThenInclude(x=>x.Attribute).Include(x=>x.Pictures).ToListAsync();
            return _mapper.Map<ICollection<ProductDto>>(ans);
        }

        public async Task<ProductDto> GetSpecific(int id)
        {

            var ans = await _products.Include(x => x.Values).ThenInclude(x => x.Attribute).Include(x => x.Pictures)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(ans);
        }

        public Task<ProductDto> Add(NewProductDto newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> Edit(int id, NewProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromSale(int id)
        {
            throw new NotImplementedException();
        }
    }
}
