using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidos.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmissorPedidos.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IPaisRepository _paisRepository;

        public EmpresaController(IEstadoRepository estadoRepository,
            IPaisRepository paisRepository)
        {
            _estadoRepository = estadoRepository;
            _paisRepository = paisRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEstados()
        {
            var retorno = _estadoRepository.CarregarTodosEstados();

            return Json(retorno);
        }

        [HttpGet]
        public JsonResult GetPaises()
        {
            var retorno = _paisRepository.CarregarTodosPaises();

            return Json(retorno);
        }
    }
}