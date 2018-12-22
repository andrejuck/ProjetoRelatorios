using Microsoft.EntityFrameworkCore;
using ProjetoRelatorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoRelatorio.Contexto
{
    public class ContextoUtil : DbContext
    {

        public ContextoUtil(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<ContasPagarReceber> ContasPagarReceber { get; set; }

    }
}
