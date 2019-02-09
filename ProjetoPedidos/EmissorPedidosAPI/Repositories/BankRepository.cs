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
    public class BankRepository : BaseRepository<Bank>, IBankRepository
    {
        public BankRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(Bank model)
        {
            try
            {
                var user = _context.Users
                    .Include(b => b.Banks)
                    .Where(w => w.Id == model.User.Id)
                    .SingleOrDefault();

                user.Banks.Add(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on creating bank: " + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var bank = await Get(id);
                _context.Banks.Remove(bank);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on deleting bank: " + ex.Message);
            }
        }

        public async Task<Bank> Get(int id)
        {
            try
            {
                return await _context.Banks
                    .Include(u => u.User)
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error on getting bank: " + ex.Message);
            }
        }

        public async Task<IList<Bank>> GetAll(int idUser)
        {
            try
            {
                return await _context.Banks
                    .Include(u => u.User)
                    .Where(w => w.User.Id == idUser)
                    .ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception("Error on getting all banks" + ex.Message);
            }
        }

        public async Task<bool> Update(Bank model)
        {
            try
            {
                _context.Banks.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error on updating bank: " + ex.Message);
            }
        }
    }
}
