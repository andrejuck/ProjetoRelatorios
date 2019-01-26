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

        public bool Create(Address model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Address model)
        {
            throw new NotImplementedException();
        }

        public Address Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Address> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
