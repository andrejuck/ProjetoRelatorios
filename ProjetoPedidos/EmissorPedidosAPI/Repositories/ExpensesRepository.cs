using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(Expense model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Expense>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Expense model)
        {
            throw new NotImplementedException();
        }
    }
}
