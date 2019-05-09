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
    public class QuartelViaturaRepository : BaseRepository, IQuartelViaturaRepository
    {
        public QuartelViaturaRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<QuartelViatura> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.QuartelViaturas.ToList();
            }
        }

        public IList<QuartelViatura> GetByQuartelId(Guid quartelId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.QuartelViaturas.Where(x => x.QuartelId == quartelId).ToList();
            }
        }

        public IList<QuartelViatura> GetByViaturaId(Guid viaturaId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.QuartelViaturas.Where(x => x.ViaturaId == viaturaId).ToList();
            }
        }

        public QuartelViatura GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.QuartelViaturas.FirstOrDefault(x => x.Id == id);
            }
        }

        public QuartelViatura Create(QuartelViatura quartelViatura)
        {
            if (quartelViatura == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                quartelViatura.Id = Guid.NewGuid();
                context.QuartelViaturas.Add(quartelViatura);
                context.Entry(quartelViatura).State = EntityState.Added;

                return context.SaveChanges() > 0 ? quartelViatura : null;
            }
        }

        public QuartelViatura Update(QuartelViatura quartelViatura)
        {
            if (quartelViatura == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.QuartelViaturas.Add(quartelViatura);
                context.Entry(quartelViatura).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? quartelViatura : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.QuartelViaturas.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.QuartelViaturas.FirstOrDefault(x => x.Id == id);

                context.QuartelViaturas.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
