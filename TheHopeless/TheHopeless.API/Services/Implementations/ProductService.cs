using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Database;
using TheHopeless.API.Database.Entities.ProductControl;
using Attribute = TheHopeless.API.Database.Entities.ProductControl.Attribute;


namespace TheHopeless.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly EshopDbContext _context;
        private readonly DbSet<Product> _products;
        private readonly DbSet<Attribute> _attributes;
        private readonly IMapper _mapper;
        public ProductService(EshopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _products = context.Products;
            _attributes = context.Attributes;
        }
        
        public async Task<ICollection<ProductDto>> Get()
        {
            var ans = await IncludeDependencies().ToListAsync();
            return _mapper.Map<ICollection<ProductDto>>(ans);
        }

        private IQueryable<Product> IncludeDependencies()
        {
            return _products.Include(x => x.Values).ThenInclude(x => x.Attribute).Include(x => x.Pictures);
        }

        public async Task<ProductDto> GetSpecific(int id)
        {

            var ans = await IncludeDependencies().Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDto>(ans);
        }

        public async Task<ProductDto> Add(NewProductDto newProduct)
        {
            var entity = _mapper.Map<Product>(newProduct);
            await MapAttriubes(entity.Values);
            _products.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(entity); ;

        }

        private async Task MapAttriubes(ICollection<ProductAttribute> entityValues)
        {
            foreach (var attribute in entityValues)
            {
                var dbattribute =await _attributes.FirstOrDefaultAsync(x => x.Name == attribute.Attribute.Name);
                if (!(dbattribute is null))
                {
                    attribute.AttributeId = dbattribute.Id;
                    attribute.Attribute = null;
                }
            }
        }

        public async Task<ProductDto> Edit(int id, NewProductDto product)
        {
            var entity = await IncludeDependencies().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                return null;
            }

            _context.Update(entity);
            _mapper.Map(product, entity);
            await MapAttriubes(entity.Values);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<bool> RemoveFromSale(int id)
        {
            var entity = await IncludeDependencies().Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entity is null)
            {
                return false;
            }
            
            _context.Update(entity);
            entity.Sellable = false;
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
