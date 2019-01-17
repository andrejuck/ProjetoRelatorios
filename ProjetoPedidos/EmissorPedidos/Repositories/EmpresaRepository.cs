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
        private readonly ITelefoneRepository _telefoneRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IEstadoRepository _estadoRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public EmpresaRepository(ApplicationDbContext context,
            ITelefoneRepository telefoneRepository, IEnderecoRepository enderecoRepository,
            IEstadoRepository estadoRepository, IMunicipioRepository municipioRepository,
            IUsuarioRepository usuarioRepository) : base(context)
        {
            _telefoneRepository = telefoneRepository;
            _enderecoRepository = enderecoRepository;
            _estadoRepository = estadoRepository;
            _municipioRepository = municipioRepository;
            _usuarioRepository = usuarioRepository;
        }

        public int SalvarCadastroEmpresa(Empresas empresa)
        {
            Empresas novaEmpresa = new Empresas
            {
                Contato = empresa.Contato,
                Email = empresa.Email,
                Endereco = _enderecoRepository.PopulaEndereco(empresa.Endereco),
                Inscricao = empresa.Inscricao,
                InscricaoEstadual = empresa.InscricaoEstadual,
                NomeFantasia = empresa.NomeFantasia,
                RazaoSocial = empresa.RazaoSocial,
                Telefone = empresa.Telefone,
                Usuario = _usuarioRepository.CarregarUsuarioPorId(empresa.Usuario.Id)
            };

            try
            {
                _context.AddAsync(novaEmpresa);                
                var resultado = _context.SaveChanges();

                if (novaEmpresa.Id <= 0)
                    throw new Exception("Erro ao salvar dados da empresa");

                //if (!_enderecoRepository.SalvarEndereco(empresa.Endereco, empresa.Id))
                //    throw new Exception("Erro ao salvar endereços da empresa");

                //if (!_telefoneRepository.SalvarTelefone(empresa.Telefone, empresa.Id))
                //    throw new Exception("Erro ao salvar os telefones da empresa");

                if (resultado > 0)
                    return novaEmpresa.Id;
                throw new Exception("Erro ao salvar Empresa");
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        
        
    }
}
