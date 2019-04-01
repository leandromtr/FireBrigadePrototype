using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class ViaturaTipoStore : IViaturaTipoStore
    {
        private readonly IViaturaTipoRepository _repository;

        public ViaturaTipoStore(IViaturaTipoRepository repository)
        {
            _repository = repository;
        }

        public IList<ViaturaTipo> GetAll()
        {
            return _repository.GetAll();
        }

        public ViaturaTipo GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public ViaturaTipo Save(ViaturaTipo save)
        {
            ViaturaTipo saved = null;

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
