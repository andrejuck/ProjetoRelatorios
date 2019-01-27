using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmissorPedidosAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Pass idCompany as a parameter
        /// </summary>
        /// <param name="idCompany"></param>
        /// <returns></returns>
        [HttpGet("{id}")]        
        public IActionResult GetUsersFromCompany(int id)
        {
            var users = _userRepository.GetUsersFromCompany(id);
            return Ok(users);
        }

        //GET /api/user/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.Get(id);
            return Ok(user);
        }

        // POST api/user/createUser
        [HttpPost]                
        public IActionResult CreateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {

                if (_userRepository.Create(user))
                    return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                if (_userRepository.Update(user))
                    return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userRepository.Delete(id))
                return Ok();

            return BadRequest();
        }
    }
}