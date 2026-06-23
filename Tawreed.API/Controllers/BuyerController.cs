using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tawreed.BLL.Dtos.Buyer;
using Tawreed.BLL.Services.BuyerService;

namespace Tawreed.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuyerController : ControllerBase
{
    private readonly IBuyerService _buyerService;

    public BuyerController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBuyers()
    {
        var res = await _buyerService.GetAllBuyersAsync();

        if (res == null)
            return NotFound();

        return Ok(res);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetBuyerById([FromRoute] Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest();

        var res = await _buyerService.GetBuyerByUserId(userId);

        if (res == null)
            return NotFound();

        return Ok(res);
    }


    [HttpPut("{userId:guid}")]
    public async Task<IActionResult> UpdateBuyer([FromRoute] Guid userId, [FromBody] UpdateBuyerDto updateDto)
    {
        if (updateDto == null || userId == Guid.Empty)
            return BadRequest();

        var res = await _buyerService.UpdateBuyer(userId, updateDto);

        if (res == null)
            return NotFound();

        return Ok(res);

    }
    [HttpPatch("{userId:guid}")]
    public async Task<IActionResult> PatchBuyer(
[FromRoute] Guid userId,
[FromBody] PatchBuyerDto patchDto)
    {
        if (userId == Guid.Empty || patchDto == null)
            return BadRequest();

        var res = await _buyerService.PatchBuyerAsync(userId, patchDto);

        if (res == null)
            return NotFound();

        return Ok(res);
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> DeleteBuyer([FromRoute] Guid userId)
    {
        if (userId == Guid.Empty)
            return BadRequest();

        var res = await _buyerService.DeleteBuyerAsync(userId);

        if (res)
            return Ok("Buyer Deleted Successfully");

        return NotFound();

    }
}
