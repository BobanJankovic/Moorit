using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository bookingRepository)
        {
            _userRepository = bookingRepository;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var records = await _userRepository.GetAllUsersAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var records = await _userRepository.GetUserByIdAsync(id);
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }
    }
}
