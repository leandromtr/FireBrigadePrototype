using MapaDaForca.Core.Store;
using MapaDaForca.Data.Repository;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public class PostoStore : IPostoStore
    {
        private readonly IPostoRepository _repository;
        //private readonly ICompanhiaRepository _companhiaRepository;

        public PostoStore(IPostoRepository repository)
        {
            _repository = repository;
            //_companhiaRepository = companhiaRepository;
        }

        public IList<Posto> GetAll()
        {
            return _repository.GetAll();
        }

        public Posto GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public Posto Save(Posto save)
        {
            Posto saved = null;

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
