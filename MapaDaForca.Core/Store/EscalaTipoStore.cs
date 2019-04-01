using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class EscalaTipoStore : IEscalaTipoStore
    {
        private readonly IEscalaTipoRepository _repository;

        public EscalaTipoStore(IEscalaTipoRepository repository)
        {
            _repository = repository;
        }

        public IList<EscalaTipo> GetAll()
        {
            return _repository.GetAll();
        }

        public EscalaTipo GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public EscalaTipo Save(EscalaTipo save)
        {
            EscalaTipo saved = null;

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
