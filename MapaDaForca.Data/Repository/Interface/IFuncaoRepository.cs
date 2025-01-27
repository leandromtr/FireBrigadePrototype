using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IFuncaoRepository
    {
        IList<Funcao> GetAll();

        Funcao GetById(Guid id);

        Funcao Create(Funcao create);

        Funcao Update(Funcao update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
