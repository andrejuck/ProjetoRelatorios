using ProjetoRelatorio.Contexto;
using ProjetoRelatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Models
{
    public class Pedidos : IPedidos
    {
        protected readonly ContextoUtil _context;

        public Pedidos(ContextoUtil contexto)
        {
            _context = contexto;
        }        
        public int id_pedido { get; set; }
        public int numero_pedido { get; set; }
        public int id_empresa { get; set; }
        public int nota_fiscal { get; set; }
        public string cnpj { get; set; }
        public DateTime data { get; set; }
        public string forma_pagto { get; set; }
        public int codigo_vendedor { get; set; }
        public int codigo_transportadora { get; set; }
        public int codigo_veiculo { get; set; }
        public string situacao { get; set; }
        public string motivo { get; set; }
        public string obs { get; set; }
        public bool selecionado { get; set; }
        public bool carteira { get; set; }
        public string origem { get; set; }
        public decimal desconto_pedido { get; set; }
        public int pedido { get; set; }
        public string serie { get; set; }
        public int tipo_frete { get; set; }
        public decimal valor_frete { get; set; }
        public decimal valor_total { get; set; }
        public int nota_mae { get; set; }
        public DateTime data_previsao { get; set; }
        public int codigo_cc { get; set; }
        public bool importado { get; set; }
        public string obs_nota { get; set; }
        public string localizacao { get; set; }
        public int id_tipo_movimento { get; set; }
        public DateTime data_emissao_pedido { get; set; }
        public decimal quantidade_volumes { get; set; }
        public decimal desconto_pedido_dinheiro { get; set; }
        public decimal valor_total_sem_desconto { get; set; }
        public string cartaCreditoProcessada { get; set; }
        public int destacar_frete { get; set; }
        public int cobrar_frete { get; set; }
        public int idCondPagto { get; set; }
        public int id_pedido_nota_mae { get; set; }
        public int id_modelo_documento_fiscal { get; set; }
    }
}
