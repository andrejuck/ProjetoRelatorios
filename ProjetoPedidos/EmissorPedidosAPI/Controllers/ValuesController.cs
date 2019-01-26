using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmissorPedidosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public ValuesController(ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _companyRepository.GetAll();
            return Ok(companies);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.Get(id);
            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if(ModelState.IsValid)
            {

                if (_userRepository.Create(user))
                    return Ok();
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
