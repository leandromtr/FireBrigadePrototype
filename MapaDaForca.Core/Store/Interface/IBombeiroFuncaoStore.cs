using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IBombeiroFuncaoStore
    {
        IList<BombeiroFuncao> GetAll();

        IList<BombeiroFuncao> GetByBombeiroId(Guid bombeiroId);

        IList<BombeiroFuncao> GetByFuncaoId(Guid viaturaTipoId);

        BombeiroFuncao GetById(Guid id);

        BombeiroFuncao GetPrincipalByBombeiroId(Guid bombeiroId);

        BombeiroFuncao Save(BombeiroFuncao save);

        bool Delete(Guid id);
    }
}
