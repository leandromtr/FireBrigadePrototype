using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class BombeiroFuncaoRepository : BaseRepository, IBombeiroFuncaoRepository
    {
        public BombeiroFuncaoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<BombeiroFuncao> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.BombeiroFuncoes.ToList();
            }
        }

        public IList<BombeiroFuncao> GetByBombeiroId(Guid bombeiroId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.BombeiroFuncoes.Where(x => x.BombeiroId == bombeiroId).ToList();
            }
        }

        public IList<BombeiroFuncao> GetByFuncaoId(Guid funcaoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.BombeiroFuncoes.Where(x => x.FuncaoId == funcaoId).ToList();
            }
        }

        public BombeiroFuncao GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.BombeiroFuncoes.FirstOrDefault(x => x.Id == id);
            }
        }

        public BombeiroFuncao Create(BombeiroFuncao bombeiroFuncao)
        {
            if (bombeiroFuncao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                bombeiroFuncao.Id = Guid.NewGuid();
                context.BombeiroFuncoes.Add(bombeiroFuncao);
                context.Entry(bombeiroFuncao).State = EntityState.Added;

                return context.SaveChanges() > 0 ? bombeiroFuncao : null;
            }
        }

        public BombeiroFuncao Update(BombeiroFuncao bombeiroFuncao)
        {
            if (bombeiroFuncao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.BombeiroFuncoes.Add(bombeiroFuncao);
                context.Entry(bombeiroFuncao).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? bombeiroFuncao : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.BombeiroFuncoes.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.BombeiroFuncoes.FirstOrDefault(x => x.Id == id);

                context.BombeiroFuncoes.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
