using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Data
{
    public class MapaDaForcaDbContext: IdentityDbContext<Bombeiro>
    {
        private IConfiguration Configuration { get; }

        public MapaDaForcaDbContext() : base() { }

        public MapaDaForcaDbContext(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = PerfilAcesso.Administrador, NormalizedName = PerfilAcesso.Administrador.ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = PerfilAcesso.Bombeiro, NormalizedName = PerfilAcesso.Bombeiro.ToUpper() });
        }

        public DbSet<Bombeiro> Bombeiros { get; set; }

        public DbSet<Posto> Postos { get; set; }

        public DbSet<Escala> Escalas { get; set; }

        public DbSet<BombeiroFuncao> BombeiroFuncoes { get; set; }

        public DbSet<EscalaTipo> EscalaTipos { get; set; }

        //public DbSet<EscalaTipoDetalhe> EscalaTipoDetalhes { get; set; }

        public DbSet<Quartel> Quarteis { get; set; }

        public DbSet<Companhia> Companhias { get; set; }

        public DbSet<Batalhao> Batalhoes { get; set; }

        public DbSet<Funcao> Funcoes { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<EscalaTurno> EscalaTurnos { get; set; }

        public DbSet<QuartelViatura> QuartelViaturas { get; set; }

        public DbSet<QuartelViaturaCondicao> QuartelViaturaCondicoes { get; set; }

        public DbSet<Viatura> Viaturas { get; set; }

        public DbSet<ViaturaTipo> ViaturaTipos { get; set; }

        public DbSet<ViaturaTipoFuncao> ViaturaTipoFuncoes { get; set; }
    }
}
