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

        [HttpGet("{id}")]
        public IActionResult GetChartAccount(int idChart)
        {
            var chartAccount = _chartAccountRepository.Get(idChart);
            return Ok(chartAccount);
        }

        [HttpGet("{id}")]
        public IActionResult GetChartAccounts(int idUser)
        {
            var chartAccount = _chartAccountRepository.GetAll(idUser);
            return Ok(chartAccount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChartAccounts([FromBody] ChartAccount chartAccount)
        {
            if (ModelState.IsValid)
            {

                if (await _chartAccountRepository.Create(chartAccount))
                    return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChartAccount(int idChart)
        {
            if (await _chartAccountRepository.Delete(idChart))
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
