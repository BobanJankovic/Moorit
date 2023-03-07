using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RolesController(IRoleRepository bookingRepository)
        {
            _roleRepository = bookingRepository;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllRoles()
        {
            var records = await _roleRepository.GetAllRolesAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById([FromRoute] int id)
        {
            var records = await _roleRepository.GetRoleByIdAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }
    }
}
