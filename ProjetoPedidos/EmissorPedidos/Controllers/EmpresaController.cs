using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmissorPedidos.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IEmpresaRepository _empresaRepository;

        
        public EmpresaController(IEstadoRepository estadoRepository, IPaisRepository paisRepository,
            IEmpresaRepository empresaRepository)
        {
            _estadoRepository = estadoRepository;
            _paisRepository = paisRepository;
            _empresaRepository = empresaRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult SalvarEmpresa(Empresa empresa)
        {
            var idEmpresa = _empresaRepository.SalvarCadastroEmpresa(empresa);

            return Json(new { });
        }

        //[HttpPost]
        //public IActionResult SalvarEnderecoEmpresa(Enderecos endereco)
        //{

        //}
    }
}