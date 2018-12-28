using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios
{
    public class RelatorioVendasBaseModel
    {
        public int? IdPedido { get; set; }
        public int? NumeroPedido { get; set; }
        public int? IdNotaFiscal { get; set; }
        public int? NotaFiscal { get; set; }

    }
}
