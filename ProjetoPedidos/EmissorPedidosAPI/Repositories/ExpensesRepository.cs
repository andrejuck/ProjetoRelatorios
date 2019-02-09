using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            try
            {
                var user = _context.Users
                    .Include(ex => ex.Expenses)
                    .Where(w => w.Id == model.User.Id)
                    .SingleOrDefault();

                _context.BankAccounts
                    .Include(ex => ex.Expenses)
                    .Where(w => w.Id == model.BankAccount.Id)
                    .SingleOrDefault();

                _context.PaymentTypes
                    .Include(ex => ex.Expenses)
                    .Where(w => w.Id == model.PaymentType.Id)
                    .SingleOrDefault();

                _context.ChartAccounts
                    .Include(ex => ex.Expenses)
                    .Where(w => w.Id == model.ChartAccount.Id)
                    .SingleOrDefault();

                user.Expenses.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on creating Expense: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var expense = await Get(id);

                _context.Expenses.Remove(expense);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on deleting Expense: " + ex.Message);
            }
        }

        public async Task<Expense> Get(int id)
        {
            try
            {
                return await _context.Expenses
                    .Include(u => u.User)
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();                
            }
            catch (Exception ex)
            {

                throw new Exception("Error on getting Expense: " + ex.Message);
            }
        }

        public async Task<IList<Expense>> GetAll(int idUser)
        {
            try
            {
                return await _context.Expenses
                    .Include(u => u.User)
                    .Where(w => w.User.Id == idUser)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error on getting all Expenses: " + ex.Message);
            }
        }

        public async Task<bool> Update(Expense model)
        {
            try
            {
                _context.Expenses.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on updating Expense: " + ex.Message);
            }
        }
    }
}
