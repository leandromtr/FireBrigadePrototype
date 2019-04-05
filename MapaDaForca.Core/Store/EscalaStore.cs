using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class EscalaStore : IEscalaStore
    {
        private readonly IEscalaRepository _repository;
        //private readonly ICompanhiaRepository _companhiaRepository;

        public EscalaStore(IEscalaRepository repository)
        {
            _repository = repository;
            //_companhiaRepository = companhiaRepository;
        }

        public IList<Escala> GetAll()
        {
            return _repository.GetAll().ToList(); ;
        }

        public IList<Escala> GetByBombeiroId(Guid bombeiroId)
        {
            return _repository.GetByBombeiroId(bombeiroId).ToList();
        }

        public IList<Escala> GetByEscalaTipoId(Guid escalaTipoId)
        {
            return _repository.GetByEscalaTipoId(escalaTipoId).ToList();
        }

        public IList<Escala> GetByFuncaoId(Guid funcaoId)
        {
            return _repository.GetByFuncaoId(funcaoId).ToList();
        }

        public IList<Escala> GetByQuartelId(Guid quartelId)
        {
            return _repository.GetByQuartelId(quartelId).ToList();
        }

        public Escala GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Escala Save(Escala save)
        {
            Escala saved = null;

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
