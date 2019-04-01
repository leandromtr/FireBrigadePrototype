using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class FuncaoStore : IFuncaoStore
    {
        private readonly IFuncaoRepository _repository;

        public FuncaoStore(IFuncaoRepository repository)
        {
            _repository = repository;
        }

        public IList<Funcao> GetAll()
        {
            return _repository.GetAll();
        }

        public Funcao GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Funcao Save(Funcao save)
        {
            Funcao saved = null;

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
