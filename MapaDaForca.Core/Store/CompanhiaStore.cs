using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Core.Store
{
    public class CompanhiaStore : ICompanhiaStore
    {
        private readonly ICompanhiaRepository _repository;
        private readonly IBatalhaoStore _batalhaoStore;

        public CompanhiaStore(
            ICompanhiaRepository repository,
            IBatalhaoStore batalhaoStore)
        {
            _repository = repository;
            _batalhaoStore = batalhaoStore;
        }

        public IList<Companhia> GetAll()
        {
            var companhias = _repository.GetAll().OrderBy(x => x.Nome).ToList();
            var batalhoes = _batalhaoStore.GetAll().OrderBy(x => x.Nome).ToList();

            companhias.ForEach(c => c.Batalhao = batalhoes.FirstOrDefault(b => b.Id == c.BatalhaoId));

            return companhias;
        }

        public IList<Companhia> GetByBatalhaoId(Guid batalhaoId)
        {
            return _repository.GetByBatalhaoId(batalhaoId);
        }

        public Companhia GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Companhia Save(Companhia save)
        {
            Companhia saved = null;

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
