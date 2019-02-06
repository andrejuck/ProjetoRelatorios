using EmissorPedidosAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Repositories.Interfaces
{
    public interface IChartAccountRepository : IBaseRepository<ChartAccount>
    {
        Task<IList<ChartAccount>> GetAll(int idUser);
    }
}
