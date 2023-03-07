using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moorit.Models;
using Moorit.Repository;

namespace Moorit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
       public readonly IAccountRepository _accountRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            IAccountRepository accountRepository,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger
            )
        {
            _accountRepository = accountRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
        
    }

        [HttpPost("signUp")]
        public async Task<ActionResult> SignUp([FromBody]SignUpModel signUpModel)
        {
            var result = await _accountRepository.SignUpAsync(signUpModel);
            String userRole = "User";

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(signUpModel.Email);
                if (user == null)
                {
                    _logger.LogInformation($"The role {signUpModel.Email} has not been added, user doesn't exist");
                    return BadRequest(new { error = "User doesn't exist" });
                }
                var roleExist = await _roleManager.RoleExistsAsync(userRole);
                if (!roleExist)
                {

                    _logger.LogInformation("The role not exist");
                    return BadRequest(new { error = "The role not exist" });

                }
                var resultRole = await _userManager.AddToRoleAsync(user, userRole);


                if (!resultRole.Succeeded)
                {

                    _logger.LogInformation("Role is not assigned to the user");
                    return BadRequest(new { error = "Role is not assigned to the user" });

                }
             

                return Ok(result.Succeeded);
            }
            // Treba izhendlati neke osnovne greske koje identity vraca
            // imaso sam nesto sa passwordom ali je vratilo unauthorized, sto nije dobro.
            return Unauthorized();

        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }

    }
}
