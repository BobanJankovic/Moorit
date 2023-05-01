using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Moorit.Models;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User,Admin")] 
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllLocations()
        {
            var records = await _locationRepository.GetAllLocationsAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById([FromRoute] int id)
        {
            var records = await _locationRepository.GetLocationByIdAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewLocation([FromBody] LocationModel locationModel)
        {
            var id = await _locationRepository.AddLocationAsync(locationModel);
            return CreatedAtAction(nameof(GetLocationById), new { id = id, controller = "locations" }, id);
        }

        [HttpPut("putUpdateLocationAsync/{locationId}")]
        public async Task<IActionResult> PutUpdateLocationAsync([FromRoute] int locationId, [FromBody] LocationModel locationModel)
        {
            await _locationRepository.PutUpdateLocationAsync(locationId, locationModel);

            return Ok(true);
        }


        [HttpDelete("deleteLocationAsync/{id}")]
        public async Task<IActionResult> DeleteLocationAsync(int Id)
        {

            await _locationRepository.DeleteLocationAsync(Id);
            return Ok(true);
        }
    }
}
