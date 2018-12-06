using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheHopeless.API.Constants;
using TheHopeless.API.Contracts.ProductController;
using TheHopeless.API.Services;

namespace TheHopeless.API.Controllers
{

    [Route("api/Products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        [HttpGet]
        
        [Produces(typeof(ICollection<ProductDto>))]
        public async Task<IActionResult> Get()
        {
            var results = await _service.Get();

            return Ok(results);
        }

        [HttpGet("{id}",Name=nameof(RoutingEnum.GetProduct))]
        [Produces(typeof(ProductDto))]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetSpecific(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewProductDto newProduct)
        {
            var createdProduct = await _service.Add(newProduct);
            var productUri = CreateResourceUri(createdProduct.Id);
            return Created(productUri, createdProduct);
        }

        [HttpPut("{id}")]
        [Produces(typeof(ProductDto))]
        public async Task<IActionResult> Put(int id, [FromBody] NewProductDto product)
        {
            var modifiedProduct = await _service.Edit(id, product);
            
            var productUri = CreateResourceUri(modifiedProduct.Id);
            return Accepted(productUri, modifiedProduct);
        }

        [HttpPost("{id}/Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            if (await _service.RemoveFromSale(id))
            {
                return NoContent();
            }
            return NotFound(id);
        }

        private Uri CreateResourceUri(int id)
        {
            return new Uri(Url.Link(nameof(RoutingEnum.GetProduct), new { id = id }));
        }

    }
}
