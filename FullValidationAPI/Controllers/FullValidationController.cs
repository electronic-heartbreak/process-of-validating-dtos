using AutoMapper;
using FullValidationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullValidationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FullValidationController : ControllerBase
    {
        private readonly IMapper _mapper;

        public FullValidationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost(Name = "PostFullValidation")]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var product = _mapper.Map<Product>(productDto);

            Console.WriteLine("Simulating of storing the product in the database.");

            Thread.Sleep(2000);

            Console.WriteLine($"Product with name: {product.Name} stored.");

            Console.WriteLine("End simulating of storing the product in the database.");

            return Ok();
        }
    }
}
