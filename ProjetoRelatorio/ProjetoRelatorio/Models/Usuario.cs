using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Models
{
    public class Usuario
    {

        public int codigo_usuario { get; set; }
        public string usuario { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string cep { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string cargo { get; set; }
        public int vendedor { get; set; }
        public string senha { get; set; }
        public int nivel_senha { get; set; }
        public bool ativo { get; set; }
        public float comissao_porcentagem { get; set; }
        public string configApp { get; set; }
        public int codigo_transportadora { get; set; }
        public int codigo_representante { get; set; }
        public int tabela_preco { get; set; }
        public bool is_gerente { get; set; }
        public int codigo_gerente { get; set; }
        public int codigo_estoque { get; set; }
        public string nome { get; set; }
        public string idc_servidor_requer_autenticacao { get; set; }
        public string idc_servidor_requer_conexao_segura { get; set; }

    }
}
