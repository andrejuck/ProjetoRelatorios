﻿// <auto-generated />
using System;
using EmissorPedidosAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmissorPedidosAPI.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    partial class ApiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmissorPedidosAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CivicNumber");

                    b.Property<string>("CivicNumberSuffix");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("MunicipalityName");

                    b.Property<string>("PostalBox");

                    b.Property<string>("Province");

                    b.Property<string>("StreetName");

                    b.Property<string>("StreetType");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FantasyName");

                    b.Property<string>("SocialName");

                    b.Property<string>("StateSubscription");

                    b.Property<string>("Subscription");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("PhoneNumber");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Email");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Address", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.Company", "Company")
                        .WithMany("Address")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Phone", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.Company", "Company")
                        .WithMany("Phone")
                        .HasForeignKey("CompanyId");

                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("Phones")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.User", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
