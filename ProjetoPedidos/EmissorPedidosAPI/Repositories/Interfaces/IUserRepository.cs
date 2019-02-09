using EmissorPedidosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        IList<User> GetUsersFromCompany(int idCompany);
        User Authenticate(string login, string password);
    }
}
