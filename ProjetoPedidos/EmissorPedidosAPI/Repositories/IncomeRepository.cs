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
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(Income model)
        {
            try
            {
                var user = _context.Users
                    .Include(ex => ex.Incomes)
                    .Where(w => w.Id == model.User.Id)
                    .SingleOrDefault();

                _context.BankAccounts
                    .Include(ex => ex.Incomes)
                    .Where(w => w.Id == model.BankAccount.Id)
                    .SingleOrDefault();

                _context.PaymentTypes
                    .Include(ex => ex.Incomes)
                    .Where(w => w.Id == model.PaymentType.Id)
                    .SingleOrDefault();

                _context.ChartAccounts
                    .Include(ex => ex.Incomes)
                    .Where(w => w.Id == model.ChartAccount.Id)
                    .SingleOrDefault();

                user.Incomes.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on creating Income: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var income = await Get(id);

                _context.Incomes.Remove(income);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on getting all Incomes: " + ex.Message);
            }
        }

        public async Task<Income> Get(int id)
        {
            try
            {
                return await _context.Incomes
                    .Include(u => u.User)
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error on getting Income: " + ex.Message);
            }
        }

        public async Task<IList<Income>> GetAll(int idUser)
        {
            try
            {
                return await _context.Incomes
                    .Include(u => u.User)
                    .Where(w => w.User.Id == idUser)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error on getting all Incomes: " + ex.Message);
            }
        }

        public async Task<bool> Update(Income model)
        {
            try
            {
                _context.Incomes.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on updating Income: " + ex.Message);
            }
        }
    }
}
