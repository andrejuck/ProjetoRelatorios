using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class PaisRepository : BaseRepository, IPaisRepository
    {
        public PaisRepository(ApplicationDbContext context) : base(context)
        {
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
