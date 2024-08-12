using AutoMapper;
using ExtensionMethodValidation.Extensions;
using ExtensionMethodValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExtensionMethodValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExtensionMethodValidationController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ExtensionMethodValidationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost(Name = "PostExtensionMethodValidation")]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            try
            {
                var validationErrors = productDto.Validate();

                if (validationErrors.Any())
                {
                    return BadRequest(new { Errors = validationErrors });
                }

                var product = _mapper.Map<Product>(productDto);

                Console.WriteLine("Simulating of storing the product in the database.");

                Thread.Sleep(2000);

                Console.WriteLine($"Product with name: {productDto.Name} stored.");

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
