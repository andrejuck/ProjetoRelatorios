using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class TelefoneRepository : BaseRepository, ITelefoneRepository
    {
        public TelefoneRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool SalvarTelefone(IList<Telefone> listTelefones, int idEmpresa)
        {
            bool retorno = false;

            if (idEmpresa <= 0)
                retorno = false;
            else
            {
                try
                {
                    foreach (var tel in listTelefones)
                    {
                        tel.Empresa.Id = idEmpresa;
                        _context.Telefones.Add(tel);
                    }

                    _context.SaveChanges();
                    retorno = true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }                
            }

            return retorno;
        }
    }
}
