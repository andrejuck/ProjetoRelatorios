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

        public bool Create(Phone model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Phone model)
        {
            throw new NotImplementedException();
        }

        public Phone Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Phone> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
