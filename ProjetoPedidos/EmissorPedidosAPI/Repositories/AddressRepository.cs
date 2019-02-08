using EmissorPedidosAPI.Context;
using EmissorPedidosAPI.Models;
using EmissorPedidosAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApiDBContext context) : base(context)
        {
        }

        public Task<bool> Create(Address model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Address> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Address>> GetAll(int idUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Address model)
        {
            throw new NotImplementedException();
        }
    }
}
