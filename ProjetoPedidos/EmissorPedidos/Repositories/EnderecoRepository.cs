using EmissorPedidos.Interfaces.Repositories;
using EmissorPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidos.Repositories
{
    public class EnderecoRepository : BaseRepository, IEnderecoRepository
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMunicipioRepository _municipioRepository;
        public EnderecoRepository(ApplicationDbContext context,
            IEstadoRepository estadoRepository, IMunicipioRepository municipioRepository) : base(context)
        {
            _estadoRepository = estadoRepository;
            _municipioRepository = municipioRepository;
        }

        public bool SalvarEndereco(IList<Endereco> listEnderecos, int idEmpresa)
        {            
            bool retorno = false;

            if (idEmpresa <= 0)
                retorno = false;
            else
            {
                try
                {
                    foreach (var endereco in listEnderecos)
                    {
                        endereco.Empresa.Id = idEmpresa;
                        _context.Enderecos.Add(endereco);
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

        public IList<Endereco> PopulaEndereco(IList<Endereco> enderecos)
        {
            var listEnderecoPopulado = new List<Endereco>();

            foreach (var endereco in enderecos)
            {
                var enderecoPopulado = new Endereco
                {
                    Bairro = endereco.Bairro,
                    Cep = endereco.Cep,
                    Complemento = endereco.Complemento,
                    Empresa = endereco.Empresa,
                    Estado = _estadoRepository.CarregarEstadoPorId(endereco.Estado.Id),
                    Logradouro = endereco.Logradouro,
                    Municipio = _municipioRepository.CarregarMunicipioPorId(endereco.Municipio.Id),
                    Numero = endereco.Numero
                    //Pais = endereco.Pais.Id
                };

                listEnderecoPopulado.Add(enderecoPopulado);
            }

            return listEnderecoPopulado;
        }

    }
}
