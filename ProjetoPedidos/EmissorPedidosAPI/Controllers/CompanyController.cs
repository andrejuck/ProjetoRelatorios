﻿using EmissorPedidosAPI.Models;
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

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        //GET /api/Company
        [HttpGet]
        public IActionResult GetCompanies()
        {

            //var companies = _companyRepository.GetAll();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCompany(int id)
        {

            var company = _companyRepository.Get(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {

            if (await _companyRepository.Create(company))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanly([FromBody] Company company)
        {
            if (await _companyRepository.Update(company))
                return Ok();

            return BadRequest();
        }
    }
}
