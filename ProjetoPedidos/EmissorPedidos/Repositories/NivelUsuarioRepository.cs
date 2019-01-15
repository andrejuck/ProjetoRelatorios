using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class NivelUsuarioRepository : BaseRepository, INivelUsuarioRepository
    {
        public NivelUsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public NivelUsuario CarregarNivelUsuario(int id)
        {
            try
            {
                var resultado = _context.NivelUsuario.Where(w => w.Id == id).SingleOrDefault();
                if(resultado != null)
                    return resultado;

                throw new Exception($"Não foi possivel carregar o nivel de usuario {id}");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
