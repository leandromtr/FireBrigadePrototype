using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class BombeiroFuncaoStore : IBombeiroFuncaoStore
    {
        private readonly IBombeiroFuncaoRepository _repository;
        //private readonly ICompanhiaRepository _companhiaRepository;

        public BombeiroFuncaoStore(IBombeiroFuncaoRepository repository)
        {
            _repository = repository;
            //_companhiaRepository = companhiaRepository;
        }

        public IList<BombeiroFuncao> GetAll()
        {
            return _repository.GetAll();
        }

        public BombeiroFuncao GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public BombeiroFuncao Save(BombeiroFuncao save)
        {
            BombeiroFuncao saved = null;

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
