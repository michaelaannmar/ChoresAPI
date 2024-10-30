using ChoresAPI.Models;
using ChoresAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChoresAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        public readonly IChoreService _choreService;
       
        public ChoreController(IChoreService choreService) {
            _choreService = choreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chore>>> GetChores()
        {
            var chores = await _choreService.GetAllChoresAsync();

            return Ok(chores);
        }

        [HttpPost]
        public async Task<ActionResult> AddChore([FromBody]Chore chore)
        {
            chore.Id = Guid.NewGuid();

            await _choreService.AddChoreAsync(chore);

            return CreatedAtAction(nameof(GetChore), new { id = chore.Id }, chore);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChore(Guid id)
        {
            try
            {
                var chore = await _choreService.GetChoreByIdAsync(id);
                return Ok(chore); //return 200 OK with the coffee object
            }
            catch (KeyNotFoundException)
            {
                return NotFound(); // Return 404 if coffee is not found
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the coffee."); // Return 500 for any server error
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChore(Guid id, [FromBody] Chore chore)
        {
            if (id != chore.Id)
            {
                return BadRequest();
            }

            await _choreService.UpdateChoreAsync(chore);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChore(Guid id)
        {
            await _choreService.DeleteChoreAsync(id);
            return NoContent();
        }

       
        

    }
}
