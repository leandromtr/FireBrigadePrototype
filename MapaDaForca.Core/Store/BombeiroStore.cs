using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class BombeiroStore : IBombeiroStore
    {
        private readonly IBombeiroRepository _repository;
        private readonly IPostoRepository _postoStore;
        private readonly IQuartelRepository _quartelStore;

        public BombeiroStore(
            IBombeiroRepository repository,
            IPostoRepository postoStore,
            IQuartelRepository quartelStore)
        {
            _repository = repository;
            _postoStore = postoStore;
            _quartelStore = quartelStore;
        }

        public IList<Bombeiro> GetAll()
        {
            var bombeiros = _repository.GetAll().OrderBy(x => x.Nome).ToList();

            var postos = _postoStore.GetAll().OrderBy(x => x.Nome).ToList();
            var quarteis = _quartelStore.GetAll().OrderBy(x => x.Nome).ToList();

            bombeiros.ForEach(b => b.Posto = postos.FirstOrDefault(p => p.Id == b.PostoId));
            bombeiros.ForEach(b => b.Quartel = quarteis.FirstOrDefault(p => p.Id == b.QuartelId));

            return bombeiros;
        }

        public IList<Bombeiro> GetByPostoId(Guid postoId)
        {
            return _repository.GetByPostoId(postoId);
        }

        public IList<Bombeiro> GetByQuartelId(Guid quartelId)
        {
            return _repository.GetByQuartelId(quartelId);
        }

        public Bombeiro GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Bombeiro Save(Bombeiro save)
        {
            Bombeiro saved = null;

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
