using ARMSBackend.DTOs;
using ARMSBackend.Models;
using ARMSBackend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult<ResponseDTO<List<User>>> Get()
        {
            try
            {
                List<User> newList = usersRepo.AllUsers();

                return Ok(new ResponseDTO<List<User>>(true, newList));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<ResponseDTO<User>> Get(int id)
        {
            try
            {
                User user = usersRepo.GetUser(id);

                return Ok(new ResponseDTO<User>(true, user));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<ResponseDTO<User>> Post([FromBody] User user)
        {
            try
            {
                User newUser = usersRepo.AddUser(user);

                return Ok(new ResponseDTO<User>(true, user));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
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
