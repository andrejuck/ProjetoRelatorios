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
    public class ExpenseController : ControllerBase
    {
        //TODO - TESTAR METODOS
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] Expense expense)
        {
            if (await _expenseRepository.Create(expense))
                return Ok();

            return BadRequest();
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetAllExpenses(int idUser)
        {
            var expenses = await _expenseRepository.GetAll(idUser);
            return Ok(expenses);
        }

        [HttpGet("{idExpense}")]
        public async Task<IActionResult> GetExpense(int idExpense)
        {
            var expense = await _expenseRepository.Get(idExpense);
            return Ok(expense);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExpense([FromBody] Expense expense)
        {
            if (await _expenseRepository.Update(expense))
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{idExpense}")]
        public async Task<IActionResult> DeleteExpense(int idExpense)
        {
            if (await _expenseRepository.Delete(idExpense))
                return Ok();

            return BadRequest();
        }
    }
}
