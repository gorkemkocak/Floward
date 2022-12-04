using CatalogService.Models;
using CatalogService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productService.GetProducts();

            if (!products.Any())
                return NotFound();

            return Ok(products);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        { 
            var product = _productService.GetProductById(id);

            if (product.Id != id)
                return NotFound();

            return product;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
                return BadRequest();
            
            try
            {
                _productService.UpdateProduct(id, product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_productService.ProductExists(id))
                    return NotFound();
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _productService.SaveProduct(product);
            //return CreatedAtAction("GetProduct", "", product);
            return Ok("sad");

            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = new Product
            {
                Id = id
            };
            _productService.DeleteProduct(product);

            return NoContent();
        }
    }
}
