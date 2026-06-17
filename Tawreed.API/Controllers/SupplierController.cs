using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Dtos.Supplier;
using Tawreed.BLL.Services.SupplierService;

namespace Tawreed.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var res = await _supplierService.GetAllSuppliers();

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetSupplierById(Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest();

            var res = await _supplierService.GetSupplierByUserId(userId);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDto createDto)
        {
            throw new NotImplementedException();
        }


        [HttpPut("{userId:guid}")]
        public async Task<IActionResult> UpdateSupplier([FromRoute] Guid userId, [FromBody] UpdateSupplierDto updateDto)
        {
            if (userId == Guid.Empty || userId != updateDto.UserId)
                return BadRequest();

            var res = await _supplierService.UpdateSupplier(userId, updateDto);

            if (res == null)
                return NotFound();

            return Ok(res);
        }


        [HttpDelete("{userId:guid}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
