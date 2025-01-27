using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class PostoRepository : BaseRepository, IPostoRepository
    {
        public PostoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Posto> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Postos.ToList();
            }
        }

        public Posto GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Postos.FirstOrDefault(x => x.Id == id);
            }
        }

        public Posto Create(Posto posto)
        {
            if (posto == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                posto.Id = Guid.NewGuid();
                context.Postos.Add(posto);
                context.Entry(posto).State = EntityState.Added;

                return context.SaveChanges() > 0 ? posto : null;
            }
        }

        public Posto Update(Posto posto)
        {
            if (posto == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Postos.Add(posto);
                context.Entry(posto).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? posto : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Postos.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Postos.FirstOrDefault(x => x.Id == id);

                context.Postos.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
