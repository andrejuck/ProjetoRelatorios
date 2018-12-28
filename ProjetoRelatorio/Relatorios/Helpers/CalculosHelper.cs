using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relatorios.Helpers
{
    public class CalculosHelper
    {
        /// <summary>
        /// Método criado para padronizar o calculo de valor total do Pedido. Se for passado paramêtro nulo, será atribuído o valor 0(zero)
        /// para o mesmo.
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="juros"></param>
        /// <param name="desconto"></param>
        /// <param name="multa"></param>
        /// <returns></returns>
        public decimal CalculaValorTotal(decimal valor = 0, decimal juros = 0, decimal desconto = 0, decimal multa = 0)
        {
            var resultado = valor + juros + multa - desconto;

            return resultado;
        }
    }
}
