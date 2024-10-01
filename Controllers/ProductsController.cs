using Microsoft.AspNetCore.Mvc;
using repository_template.Data;
using repository_template.Models;
using repository_template.Repositories.Interfaces;

namespace repository_template.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductRepository _repository;

        public ProductsController(ApplicationDbContext context, IProductRepository repository) 
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _repository.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var newProduct = await _repository.AddProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _repository.DeleteProduct(id);
            return NoContent();
        }
    }
}
