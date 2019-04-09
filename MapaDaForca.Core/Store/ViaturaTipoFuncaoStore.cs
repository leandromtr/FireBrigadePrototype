using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class ViaturaTipoFuncaoStore : IViaturaTipoFuncaoStore
    {
        private readonly IViaturaTipoFuncaoRepository _repository;
        private readonly IFuncaoStore _funcaoStore;

        public ViaturaTipoFuncaoStore(
            IViaturaTipoFuncaoRepository repository,
            IFuncaoStore funcaoStore
            )
        {
            _repository = repository;
            _funcaoStore = funcaoStore;
        }

        public IList<ViaturaTipoFuncao> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public IList<ViaturaTipoFuncao> GetByFuncaoId(Guid funcaoId)
        {
            return _repository.GetByFuncaoId(funcaoId).ToList();
        }

        public IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId)
        {           
            var viaturaTipos = _repository.GetByViaturaTipoId(viaturaTipoId).ToList();
            var funcoes = _funcaoStore.GetAll().ToList();

            viaturaTipos.ForEach(v => v.Funcao = funcoes.FirstOrDefault(f => f.Id == v.FuncaoId));

            return viaturaTipos;
        }

        public ViaturaTipoFuncao GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public ViaturaTipoFuncao Save(ViaturaTipoFuncao save)
        {
            ViaturaTipoFuncao saved = null;

            if (_repository.IsExisting(save.Id))
            {
                saved = _repository.Update(save);
            }
            else
            {
                saved = _repository.Create(save);
            }

            return saved;
        }

        public bool Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}
