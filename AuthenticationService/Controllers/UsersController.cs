using AuthenticationService.Models;
using AuthenticationService.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Authorize]
    [Route("api/Users")]
    //[Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(UsersController));
        public UsersController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        /// <summary>
        /// Authnticate the user using username and password
        /// </summary>
        /// <param name="model">Login credentials of user</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            _log4net.Info(" Http POST Request From Authentication method of: " + nameof(UsersController));
            var user = _userRepo.Authenticate(model.Username, model.Password);
            if (user == null)
            {
                _log4net.Error(" bad Request returned From Authentication method of: " + nameof(UsersController));
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            _log4net.Info("data return successfully from authentication method of: " + nameof(UsersController));
            return Ok(user);
        }

      
    }
}
