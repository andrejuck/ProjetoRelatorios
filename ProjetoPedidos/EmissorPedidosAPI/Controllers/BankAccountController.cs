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
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountController(IBankAccountRepository bankAccountRepository)
        {
            _bankAccountRepository = bankAccountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBankAccount([FromBody] BankAccount bankAccount)
        {
            if (await _bankAccountRepository.Create(bankAccount))
                return Ok();

            return BadRequest();
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetAllBankAccounts(int idUser)
        {
            var bankAccounts = await _bankAccountRepository.GetAll(idUser);
            return Ok(bankAccounts);
        }

        [HttpGet("{idBankAccount}")]
        public async Task<IActionResult> GetBankAccount(int idBankAccount)
        {
            var bankAccount = await _bankAccountRepository.Get(idBankAccount);
            return Ok(bankAccount);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBankAccount([FromBody] BankAccount bankAccount)
        {
            if (await _bankAccountRepository.Update(bankAccount))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{idBankAccount}")]
        public async Task<IActionResult> DeleteBankAccount(int idBankAccount)
        {
            if (await _bankAccountRepository.Delete(idBankAccount))
                return Ok();

            return BadRequest();
        }
    }
}
