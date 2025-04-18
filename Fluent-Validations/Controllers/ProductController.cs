using Fluent_Validations.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fluent_Validations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        public ProductController(IValidator<Product> validator)
        {
            _validator = validator;
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var validationResult = _validator.Validate(product);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            // If validation is successful, save to database or perform your logic
            return Ok(new { message = "Product created successfully" });
        }
    }
}
