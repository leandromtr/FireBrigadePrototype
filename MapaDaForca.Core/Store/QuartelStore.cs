using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Core.Store
{
    public class QuartelStore : IQuartelStore
    {
        private readonly IQuartelRepository _repository;
        private readonly ICompanhiaStore _companhiaStore;

        public QuartelStore(
            IQuartelRepository repository,
            ICompanhiaStore companhiaStore)
        {
            _repository = repository;
            _companhiaStore = companhiaStore;
        }

        public IList<Quartel> GetAll()
        {
            var quarteis = _repository.GetAll().OrderBy(x => x.Nome).ToList();
            var companhias = _companhiaStore.GetAll().OrderBy(x => x.Nome).ToList();

            quarteis.ForEach(q => q.Companhia = companhias.FirstOrDefault(c => c.Id == q.CompanhiaId));

            return quarteis;
        }

        public IList<Quartel> GetByCompanhiaId(Guid companhiaId)
        {
            return _repository.GetByCompanhiaId(companhiaId);
        }

        public Quartel GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Quartel Save(Quartel save)
        {
            Quartel saved = null;

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
