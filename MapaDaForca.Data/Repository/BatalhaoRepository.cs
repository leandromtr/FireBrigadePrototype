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
    public class BatalhaoRepository : BaseRepository, IBatalhaoRepository
    {
        public BatalhaoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Batalhao> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Batalhoes.ToList();
            }
        }

        public Batalhao GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Batalhoes.FirstOrDefault(x => x.Id == id);
            }
        }

        public Batalhao Create(Batalhao batalhao)
        {
            if (batalhao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                batalhao.Id = Guid.NewGuid();
                context.Batalhoes.Add(batalhao);
                context.Entry(batalhao).State = EntityState.Added;

                return context.SaveChanges() > 0 ? batalhao : null;
            }
        }

        public Batalhao Update(Batalhao batalhao)
        {
            if (batalhao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Batalhoes.Add(batalhao);
                context.Entry(batalhao).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? batalhao : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Batalhoes.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Batalhoes.FirstOrDefault(x => x.Id == id);

                context.Batalhoes.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
