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
    public class ViaturaTipoFuncaoRepository : BaseRepository, IViaturaTipoFuncaoRepository
    {
        public ViaturaTipoFuncaoRepository(DbContextOptions<MapaDaForcaDbContext> options) : base(options) { }

        public IList<ViaturaTipoFuncao> GetAll()
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipoFuncoes.ToList();
            }
        }

        public IList<ViaturaTipoFuncao> GetByFuncaoId(Guid funcaoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipoFuncoes.Where(x => x.FuncaoId == funcaoId).ToList();
            }
        }

        public IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipoFuncoes.Where(x => x.ViaturaTipoId == viaturaTipoId).ToList();
            }
        }

        public ViaturaTipoFuncao GetById(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipoFuncoes.FirstOrDefault(x => x.Id == id);
            }
        }

        public ViaturaTipoFuncao Create(ViaturaTipoFuncao viaturaTipoFuncao)
        {
            if (viaturaTipoFuncao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                viaturaTipoFuncao.Id = Guid.NewGuid();
                context.ViaturaTipoFuncoes.Add(viaturaTipoFuncao);
                context.Entry(viaturaTipoFuncao).State = EntityState.Added;

                return context.SaveChanges() > 0 ? viaturaTipoFuncao : null;
            }
        }

        public ViaturaTipoFuncao Update(ViaturaTipoFuncao viaturaTipoFuncao)
        {
            if (viaturaTipoFuncao == null)
                return null;

            using (var context = new MapaDaForcaDbContext(Options))
            {
                context.ViaturaTipoFuncoes.Add(viaturaTipoFuncao);
                context.Entry(viaturaTipoFuncao).State = EntityState.Modified;

                return context.SaveChanges() > 0 ? viaturaTipoFuncao : null;
            }
        }

        public bool IsExisting(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                return context.ViaturaTipoFuncoes.Any(x => x.Id == id);
            }
        }

        public bool Delete(Guid id)
        {
            using (var context = new MapaDaForcaDbContext(Options))
            {
                var delete = context.ViaturaTipoFuncoes.FirstOrDefault(x => x.Id == id);

                context.ViaturaTipoFuncoes.Remove(delete);

                return context.SaveChanges() > 0;
            }
        }
    }
}
