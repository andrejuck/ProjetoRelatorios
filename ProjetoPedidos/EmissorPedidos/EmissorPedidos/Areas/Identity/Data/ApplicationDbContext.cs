﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmissorPedidos.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmissorPedidos.Models
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioIdentity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder
                .Entity<Usuarios>()
                .HasKey(k => k.Id);

            builder
                .Entity<NivelUsuario>()
                .ToTable("nivel_usuario")
                .HasKey(k => k.Id);

            builder
                .Entity<Telefones>()
                .HasKey(k => k.Id);

            builder
                .Entity<EmpresaUsuario>()
                .HasKey(kk => new { kk.EmpresaId, kk.UsuarioId });
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<NivelUsuario> NivelUsuario { get; set; }
        public DbSet<Telefones> Telefones { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
    }
}
