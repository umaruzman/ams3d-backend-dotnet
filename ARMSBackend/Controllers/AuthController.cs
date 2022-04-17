using ARMSBackend.Models;
using ARMSBackend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ARMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;

        public AuthController(IJWTManagerRepository jWTManagerRepository)
        {
            this._jWTManager = jWTManagerRepository;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Authenticate(User usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
