using MapaDaForca.Data.Data;
using MapaDaForca.Data.Repository.Base;
using MapaDaForca.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Data.Repository
{
    public class FuncaoRepository : BaseRepository, IFuncaoRepository
    {
        public FuncaoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<Funcao> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Funcoes.ToList();
            }
        }

        public Funcao GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Funcoes.FirstOrDefault(x => x.Id == id);
            }
        }

        public Funcao Create(Funcao funcao)
        {
            if (funcao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                funcao.Id = Guid.NewGuid();
                context.Funcoes.Add(funcao);
                context.Entry(funcao).State = EntityState.Added;

                return context.SaveChanges() > 0 ? funcao : null;
            }
        }

        public Funcao Update(Funcao funcao)
        {
            if (funcao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.Funcoes.Add(funcao);
                context.Entry(funcao).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? funcao : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.Funcoes.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.Funcoes.FirstOrDefault(x => x.Id == id);

                context.Funcoes.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
