using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly ApplicationDbContext _context;

        public EstadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Estados> CarregarTodosEstados()
        {
            var listEstados = _context.Estados.ToList();

            if (listEstados.Count > 0)
                return listEstados;

            throw new Exception("Não foi possível carregar os estados");
        }
    }
}
