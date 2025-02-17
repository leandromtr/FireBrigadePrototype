﻿using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class EscalaRepository : BaseRepository, IEscalaRepository
    {
        public EscalaRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Escala> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.ToList();
            }
        }

        public IList<Escala> GetByBombeiroId(Guid bombeiroId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.BombeiroId == bombeiroId).ToList();
            }
        }

        public IList<Escala> GetByEscalaTipoId(Guid escalaTipoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.EscalaTipoId == escalaTipoId).ToList();
            }
        }

        public IList<Escala> GetByFuncaoId(Guid funcaoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.FuncaoId == funcaoId).ToList();
            }
        }

        public IList<Escala> GetByQuartelId(Guid quartelId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.QuartelId == quartelId).ToList();
            }
        }


        public IList<Escala> GetByBombeiroIdAndMonthYear(Guid bombeiroId, int month, int year)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.BombeiroId == bombeiroId && x.DtEscala.Month == month && x.DtEscala.Year == year).ToList();
            }
        }

        public IList<Escala> GetByBombeiroIdAndYear(Guid bombeiroId, int year)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.BombeiroId == bombeiroId && x.DtEscala.Year == year).ToList();
            }
        }

        public IList<Escala> GetByQuartelIdAndDtEscala(Guid quartelId, DateTime dtEscala)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.QuartelId == quartelId && x.DtEscala == dtEscala).ToList();
            }
        }

        public IList<Escala> GetByQuartelIdAndDtEscalaAndPeriodoDiurno(Guid quartelId, DateTime dtEscala, bool periodoDiurno)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.QuartelId == quartelId && x.PeriodoDiurno == periodoDiurno && x.DtEscala == dtEscala).ToList();
            }
        }

        public IList<Escala> GetByQuartelIdAndMonthYearAndPeriodoDiurno(Guid quartelId, int month, int year, bool periodoDiurno)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.QuartelId == quartelId && x.PeriodoDiurno == periodoDiurno && x.DtEscala.Month == month && x.DtEscala.Year == year).ToList();
            }
        }

        public Escala GetByBombeiroIdAndDtEscala(Guid bombeiroId, DateTime dtEscala)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.FirstOrDefault(x => x.DtEscala == dtEscala && x.BombeiroId == bombeiroId);
            }
        }


        public Escala GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.FirstOrDefault(x => x.Id == id);
            }
        }

        public Escala Create(Escala escala)
        {
            if (escala == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                escala.Id = Guid.NewGuid();
                context.Escalas.Add(escala);
                context.Entry(escala).State = EntityState.Added;

                return context.SaveChanges() > 0 ? escala : null;
            }
        }

        public Escala Update(Escala escala)
        {
            if (escala == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Escalas.Add(escala);
                context.Entry(escala).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? escala : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Escalas.FirstOrDefault(x => x.Id == id);

                context.Escalas.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }

        public int GetQuantityToDispositivoMinimo(Guid quartelId, Guid funcaoId, DateTime dtEscala, bool periodoDiurno)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Count(x =>
                x.QuartelId == quartelId &&
                x.FuncaoId == funcaoId &&
                x.DtEscala == dtEscala &&
                x.PeriodoDiurno == periodoDiurno
                );
            }
        }
    }
}
