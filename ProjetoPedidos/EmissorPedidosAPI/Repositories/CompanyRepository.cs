using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmissorPedidosAPI.Repositories
{
    //TODO - Work on errors for each saveChanges return message; 
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly ICompanyAuditRepository _companyAuditRepository;
        public CompanyRepository(ApiDBContext context,
            ICompanyAuditRepository companyAuditRepository) : base(context)
        {
            _companyAuditRepository = companyAuditRepository;
        }

        public bool Create(Company model)
        {
            try
            {
                var newCompany = new Company
                {
                    Addresses = model.Addresses,
                    Email = model.Email,
                    FantasyName = model.FantasyName,
                    Phones = model.Phones,
                    SocialName = model.SocialName,
                    StateSubscription = model.StateSubscription,
                    Subscription = model.Subscription
                };

                _context.Add(newCompany);

                if (_context.SaveChanges() < 0)
                    return false;

                var user = _context.Users  
                    .Include(c => c.Company)
                    .Where(u => u.Id == model.Users.FirstOrDefault().Id)
                    .FirstOrDefault();

                user.Company = newCompany;

                _context.Update(user);
                if (_context.SaveChanges() < 0)
                    return false;
                else
                    return _companyAuditRepository.Create(newCompany, "Created");               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Update(Company model)
        {
            throw new Exception("Função não implementada");
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
                    Phones = _context.Phones.Where(p => p.Company.Id == c.Id).ToList(),
                    Addresses = _context.Addresses.Where(a => a.Company.Id == c.Id).ToList()
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
                    Phones = _context.Phones.Where(p => p.Company.Id == c.Id).ToList(),
                    Addresses = _context.Addresses.Where(a => a.Company.Id == c.Id).ToList()

                }).ToList();
        }

        
    }
}
