using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoRelatorio.Contexto;
using ProjetoRelatorio.Models;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly ContextoUtil _context;

        public RelatorioController(ContextoUtil context)
        {
            _context = context;
        }

        public IActionResult Index ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData(DataTableParameters dtParams)
        {
            try
            {
                var data = _context.Pedidos.Select(s => new RelatorioBaseModel { nota_fiscal = s.nota_fiscal, numero_pedido = s.numero_pedido } ).Take(1).ToList();

                return Json(new { data = data });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
