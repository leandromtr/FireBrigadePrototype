using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public class BatalhaoStore : IBatalhaoStore
    {
        private readonly IBatalhaoRepository _repository;

        public BatalhaoStore(IBatalhaoRepository repository)
        {
            _repository = repository;
        }

        public IList<Batalhao> GetAll()
        {
            return _repository.GetAll();
        }

        public Batalhao GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Batalhao Save(Batalhao save)
        {
            Batalhao saved = null;

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
