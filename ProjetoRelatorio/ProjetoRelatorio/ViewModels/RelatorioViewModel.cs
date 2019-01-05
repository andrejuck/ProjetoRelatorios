using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.ViewModels
{
    public class RelatorioViewModel
    {
        public RelatorioViewModel()
        {

        }
        public RelatorioViewModel(decimal valor, decimal juros,
            decimal multa, decimal desconto, decimal valorPago)
        {
            TitulosTotais = CalculaTitulosTotais(valor, juros, multa, desconto);
            TitulosAbertos = CalculaTitulosAbertos(valorPago);
        }       

        public int IdPedido { get; set; }
        public int IdNotaFiscal { get; set; }
        public decimal TitulosAbertos { get; set; }
        public decimal TitulosTotais { get; set; }
        public decimal IndiceEmAberto { get; set; }
        public string Usuario { get; set; }

        private static decimal CalculaTitulosTotais(decimal valor, decimal juros, decimal multa, decimal desconto)
        {
            return valor + juros + multa - desconto;
        }

        private decimal CalculaTitulosAbertos(decimal valorPago)
        {
            return TitulosTotais - valorPago;
        }

        public decimal CalculaIndiceEmAberto()
        {
            return (TitulosAbertos / TitulosTotais) * 100;
        }

    }
}
