using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidos.Models;

namespace EmissorPedidos.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        bool SalvarEndereco(IList<Endereco> listEnderecos, int id);
        IList<Endereco> PopulaEndereco(IList<Endereco> enderecos);
    }
}
