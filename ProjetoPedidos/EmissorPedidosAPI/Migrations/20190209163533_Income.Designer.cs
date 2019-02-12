﻿// <auto-generated />
using System;
using EmissorPedidosAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmissorPedidosAPI.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20190209163533_Income")]
    partial class Income
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("EmissorPedidosAPI.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AccountDigit");

                    b.Property<int>("AccountNumber");

                    b.Property<int>("BankAgency");

                    b.Property<byte>("BankAgencyDigit");

                    b.Property<int?>("BankId");

                    b.Property<string>("Description");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("UserId");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.ChartAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ChartAccounts");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

                    b.Property<string>("Email");

                    b.Property<string>("FantasyName");

                    b.Property<string>("SocialName");

                    b.Property<string>("StateSubscription");

                    b.Property<string>("Subscription");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.CompanyAudit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Change");

                    b.Property<DateTime>("ChangeDate");

                    b.Property<int?>("CompanyId");

                    b.Property<bool>("NewActivated");

                    b.Property<string>("NewEmail");

                    b.Property<string>("NewFantasyName");

                    b.Property<string>("NewSocialName");

                    b.Property<string>("NewStateSubscription");

                    b.Property<string>("NewSubscription");

                    b.Property<bool>("OldActivated");

                    b.Property<string>("OldEmail");

                    b.Property<string>("OldFantasyName");

                    b.Property<string>("OldSocialName");

                    b.Property<string>("OldStateSubscription");

                    b.Property<string>("OldSubscription");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("CompaniesAudit");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankAccountId");

                    b.Property<int?>("ChartAccountId");

                    b.Property<string>("Description");

                    b.Property<decimal>("DiscountValue");

                    b.Property<DateTime?>("ExpenseDate");

                    b.Property<decimal>("ExpenseValue");

                    b.Property<string>("Observation");

                    b.Property<DateTime?>("PaidDate");

                    b.Property<decimal>("PaidValue");

                    b.Property<DateTime>("PayDate");

                    b.Property<int?>("PaymentTypeId");

                    b.Property<decimal>("PenaltyValue");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("ChartAccountId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankAccountId");

                    b.Property<int?>("ChartAccountId");

                    b.Property<string>("Description");

                    b.Property<decimal>("IncomeValue");

                    b.Property<string>("Observation");

                    b.Property<DateTime?>("PaidDate");

                    b.Property<decimal>("PaidValue");

                    b.Property<int?>("PaymentTypeId");

                    b.Property<DateTime?>("ReceiveDate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.HasIndex("ChartAccountId");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dinheiro"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Boleto"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Cartão de Crédito"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Cartão de Débito"
                        });
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

                    b.Property<bool>("Activated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(true);

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
                        .WithMany("Addresses")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Bank", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("Banks")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.BankAccount", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.Bank", "Bank")
                        .WithMany("BankAccounts")
                        .HasForeignKey("BankId");

                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("BankAccounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.ChartAccount", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("ChartAccounts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.CompanyAudit", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.Company", "Company")
                        .WithMany("CompaniesAudit")
                        .HasForeignKey("CompanyId");

                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("CompaniesAudit")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Expense", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.BankAccount", "BankAccount")
                        .WithMany("Expenses")
                        .HasForeignKey("BankAccountId");

                    b.HasOne("EmissorPedidosAPI.Models.ChartAccount", "ChartAccount")
                        .WithMany("Expenses")
                        .HasForeignKey("ChartAccountId");

                    b.HasOne("EmissorPedidosAPI.Models.PaymentType", "PaymentType")
                        .WithMany("Expenses")
                        .HasForeignKey("PaymentTypeId");

                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("Expenses")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Income", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.BankAccount", "BankAccount")
                        .WithMany("Incomes")
                        .HasForeignKey("BankAccountId");

                    b.HasOne("EmissorPedidosAPI.Models.ChartAccount", "ChartAccount")
                        .WithMany("Incomes")
                        .HasForeignKey("ChartAccountId");

                    b.HasOne("EmissorPedidosAPI.Models.PaymentType", "PaymentType")
                        .WithMany("Incomes")
                        .HasForeignKey("PaymentTypeId");

                    b.HasOne("EmissorPedidosAPI.Models.User", "User")
                        .WithMany("Incomes")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("EmissorPedidosAPI.Models.Phone", b =>
                {
                    b.HasOne("EmissorPedidosAPI.Models.Company", "Company")
                        .WithMany("Phones")
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