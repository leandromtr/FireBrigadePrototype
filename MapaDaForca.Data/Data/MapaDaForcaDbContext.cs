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
    public class MapaDaForcaDbContext : IdentityDbContext<Bombeiro>
    {
        private IConfiguration Configuration { get; }

        public MapaDaForcaDbContext() : base() { }

        public MapaDaForcaDbContext(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = new Guid("0dc9f029-e6f9-46ec-9e8f-04273de86631").ToString(), Name = PerfilAcesso.Administrador, NormalizedName = PerfilAcesso.Administrador.ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = new Guid("aebc2354-ecb3-4c70-93cc-47849872f57b").ToString(), Name = PerfilAcesso.Bombeiro, NormalizedName = PerfilAcesso.Bombeiro.ToUpper() });

            //modelBuilder.Entity<Bombeiro>().HasData(new Bombeiro
            //{
            //    Id = new Guid("e7f067a9-37e9-4dac-9bd6-4c84eeaaa733").ToString(),
            //    UserName = "admin@gmail.com",
            //    NormalizedUserName = "admin@gmail.com",
            //    Email = "admin@gmail.com",
            //    NormalizedEmail = "admin@gmail.com",
            //    EmailConfirmed = true,
            //    PasswordHash = "AQAAAAEAACcQAAAAEHcjRUNHmzhl8qx9dKHTcKcXcb0k99YPE2caUy7QmbnM/a5OzPoYNq450AdMmUgRQA==",
            //    SecurityStamp = "AT6RKF5YUMZXUJXXW3H64WOJTF73NVF2",
            //    ConcurrencyStamp = "56253053-b77e-49fe-a190-97596fc8dba3",
            //    PhoneNumber = null,
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnd = null,
            //    LockoutEnabled = false,
            //    AccessFailedCount = 0,
            //    NumeroMecanografico = 00000000,
            //    Nome = "Admin",
            //    DtInicio = DateTime.Now,
            //    PostoId = new Guid(),
            //    QuartelId = new Guid(),
            //    Turno = Turno.T1
            //});
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
