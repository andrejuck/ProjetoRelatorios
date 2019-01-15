using EmissorPedidos.Interfaces;
using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Usuarios CarregarUsuarioLogado(string identityId)
        {
            try
            {
                var usuario = _context.Usuarios.Where(w => w.IdentityId == identityId).SingleOrDefault();

                if (usuario != null)
                    return usuario;

                throw new Exception("Não foi possivel encontrar o usuario logado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SalvarUsuarioAsync(Usuarios user)
        {
            bool retorno = false;
            try
            {
                await _context.AddAsync(user);
                var resultado = await _context.SaveChangesAsync();
                if(resultado > 0)
                {
                   retorno = true;
                }
                return retorno;
            }
            catch (Exception ex)
            {
                return retorno;
                throw ex;
            }            
        }
    }
}
