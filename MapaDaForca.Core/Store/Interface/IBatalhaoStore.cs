using MapaDaForca.Model;
using System;
using System.Collections.Generic;

namespace MapaDaForca.Core.Store
{
    public interface IBatalhaoStore
    {
        IList<Batalhao> GetAll();

        Batalhao GetById(Guid id);

        Batalhao Save(Batalhao save);

        bool Delete(Guid id);
    }
}
