using ARMSBackend.DTOs;
using ARMSBackend.Models;
using ARMSBackend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARMSBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUsersRepository usersRepo;


        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepo = usersRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<List<UserDTO>> Get()
        {
            List<UserDTO> newList = usersRepo.AllUsers().Select(u => new UserDTO(u)).ToList();

            return Ok(newList);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            User user = usersRepo.GetUser(id);

            return Ok(new UserDTO(user));
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
