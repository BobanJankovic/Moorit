using Moorit.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Moorit.Models;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
      
        private readonly UserManager<ApplicationUserModel> _userManager;

        public UsersController( UserManager<ApplicationUserModel> userManager)
        {
         
            _userManager = userManager;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers()
        {
            var records = await _userManager.GetUsersInRoleAsync("User");
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            
            var records = await _userManager.FindByIdAsync(id.ToString());
            if (records == null)
            {
                return NotFound();
            }
            return Ok(records);
        }
    }
}
