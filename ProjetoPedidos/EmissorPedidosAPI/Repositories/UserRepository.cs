using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool Create(User model)
        {
            try
            {
                var company = _context.Companies
                    .Include(u => u.Users).Where(c => c.Id == model.Company.Id).First();

                var user = model;
                company.Users.Add(user);
                var db = _context.SaveChanges();
                if (db > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(User model)
        {
            try
            {
                _context.Users.Remove(model);
                var db = _context.SaveChanges();
                if (db > 0)
                    return true;

                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public User Get(int id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                //.Select(u => new User
                //{
                //    Id = u.Id,
                //    Email = u.Email,
                //    Login = u.Login,
                //    UserName = u.UserName,
                //    Password = u.Password
                //})
                .FirstOrDefault();
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
