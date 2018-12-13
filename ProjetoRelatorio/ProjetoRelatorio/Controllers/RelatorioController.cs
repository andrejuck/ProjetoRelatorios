using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
    }
}
