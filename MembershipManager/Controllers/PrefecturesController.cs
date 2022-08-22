using MembershipManager.Models;
using MembershipManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MembershipManager.Controllers
{
   
        // [Authorize]
        [ApiController]
    [Route("api/v1/[controller]")]
        public class PrefecturesController : ControllerBase
        {
            private readonly PrefecturesService _prefecturesService;

            public PrefecturesController(PrefecturesService prefecturesService) =>
                _prefecturesService = prefecturesService;

            [HttpGet]
            public async Task<List<Prefecture>> Get() =>
                await _prefecturesService.GetAsync();

            [HttpGet("{id:length(24)}")]
            public async Task<ActionResult<Prefecture>> Get(string id)
            {
                var prefecture = await _prefecturesService.GetAsync(id);

                if (prefecture is null)
                {
                    return NotFound();
                }

                return prefecture;
            }

            [HttpPost]
            public async Task<IActionResult> Post(Prefecture newPrefecture)
            {
                await _prefecturesService.CreateAsync(newPrefecture);

                return CreatedAtAction(nameof(Get), new { id = newPrefecture.Id }, newPrefecture);
            }

            [HttpPut("{id:length(24)}")]
            public async Task<IActionResult> Update(string id, Prefecture updatedPrefecture)
            {
                var prefecture = await _prefecturesService.GetAsync(id);

                if (prefecture is null)
                {
                    return NotFound();
                }

                updatedPrefecture.Id = prefecture.Id;

                await _prefecturesService.UpdateAsync(id, updatedPrefecture);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public async Task<IActionResult> Delete(string id)
            {
                var prefecture = await _prefecturesService.GetAsync(id);

                if (prefecture is null)
                {
                    return NotFound();
                }

                await _prefecturesService.RemoveAsync(id);

                return NoContent();
            }
        }
    }

