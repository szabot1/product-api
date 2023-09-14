using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<ProductDto> Products = new()
        {
            new ProductDto { Name = "Termek1", Price = 2500 },
            new ProductDto { Name = "Termek2", Price = 5500 },
            new ProductDto { Name = "Termek3", Price = 12500 },
        };

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(Guid id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product is null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDto> Create(CreateProductDto productDto)
        {
            ProductDto product = new()
            {
                Name = productDto.Name,
                Price = productDto.Price,
            };
            Products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> Update(Guid id, UpdateProductDto productDto)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct is null) return NotFound();

            var updatedProduct = existingProduct with
            {
                Name = productDto.Name,
                Price = productDto.Price,
                ModifiedTime = DateTimeOffset.UtcNow,
            };

            var index = Products.FindIndex(p => p.Id == existingProduct.Id);
            Products[index] = updatedProduct;

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var existingProduct = Products.FirstOrDefault(p => p.Id == id);
            if (existingProduct is null) return NotFound();

            Products.Remove(existingProduct);

            return NoContent();
        }
    }
}