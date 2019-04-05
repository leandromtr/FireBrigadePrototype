using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class QuartelViaturaStore : IQuartelViaturaStore
    {
        private readonly IQuartelViaturaRepository _repository;

        public QuartelViaturaStore(IQuartelViaturaRepository repository)
        {
            _repository = repository;
        }

        public IList<QuartelViatura> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public IList<QuartelViatura> GetByQuartelId(Guid quartelId)
        {
            return _repository.GetByQuartelId(quartelId).ToList();
        }

        public QuartelViatura GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public QuartelViatura Save(QuartelViatura save)
        {
            QuartelViatura saved = null;

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
