using MapaDaForca.Model;
using MapaDaForca.Model.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Data
{
    public class MapaDaForcaDbContext : IdentityDbContext<Bombeiro>
    {
        private IConfiguration Configuration { get; }

        public MapaDaForcaDbContext() : base() { }

        public MapaDaForcaDbContext(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roleAdminId = Guid.NewGuid().ToString();
            var roleBombeiroId = Guid.NewGuid().ToString();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { 
                Id = roleAdminId, 
                Name = PerfilAcesso.Administrador, 
                NormalizedName = PerfilAcesso.Administrador.ToUpper() 
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { 
                Id = roleBombeiroId, 
                Name = PerfilAcesso.Bombeiro, 
                NormalizedName = PerfilAcesso.Bombeiro.ToUpper() 
            });


            var passwordHasher = new PasswordHasher<IdentityUser>();

            var userAdmin = new IdentityUser { Id = Guid.NewGuid().ToString(), UserName = "admin@gmail.com" };
            string hashedPasswordAdmin = passwordHasher.HashPassword(userAdmin, "Teste123!");

            var userBombeiro = new IdentityUser { Id = Guid.NewGuid().ToString(), UserName = "bombeiro@gmail.com" };
            string hashedPasswordBombeiro = passwordHasher.HashPassword(userBombeiro, "Teste123!");


            modelBuilder.Entity<Bombeiro>().HasData(new Bombeiro
            {
                Id = userAdmin.Id,
                UserName = userAdmin.UserName,
                NormalizedUserName = userAdmin.UserName.ToUpper(),
                Email = userAdmin.UserName,
                NormalizedEmail = userAdmin.UserName.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hashedPasswordAdmin,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                NumeroMecanografico = 00000000,
                Nome = "Admin",
                DtInicio = new DateTime(2025, 1, 1),
                PostoId = Guid.Empty,
                QuartelId = Guid.Empty,
                Turno = Turno.T1
            });
            modelBuilder.Entity<Bombeiro>().HasData(new Bombeiro
            {
                Id = userBombeiro.Id,
                UserName = userBombeiro.UserName,
                NormalizedUserName = userBombeiro.UserName.ToUpper(),
                Email = userBombeiro.UserName,
                NormalizedEmail = userBombeiro.UserName.ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hashedPasswordBombeiro,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnd = null,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                NumeroMecanografico = 00000000,
                Nome = "Bombeiro0",
                DtInicio = new DateTime(2025, 1, 1),
                PostoId = Guid.Empty,
                QuartelId = Guid.Empty,
                Turno = Turno.T1
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userAdmin.Id,
                RoleId = roleAdminId
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = userBombeiro.Id,
                RoleId = roleBombeiroId
            });
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
