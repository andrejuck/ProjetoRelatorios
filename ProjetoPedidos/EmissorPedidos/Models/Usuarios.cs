using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public NivelUsuario NivelUsuario { get; set; }
        public IList<EmpresaUsuario> Empresas { get; set; }
        public string IdentityId { get; set; }
    }
}
