﻿using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MapaDaForca.Core.Store
{
    public class QuartelViaturaStore : IQuartelViaturaStore
    {
        private readonly IQuartelViaturaRepository _repository;
        private readonly IViaturaStore _viaturaStore;
        private readonly IViaturaTipoStore _viaturaTipoStore;

        public QuartelViaturaStore(
            IQuartelViaturaRepository repository,
            IViaturaStore viaturaStore,
            IViaturaTipoStore viaturaTipoStore)
        {
            _repository = repository;
            _viaturaStore = viaturaStore;
            _viaturaTipoStore = viaturaTipoStore;
        }

        public IList<QuartelViatura> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public IList<QuartelViatura> GetByQuartelId(Guid quartelId)
        {
            var quarteis = _repository.GetByQuartelId(quartelId).ToList();
            var viaturas = _viaturaStore.GetAll().ToList();
            var viaturaTipos = _viaturaTipoStore.GetAll().ToList();

            quarteis.ForEach(q => q.Viatura = viaturas.FirstOrDefault(v => v.Id == q.ViaturaId));
            quarteis.ForEach(q => q.Viatura.ViaturaTipo = viaturaTipos.FirstOrDefault(vt => vt.Id == q.Viatura.ViaturaTipoId));

            return quarteis;
        }

        public IList<QuartelViatura> GetByViaturaId(Guid viaturaId)
        {
            return _repository.GetByViaturaId(viaturaId).ToList();
        }

        public QuartelViatura GetById(Guid id)
        {
            var quartelViatura = _repository.GetById(id);
            quartelViatura.Viatura = _viaturaStore.GetById(quartelViatura.ViaturaId);
            quartelViatura.Viatura.ViaturaTipo = _viaturaTipoStore.GetById(quartelViatura.Viatura.ViaturaTipoId);

            return quartelViatura;
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

        public void DeleteByQuartelId(Guid quartelId)
        {
            var requests = _repository.GetByQuartelId(quartelId);
            foreach (var item in requests)
            {
                _repository.Delete(item.Id);
            }
        }
    }
}
