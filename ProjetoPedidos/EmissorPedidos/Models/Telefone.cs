using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Models
{
    public class Telefone
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public Empresa Empresa { get; set; }
        public int NumeroTelefone { get; set; }
    }
}
