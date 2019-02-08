using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ApiDBContext context) : base(context)
        {
        }

        public Task<bool> Create(Phone model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Phone> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Phone>> GetAll(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Phone model)
        {
            throw new NotImplementedException();
        }
    }
}
