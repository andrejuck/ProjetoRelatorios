using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;

namespace EmissorPedidosAPI.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApiDBContext context) : base(context)
        {
        }

        public bool Create(Company model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Company Get(int id)
        {
            return _context.Companies
                .Where(c => c.Id == id)
                .Select(c => new Company
                {
                    Id = c.Id,
                    Email = c.Email,
                    FantasyName = c.FantasyName,
                    SocialName = c.SocialName,
                    StateSubscription = c.StateSubscription,
                    Subscription = c.Subscription,
                    Phone = _context.Phones.Where(p => p.Company.Id == c.Id).ToList(),
                    Address = _context.Addresses.Where(a => a.Company.Id == c.Id).ToList()
                }).FirstOrDefault();
        }

        public IList<Company> GetAll()
        {

            return _context.Companies
                .Select(c => new Company
                {
                    Id = c.Id,
                    Email = c.Email,
                    FantasyName = c.FantasyName,
                    SocialName = c.SocialName,
                    StateSubscription = c.StateSubscription,
                    Subscription = c.Subscription,
                    Phone = _context.Phones.Where(p => p.Company.Id == c.Id).ToList(),
                    Address = _context.Addresses.Where(a => a.Company.Id == c.Id).ToList()

                }).ToList();
        }

        public bool Update(Company model)
        {
            throw new NotImplementedException();
        }
    }
}
