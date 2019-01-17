using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidos.Models;

namespace EmissorPedidos.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        bool SalvarEndereco(IList<Enderecos> listEnderecos, int id);
        IList<Enderecos> PopulaEndereco(IList<Enderecos> enderecos);
    }
}
