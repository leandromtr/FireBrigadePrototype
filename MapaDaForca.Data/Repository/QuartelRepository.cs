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
    public class QuartelRepository : BaseRepository, IQuartelRepository
    {
        public QuartelRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Quartel> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Quarteis.ToList();
            }
        }

        public IList<Quartel> GetByCompanhiaId(Guid companhiaId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Quarteis.Where(x => x.CompanhiaId == companhiaId).ToList();
            }
        }

        public Quartel GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Quarteis.FirstOrDefault(x => x.Id == id);
            }
        }

        public Quartel Create(Quartel quartel)
        {
            if (quartel == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                quartel.Id = Guid.NewGuid();
                context.Quarteis.Add(quartel);
                context.Entry(quartel).State = EntityState.Added;

                return context.SaveChanges() > 0 ? quartel : null;
            }
        }

        public Quartel Update(Quartel quartel)
        {
            if (quartel == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Quarteis.Add(quartel);
                context.Entry(quartel).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? quartel : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Quarteis.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Quarteis.FirstOrDefault(x => x.Id == id);

                context.Quarteis.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}