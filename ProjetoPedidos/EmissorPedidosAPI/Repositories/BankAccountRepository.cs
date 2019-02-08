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
    public class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(BankAccount model)
        {
            try
            {
                //testar
                var user = _context.Users
                    .Include(ba => ba.BankAccounts)
                    .Where(w => w.Id == model.User.Id)
                    .SingleOrDefault();

                var bank = _context.Banks
                    .Include(ba => ba.BankAccounts)
                    .Where(w => w.Id == model.Bank.Id)
                    .SingleOrDefault();

                bank.BankAccounts.Add(model);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on creating bank account" + ex.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var bankAccount = await Get(id);
                _context.BankAccounts.Remove(bankAccount);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on deleting Bank account" + ex.Message);
            }
        }

        public async Task<BankAccount> Get(int id)
        {
            try
            {
                return await _context.BankAccounts
                    .Where(w => w.Id == id)
                    .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error on getting Bank Account" + ex.Message);
            }
        }

        public async Task<IList<BankAccount>> GetAll(int idUser)
        {
            try
            {
                return await _context.BankAccounts
                    .Where(w => w.User.Id == idUser)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error on getting all bank accounts" + ex.Message);
            }
        }

        public async Task<bool> Update(BankAccount model)
        {
            try
            {
                _context.BankAccounts.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error on updating Bank Account" + ex.Message);
            }
        }
    }
}
