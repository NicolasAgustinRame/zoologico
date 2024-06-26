﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_zoologico.Data;

#nullable disable

namespace api_zoologico.Migrations
{
    [DbContext(typeof(ContextDb))]
    [Migration("20240626202655_primera_migration")]
    partial class primera_migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api_zoologico.Models.EspeciesAnimales", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Familia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCientifico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreVulgar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PeligroExtincion")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("especies_animales");
                });

            modelBuilder.Entity("api_zoologico.Models.Zoologicos", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AnioNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Continente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdAnimal")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEspecie")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisDeOrigen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PresupuestoAnual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Tamanio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdEspecie");

                    b.ToTable("zoologicos");
                });

            modelBuilder.Entity("api_zoologico.Models.Zoologicos", b =>
                {
                    b.HasOne("api_zoologico.Models.EspeciesAnimales", "Especie")
                        .WithMany()
                        .HasForeignKey("IdEspecie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");
                });
#pragma warning restore 612, 618
        }
    }
}
