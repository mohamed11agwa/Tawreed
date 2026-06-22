using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Dtos.GroupOrderParticipants;
using Tawreed.BLL.Services.GroupOrderParticipants;

namespace Tawreed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupOrderParticipantsController(IGroupOrderParticipantService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupOrderParticipantDto>>> GetAll()
        {
            var result = await service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GroupOrderParticipantDto>> GetById(Guid id)
        {
            var result = await service.GetByIdAsync(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GroupOrderParticipantDto>> Create(CreateGroupOrderParticipantDto dto)
        {
            var result = await service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GroupOrderParticipantDto>> Update(Guid id, UpdateGroupOrderParticipantDto dto)
        {
            if (id != dto.Id)
                return BadRequest("Route id and body id do not match.");

            var result = await service.UpdateAsync(dto);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await service.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
