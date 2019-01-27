using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;

        public CompanyController(ICompanyRepository companyRepository, IUserRepository userRepository)
        {
            _companyRepository = companyRepository;
            _userRepository = userRepository;
        }

        //GET /api/Company
        [HttpGet]
        public IActionResult GetCompanies()
        {

            var companies = _companyRepository.GetAll();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {

            var company = _companyRepository.Get(id);
            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Company company)
        {

            if (_companyRepository.Create(company))
                return Ok();

            return BadRequest();
        }
    }
}
