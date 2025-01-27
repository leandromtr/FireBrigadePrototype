using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class CompanhiaRepository : BaseRepository, ICompanhiaRepository
    {
        public CompanhiaRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Companhia> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Companhias.ToList();
            }
        }

        public IList<Companhia> GetByBatalhaoId(Guid batalhaoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Companhias.Where(x => x.BatalhaoId == batalhaoId).ToList();
            }
        }

        public Companhia GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Companhias.FirstOrDefault(x => x.Id == id);
            }
        }

        public Companhia Create(Companhia companhia)
        {
            if (companhia == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                companhia.Id = Guid.NewGuid();
                context.Companhias.Add(companhia);
                context.Entry(companhia).State = EntityState.Added;

                return context.SaveChanges() > 0 ? companhia : null;
            }
        }

        public Companhia Update(Companhia companhia)
        {
            if (companhia == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Companhias.Add(companhia);
                context.Entry(companhia).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? companhia : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Companhias.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Companhias.FirstOrDefault(x => x.Id == id);

                context.Companhias.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}