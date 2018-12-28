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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Contas Pagar Receber
            modelBuilder
               .Entity<ContasPagarReceber>()
               .ToTable("Contas_pagar_receber");

            modelBuilder
               .Entity<ContasPagarReceber>()
               .HasKey(k => k.codigo_conta_pr);
            #endregion

            #region Pedidos
            modelBuilder
                .Entity<Pedidos>()
                .HasKey(k => k.id_pedido);
            #endregion

            #region Usuario
            modelBuilder
                .Entity<Usuario>()
                .ToTable("usuarios");

            modelBuilder
                .Entity<Usuario>()
                .HasKey(k => k.codigo_usuario);
            #endregion

        }

        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<ContasPagarReceber> ContasPagarReceber { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
