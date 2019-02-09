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
    public class ChartAccountRepository : BaseRepository<ChartAccount>, IChartAccountRepository
    {
        public ChartAccountRepository(ApiDBContext context) : base(context)
        {
        }

        public async Task<bool> Create(ChartAccount model)
        {
            try
            {
                var user = _context.Users
                    .Include(ca => ca.ChartAccounts)
                    .Where(u => u.Id == model.User.Id)
                    .SingleOrDefault();

                var chart = model;
                user.ChartAccounts.Add(chart);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var chart = _context.ChartAccounts
                    .Where(ca => ca.Id == id)
                    .SingleOrDefault();

                if (chart == null)
                    throw new Exception("Error on finding the Chart Account");

                _context.ChartAccounts.Remove(chart);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ChartAccount> Get(int idChart)
        {
            return await _context.ChartAccounts
                .Include(u => u.User)
                .Where(c => c.Id == idChart)
                .SingleOrDefaultAsync();
        }

       

        public async Task<IList<ChartAccount>> GetAll(int idUser)
        {
            return await _context.ChartAccounts
                .Include(u => u.User)
                .Where(u => u.User.Id == idUser)
                .ToListAsync();
        }

        public async Task<IList<ChartAccount>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ChartAccount model)
        {
            try
            {
                _context.ChartAccounts.Update(model);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
