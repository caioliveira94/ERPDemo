﻿// <auto-generated />
using System;
using ERPDemo.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERPDemo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("ERPDemo.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("CNPJ")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataFundacao")
                        .HasColumnType("datetime(6)");

                    b.Property<long?>("GrupoId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ERPDemo.Domain.Entities.Gerente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Nivel")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Gerentes");
                });

            modelBuilder.Entity("ERPDemo.Domain.Entities.Grupo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("ERPDemo.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("ERPDemo.Domain.Entities.Grupo", "Grupo")
                        .WithMany("Clientes")
                        .HasForeignKey("GrupoId");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("ERPDemo.Domain.Entities.Grupo", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
