using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoRelatorio.Contexto;
using ProjetoRelatorio.Interfaces;
using ProjetoRelatorio.Models;
using ProjetoRelatorio.Repositorios;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly IRelatorioRepository _relRepo;

        public RelatorioController(IRelatorioRepository relRepo)
        {
            _relRepo = relRepo;
        }

        public IActionResult Index ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData(DataTableParameters dtParams)
        {
            List<RelatorioVendedorTitulosAbertos> data = _relRepo.GetRelatorioVendedorTitulos();

            return Json(new { data });
        }  
    }
}
