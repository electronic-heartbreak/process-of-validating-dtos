using BuiltInValidationAPI.DTOs;
using BuiltInValidationAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExtensionMethodValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtensionMethodValidationController : ControllerBase
    {
        [HttpPost(Name = "PostBuiltInValidation")]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            try
            {         
                var product = productDto.ToDomain();

                Console.WriteLine("Simulating of storing the product in the database.");

                Thread.Sleep(2000);

                Console.WriteLine($"Product with name: {product.Name} stored.");

                Console.WriteLine("End simulating of storing the product in the database.");

                return Ok();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                return StatusCode(500);
            }
        }
    }
}
