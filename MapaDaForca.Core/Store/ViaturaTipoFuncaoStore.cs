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

        public ViaturaTipoFuncaoStore(IViaturaTipoFuncaoRepository repository)
        {
            _repository = repository;
        }

        public IList<ViaturaTipoFuncao> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public IList<ViaturaTipoFuncao> GetByViaturaTipoId(Guid viaturaTipoId)
        {
            return _repository.GetByViaturaTipoId(viaturaTipoId).ToList();
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
