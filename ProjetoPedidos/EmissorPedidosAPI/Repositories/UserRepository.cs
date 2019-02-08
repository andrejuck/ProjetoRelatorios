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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ICompanyRepository _companyRepository;

        public UserRepository(ApiDBContext context,
            ICompanyRepository companyrepository) : base(context)
        {
            _companyRepository = companyrepository;
        }

        //{
        //	"login":"Vendedor",
        //	"password":"123456",
        //	"company":{"id": "2"},
        //	"username": "vendedor",
        //	"email": "vendedor@andrejuck.com.br",
        //	"phones": 
        //	[
        //		{"phoneNumber": "6516518" }, 
        //		{"phoneNumber": "6516518" }
        //	]
        //}
        public async Task<bool> Create(User model)
        {
            try
            {
                var company = _context.Companies
                    .Include(u => u.Users)
                    .Where(c => c.Id == model.Company.Id)
                    .FirstOrDefault();

                var user = model;
                company.Users.Add(user);
                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(User model)
        {
            try
            {
                _context.Users.Update(model);
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
            throw new NotImplementedException();
            try
            {
                var model = _context.Users
                    .Include(p => p.Phones)
                    .Where(u => u.Id == id)
                    .FirstOrDefault();

                if (model == null)
                    return false;

                _context.Phones.RemoveRange(model.Phones);
                _context.Users.Remove(model);

                if (await _context.SaveChangesAsync() > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IList<User> GetUsersFromCompany(int idCompany)
        {
            try
            {
                return _context.Users
                    .Include(p => p.Phones)
                    .Where(u => u.Company.Id == idCompany)
                    .ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IList<User>> GetAll(int idCompany)
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }
                
    }
}
