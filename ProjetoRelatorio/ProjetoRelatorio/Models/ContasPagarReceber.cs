using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Models
{       
    public class ContasPagarReceber
    {
        public int codigo_conta_pr { get; set; }
        public int codigo_pedido { get; set; }
        public int? id_pedido { get; set; }
        public int nota_fiscal { get; set; }
        public int pedido { get; set; }
        public int id_empresa { get; set; }
        public string tipo_conta { get; set; }
        public string descricao { get; set; }
        public string cnpj { get; set; }
        public string conta { get; set; }
        public int codigo_cc { get; set; }
        public DateTime emissao { get; set; }
        public DateTime vencimento { get; set; }
        public decimal valor { get; set; }
        public string Tipo_pagto { get; set; }
        public string nosso_numero { get; set; }
        public string obs { get; set; }
        public DateTime data_pagto { get; set; }
        public decimal desconto { get; set; }
        public decimal juros { get; set; }
        public decimal valor_pago { get; set; }
        public bool cancelado { get; set; }
        public bool carteira { get; set; }
        public string conta_contabil { get; set; }
        public decimal multa { get; set; }
        public int enviado_banco { get; set; }
        public string banco_cheque { get; set; }
        public string n_cheque { get; set; }
        public decimal valor_cheque { get; set; }
        public DateTime data_cheque { get; set; }
        public int lote { get; set; }
        public int codigo_fabricante { get; set; }
        public int codigo_conta_contabil { get; set; }
        public int cartorio { get; set; }
        public int codigo_plano { get; set; }
        public int numDoc { get; set; }
        public int arquivo_gerado { get; set; }
        public int imprimido { get; set; }
        public int codigo_compra { get; set; }
        public string numDocImpressao { get; set; }
        public int id_nota_fiscal_entrada { get; set; }
        public int parcela_numero { get; set; }
        public int id_condicao_pagamento { get; set; }
        public int id_pedido_sat { get; set; }
        public int nota_fiscal_sat { get; set; }
        public int codigo_conta_pr_origem { get; set; }
        public int conta_pr_origem { get; set; }


        public decimal CalculaTitulosTotais()
        {
            return 0;
        }
    }


}
