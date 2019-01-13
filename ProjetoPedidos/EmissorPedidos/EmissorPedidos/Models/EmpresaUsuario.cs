using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Models
{
    public class EmpresaUsuario
    {
        public int EmpresaId { get; set; }
        public int UsuarioId { get; set; }
        public Empresas Empresa { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
