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
    public class ChartAccountController : ControllerBase
    {
        private readonly IChartAccountRepository _chartAccountRepository;

        public ChartAccountController(IChartAccountRepository chartAccountRepository)
        {
            _chartAccountRepository = chartAccountRepository;
        }

        [HttpGet("{idChartAccount}")]
        public IActionResult GetChartAccount(int idChartAccount)
        {
            var chartAccount = _chartAccountRepository.Get(idChartAccount);
            return Ok(chartAccount);
        }

        [HttpGet("{idUser}")]
        public IActionResult GetChartAccounts(int idUser)
        {
            var chartAccount = _chartAccountRepository.GetAll(idUser);
            return Ok(chartAccount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChartAccount([FromBody] ChartAccount chartAccount)
        {
            if (ModelState.IsValid)
            {

                if (await _chartAccountRepository.Create(chartAccount))
                    return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{idChartAccount}")]
        public async Task<IActionResult> DeleteChartAccount(int idChartAccount)
        {
            if (await _chartAccountRepository.Delete(idChartAccount))
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateChartAccount([FromBody] ChartAccount chartAccount)
        {
            if (ModelState.IsValid)
            {
                if (await _chartAccountRepository.Update(chartAccount))
                    return Ok();
            }

            return BadRequest();
        }
    }
}
