using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class EscalaTurnoStore : IEscalaTurnoStore
    {
        private readonly IEscalaTurnoRepository _repository;

        public EscalaTurnoStore(IEscalaTurnoRepository repository)
        {
            _repository = repository;
        }

        public IList<EscalaTurno> GetAll()
        {
            return _repository.GetAll();
        }

        public EscalaTurno GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public EscalaTurno Save(EscalaTurno save)
        {
            EscalaTurno saved = null;

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
