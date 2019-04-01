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
    public class EscalaTipoRepository : BaseRepository, IEscalaTipoRepository
    {
        public EscalaTipoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<EscalaTipo> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTipos.ToList();
            }
        }

        public EscalaTipo GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTipos.FirstOrDefault(x => x.Id == id);
            }
        }

        public EscalaTipo Create(EscalaTipo escalaTipo)
        {
            if (escalaTipo == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                escalaTipo.Id = Guid.NewGuid();
                context.EscalaTipos.Add(escalaTipo);
                context.Entry(escalaTipo).State = EntityState.Added;

                return context.SaveChanges() > 0 ? escalaTipo : null;
            }
        }

        public EscalaTipo Update(EscalaTipo escalaTipo)
        {
            if (escalaTipo == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.EscalaTipos.Add(escalaTipo);
                context.Entry(escalaTipo).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? escalaTipo : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.EscalaTipos.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.EscalaTipos.FirstOrDefault(x => x.Id == id);

                context.EscalaTipos.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
