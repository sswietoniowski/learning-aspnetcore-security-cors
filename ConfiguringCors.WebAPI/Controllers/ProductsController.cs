using ConfiguringCors.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringCors.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IEnumerable<ProductDto> _products = new List<ProductDto>
        {
            new ProductDto { Name = "Product 1", Price = 10 },
            new ProductDto { Name = "Product 2", Price = 20}
        };

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetAll()
        {
            return Ok(_products);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}
