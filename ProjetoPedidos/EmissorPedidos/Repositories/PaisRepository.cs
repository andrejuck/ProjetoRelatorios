using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly ApplicationDbContext _context;

        public PaisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Paises> CarregarTodosPaises()
        {
            var listaPaises = _context.Paises.ToList();

            if (listaPaises.Count > 0)
                return listaPaises;

            throw new Exception("Não foi possivel carregar os paises");
        }
    }
}
