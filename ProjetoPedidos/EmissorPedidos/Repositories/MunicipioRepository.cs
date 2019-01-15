using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;

namespace EmissorPedidos.Repositories
{
    public class MunicipioRepository : BaseRepository, IMunicipioRepository
    {
        public MunicipioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IList<Municipios> CarregarTodosMunicipios()
        {
            var listMunicipios = _context.Municipios.ToList();

            if (listMunicipios.Count > 0)
                return listMunicipios;

            throw new Exception("Não foi possível carregar os municipios");
        }
    }
}
