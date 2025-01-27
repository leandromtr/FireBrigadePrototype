using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IFuncaoStore
    {
        IList<Funcao> GetAll();

        Funcao GetById(Guid id);

        Funcao Save(Funcao save);

        bool Delete(Guid id);
    }
}
