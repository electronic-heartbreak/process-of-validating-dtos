using AutoMapper;
using FluentValidation;
using FluentValidationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentValidationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FluentValidationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;

        public FluentValidationController(IMapper mapper, IValidator<Product> validator)
        {
            _mapper = mapper;
            _validator = validator;
        }

        [HttpPost(Name = "PostFluentValidation")]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] CreateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest();
            }

            try
            {
                var product = _mapper.Map<Product>(productDto);

                await _validator.ValidateAndThrowAsync(product);

                Console.WriteLine("Simulating of storing the product in the database.");

                Thread.Sleep(2000);

                Console.WriteLine($"Product with name: {product.Name} stored.");

                Console.WriteLine("End simulating of storing the product in the database.");

                return Ok();
            }
            catch (ValidationException ex)
            {
                return UnprocessableEntity(ex.Errors);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                
                return StatusCode(500);
            }
        }
    }
}
