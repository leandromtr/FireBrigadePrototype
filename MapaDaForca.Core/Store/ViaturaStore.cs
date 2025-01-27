using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Core.Store
{
    public class ViaturaStore : IViaturaStore
    {
        private readonly IViaturaRepository _repository;
        private readonly IViaturaTipoStore _viaturaTipoStore;

        public ViaturaStore(
            IViaturaRepository repository,
            IViaturaTipoStore viaturaTipoStore)
        {
            _repository = repository;
            _viaturaTipoStore = viaturaTipoStore;
        }

        public IList<Viatura> GetAll()
        {
            var viaturas = _repository.GetAll().OrderBy(x => x.Matricula).ToList();
            var viaturaTipos = _viaturaTipoStore.GetAll().OrderBy(x => x.Sigla).ToList();

            viaturas.ForEach(v => v.ViaturaTipo = viaturaTipos.FirstOrDefault(vt => vt.Id == v.ViaturaTipoId));

            return viaturas;
        }

        public IList<Viatura> GetByViaturaTipoId(Guid viaturaTipoId)
        {
            return _repository.GetByViaturaTipoId(viaturaTipoId);
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
