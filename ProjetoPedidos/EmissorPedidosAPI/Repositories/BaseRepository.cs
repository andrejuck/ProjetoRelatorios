using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApiDBContext _context;

        protected BaseRepository(ApiDBContext context)
        {
            _context = context;
        }

        //protected virtual 
    }
}
