using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Options;
using MapaDaForca.Data.Repository.Base;

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


        public IList<Escala> GetByBombeiroAndMonthYear(Guid bombeiroId, int month, int year)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Escalas.Where(x => x.BombeiroId == bombeiroId && x.DtEscala.Month == month && x.DtEscala.Year == year).ToList();
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
    }
}
