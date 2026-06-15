using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Dtos.Reigon;
using Tawreed.BLL.Services.RegionService;

namespace Tawreed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController(
       IRegionService service,
       IValidator<CreateRegionDto> createValidator,
       IValidator<UpdateRegionDto> updateValidator) : ControllerBase
    {
        private readonly IRegionService _service = service;
        private readonly IValidator<CreateRegionDto> _createValidator = createValidator;
        private readonly IValidator<UpdateRegionDto> _updateValidator = updateValidator;

        // GET api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await _service.GetAllAsync();
            return Ok(regions);
        }

        // GET api/regions/active
        [HttpGet("active")]
        public async Task<IActionResult> GetActive()
        {
            var regions = await _service.GetActiveAsync();
            return Ok(regions);
        }

        // GET api/regions/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var region = await _service.GetByIdAsync(id);
            return region is null ? NotFound() : Ok(region);
        }

        // POST api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/regions/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRegionDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                return BadRequest(validation.Errors.Select(e => e.ErrorMessage));

            var updated = await _service.UpdateAsync(id, dto);
            return updated is null ? NotFound() : Ok(updated);
        }

        // DELETE api/regions/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }

}
