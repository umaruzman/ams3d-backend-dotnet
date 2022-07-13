using ARMSBackend.DTOs;
using ARMSBackend.Models;
using ARMSBackend.Repository;
using AutoMapper;
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
        private IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepo = usersRepository;
            this._mapper = mapper;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<ResponseDTO<List<UserReadDto>>> Get()
        {
            try
            {
                var newList = usersRepo.AllUsers();
                    
                return Ok(new ResponseDTO<List<UserReadDto>>(true, _mapper.Map<List<UserReadDto>>(newList)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<ResponseDTO<UserReadDto>> Get(int id)
        {
            try
            {
                User user = usersRepo.GetUser(id);


                return Ok(new ResponseDTO<UserReadDto>(true, _mapper.Map<UserReadDto>(user)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<ResponseDTO<User>> Post([FromBody] UserWriteDto user)
        {
            try
            {
                var newUser = _mapper.Map<User>(user);

                var userRes = usersRepo.AddUser(newUser);

                return Ok(new ResponseDTO<User>(true, userRes));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<ResponseDTO<User>> Put(int id, [FromBody] UserEditDto value)
        {
            try
            {
                return Ok(new ResponseDTO<User>(true, usersRepo.UpdateUser(id, value)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult<ResponseDTO> Delete(int id)
        {
            try
            {
                if (usersRepo.DeleteUser(id))
                {
                    return Ok(new ResponseDTO(true, "User Deleted Sucessfully"));
                }

                return BadRequest(new ResponseDTO(false, "Failed to delete User"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDTO(false, ex.Message));
            }
        }
    }
}
