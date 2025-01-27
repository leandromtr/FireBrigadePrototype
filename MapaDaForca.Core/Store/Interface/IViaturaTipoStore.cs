using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IViaturaTipoStore
    {
        IList<ViaturaTipo> GetAll();

        ViaturaTipo GetById(Guid id);

        ViaturaTipo Save(ViaturaTipo save);

        bool Delete(Guid id);
    }
}
