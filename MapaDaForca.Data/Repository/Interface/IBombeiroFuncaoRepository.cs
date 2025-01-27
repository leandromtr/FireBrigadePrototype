using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Data.Repository
{
    public interface IBombeiroFuncaoRepository
    {
        IList<BombeiroFuncao> GetAll();

        BombeiroFuncao GetById(Guid id);

        IList<BombeiroFuncao> GetByBombeiroId(Guid bombeiroId);

        IList<BombeiroFuncao> GetByFuncaoId(Guid funcaoId);

        BombeiroFuncao Create(BombeiroFuncao create);

        BombeiroFuncao Update(BombeiroFuncao update);

        bool Delete(Guid id);

        bool IsExisting(Guid id);
    }
}
