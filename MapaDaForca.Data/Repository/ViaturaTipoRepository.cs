using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class ViaturaTipoRepository : BaseRepository, IViaturaTipoRepository
    {
        public ViaturaTipoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<ViaturaTipo> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipos.ToList();
            }
        }

        public ViaturaTipo GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipos.FirstOrDefault(x => x.Id == id);
            }
        }

        public ViaturaTipo Create(ViaturaTipo viaturaTipo)
        {
            if (viaturaTipo == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                viaturaTipo.Id = Guid.NewGuid();
                context.ViaturaTipos.Add(viaturaTipo);
                context.Entry(viaturaTipo).State = EntityState.Added;

                return context.SaveChanges() > 0 ? viaturaTipo : null;
            }
        }

        public ViaturaTipo Update(ViaturaTipo viaturaTipo)
        {
            if (viaturaTipo == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.ViaturaTipos.Add(viaturaTipo);
                context.Entry(viaturaTipo).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? viaturaTipo : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipos.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.ViaturaTipos.FirstOrDefault(x => x.Id == id);

                context.ViaturaTipos.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
