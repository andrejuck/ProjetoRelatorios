using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class NivelUsuarioRepository : INivelUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public NivelUsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public NivelUsuario CarregarNivelUsuario(int id)
        {
            try
            {
                var resultado = _context.NivelUsuario.Where(w => w.Id == id).SingleOrDefault();

                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
