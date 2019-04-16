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
    public class EscalaTurnoRepository : BaseRepository, IEscalaTurnoRepository
    {
        public EscalaTurnoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<EscalaTurno> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTurnos.ToList();
            }
        }

        public IList<EscalaTurno> GetByDtEscalaTurno(DateTime dtEscalaTurno)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTurnos.Where(x => x.DtEscalaTurno == dtEscalaTurno).ToList();
            }
        }

        public IList<EscalaTurno> GetByMonthYear(int month, int year)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTurnos.Where(x => x.DtEscalaTurno.Month == month && x.DtEscalaTurno.Year == year).ToList();
            }
        }

        public EscalaTurno GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTurnos.FirstOrDefault(x => x.Id == id);
            }
        }


        public EscalaTurno Create(EscalaTurno escalaTurno)
        {
            if (escalaTurno == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                escalaTurno.Id = Guid.NewGuid();
                context.EscalaTurnos.Add(escalaTurno);
                context.Entry(escalaTurno).State = EntityState.Added;

                return context.SaveChanges() > 0 ? escalaTurno : null;
            }
        }

        public EscalaTurno Update(EscalaTurno escalaTurno)
        {
            if (escalaTurno == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.EscalaTurnos.Add(escalaTurno);
                context.Entry(escalaTurno).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? escalaTurno : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTurnos.Any(x => x.Id == id);
            }
        }

        public EscalaTurno IsExistingByDateAndTurno(DateTime dtEscalaTurno, bool periodoDiurno)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTurnos.FirstOrDefault(x => x.DtEscalaTurno == dtEscalaTurno && x.PeriodoDiurno == periodoDiurno);
            }
        }


        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.EscalaTurnos.FirstOrDefault(x => x.Id == id);

                context.EscalaTurnos.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
