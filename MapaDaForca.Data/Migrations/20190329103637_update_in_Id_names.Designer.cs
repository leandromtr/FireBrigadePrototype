﻿// <auto-generated />
using System;
using MapaDaForca.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MapaDaForca.Data.Migrations
{
    [DbContext(typeof(MapaDaForcaDbContext))]
    [Migration("20190329103637_update_in_Id_names")]
    partial class update_in_Id_names
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MapaDaForca.Model.Batalhao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Batalhoes");
                });

            modelBuilder.Entity("MapaDaForca.Model.Bombeiro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DtInicio");

                    b.Property<string>("Nome");

                    b.Property<Guid>("PostoId");

                    b.Property<Guid>("QuartelId");

                    b.Property<int>("Turno");

                    b.HasKey("Id");

                    b.ToTable("Bombeiros");
                });

            modelBuilder.Entity("MapaDaForca.Model.BombeiroFuncao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BombeiroId");

                    b.Property<Guid>("FuncaoId");

                    b.Property<bool>("FuncaoPrincipal");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("BombeiroFuncoes");
                });

            modelBuilder.Entity("MapaDaForca.Model.Companhia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BatalhaoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Companhias");
                });

            modelBuilder.Entity("MapaDaForca.Model.DetalheTipo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("DetalheTipos");
                });

            modelBuilder.Entity("MapaDaForca.Model.Escala", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AprovadoEm");

                    b.Property<Guid>("AprovadoPor");

                    b.Property<Guid>("BombeiroId");

                    b.Property<DateTime>("Data");

                    b.Property<Guid>("FuncaoId");

                    b.Property<bool>("Periodo1");

                    b.Property<int>("PrioridadeFerias");

                    b.Property<Guid>("QuartelId");

                    b.Property<Guid>("TipoEscalaId");

                    b.HasKey("Id");

                    b.ToTable("Escalas");
                });

            modelBuilder.Entity("MapaDaForca.Model.EscalaTurno", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<bool>("Periodo1");

                    b.Property<int>("Turno");

                    b.HasKey("Id");

                    b.ToTable("EscalaTurnos");
                });

            modelBuilder.Entity("MapaDaForca.Model.Funcao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Funcoes");
                });

            modelBuilder.Entity("MapaDaForca.Model.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BatalhaoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("MapaDaForca.Model.Posto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Postos");
                });

            modelBuilder.Entity("MapaDaForca.Model.Quartel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanhiaId");

                    b.Property<string>("Nome");

                    b.Property<bool>("Portao");

                    b.HasKey("Id");

                    b.ToTable("Quarteis");
                });

            modelBuilder.Entity("MapaDaForca.Model.QuartelViatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("QuartelId");

                    b.Property<Guid>("ViaturaId");

                    b.HasKey("Id");

                    b.ToTable("QuartelViaturas");
                });

            modelBuilder.Entity("MapaDaForca.Model.QuartelViaturaCondicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("QuartelViaturaId");

                    b.Property<Guid>("ViaturaId");

                    b.HasKey("Id");

                    b.ToTable("QuartelViaturaCondicoes");
                });

            modelBuilder.Entity("MapaDaForca.Model.TipoEscala", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<Guid>("DetalheTipoId");

                    b.HasKey("Id");

                    b.ToTable("TipoEscalas");
                });

            modelBuilder.Entity("MapaDaForca.Model.TipoViatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Sigla");

                    b.HasKey("Id");

                    b.ToTable("TipoViaturas");
                });

            modelBuilder.Entity("MapaDaForca.Model.TipoViaturaFuncao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FuncaoId");

                    b.Property<int>("Quantidade");

                    b.Property<Guid>("TipoViaturaId");

                    b.HasKey("Id");

                    b.ToTable("TipoViaturaFuncoes");
                });

            modelBuilder.Entity("MapaDaForca.Model.Viatura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<DateTime>("DataInicioUso");

                    b.Property<string>("Matricula");

                    b.Property<bool>("Operacional");

                    b.Property<Guid>("TipoViaturaId");

                    b.HasKey("Id");

                    b.ToTable("Viaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
