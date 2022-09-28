using ARMSBackend.DTOs;
using ARMSBackend.Models;
using ARMSBackend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ARMSBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManager;
        private readonly AppContext _context;

        public AuthController(IJWTManagerRepository jWTManagerRepository, AppContext context)
        {
            this._jWTManager = jWTManagerRepository;
            this._context = context;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Authenticate(AuthRequestDTO usersdata)
        {
            var verification = _context.Users.Where(u => u.Username == usersdata.Username || u.Email == usersdata.Username).Where(u => u.Password == usersdata.Password).ToList();

            if(verification.Count == 0)
            {
                return Unauthorized();
            }


            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
