using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EmissorPedidos.Areas.Identity.Data;
using EmissorPedidos.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmissorPedidos.Controllers
{
    public class UtilController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IUsuarioRepository _userRepository;
        private readonly IMunicipioRepository _municipioRepository;
        
        public UtilController(IEstadoRepository estadoRepository, IPaisRepository paisRepository,
            IUsuarioRepository userRepository, IMunicipioRepository municipioRepository)
        {
            _estadoRepository = estadoRepository;
            _paisRepository = paisRepository;
            _userRepository = userRepository;
            _municipioRepository = municipioRepository;
        }

        public IActionResult Index()
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

        [HttpGet]
        public JsonResult GetMunicipios()
        {
            var retorno = _municipioRepository.CarregarTodosMunicipios();

            return Json(retorno.OrderBy(o => o.Nome));
        }

        [HttpGet]
        public JsonResult GetUsuarioLogado()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var retorno = _userRepository.CarregarUsuarioLogado(userId);

            return Json(retorno);
        }

    }
}