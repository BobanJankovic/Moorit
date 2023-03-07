using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moorit.Data;
using Moorit.Models;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly MooritContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ILogger<SetupController> _logger;
        public SetupController(
            MooritContext context, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ILogger<SetupController> logger)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        }

  
        [HttpGet("")]
        public List<IdentityRole> GetAllRoles() //async Task
        {

            var records = _roleManager.Roles.ToList(); //_bookingRepository.GetAllBookingsAsync();
            return records;
        }



        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            var roleExist = await _roleManager.RoleExistsAsync(name);
            if (!roleExist)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"The Role {name} has been added successfully.");


                    return Ok(new
                    {
                        result = $"The role {name} has been added successfully."
                    });
                }
                else
                {
                    _logger.LogInformation($"The Role {name} has not been added.");
                    return BadRequest(new { error = "Role has not been added" });
                }
            }
            return BadRequest(new { error = "Role already exist" });
        }


        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"The role {email} has not been added, user doesn't exist");
                return BadRequest(new { error = "User doesn't exist" });
            }
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {

                _logger.LogInformation("The role not exist");
                return BadRequest(new { error = "The role not exist" });

            }
            var result = await _userManager.AddToRoleAsync(user, roleName);


            if (result.Succeeded)
            {

                return Ok(new
                {
                    result = $"Success, user has been added to the role."
                });

            }
            else
            {
                _logger.LogInformation("Role is not assigned to the user");
                return BadRequest(new { error = "Role is not assigned to the user" });
            }

        }



        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email) //async Task
        {

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"Can't find the user");
                return BadRequest(new { error = "Can't find the user" });
            }
            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }
    }
}
