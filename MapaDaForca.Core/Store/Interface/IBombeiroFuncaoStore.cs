using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Core.Store
{
    public interface IBombeiroFuncaoStore
    {
        IList<BombeiroFuncao> GetAll();

        BombeiroFuncao GetById(Guid id);

        BombeiroFuncao Save(BombeiroFuncao save);

        bool Delete(Guid id);
    }
}
