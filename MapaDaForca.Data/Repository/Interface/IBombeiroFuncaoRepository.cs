using MapaDaForca.Data.Data;
using MapaDaForca.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MapaDaForca.Data.Repository
{
    public interface IBombeiroFuncaoRepository
    {
        IList<BombeiroFuncao> GetAll();

        BombeiroFuncao GetById(Guid id);

        BombeiroFuncao Create(BombeiroFuncao create);

        BombeiroFuncao Update(BombeiroFuncao update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
