using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios
{
    public class RelatorioVendedorTitulosAbertos 
    {
        public RelatorioVendedorTitulosAbertos()
        {
        }       

        public string Usuario { get; set; }
        public decimal TitulosAbertos { get; set; }
        public decimal TitulosTotais { get; set; }
        public decimal IndiceEmAberto { get; set; }
    }
}
