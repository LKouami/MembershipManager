using MembershipManager.Models;
using MembershipManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MembershipManager.Controllers
{
   
        // [Authorize]
        [ApiController]
        [Route("api/v1/[controller]")]
        public class RegionsController : ControllerBase
        {
            private readonly RegionsService _regionsService;

            public RegionsController(RegionsService regionsService) =>
                _regionsService = regionsService;

            [HttpGet]
            public async Task<List<Region>> Get() =>
                await _regionsService.GetAsync();

            [HttpGet("{id:length(24)}")]
            public async Task<ActionResult<Region>> Get(string id)
            {
                var region = await _regionsService.GetAsync(id);

                if (region is null)
                {
                    return NotFound();
                }

                return region;
            }

            [HttpPost]
            public async Task<IActionResult> Post(Region newRegion)
            {
                await _regionsService.CreateAsync(newRegion);

                return CreatedAtAction(nameof(Get), new { id = newRegion.Id }, newRegion);
            }

            [HttpPut("{id:length(24)}")]
            public async Task<IActionResult> Update(string id, Region updatedRegion)
            {
                var region = await _regionsService.GetAsync(id);

                if (region is null)
                {
                    return NotFound();
                }

                updatedRegion.Id = region.Id;

                await _regionsService.UpdateAsync(id, updatedRegion);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public async Task<IActionResult> Delete(string id)
            {
                var region = await _regionsService.GetAsync(id);

                if (region is null)
                {
                    return NotFound();
                }

                await _regionsService.RemoveAsync(id);

                return NoContent();
            }
        }
    }

