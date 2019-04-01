using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class ViaturaStore : IViaturaStore
    {
        private readonly IViaturaRepository _repository;

        public ViaturaStore(IViaturaRepository repository)
        {
            _repository = repository;
        }

        public IList<Viatura> GetAll()
        {
            return _repository.GetAll();
        }

        public Viatura GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Viatura Save(Viatura save)
        {
            Viatura saved = null;

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
