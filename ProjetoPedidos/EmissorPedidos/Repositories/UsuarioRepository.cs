using EmissorPedidos.Interfaces;
using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
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
