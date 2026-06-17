using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Dtos.Product;
using Tawreed.BLL.Services.ProductService;

namespace Tawreed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductsController(
       IProductService service,
       IValidator<CreateProductDto> createValidator,
       IValidator<UpdateProductDto> updateValidator,
       IValidator<PatchProductDto> patchValidator) : ControllerBase
    {
        private readonly IProductService _service = service;
        private readonly IValidator<CreateProductDto> _createValidator = createValidator;
        private readonly IValidator<UpdateProductDto> _updateValidator = updateValidator;
        private readonly IValidator<PatchProductDto> _patchValidator = patchValidator;

        // GET api/products
        [HttpGet]
        
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAllAsync();
            return Ok(products);
        }

        // GET api/products/category/{categoryId}
        [HttpGet("category/{categoryId:guid}")]
        public async Task<IActionResult> GetByCategory(Guid categoryId)
        {
            var products = await _service.GetByCategoryAsync(categoryId);
            return Ok(products);
        }

        // GET api/products/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _service.GetByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        // POST api/products
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                var created = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT api/products/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                var updated = await _service.UpdateAsync(id, dto);
                return updated is null ? NotFound() : Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // DELETE api/products/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
        // PATCH api/products/{id}
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchProductDto dto)
        {
            var validation = await _patchValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            try
            {
                var patched = await _service.PatchAsync(id, dto);
                return patched is null ? NotFound() : Ok(patched);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
