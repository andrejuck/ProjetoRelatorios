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
    public class CompanyAuditRepository : BaseRepository<CompanyAudit>, ICompanyAuditRepository
    {
        public CompanyAuditRepository(ApiDBContext context) : base(context)
        {
        }

        public bool Create(Company audit, string changes)
        {
            try
            {
                var company = _context.Companies
                    .Include(ca => ca.CompaniesAudit)
                    .Where(c => c.Id == audit.Id)
                    .FirstOrDefault();

                var newAudit = new CompanyAudit
                {
                    Change = changes,
                    ChangeDate = DateTime.Now,
                    NewActivated = audit.Activated,
                    NewEmail = audit.Email,
                    NewFantasyName = audit.FantasyName,
                    NewSocialName = audit.SocialName,
                    NewSubscription = audit.Subscription,
                    NewStateSubscription = audit.StateSubscription                    
                };

                company.CompaniesAudit.Add(newAudit);
                if (_context.SaveChanges() < 0)
                    return false;

                var user = _context.Users
                    .Include(ca => ca.CompaniesAudit)
                    .Where(c => c.Id == audit.Users.FirstOrDefault().Id)
                    .FirstOrDefault();

                user.CompaniesAudit.Add(newAudit);
                if (_context.SaveChanges() > 0)
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
