using ProjetoRelatorio.Contexto;
using ProjetoRelatorio.Interfaces;
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
            List<RelatorioVendedorTitulosAbertos> teste = _context
                .ContasPagarReceber
                .Join(_context.Pedidos,
                    cpr => cpr.id_pedido,
                    ped => ped.id_pedido,
                    (cpr, ped) => new { ContasPagarReceber = cpr, Pedidos = ped }
                    )
                .Where(w => w.ContasPagarReceber.vencimento >= DateTime.Now.AddMonths(-1))                
                .Select(s => new RelatorioVendedorTitulosAbertos
                {
                    IdPedido = s.ContasPagarReceber.id_pedido,
                    IdNotaFiscal = s.Pedidos.nota_fiscal,
                    Usuario = _context
                                .Usuario
                                .Where(u => u.codigo_usuario == s.Pedidos.codigo_vendedor)
                                .Select(n => n.usuario)
                                .FirstOrDefault(),
                })                
                .Take(10)                
                .ToList();


            var lala = teste.GroupBy(p => p.Usuario).ToList(); //TODO - agrupar por código do usuario

            return teste;
        }
    }
}
