using AutoMapper;
using LightWeightValidationAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LightWeightValidationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LightWeightValidationController : ControllerBase
    {
        private readonly IMapper _mapper;

        public LightWeightValidationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost(Name = "LightWeightValidationValidation")]
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

            // Checking if for example the supplier e-mail and price is valid here
            // or set this validation in the Product class...?

            var product = _mapper.Map<Product>(productDto);

            Console.WriteLine("Simulating of storing the product in the database.");

            Thread.Sleep(2000);

            Console.WriteLine($"Product with name: {product.Name} stored.");

            Console.WriteLine("End simulating of storing the product in the database.");

            return Ok();
        }
    }
}
