using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoRelatorio.Contexto;
using Relatorios;

namespace ProjetoRelatorio.Repositorios
{
    public class ContasPagarReceberRepository : BaseRepository
    {
        protected ContasPagarReceberRepository(ContextoUtil context) : base(context)
        {
        }

        public List<RelatorioVendedorTitulosAbertos> GetRelatorio()
        {
            var resultado = _context.ContasPagarReceber
                .Where(cpr => cpr.id_pedido != null)
                .Select(s => new RelatorioVendedorTitulosAbertos()
                {
                   //IdPedido = s.id_pedido ?? 0,
                   //Desconto = s.desconto,
                   //Juros = s.juros,
                   //Multa = s.multa,
                   //ValorConta = s.valor                  

                }).ToList();

            return resultado;
        }
    }
}
