using EmissorPedidosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmissorPedidosAPI.Context
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<ChartAccount> ChartAccounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        #region Audits
        public DbSet<CompanyAudit> CompaniesAudit { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Company
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Users)
                .WithOne(c => c.Company);

            modelBuilder.Entity<Company>()
                .Property(c => c.Activated)
                .HasDefaultValue(true);
            #endregion

            #region User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Phones)
                .WithOne(u => u.User);

            modelBuilder.Entity<User>()
                .Property(u => u.Activated)
                .HasDefaultValue(true);
            #endregion

            #region Expenses
            modelBuilder.Entity<Expense>()
                .HasOne(u => u.User);
            #endregion

            #region PaymentType
            //Populating default values for types of payment
            modelBuilder.Entity<PaymentType>()
                .HasData(
                    new PaymentType() { Id = 1, Description = "Dinheiro" },
                    new PaymentType() { Id = 2, Description = "Boleto" },
                    new PaymentType() { Id = 3, Description = "Cartão de Crédito" },
                    new PaymentType() { Id = 4, Description = "Cartão de Débito" }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
