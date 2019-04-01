using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
