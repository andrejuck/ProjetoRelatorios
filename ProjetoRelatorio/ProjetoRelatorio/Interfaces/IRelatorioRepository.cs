using Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Interfaces
{
    public interface IRelatorioRepository
    {
        List<RelatorioVendedorTitulosAbertos> GetRelatorioVendedorTitulos();
    }
}
