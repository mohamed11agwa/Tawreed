using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Dtos.Reigon;
using Tawreed.BLL.Services.RegionService;

namespace Tawreed.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController(IRegionService service) : ControllerBase
    {
        private readonly IRegionService _service = service;

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
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/regions/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateRegionDto dto)
        {
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
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Patch(Guid id, [FromBody] PatchRegionDto dto)
        {
            var patched = await _service.PatchAsync(id, dto);
            return patched is null ? NotFound() : Ok(patched);
        }
    }

}
