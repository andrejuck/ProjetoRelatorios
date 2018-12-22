using ProjetoRelatorio.Contexto;
using ProjetoRelatorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Repositorios
{
    public abstract class BaseRepository
    {
        protected readonly ContextoUtil _context;

        protected BaseRepository(ContextoUtil context)
        {
            _context = context;
        }
    }
}
