using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Models
{
    public class Empresas
    {
        public int Id { get; set; }
        public IList<EmpresaUsuario> Usuarios { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public int Inscricao { get; set; }
        public int InscricaoEstadual { get; set; }
        public string Contato { get; set; }
        public IList<Enderecos> Endereco { get; set; }
        public string Email { get; set; }

    }
}
