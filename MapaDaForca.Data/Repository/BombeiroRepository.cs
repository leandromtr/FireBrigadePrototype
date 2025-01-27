using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class BombeiroRepository : BaseRepository, IBombeiroRepository
    {
        public BombeiroRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Bombeiro> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Bombeiros.ToList();
            }
        }

        public IList<Bombeiro> GetByPostoId(Guid postoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Bombeiros.Where(x => x.PostoId == postoId).ToList();
            }
        }

        public IList<Bombeiro> GetByQuartelId(Guid quartelId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Bombeiros.Where(x => x.QuartelId == quartelId).ToList();
            }
        }

        public Bombeiro GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Bombeiros.FirstOrDefault(x => x.Id == id.ToString());
            }
        }

        public Bombeiro Create(Bombeiro bombeiro)
        {
            if (bombeiro == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                bombeiro.Id = Guid.NewGuid().ToString();
                context.Bombeiros.Add(bombeiro);
                context.Entry(bombeiro).State = EntityState.Added;

                return context.SaveChanges() > 0 ? bombeiro : null;
            }
        }

        public Bombeiro Update(Bombeiro bombeiro)
        {
            if (bombeiro == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Bombeiros.Add(bombeiro);
                context.Entry(bombeiro).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? bombeiro : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Bombeiros.Any(x => x.Id == id.ToString());
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Bombeiros.FirstOrDefault(x => x.Id == id.ToString());

                context.Bombeiros.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
