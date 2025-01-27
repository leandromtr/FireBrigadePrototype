using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IViaturaStore
    {
        IList<Viatura> GetAll();

        IList<Viatura> GetByViaturaTipoId(Guid viaturaTipoId);

        Viatura GetById(Guid id);

        Viatura Save(Viatura save);

        bool Delete(Guid id);
    }
}
