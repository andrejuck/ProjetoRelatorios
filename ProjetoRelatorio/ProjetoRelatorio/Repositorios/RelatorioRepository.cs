using ProjetoRelatorio.Contexto;
using ProjetoRelatorio.Interfaces;
using ProjetoRelatorio.ViewModels;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Repositorios
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ContextoUtil _context;

        public RelatorioRepository(ContextoUtil context)
        {
            _context = context;
        }
        public List<RelatorioVendedorTitulosAbertos> GetRelatorioVendedorTitulos()
        {

            List<RelatorioViewModel> titulos = _context
                .ContasPagarReceber
                .Join(_context.Pedidos,
                    cpr => cpr.id_pedido,
                    ped => ped.id_pedido,
                    (cpr, ped) => new { ContasPagarReceber = cpr, Pedidos = ped })                
                .Where(w => w.ContasPagarReceber.vencimento >= DateTime.Now.AddMonths(-1))                      
                .Select(s => new RelatorioViewModel(s.ContasPagarReceber.valor, s.ContasPagarReceber.juros, s.ContasPagarReceber.multa,
                    s.ContasPagarReceber.desconto, s.ContasPagarReceber.valor_pago)
                {
                    Usuario = _context
                                .Usuario
                                .Where(u => u.codigo_usuario == s.Pedidos.codigo_vendedor)
                                .Select(n => n.usuario)
                                .FirstOrDefault(),
                })                
                .ToList();

            var lala = titulos.GroupBy(p => p.Usuario)
                .Select(s => new RelatorioVendedorTitulosAbertos
                {
                    Usuario = s.Key,
                    TitulosAbertos = s.Sum(t => t.TitulosAbertos),
                    TitulosTotais = s.Sum(t => t.TitulosTotais),
                    IndiceEmAberto = ((1 - s.Sum(t => t.TitulosAbertos) / s.Sum(t => t.TitulosTotais)) * 100 )
                })
                .ToList(); 

            return lala;
        }
    }
}
