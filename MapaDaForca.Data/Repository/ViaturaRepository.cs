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
    public class ViaturaRepository : BaseRepository, IViaturaRepository
    {
        public ViaturaRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Viatura> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Viaturas.ToList();
            }
        }

        public Viatura GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Viaturas.FirstOrDefault(x => x.Id == id);
            }
        }

        public Viatura Create(Viatura viatura)
        {
            if (viatura == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                viatura.Id = Guid.NewGuid();
                context.Viaturas.Add(viatura);
                context.Entry(viatura).State = EntityState.Added;

                return context.SaveChanges() > 0 ? viatura : null;
            }
        }

        public Viatura Update(Viatura viatura)
        {
            if (viatura == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Viaturas.Add(viatura);
                context.Entry(viatura).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? viatura : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Viaturas.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Viaturas.FirstOrDefault(x => x.Id == id);

                context.Viaturas.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
