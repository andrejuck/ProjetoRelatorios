using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Helpers;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly AppSettings _appSettings;

        public UserRepository(ICompanyRepository companyRepository, IOptions<AppSettings> appSettings,
            ApiDBContext context) : base(context)

        {
            _companyRepository = companyRepository;
            _appSettings = appSettings.Value;
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

        public User Authenticate(string login, string password)
        {
            var user = _context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);

            if (user == null)
                return null;

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.Id.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}
