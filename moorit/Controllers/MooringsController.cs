using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;
using Moorit.Models;
using Microsoft.AspNetCore.Authorization;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User,Admin")]
    public class MooringsController : ControllerBase
    {
        private readonly IMooringRepository _mooringRepository;
        public MooringsController(IMooringRepository bookingRepository)
        {
            _mooringRepository = bookingRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoorings([FromQuery] string startDate, string endDate)
        {
            var records = await _mooringRepository.GetAllMooringsAsync(startDate,endDate);
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMooringById([FromRoute] int id)
        {
            var records = await _mooringRepository.GetMooringByIdAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewMooring([FromBody] MooringModel mooringModel)
        {
            var id = await _mooringRepository.AddMooringAsync(mooringModel);
            return CreatedAtAction(nameof(GetMooringById), new { id = id, controller = "moorings" }, id);
        }

        [HttpDelete("deleteMooringAsync/{id}")]
        public async Task<IActionResult> DeleteMooringAsync(int Id)
        {

            await _mooringRepository.DeleteMooringAsync(Id);
            return Ok(true);
        }
    }
}
