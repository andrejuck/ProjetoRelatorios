using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios
{
    public class RelatorioVendedorTitulosAbertos : RelatorioVendasBaseModel
    {
        #region Colunas
        public string Usuario { get; set; }

        public decimal TitulosAbertos { get; set; }

        public decimal TitulosTotais { get; set; }

        public decimal IndiceEmAberto { get; set; }
        #endregion

        public decimal ValorConta { get; set; }

        public decimal Multa { get; set; }

        public decimal Juros { get; set; }

        public decimal Desconto { get; set; }

        public decimal ValorPago { get; set; }


        public RelatorioVendedorTitulosAbertos()
        {

        }

    }
}
