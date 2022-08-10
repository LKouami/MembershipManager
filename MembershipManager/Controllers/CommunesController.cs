using MembershipManager.Models;
using MembershipManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MembershipManager.Controllers
{
        [Authorize]
        [ApiController]
        [Route("api/v1/[controller]")]
        public class CommunesController : ControllerBase
        {
            private readonly CommunesService _communesService;

            public CommunesController(CommunesService communesService) =>
                _communesService = communesService;

        
            [HttpGet]
            public async Task<List<Commune>> Get() =>
                await _communesService.GetAsync();

            [HttpGet("{id:length(24)}")]
            public async Task<ActionResult<Commune>> Get(string id)
            {
                var commune = await _communesService.GetAsync(id);

                if (commune is null)
                {
                    return NotFound();
                }

                return commune;
            }

            [HttpPost]
            public async Task<IActionResult> Post(Commune newCommune)
            {
                await _communesService.CreateAsync(newCommune);

                return CreatedAtAction(nameof(Get), new { id = newCommune.Id }, newCommune);
            }

            [HttpPut("{id:length(24)}")]
            public async Task<IActionResult> Update(string id, Commune updatedCommune)
            {
                var commune = await _communesService.GetAsync(id);

                if (commune is null)
                {
                    return NotFound();
                }

                updatedCommune.Id = commune.Id;

                await _communesService.UpdateAsync(id, updatedCommune);

                return NoContent();
            }

            [HttpDelete("{id:length(24)}")]
            public async Task<IActionResult> Delete(string id)
            {
                var commune = await _communesService.GetAsync(id);

                if (commune is null)
                {
                    return NotFound();
                }

                await _communesService.RemoveAsync(id);

                return NoContent();
            }
        }
    }

