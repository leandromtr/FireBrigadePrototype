using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IEscalaTipoStore
    {
        IList<EscalaTipo> GetAll();

        EscalaTipo GetById(Guid id);

        EscalaTipo Save(EscalaTipo save);

        bool Delete(Guid id);
    }
}
