using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class EmpresaRepository : BaseRepository, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int SalvarCadastroEmpresa(Empresas empresa)
        {
            try
            {
                _context.AddAsync(empresa);                
                var resultado = _context.SaveChanges();

                if (resultado > 0)
                    return empresa.Id;
                throw new Exception("Erro ao salvar Empresa");
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }
    }
}
