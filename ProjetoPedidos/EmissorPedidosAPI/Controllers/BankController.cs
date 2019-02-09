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
    public class BankController : ControllerBase
    {
        //TODO - TESTAR METHODS
        private readonly IBankRepository _bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBank([FromBody] Bank bank)
        {
            if (await _bankRepository.Create(bank))
                return Ok();

            return BadRequest();
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetAllBanks(int idUser)
        {
            var banks = await _bankRepository.GetAll(idUser);
            return Ok(banks);
        }

        [HttpGet("{idBank}")]
        public async Task<IActionResult> GetBank(int idBank)
        {
            var bank = await _bankRepository.Get(idBank);
            return Ok(bank);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBank([FromBody] Bank bank)
        {
            if (await _bankRepository.Update(bank))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{idBank}")]
        public async Task<IActionResult> DeleteBank(int idBank)
        {
            if (await _bankRepository.Delete(idBank))
                return Ok();

            return BadRequest();
        }
    } 
}
