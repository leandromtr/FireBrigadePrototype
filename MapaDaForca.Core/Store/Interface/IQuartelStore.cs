using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IQuartelStore
    {
        IList<Quartel> GetAll();

        IList<Quartel> GetByCompanhiaId(Guid companhiaId);

        Quartel GetById(Guid id);

        Quartel Save(Quartel save);

        bool Delete(Guid id);
    }
}